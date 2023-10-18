using Domain;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service
{
    public class ConsolidatedPositionService
    {
        private readonly IConsolidatedPositionRepo _repository;
        private readonly INotificationService _notificationService;

        public ConsolidatedPositionService()
        {
            _repository = new ConsolidatedPositionRepo();
            _notificationService = new NotificationService();
        }

        public ConsolidatedPositionModel Bonification(int clientID, decimal factor)
        {
            #region CalculateCustody

            var entityForCustody = _repository.GetById(clientID);
            foreach (var custodia in entityForCustody.Custodies)
            {
                if (custodia.Ativo == "PETR4") continue;
                custodia.Valor *= factor;
            }
            Console.WriteLine("Custody calculation finised!");

            #endregion


            #region CalculateFinance

            var entityForFinance = _repository.GetById(clientID);
            entityForFinance.TotalBalance = 0;
            foreach (var custodia in entityForFinance.Custodies)
            {
                entityForFinance.TotalBalance += custodia.Valor;
            }
            Console.WriteLine("Finance calculation finised!");

            #endregion


            #region Notification

            var entityForNotification = _repository.GetById(clientID);
            _notificationService.Notify(entityForNotification);

            #endregion

            return _repository.GetById(clientID);
        }
    }
}
