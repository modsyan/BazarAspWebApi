using Bazar.Core.Models;

namespace Bazar.Api.Services.Interfaces;

public interface IFaqService
{
    public Task<IEnumerable<Faq>> Get()
    {
        throw new NotImplementedException();
    }
    
    public Task<Faq> Add(string question, string answer)
    {
        throw new NotImplementedException();
    }
    
    public void Remove(string id)
    {
        throw new NotImplementedException();
    }
}