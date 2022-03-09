using AluraTunes.LinqToEntitiesCountSumGroupby.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraTunes.LinqToEntitiesCountSumGroupby
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AluraTunesEntities())
            {
                //COUNT

                var query = from f in context.Faixas
                            where f.Album.Artista.Nome == "Led Zeppelin"
                            select f;

                //Método 1
                //var quantity = query.Count();

                //Console.WriteLine($"Led Zeppelin tem {quantity} músicas no banco de dados");


                //Método 2
                var quantity = context.Faixas.Count(f => f.Album.Artista.Nome == "Led Zeppelin");

                Console.WriteLine();
                Console.WriteLine("COUNT QUANTIDADE DE MUSICAS NO BD");
                Console.WriteLine();

                Console.WriteLine($"Led Zeppelin tem {quantity} músicas no banco de dados");


                //SUM

                var querySum = from inv in context.ItemsNotaFiscal
                               where inv.Faixa.Album.Artista.Nome == "Led Zeppelin"
                               select new { totalItem = inv.Quantidade * inv.PrecoUnitario};

                Console.WriteLine();
                Console.WriteLine("NOTA FISCAL");
                Console.WriteLine();

                //foreach (var inv in querySum)
                //{
                //    Console.WriteLine($"{inv.totalItem}");
                //}

                var totalArtist = querySum.Sum(q => q.totalItem);

                Console.WriteLine($"Total do artista: R$ {totalArtist}");



                //GROUPBY

                var queryGroupby = from inv in context.ItemsNotaFiscal
                                   where inv.Faixa.Album.Artista.Nome == "Led Zeppelin"
                                   group inv by inv.Faixa.Album into grouped
                                   let sellsPerAlbum = grouped.Sum(a => a.Quantidade * a.PrecoUnitario)
                                   orderby sellsPerAlbum descending
                                   select new
                                   {
                                        albumTitle = grouped.Key.Titulo,
                                        totalPerAlbum = sellsPerAlbum
                                   };

                foreach (var grouped in queryGroupby)
                {
                    Console.WriteLine($"{grouped.albumTitle, -40}\t{grouped.totalPerAlbum}");
                }
            }

            Console.ReadKey();
        }
    }
}
