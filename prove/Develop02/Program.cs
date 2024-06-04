using System;
using System.Collections.Generic;

public class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    public List<Comment> Comments { get; set; }

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

    public int NumComments()
    {
        return Comments.Count;
    }
}

class Program
{
    static void Main()
    {
        // Create videos and comments
        Video video1 = new Video("Video 1", "Author 1", 300);
        video1.AddComment(new Comment("John", "Great video!"));
        video1.AddComment(new Comment("Jane", "Love this!"));
        video1.AddComment(new Comment("Bob", "Awesome content"));

        Video video2 = new Video("Video 2", "Author 2", 240);
        video2.AddComment(new Comment("Alice", "Interesting"));
        video2.AddComment(new Comment("Mike", "Good job!"));
        video2.AddComment(new Comment("Sarah", "Thanks for sharing"));

        Video video3 = new Video("Video 3", "Author 3", 180);
        video3.AddComment(new Comment("Tom", "Nice video"));
        video3.AddComment(new Comment("Lily", "Well done!"));
        video3.AddComment(new Comment("Sam", "Keep up the good work"));

        // Put videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display video information and comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of comments: {video.NumComments()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"  {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}