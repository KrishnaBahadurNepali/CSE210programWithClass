using System;
using System.Threading;

// Base class for all activities
class Activity
{
    public string Name { get; set; }
    public int Duration { get; set; }

    public Activity(string name, int duration)
    {
        Name = name;
        Duration = duration;
    }

    public void Start()
    {
        Console.WriteLine($"Starting {Name} activity ({Duration} seconds)...");
        // Show animation/countdown here
        Thread.Sleep(2000); // Simulated delay

        PerformActivity();

        Console.WriteLine($"{Name} activity completed in {Duration} seconds.");
        // Show animation/countdown here
        Thread.Sleep(2000); // Simulated delay
    }

    public virtual void PerformActivity()
    {
        // Activity-specific logic goes here
    }
}

// Subclass for the Breathing Activity
class BreathingActivity : Activity
{
    public BreathingActivity(string name, int duration) : base(name, duration) { }

    public override void PerformActivity()
    {
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly.");
        // Perform breathing activity logic here
    }
}

// Subclass for the Reflection Activity
class ReflectionActivity : Activity
{
    public ReflectionActivity(string name, int duration) : base(name, duration) { }

    public override void PerformActivity()
    {
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience.");
        // Perform reflection activity logic here
    }
}

// Subclass for the Listing Activity
class ListingActivity : Activity
{
    public ListingActivity(string name, int duration) : base(name, duration) { }

    public override void PerformActivity()
    {
        Console.WriteLine("This activity will help you reflect on the good things in your life by listing as many things as you can in a certain area.");
        // Perform listing activity logic here
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Activity Program!");

        // Example usage
        Activity breathingActivity = new BreathingActivity("Breathing", 5);
        breathingActivity.Start();

        Activity reflectionActivity = new ReflectionActivity("Reflection", 7);
        reflectionActivity.Start();

        Activity listingActivity = new ListingActivity("Listing", 4);
        listingActivity.Start();
    }
}
