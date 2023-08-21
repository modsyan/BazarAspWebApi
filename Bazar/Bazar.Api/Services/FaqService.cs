using Bazar.Api.Services.Contracts;
using Bazar.Core.Entities;
using Bazar.Core.Interfaces;
using Bazar.Core.Models;

namespace Bazar.Api.Services;

public class FaqService : BaseService<FaqService>, IFaqService
{
    public FaqService(IUnitOfWork unitOfWork, ILogger<FaqService> logger) : base(unitOfWork, logger)
    {
    }

    public async Task<IEnumerable<Faq>> Get()
    {
        return await UnitOfWork.Faqs.GetAsync();
    }

    public async Task<Faq?> Get(Guid id)
    {
        return await UnitOfWork.Faqs.GetAsync(id);
    }

    public async Task<Faq> Add(Faq faq)
    {
        var newFaq = await UnitOfWork.Faqs.CreateAsync(faq);
        await UnitOfWork.CompleteAsync();
        return newFaq;
    }

    public void Remove(Guid id)
    {
        UnitOfWork.Faqs.Delete(id);
        UnitOfWork.Complete();
    }
}