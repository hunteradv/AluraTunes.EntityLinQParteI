using AluraTunes.LinqToEntities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraTunes.LinqToEntities
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(var context = new AluraTunesEntities())
            {
                var query = from g in context.Generos
                            select g;

                Console.WriteLine("Primeira query");
                Console.WriteLine();

                foreach (var genre in query)
                {
                    Console.WriteLine("{0}\t{1}", genre.GeneroId, genre.Nome);
                }

                var query2 = from g in context.Generos
                             join f in context.Faixas
                             on g.GeneroId equals f.GeneroId
                             select new { f, g };

                query2 = query2.Take(10);

                //context.Database.Log = Console.WriteLine;

                Console.WriteLine();
                Console.WriteLine("Query faixa e genero");
                Console.WriteLine();

                foreach (var item in query2)
                {
                    Console.WriteLine($"{item.f.Nome} \t {item.g.Nome}");
                }


                //AULA 03

                var searchText = "Led";

                //var query3 = from a in context.Artistas
                //             where a.Nome.Contains(searchText)
                //             select a;

                var query3 = context.Artistas.Where(a => a.Nome.Contains(searchText));

                Console.WriteLine();
                Console.WriteLine("Query artista com where");
                Console.WriteLine();

                foreach (var artista in query3)
                {
                    Console.WriteLine($"{artista.ArtistaId}\t{artista.Nome}");
                }


                //AULA 04
                Console.WriteLine();
                Console.WriteLine("Aula 04");
                Console.WriteLine();

                //var query3 = from a in context.Artistas
                //             where a.Nome.Contains(searchText)
                //             select a;

                var queryArtistasEAlbuns = from a in context.Artistas
                                           join alb in context.Albums
                                           on a.ArtistaId equals alb.ArtistaId
                                           where a.Nome.Contains(searchText)
                                           select new
                                           {
                                               ArtistName = a.Nome,
                                               AlbumName = alb.Titulo
                                           };

                Console.WriteLine();
                Console.WriteLine("Query artista com album");
                Console.WriteLine();

                foreach (var item in queryArtistasEAlbuns)
                {
                    Console.WriteLine($"{item.ArtistName}\t{item.AlbumName}");
                }

                Console.WriteLine();
                Console.WriteLine("Album usando navigation property");
                Console.WriteLine();

                var queryAlbums = from album in context.Albums
                                  where album.Artista.Nome.Contains(searchText)
                                  select new
                                  {
                                      ArtistName = album.Artista.Nome,
                                      AlbumName = album.Titulo
                                  };

                foreach (var album in queryAlbums)
                {
                    Console.WriteLine($"{album.ArtistName}\t{album.AlbumName}");
                }


                Console.WriteLine();
                Console.WriteLine("Album usando navigation property sem filtrar por album");
                Console.WriteLine();

                GetTunes(context, "Led Zeppelin", "");

                Console.WriteLine();
                Console.WriteLine("Filtrando por album");
                Console.WriteLine();

                GetTunes(context, "Led Zeppelin", "Graffiti");
            }

            Console.ReadKey();
        }

        private static void GetTunes(AluraTunesEntities context, string searchText, string searchAlbum)
        {
            //PRIMEIRA FORMA DE FAZER
            //var queryAlbumsAndArtists = from f in context.Faixas
            //                            where f.Album.Artista.Nome.Contains(searchText)
            //                            select f;

            //if(!string.IsNullOrEmpty(searchAlbum))
            //{
            //    queryAlbumsAndArtists = queryAlbumsAndArtists.Where(q => q.Album.Titulo.Contains(searchAlbum));
            //}

            ////filtrando pelo nome de album e nome de faixa em ordem crescente (alfabética)
            ////queryAlbumsAndArtists = queryAlbumsAndArtists.OrderBy(q => q.Album.Titulo).ThenBy(q => q.Nome);

            ////filtrando pelo nome de album e nome de faixa em ordem decrescente (alfabética)
            //queryAlbumsAndArtists = queryAlbumsAndArtists.OrderBy(q => q.Album.Titulo).ThenByDescending(q => q.Nome);


            //SEGUNDA FORMA DE FAZER (MAIS SIMPLES)

            var queryAlbumsAndArtists = from f in context.Faixas
                                        where f.Album.Artista.Nome.Contains(searchText)
                                        && (!string.IsNullOrEmpty(searchAlbum) ? f.Album.Titulo.Contains(searchAlbum) : true)
                                        orderby f.Album.Titulo, f.Nome
                                        select f;


            foreach (var faixa in queryAlbumsAndArtists)
            {
                Console.WriteLine($"{faixa.Album.Titulo.PadRight(40)}\t{faixa.Nome}");
            }
        }
    }
}
