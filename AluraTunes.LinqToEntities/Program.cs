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

                Console.WriteLine();
                Console.WriteLine("Segunda query");
                Console.WriteLine();

                foreach (var item in query2)
                {
                    Console.WriteLine($"{item.f.Nome} \t {item.g.Nome}");
                }
            }

            Console.ReadKey();
        }
    }
}
