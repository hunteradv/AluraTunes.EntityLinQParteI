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
                var query = from g in context.Generoes
                select g;

                foreach (var genre in query)
                {
                    Console.WriteLine("{0}\t{1}", genre.GeneroId, genre.Nome);
                }
            }

            Console.ReadKey();
        }
    }
}
