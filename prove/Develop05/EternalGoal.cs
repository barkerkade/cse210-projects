public class EternalGoal : Goal
    {
        public EternalGoal(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public override void MarkCompleted()
        {
            // Eternal goals are never marked completed
        }

        public void RecordEvent()
        {
            Console.WriteLine($"You've recorded progress for {Name}. +{Value} points!");
        }

        public override void DisplayProgress()
        {
            Console.WriteLine($"Eternal Goal: {Name}");
        }

        public override string SaveGoal()
        {
            return $"EternalGoal|{Name}|{Value}|{IsCompleted}";
        }
    }