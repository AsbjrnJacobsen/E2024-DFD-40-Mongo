namespace BloggingPlatformAssignment.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime PublishDate { get; set; }
    public int UserId { get; set; } //Author / OP
    
}