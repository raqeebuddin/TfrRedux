using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFR.Data.Models.Journey;

namespace TfrRedo.Services.Interfaces
{
    public interface IDatabaseService
    {
        void Save(Journey journey);
        void Delete(Journey journey);

        IEnumerable<Journey> AllJourneys();
    }
}
