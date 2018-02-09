using Domain.Instructions;

namespace Domain.Legs
{
    public class Leg
    {
        public int Id { get; set; }
        public Instruction Instruction { get; set; }
        public int Duration { get; set; }
        public int DurationHours { get; set; }
        public int DurationMinutes { get; set; }
        public float Distance { get; set; }
    }
}