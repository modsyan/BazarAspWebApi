using System.Security.Claims;
using Bazar.Api.Services.Contracts;
using Bazar.Core.Entities;
using Bazar.Core.Interfaces;
using Bazar.EF.Repositories;

namespace Bazar.Api.Services;

public class PostService : BaseService<PostService>, IPostService
{
    public PostService(IUnitOfWork unitOfWork, ILogger<PostService> logger) : base(unitOfWork, logger)
    {
    }

    public async Task<Post> Add(Guid ownerUserId, Post post)
    {
        post.UserId = ownerUserId;
        var createdPost = await UnitOfWork.Posts.CreateAsync(post);
        await UnitOfWork.CompleteAsync();
        return createdPost;
    }

    public async Task<Post> Edit(Guid id, Post post)
    {
        var updatedPost = UnitOfWork.Posts.Update(post);
        await UnitOfWork.CompleteAsync();
        return updatedPost;
    }

    public bool Delete(Guid id)
    {
        UnitOfWork.Posts.Delete(id);
        UnitOfWork.Complete();
        return true;
    }

    public async Task<IEnumerable<Post>> GetAll(Guid id)
    {
        return await UnitOfWork.Posts.GetAsync();
    }

    public async Task<Post?> Get(Guid postId)
    {
        return await UnitOfWork.Posts.GetAsync(postId);
    }

    public IEnumerable<Post> FindByQueryString(string queryString)
    {
        throw new NotImplementedException();
    }
}