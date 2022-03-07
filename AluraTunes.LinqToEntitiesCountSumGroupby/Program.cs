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
                var query = from f in context.Faixas
                            where f.Album.Artista.Nome == "Led Zeppelin"
                            select f;

                //Método 1
                //var quantity = query.Count();

                //Console.WriteLine($"Led Zeppelin tem {quantity} músicas no banco de dados");


                //Método 2
                var quantity = context.Faixas.Count(f => f.Album.Artista.Nome == "Led Zeppelin");

                Console.WriteLine($"Led Zeppelin tem {quantity} músicas no banco de dados");
            }

            Console.ReadKey();
        }
    }
}
