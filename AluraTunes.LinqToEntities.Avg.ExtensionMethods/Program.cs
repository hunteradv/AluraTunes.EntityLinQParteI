﻿using AluraTunes.LinqToEntities.Avg.ExtensionMethods.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraTunes.LinqToEntities.Avg.ExtensionMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AluraTunesEntities())
            {
                context.Database.Log = Console.WriteLine;

                var biggestSale = context.NotasFiscais.Max(nf => nf.Total);
                var lowestSale = context.NotasFiscais.Min(nf => nf.Total);
                var averageSale = context.NotasFiscais.Average(nf => nf.Total);

                Console.WriteLine($"A maior venda é de ${biggestSale}");
                Console.WriteLine($"A menor venda é de ${lowestSale}");
                Console.WriteLine($"A venda média é de ${averageSale}");

                var sales = (from inv in context.NotasFiscais
                            group inv by 1 into grouped
                            select new
                            {
                                biggestSale = grouped.Max(nf => nf.Total),
                                lowestSale = grouped.Min(nf => nf.Total),
                                averageSale = grouped.Average(nf => nf.Total)
                            }).Single();

                Console.WriteLine($"A maior venda é de $ {sales.biggestSale}");
                Console.WriteLine($"A menor venda é de $ {sales.lowestSale}");
                Console.WriteLine($"A venda média é de $ {sales.averageSale}");
            }

            Console.ReadKey();
        }
    }
}