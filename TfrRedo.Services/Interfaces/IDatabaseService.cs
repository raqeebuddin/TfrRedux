using System.Collections.Generic;
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