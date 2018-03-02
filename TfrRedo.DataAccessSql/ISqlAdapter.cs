using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFR.Data.Models.Journey;

namespace TfrRedo.DataAccessSql
{
    public interface ISqlAdapter
    {
      
        void Insert();
        void Update();
        void Delete();
        DataTable GetAll();
        void GetById();
        void Save(Journey journey);
        void Delete(Journey journey);
        IEnumerable<Journey> AllJourneys();
    }
}
