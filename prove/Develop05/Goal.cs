public abstract class Goal
    {
        public string Name { get; protected set; }
        public int Value { get; protected set; }
        public bool IsCompleted { get; protected set; }

        public abstract void MarkCompleted();
        public abstract void DisplayProgress();
        public abstract string SaveGoal();
    }