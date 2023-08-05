using Bazar.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Bazar.Test.ServiceTests;

public class PostServiceTests : BaseServiceTests<IPostService>
{
    
    // arrange
    public async void GetAllPosts_ExistingPosts_ReturnsPosts()
    {
        //Arrange
        // var posts = Service.
    }

    public async void CreatePost_ValidPost_ReturnsPost()
    {
    }

    public async void CreatePost_InvalidPost_ThrowsArgumentException()
    {
    }

    public async void UpdatePost_InvalidPostUpdate_ReturnPost()
    {
    }

    public async void UpdatePost_NonExistingPostId_ThrowsNotFoundException()
    {
    }

    public async void RemovePost_NonExistingId_ThrowsArgumentException()
    {
    }

    public async void RemovePost_ExistingId_RemoveId()
    {
    }
}