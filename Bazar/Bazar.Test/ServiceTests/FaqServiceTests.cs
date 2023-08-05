using System.Configuration;
using Bazar.Core.Entities;
using Bazar.Core.Interfaces;
using Bazar.Core.Models;
using Bazar.EF.Data;
using Bazar.EF.Repositories;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bazar.Test.ServiceTests;

public class FaqServiceTests : BaseServiceTests<IFaqService>
{
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
    public async void AddFaq_ValidFaq_ReturnCreatedFaqs()
    {
        // Arrange
        var faqItem = new Faq()
        {
            Question = "How Are you?",
            Answer = "Thanks, Im good.",
        };

        // Act
        var addedFaqItem = await Service.Add(faqItem);


        //Assert
        Assert.NotNull(addedFaqItem);
        Assert.Equal(faqItem.Question, addedFaqItem.Question);
        Assert.Equal(faqItem.Answer, addedFaqItem.Answer);
    }

    //
    [Fact]
    public async Task AddFaq_MissingQuestionOrAnswer_DoesNotCreatesFaqs()
    {
        //Arrange 

        var invalidFaqItem1 = new Faq
        {
            Question = "This is Just A Question without Answer"
        };

        var invalidFaqItem2 = new Faq
        {
            Answer = "This is Just An Answer without Question"
        };

        // Act && Assertion
        await Assert.ThrowsAsync<DbUpdateException>(async () => await Service.Add(invalidFaqItem1));
        await Assert.ThrowsAsync<DbUpdateException>(async () => await Service.Add(invalidFaqItem1));
    }

    [Fact]
    public async void RemoveFaq_ExistingId_DeletesFaq()
    {
        var newFaq = new Faq()
        {
            Question = "This is just a Question",
            Answer = "This Is An Answer to that Question"
        };

        var createdFaq = await Service.Add(newFaq);
        Service.Remove(createdFaq.Id);
        var removedFaq = await Service.Get(createdFaq.Id);
        Assert.Null(removedFaq);
    }

    [Fact]
    public void RemoveFaq_NonExistingId_ReturnFalse()
    {
    }
}