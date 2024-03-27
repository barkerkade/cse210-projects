using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EternalQuest
{
    class Program
    {
        static List<Goal> goals = new List<Goal>();

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n---Eternal Quest---");
                Console.WriteLine("1. Add Goal");
                Console.WriteLine("2. Record Event");
                Console.WriteLine("3. Display Goals");
                Console.WriteLine("4. Display Score");
                Console.WriteLine("5. Save Goals");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddGoal();
                        break;
                    case 2:
                        RecordEvent();
                        break;
                    case 3:
                        DisplayGoals();
                        break;
                    case 4:
                        DisplayScore();
                        break;
                    case 5:
                        SaveGoals();
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddGoal()
        {
            Console.Write("Enter the name of the goal: ");
            string name = Console.ReadLine();
            Console.WriteLine("Select the type of goal:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Enter your choice: ");
            int typeChoice = int.Parse(Console.ReadLine());

            switch (typeChoice)
            {
                case 1:
                    Console.Write("Enter the value for completing the goal: ");
                    int simpleValue = int.Parse(Console.ReadLine());
                    goals.Add(new SimpleGoal(name, simpleValue));
                    break;
                case 2:
                    Console.Write("Enter the value for each time the goal is recorded: ");
                    int eternalValue = int.Parse(Console.ReadLine());
                    goals.Add(new EternalGoal(name, eternalValue));
                    break;
                case 3:
                    Console.Write("Enter the value for each time the goal is recorded: ");
                    int checklistValue = int.Parse(Console.ReadLine());
                    Console.Write("Enter the target count for the checklist: ");
                    int targetCount = int.Parse(Console.ReadLine());
                    goals.Add(new ChecklistGoal(name, checklistValue, targetCount));
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            Console.WriteLine($"Goal '{name}' added successfully.");
        }

        static void RecordEvent()
        {
            Console.WriteLine("\nSelect the goal to record an event for:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].Name}");
            }
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice > 0 && choice <= goals.Count)
            {
                Goal selectedGoal = goals[choice - 1];
                selectedGoal.MarkCompleted();
                if (selectedGoal is EternalGoal || selectedGoal is ChecklistGoal)
                {
                    if (selectedGoal is ChecklistGoal checklistGoal && !checklistGoal.IsCompleted)
                    {
                        checklistGoal.RecordEvent();
                    }
                    else if (selectedGoal is EternalGoal eternalGoal)
                    {
                        eternalGoal.RecordEvent();
                    }
                }
                else
                {
                    Console.WriteLine($"You've completed the goal '{selectedGoal.Name}' and earned {selectedGoal.Value} points!");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        static void DisplayGoals()
        {
            Console.WriteLine("\n---Your Goals---");
            foreach (var goal in goals)
            {
                goal.DisplayProgress();
            }
        }

        static void DisplayScore()
        {
            int totalScore = goals.Where(g => g.IsCompleted).Sum(g => g.Value);
            Console.WriteLine($"\nTotal Score: {totalScore} points");
        }

        static void SaveGoals()
        {
            using (StreamWriter writer = new StreamWriter("goals.txt"))
            {
                foreach (var goal in goals)
                {
                    writer.WriteLine(goal.SaveGoal());
                }
            }
        }
    }
}
