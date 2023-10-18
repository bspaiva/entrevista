using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IConsolidatedPositionService
    {
        ConsolidatedPositionModel Bonification(int clientID, decimal factor);
    }
}
