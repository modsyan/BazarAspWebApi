
using Bazar.Core.Entities;
using Microsoft.Build.FileSystem;

namespace Bazar.Api.Services.Contracts;
public interface IPostService
{
    Post Crate(Post post);
    Post Update(Guid id, Post post);
    void Remove(Guid id);
    Task<IEnumerable<Post>> GetAll();
    Task<Post> FindById(Guid id);
    IEnumerable<Post> FindByQueryString(string queryString);
}