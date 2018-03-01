using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfrRedo.DataAccessSql
{
    public interface ISqlAdapter
    {
      
        void Insert();
        void Update();
        void Delete();
        DataTable GetAll();
        void GetById();
    }
}
