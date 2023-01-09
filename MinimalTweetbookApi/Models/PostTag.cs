namespace MinimalTweetbookApi.Models;

public class PostTag
{
    public string TagName { get; set; }
    public Tag Tag { get; set; }
    public Guid PostId { get; set; }
    public virtual Post Post { get; set; }
}