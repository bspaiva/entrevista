using Domain;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintConsolidatedPositionBeforeBonification();

            System.Console.WriteLine($"# EXECUTING BONIFICATION PROCESS #");
            var sw = Stopwatch.StartNew();
            var bo = new ConsolidatedPositionService();
            bo.Bonification(1, 10);
            System.Console.WriteLine($"Bonification duration: {sw.ElapsedMilliseconds}");

            PrintConsolidatedPositionAfterBonification();

            System.Console.ReadLine();
        }

        private static void PrintConsolidatedPositionBeforeBonification()
        {
            IConsolidatedPositionRepo _repository = new ConsolidatedPositionRepo();
            ConsolidatedPositionModel model = _repository.GetById(1);

            System.Console.WriteLine($"# STATE BEFORE BONIFICATION #");
            System.Console.WriteLine($"ClientID: {model.Id}");
            System.Console.WriteLine($"Financeiro: {model.TotalBalance}");
            foreach (var item in model.Custodies)
            {
                System.Console.WriteLine($"Ativo: {item.Ativo}, Valor: {item.Valor}");
            }
            System.Console.WriteLine();
            System.Console.WriteLine();
        }

        private static void PrintConsolidatedPositionAfterBonification()
        {
            IConsolidatedPositionRepo _repository = new ConsolidatedPositionRepo();
            ConsolidatedPositionModel model = _repository.GetById(1);

            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine($"# STATE AFTER BONIFICATION #");
            System.Console.WriteLine($"ClientID: {model.Id}");
            System.Console.WriteLine($"Financeiro: {model.TotalBalance}");
            foreach (var item in model.Custodies)
            {
                System.Console.WriteLine($"Ativo: {item.Ativo}, Valor: {item.Valor}");
            }
        }
    }
}
