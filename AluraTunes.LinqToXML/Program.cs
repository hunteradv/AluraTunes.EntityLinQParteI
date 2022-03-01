using System;
using System.Linq;
using System.Xml.Linq;

namespace AluraTunes.LinqToXML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XElement root = XElement.Load(@"C:\Users\gusta\source\repos\AluraTunes.EntityLinQParteI\AluraTunes.LinqToXML\Data\AluraTunes.xml");

            var queryXML = from g in root.Elements("Generos").Elements("Genero")
                           select g;

            foreach (var genre in queryXML)
            {
                Console.WriteLine("{0}\t{1}", genre.Element("GeneroId").Value, genre.Element("Nome").Value);
            }

            var query = from g in root.Element("Generos").Elements("Genero")
                        join m in root.Element("Musicas").Elements("Musica")
                            on g.Element("GeneroId").Value equals m.Element("GeneroId").Value
                        select new
                        {
                            MusicId = m.Element("MusicaId").Value,
                            Music = m.Element("Nome").Value,
                            Genre = g.Element("Nome").Value
                        };

            Console.WriteLine();
            Console.WriteLine();

            foreach (var music in query)
            {
                Console.WriteLine("{0}\t{1}\t{2}", music.MusicId, music.Music, music.Genre);
            }
        }
    }
}
