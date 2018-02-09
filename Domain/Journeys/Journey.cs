using System;
using System.Collections.Generic;
using Domain.Legs;

namespace TFR.Data.Models.Journey
{
    public class Journey
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public int Duration { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public List<Leg> Legs { get; set; }
        public List<Leg> LegsTrain { get; set; }
        public List<Leg> LegsCycle { get; set; }
    }
}