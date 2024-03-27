public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public override void MarkCompleted()
        {
            IsCompleted = true;
        }

        public override void DisplayProgress()
        {
            Console.WriteLine($"Goal: {Name} - Status: {(IsCompleted ? "Completed" : "Incomplete")}");
        }

        public override string SaveGoal()
        {
            return $"SimpleGoal|{Name}|{Value}|{IsCompleted}";
        }
    }