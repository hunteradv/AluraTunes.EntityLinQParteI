using AluraTunes.EntityLinQParteI.LinqToObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AluraTunes.EntityLinQParteI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Genre> genres = new List<Genre>()
            {
                new Genre { Id = 1, Name = "Rock"},
                new Genre { Id = 2, Name = "Rock Alternativo"},
                new Genre { Id = 3, Name = "Pop"},
                new Genre { Id = 4, Name = "Pop Rock"},
                new Genre { Id = 5, Name = "K-Pop"},
                new Genre { Id = 6, Name = "MPB"}
            };

            //select para filtrar generos que contém a palavra "Rock"
            var query = from g in genres 
                        where g.Name.Contains("Rock") 
                        select g;

            foreach (var genre in query)
            {
                Console.WriteLine($"ID: {genre.Id} Gênero: {genre.Name}");
            }

            Console.WriteLine();

            List<Music> musics = new List<Music>()
            {
                new Music { Id = 1, Name = "Highway to hell", GenreId = 2},
                new Music { Id = 2, Name = "Faroeste Caboclo", GenreId = 6},
                new Music { Id = 3, Name = "Fire", GenreId = 5},
                new Music { Id = 4, Name = "I write sins not tragedies", GenreId = 2},
                new Music { Id = 5, Name = "This is gospel", GenreId = 4},
                new Music { Id = 6, Name = "7 Rings", GenreId = 3},
            };

            //select para filtrar musicas cujo GenderId da classe Music é igual ao Id da clase Gender
            var musicQuery = from m in musics 
                             join g in genres on m.GenreId equals g.Id 
                             select new {m, g};

            foreach(var music in musicQuery)
            {
                Console.WriteLine($"ID: {music.m.Id} \t Nome: {music.m.Name} \t IdGenero: {music.m.GenreId} \t Nome genero: {music.g.Name}");
            }

            Console.WriteLine();

            //select para filtrar musicas cujo Id da classe Gender contém a palavra Pop que contém a palavra POP
            var musicQueryName = from m in musics
                             join g in genres on m.GenreId equals g.Id
                             where g.Name == "Pop"
                             select m;            

            foreach (var music in musicQueryName)
            {
                Console.WriteLine($"ID: {music.Name} \t Nome: {music.Name} \t IdGenero: {music.GenreId}");
            }
        }        
    }
}
