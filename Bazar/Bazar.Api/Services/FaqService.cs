using Bazar.Api.Services.Contracts;
using Bazar.Core.Entities;
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
        return await _unitOfWork.Faqs.GetAsync();
    }

    public async Task<Faq?> Get(Guid id)
    {
        return await _unitOfWork.Faqs.GetAsync(id);
    }

    public async Task<Faq> Add(Faq faq)
    {
        var newFaq = await _unitOfWork.Faqs.CreateAsync(faq);
        await _unitOfWork.CompleteAsync();
        return newFaq;
    }

    public void Remove(Guid id)
    {
        _unitOfWork.Faqs.Delete(id);
        _unitOfWork.Complete();
    }
}