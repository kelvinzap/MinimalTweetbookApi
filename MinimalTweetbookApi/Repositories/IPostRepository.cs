using MinimalTweetbookApi.Models;

namespace MinimalTweetbookApi.Repositories;

public interface IPostRepository
{
    List<Post> GetAllAsync();
    Post? GetPost(Guid id);
    bool CreatePost(Post post);
    bool UpdatePost(Post post);
    bool DeletePost(Guid id);
}