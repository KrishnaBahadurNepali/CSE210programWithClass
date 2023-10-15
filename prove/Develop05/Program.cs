using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Goal
{
    public string Name { get; set; }
    public int Value { get; set; }
    public bool IsEternal { get; set; }
    public bool IsChecklist { get; set; }
    public int TotalRequired { get; set; }
    public int CurrentCompleted { get; set; }

    public Goal(string name, int value, bool isEternal = false, bool isChecklist = false, int totalRequired = 0)
    {
        Name = name;
        Value = value;
        IsEternal = isEternal;
        IsChecklist = isChecklist;
        TotalRequired = totalRequired;
        CurrentCompleted = 0;
    }

    public virtual void RecordEvent()
    {
        if (IsChecklist)
        {
            CurrentCompleted++;
            if (CurrentCompleted == TotalRequired)
            {
                Console.WriteLine($"Congratulations! You've completed the {Name} goal and earned a bonus of {Value} points.");
                Value += Value; // Award bonus
            }
        }
        else
        {
            Console.WriteLine($"You completed the {Name} goal and earned {Value} points.");
        }
    }

    public bool IsCompleted()
    {
        if (IsEternal)
            return false;
        else if (IsChecklist)
            return CurrentCompleted >= TotalRequired;
        else
            return true;
    }

    public override string ToString()
    {
        string status = IsCompleted() ? "[X]" : "[ ]";
        if (IsChecklist)
            return $"{status} {Name} (Completed {CurrentCompleted}/{TotalRequired}) - Score: {Value}";
        else
            return $"{status} {Name} - Score: {Value}";
    }
}

class QuestManager
{
    private List<Goal> goals;
    private int totalScore;

    public QuestManager()
    {
        goals = new List<Goal>();
        totalScore = 0;
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        Goal goal = goals.FirstOrDefault(g => g.Name == goalName);
        if (goal != null)
        {
            goal.RecordEvent();
            totalScore += goal.Value;
        }
        else
        {
            Console.WriteLine("Goal not found!");
        }
    }

    public void ShowGoals()
    {
        Console.WriteLine("Your Goals:");
        foreach (var goal in goals)
        {
            Console.WriteLine(goal);
        }
        Console.WriteLine($"Total Score: {totalScore}");
    }

    public void SaveGoals(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var goal in goals)
            {
                writer.WriteLine($"{goal.Name},{goal.Value},{goal.IsEternal},{goal.IsChecklist},{goal.TotalRequired},{goal.CurrentCompleted}");
            }
        }
    }

    public void LoadGoals(string fileName)
    {
        goals.Clear();
        using (StreamReader reader = new StreamReader(fileName))
        {
            while (!reader.EndOfStream)
            {
                var data = reader.ReadLine().Split(',');
                string name = data[0];
                int value = int.Parse(data[1]);
                bool isEternal = bool.Parse(data[2]);
                bool isChecklist = bool.Parse(data[3]);
                int totalRequired = int.Parse(data[4]);
                int currentCompleted = int.Parse(data[5]);

                Goal goal = new Goal(name, value, isEternal, isChecklist, totalRequired);
                goal.CurrentCompleted = currentCompleted;
                goals.Add(goal);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        QuestManager questManager = new QuestManager();

        // Example goals
        questManager.AddGoal(new Goal("Run a marathon", 1000));
        questManager.AddGoal(new Goal("Read scriptures", 100, isEternal: true));
        questManager.AddGoal(new Goal("Attend the temple", 50, isChecklist: true, totalRequired: 10));

        // Recording events
        questManager.RecordEvent("Run a marathon");
        questManager.RecordEvent("Read scriptures");
        questManager.RecordEvent("Attend the temple");
        questManager.RecordEvent("Attend the temple"); // This will trigger the bonus

        // Display goals and total score
        questManager.ShowGoals();

        // Save and load goals
        questManager.SaveGoals("goals.txt");
        questManager.LoadGoals("goals.txt");

        // Show loaded goals
        questManager.ShowGoals();
    }
}
