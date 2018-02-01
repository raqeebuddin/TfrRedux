using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFR.Data.Models
{
    public interface IStation
    {
        int Id { get; set; }
        string NaptanId { get; set; }
        string IcsId { get; set; }
        string Name { get; set; }
        string Fare { get; set; }
        Nullable<int> CaloriesBurned { get; set; }
    }
}
