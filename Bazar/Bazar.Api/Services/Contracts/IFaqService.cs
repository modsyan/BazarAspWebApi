using Bazar.Core.Entities;
using Bazar.Core.Models;

namespace Bazar.Api.Services.Contracts;

public interface IFaqService
{
    public Task<IEnumerable<Faq>> Get();
    public Task<Faq?> Get(Guid id);
    public Task<Faq> Add(Faq faq);
    public void Remove(Guid id);
}