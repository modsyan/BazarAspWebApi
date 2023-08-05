using System.Security.Claims;
using Bazar.Api.Services.Contracts;
using Bazar.Core.Entities;
using Bazar.Core.Interfaces;
using Bazar.EF.Repositories;

namespace Bazar.Api.Services;

public class PostService: IPostService
{
    private readonly IUnitOfWork _unitOfWork;

    public PostService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Post Crate(Post post)
    {
        var createdPost = _unitOfWork.Posts.Create(post);
        
        // var identity = HttpContent.User.Identity as ClaimsIdentity;
        // IEnumerable<Cliam> cliams = identity.Cliams;
        
        return createdPost;
    }

    public Post Update(Guid id, Post post)
    {
        var updatedPost = _unitOfWork.Posts.Update(post);
        _unitOfWork.Complete();
        return updatedPost;
    }

    public void Remove(Guid id)
    {
        _unitOfWork.Posts.Delete(id);
        _unitOfWork.Complete();
    }

    public async Task<IEnumerable<Post>> GetAll()
    {
        return await _unitOfWork.Posts.GetAsync();
    }

    public async Task<Post> FindById(Guid id)
    {
        return await _unitOfWork.Posts.GetAsync(id);
    }


    public IEnumerable<Post> FindByQueryString(string queryString)
    {
        throw new NotImplementedException();
    }
}