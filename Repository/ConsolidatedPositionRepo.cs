using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ConsolidatedPositionRepo : IConsolidatedPositionRepo
    {
        private static IList<ConsolidatedPositionModel> _posicaoConsolidadaList = new List<ConsolidatedPositionModel> 
        { 
            new ConsolidatedPositionModel
            { 
                Id = 1,
                TotalBalance = 50,
                Custodies = new List<CustodyModel>
                {
                    new CustodyModel
                    {
                        Id = 1,
                        Ativo = "PETR4",
                        Valor = 20
                    },
                    new CustodyModel
                    {
                        Id = 2,
                        Ativo = "VALE3",
                        Valor = 30
                    },
                },
            }
        };

        public ConsolidatedPositionModel GetById(int id)
        {
            return _posicaoConsolidadaList.FirstOrDefault(o => o.Id == id);
        }
    }
}