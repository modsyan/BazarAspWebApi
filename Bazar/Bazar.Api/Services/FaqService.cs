using Bazar.Api.Services.Interfaces;
using Bazar.Core.Interfaces;
using Bazar.Core.Models;

namespace Bazar.Api.Services;

public class FaqService : IFaqService
{

    private readonly IUnitOfWork _unitOfWork;

    public FaqService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Faq>> Get()
    {
         return await _unitOfWork.Faqs.GetAllAsync();
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
