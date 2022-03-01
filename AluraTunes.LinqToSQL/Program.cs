using AluraTunes.LinqToEntities.Data;
using System;

namespace AluraTunes.LinqToEntities
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (AluraTunesEntities context = new AluraTunesEntities())
            {
                var query = from g in context.Generoes
                            select g;

                foreach (var genre in query)
                {
                    Console.WriteLine("{0}\t{1}", genre.GeneroId, genre.genero.Nome);
                }

                //imprimir no console
            }
        }
    }
}
