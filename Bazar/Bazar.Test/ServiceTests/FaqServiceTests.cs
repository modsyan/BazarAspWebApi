using System.Configuration;
using Bazar.Core.Interfaces;
using Bazar.Core.Models;
using Bazar.EF.Data;
using Bazar.EF.Repositories;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bazar.Test.ServiceTests;

public class FaqServiceTests: BaseServiceTests<IFaqService>
{
    public FaqServiceTests(): base()
    {
    }

    protected override void AddServices(IServiceCollection services)
    {
        services.AddTransient<IFaqService, FaqService>();
    }
    
    [Fact]
    public async void GetFaqs_ExistingFaqs_ReturnFaqs()
    {
        // Arrange 

        var faqList = (await Service.Get());

        // Assert.NotNull(faqList);
        // Assert.NotEmpty(faqList);

        foreach (var faq in faqList)
        {
            Assert.NotNull(faq.Question);
            Assert.NotNull(faq.Answer);
        }
    }

    [Fact]
    public void AddFaq_ValidFaq_CreatesFaqs()
    {
        //
        // var faq = new Faq()
        // {
        //     Answer = ;
        //         
        // }
    }
    //
    // // [Fact]
    // public void AddFaq_MissingQuestionOrAnswer_CreatesFaqs()
    // {
    //     
    // }
    //
    // // [Fact]
    // public void RemoveFaq_ExistingId_DeletesFaq()
    // {
    //     
    // }
    //
    // // [Fact]
    // public void RemoveFaq_NonExistingId_ReturnFalse()
    // {
    //
    // }
}
