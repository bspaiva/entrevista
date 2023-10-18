﻿using Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();

            var bo = new ConsolidatedPositionService();
            var model = bo.Bonification(1, 10);

            System.Console.WriteLine($"Bonification duration: {sw.ElapsedMilliseconds}");


            System.Console.WriteLine();
            System.Console.WriteLine();

            System.Console.WriteLine($"ClientID: {model.Id}");
            System.Console.WriteLine($"Financeiro: {model.TotalBalance}");
            foreach (var item in model.Custodies)
            {
                System.Console.WriteLine($"Ativo: {item.Ativo}, Valor: {item.Valor}");
            }
            System.Console.ReadLine();
        }
    }
}
