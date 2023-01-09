using MinimalTweetbookApi.Models;

namespace MinimalTweetbookApi.Repositories;

public class PostRepository : IPostRepository
{
    private readonly Dictionary<Guid, Post> _posts = new();
    
    public List<Post> GetAllAsync()
    {
        return _posts.Values.ToList();
    }

    public Post? GetPost(Guid id)
    {
        return _posts[id];
    }

    public bool CreatePost(Post? post)
    {
        if (post is null)
            return false;

        _posts[post.Id] = post;
        return true;
    }

    public bool UpdatePost(Post post)
    {
        var existingPost = GetPost(post.Id);
        
        if (existingPost is null)
            return false;

        _posts[post.Id] = post;
        return true;
    }

    public bool DeletePost(Guid id)
    {
        _posts.Remove(id);
        return true;
    }
}