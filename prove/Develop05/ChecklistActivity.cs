public class ChecklistGoal : Goal
    {
        private int targetCount;
        private int currentCount;

        public ChecklistGoal(string name, int value, int targetCount)
        {
            Name = name;
            Value = value;
            this.targetCount = targetCount;
        }

        public override void MarkCompleted()
        {
            currentCount++;
            if (currentCount >= targetCount)
            {
                IsCompleted = true;
                Console.WriteLine($"Congratulations! You have completed the checklist goal '{Name}' and earned a bonus of {Value} points!");
                Value += Value; // Bonus points
            }
        }

        public void RecordEvent()
        {
            Console.WriteLine($"You've recorded progress for {Name}. +{Value} points!");
        }

        public override void DisplayProgress()
        {
            Console.WriteLine($"Checklist Goal: {Name} - Completed {currentCount}/{targetCount} times");
        }

        public override string SaveGoal()
        {
            return $"ChecklistGoal|{Name}|{Value}|{IsCompleted}|{targetCount}|{currentCount}";
        }
    }