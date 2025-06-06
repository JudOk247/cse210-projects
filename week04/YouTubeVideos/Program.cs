using System;
using System.Collections.Generic;

// Define the Comment class
public class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }

    public override string ToString()
    {
        return $"{CommenterName}: {Text}";
    }
}

// Define the Video class
public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine(comment);
        }
        Console.WriteLine(); // Empty line for better readability
    }
}

class Program
{
    static void Main()
    {
        // Create videos
        var video1 = new Video("Video 1", "Author 1", 300);
        var video2 = new Video("Video 2", "Author 2", 240);
        var video3 = new Video("Video 3", "Author 3", 180);
        var video4 = new Video("Video 4", "Author 4", 420);

        // Add comments to videos
        video1.AddComment(new Comment("John Doe", "Great video!"));
        video1.AddComment(new Comment("Jane Doe", "I loved it!"));
        video1.AddComment(new Comment("Bob Smith", "Well done!"));
        video1.AddComment(new Comment("Alice Johnson", "Excellent content!"));

        video2.AddComment(new Comment("Mike Brown", "Nice job!"));
        video2.AddComment(new Comment("Emily Davis", "Keep it up!"));
        video2.AddComment(new Comment("Tom White", "Good work!"));

        video3.AddComment(new Comment("Sarah Lee", "Awesome!"));
        video3.AddComment(new Comment("Kevin Walker", "Love it!"));
        video3.AddComment(new Comment("Rebecca Martin", "Fantastic!"));
        video3.AddComment(new Comment("David Thompson", "Well done!"));

        video4.AddComment(new Comment("Peter Hall", "Great content!"));
        video4.AddComment(new Comment("Olivia Jenkins", "Excellent video!"));
        video4.AddComment(new Comment("Michael Scott", "Good job!"));

        // Put videos in a list
        var videos = new List<Video> { video1, video2, video3, video4 };

        // Display video information
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}