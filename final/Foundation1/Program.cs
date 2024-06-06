using System;
using System.Collections.Generic;

class Comment
{
    public string AuthorName { get; private set; }
    public string CommentText { get; private set; }

    public Comment(string authorName, string commentText)
    {
        AuthorName = authorName;
        CommentText = commentText;
    }

    public override string ToString()
    {
        return $"{AuthorName}: {CommentText}";
    }
}

class Video
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int Length { get; private set; }
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public override string ToString()
    {
        return $"Title: {Title}, Author: {Author}, Length: {Length} seconds, Comments: {GetNumberOfComments()}";
    }

    public void DisplayComments()
    {
        foreach (var comment in comments)
        {
            Console.WriteLine(comment);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("C# Tutorial", "John Doe", 600);
        Video video2 = new Video("Python Basics", "Jane Smith", 800);
        Video video3 = new Video("Java Programming", "Alice Johnson", 720);

        // Add comments to video1
        video1.AddComment(new Comment("User1", "Great tutorial!"));
        video1.AddComment(new Comment("User2", "Very helpful, thanks!"));
        video1.AddComment(new Comment("User3", "I learned a lot."));

        // Add comments to video2
        video2.AddComment(new Comment("UserA", "Awesome content!"));
        video2.AddComment(new Comment("UserB", "Thanks for sharing."));
        video2.AddComment(new Comment("UserC", "Clear and concise."));

        // Add comments to video3
        video3.AddComment(new Comment("UserX", "Fantastic video!"));
        video3.AddComment(new Comment("UserY", "Informative and well explained."));
        video3.AddComment(new Comment("UserZ", "Really enjoyed this."));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display video details and comments
        foreach (var video in videos)
        {
            Console.WriteLine(video);
            video.DisplayComments();
            Console.WriteLine();
        }
    }
}
