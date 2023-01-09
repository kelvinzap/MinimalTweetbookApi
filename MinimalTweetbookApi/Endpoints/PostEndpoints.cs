using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using MinimalTweetbookApi.Models;
using MinimalTweetbookApi.Repositories;
using Guid = System.Guid;

namespace MinimalTweetbookApi.Endpoints;

[DisplayName("Posts")]
public static class PostEndpoints
{
    public static void MapPostEndpoints(this WebApplication app)
    {
        app.MapGet("/posts", GetAllPosts).WithTags("Posts");
        app.MapGet("/posts/{id:guid}", GetPost).WithTags("Posts");
        app.MapPost("/posts", CreatePost).WithTags("Posts");
        app.MapPut("/posts/{id:guid}", ([FromRoute] Guid id, [FromBody] Post post, IPostRepository repository) => UpdatePost(id, post, repository)).WithTags("Posts");
        app.MapDelete("/posts/{id:guid}", DeletePost).WithTags("Posts");
    }

    private static async Task<IResult> GetAllPosts(IPostRepository _postRepository)
    {
        var posts = _postRepository.GetAllAsync();
        return Results.Ok(posts);
    }
    
    private static async Task<IResult> GetPost(Guid id, IPostRepository _postRepository)
    {
        var post = _postRepository.GetPost(id);

        return post is null ? Results.NotFound() : Results.Ok(post);
    }

    private static async Task<IResult> CreatePost(Post post, IPostRepository _postRepository)
    {
        var result = _postRepository.CreatePost(post);

        return !result ? Results.BadRequest() : Results.Created($"/posts/{post.Id}", post);
    }
    
    private static async Task<IResult> UpdatePost(Guid id, Post post, IPostRepository _postRepository)
    {
        var result = _postRepository.UpdatePost(post);

        return !result ? Results.NotFound() : Results.Ok(post);
    }

    private static async Task<IResult> DeletePost(Guid id, IPostRepository _postRepository)
    {
        var result = _postRepository.DeletePost(id);
        
        return !result ? Results.NotFound() : Results.NoContent();
    }
}