using System.Security.Claims;
using Bazar.Api.Services.Contracts;
using Bazar.Api.Services.Contracts.Base;
using Bazar.Core.Entities;
using Bazar.Core.Interfaces;
using Bazar.EF.Repositories;

namespace Bazar.Api.Services;

public class PostService: BaseService,IPostService
{

    public PostService(IUnitOfWork unitOfWork): base(unitOfWork)
    {
    }

    public Post Crate(Post post)
    {
        var createdPost = UnitOfWork.Posts.Create(post);
        
        // var identity = HttpContent.User.Identity as ClaimsIdentity;
        // IEnumerable<Cliam> cliams = identity.Cliams;
        
        return createdPost;
    }

    public Post Update(Guid id, Post post)
    {
        var updatedPost = UnitOfWork.Posts.Update(post);
        UnitOfWork.Complete();
        return updatedPost;
    }

    public void Remove(Guid id)
    {
        UnitOfWork.Posts.Delete(id);
        UnitOfWork.Complete();
    }

    public async Task<IEnumerable<Post>> GetAll()
    {
        return await UnitOfWork.Posts.GetAsync();
    }

    public async Task<Post> FindById(Guid id)
    {
        return await UnitOfWork.Posts.GetAsync(id);
    }


    public IEnumerable<Post> FindByQueryString(string queryString)
    {
        throw new NotImplementedException();
    }
}