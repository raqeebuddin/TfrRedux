using Domain.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Legs
{
    public class Leg
    {
        public Instruction Instruction { get; set; }
        public int Duration { get; set; }
        public int DurationHours { get; set; }
        public int DurationMinutes { get; set; }
        public float Distance { get; set; }
    }
}
