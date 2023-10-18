using Domain;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service
{
    public class NotificationService : INotificationService
    {
        public void Notify(ConsolidatedPositionModel posicaoConsolidada) 
        {
            SendMail(posicaoConsolidada);
            SendSMS(posicaoConsolidada);
        }

        private void SendMail(ConsolidatedPositionModel posicaoConsolidada)
        {
            Console.Write($"Start sending email, TotalBalance: {posicaoConsolidada.TotalBalance}. ");
            Thread.Sleep(5000);
            Console.WriteLine("Email sent!");
        }

        private void SendSMS(ConsolidatedPositionModel posicaoConsolidada)
        {
            Console.Write($"Start sending SMS, TotalBalance: {posicaoConsolidada.TotalBalance}. ");
            Thread.Sleep(5000);
            Console.WriteLine("SMS sent!");
        }
    }
}
