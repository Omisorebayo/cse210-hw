using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        
        Video video1 = new Video(
            "Learning C# for Beginners",
            "Programming with Bayo",
            420);

        video1.AddComment(new Comment("John", "Great explanation!"));
        video1.AddComment(new Comment("Sarah", "Very helpful."));
        video1.AddComment(new Comment("Michael", "Looking forward to more tutorials."));

        videos.Add(video1);

    
        Video video2 = new Video(
            "Object-Oriented Programming Basics",
            "Code Academy",
            615);

        video2.AddComment(new Comment("David", "Excellent introduction."));
        video2.AddComment(new Comment("Grace", "This helped me a lot."));
        video2.AddComment(new Comment("James", "Very clear examples."));
        video2.AddComment(new Comment("Linda", "Please make more videos."));

        videos.Add(video2);

        
        Video video3 = new Video(
            "Understanding Abstraction",
            "Tech Tutorials",
            510);

        video3.AddComment(new Comment("Chris", "Now I understand abstraction."));
        video3.AddComment(new Comment("Amanda", "Very informative."));
        video3.AddComment(new Comment("Daniel", "Thanks for explaining it step by step."));

        videos.Add(video3);

        
        Video video4 = new Video(
            "Encapsulation Explained",
            "Learn Programming",
            480);

        video4.AddComment(new Comment("Sophia", "Excellent lesson."));
        video4.AddComment(new Comment("Robert", "Great examples."));
        video4.AddComment(new Comment("Emma", "Very easy to understand."));
        video4.AddComment(new Comment("William", "Keep up the good work."));

        videos.Add(video4);

        Console.WriteLine("========================================");
        Console.WriteLine("YouTube Video Report");
        Console.WriteLine("========================================");
        Console.WriteLine();

        foreach (Video video in videos)
        {
            video.DisplayVideo();
        }

        Console.WriteLine("End of Program");
    }
}