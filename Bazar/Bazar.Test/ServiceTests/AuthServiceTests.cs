using System.Text;
using Bazar.Core.Entities;
using Bazar.Core.Models;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Bazar.Test.ServiceTests;

public class AuthServiceTest : BaseServiceTests<IAuthService>
{
    private const string ValidPassword = "P@ssw0rd";
    private const string InvalidPassword = "asd123";
    private const string FName = "Muhammad";
    private const string LName = "Hamdy";
    private readonly Faker _faker;

    public AuthServiceTest() {
        _faker = new Faker();
    }

    private static string NewRand()
    {
        var rand = new Random();
        const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
        var randBuilder = new StringBuilder();
        for (var i = 0; i < 8; i++)
            randBuilder.Append(pool[rand.Next(0, pool.Length)]);
        return randBuilder.ToString();
    }
    
    [Fact]
    public async void LoginUser_ValidCredentials_ReturnUser()
    {
        //  Arrange
        var registeredUser = await Service.Register(
            new User()
            {
                Email = $"mail{NewRand()}@gmail.com",
                FirstName = "Muhammad",
                LastName = "Hamdy",
                UserName = $"Modsyan{NewRand()}",
            }, ValidPassword
        );

        // Username or PasswordHash may be null because it's not required in the model
        // TODO: NEEDED TO MAKE USERNAME, EMAIL, PasswordHash Required

        Assert.NotNull(registeredUser.Email);
        Assert.NotNull(registeredUser.PasswordHash);

        var loggedUser = await Service.Login(registeredUser.Email, ValidPassword);

        Assert.NotNull(loggedUser);
        Assert.IsType<User>(loggedUser);
    }

    [Fact]
    public async void LoginUser_InvalidCredentials_ThrowsException()
    {
        var user = await Service.Register(
            user: new User()
            {
                FirstName = FName,
                LastName = LName,
                Email = $"mail{NewRand()}@gmail.com",
                UserName = $"username{NewRand()}",
            },
            ValidPassword
        );

        Assert.NotNull(user.Email);
        Assert.NotNull(user.PasswordHash);

        // "missing properties"
        await Assert.ThrowsAsync<ArgumentException>(async () =>
            await Service.Login("", ""));

        await Assert.ThrowsAsync<ArgumentException>(async () =>
            await Service.Login(user.Email, ""));

        await Assert.ThrowsAsync<ArgumentException>(async () =>
            await Service.Login("", ValidPassword));

        await Assert.ThrowsAsync<ArgumentException>(async () =>
            await Service.Login(user.Email, InvalidPassword));

        await Assert.ThrowsAsync<ArgumentException>(async () =>
            await Service.Login("wrongMail", ValidPassword));
    }

    // Register
    [Fact]
    public async void RegisterUser_ValidCredentials_ReturnUser()
    {
        var user = await Service.Register(
            new User()
            {
                FirstName = FName,
                LastName = LName,
                Email = $"mail{NewRand()}@gmail.com",
                UserName = $"modsyan{NewRand()}",
            }, ValidPassword
        );

        Assert.NotNull(user);
        Assert.IsType<User>(user);
    }

    [Fact]
    public async void RegisterUser_DuplicatedEmailOrUsername_ThrowException()
    {
        var staticEmail = new User()
        {
            FirstName = FName,
            LastName = LName,
            Email = $"modclover7{NewRand()}@gmail.com",
            UserName = $"User{NewRand()}"
        };

        var staticUsername = new User()
        {
            FirstName = FName,
            LastName = LName,
            Email = $"mail{NewRand()}@gmail.com",
            UserName = $"User{NewRand()}"
        };

        var userWithStaticEmailFirst = await Service.Register(staticEmail, ValidPassword);
        var userWithStaticUsernameFirst = await Service.Register(staticUsername, ValidPassword);

        Assert.NotNull(userWithStaticEmailFirst);

        await Assert.ThrowsAsync<DbUpdateException>(
            async () => await Service.Register(staticEmail, ValidPassword));

        Assert.NotNull(userWithStaticUsernameFirst);

        await Assert.ThrowsAsync<DbUpdateException>(async () =>
            await Service.Register(staticUsername, ValidPassword));
    }

    [Fact]
    public async void RegisterUser_MissingCredentialsProperties_ThrowException()
    {
        await Assert.ThrowsAsync<DbUpdateException>(async () =>
        {
            await Service.Register(
                user: new User()
                {
                    FirstName = FName,
                    LastName = LName,
                    Email = "",
                    UserName = $"Username{NewRand()}",
                },
                ValidPassword
            );
        });

        await Assert.ThrowsAsync<DbUpdateException>(async () =>
        {
            await Service.Register(
                user: new User()
                {
                    FirstName = FName,
                    LastName = LName,
                    Email = $"mail{NewRand()}@gmail.com",
                    UserName = "username",
                },
                ValidPassword
            );
        });

        await Assert.ThrowsAsync<DbUpdateException>(async () =>
        {
            await Service.Register(
                user: new User()
                {
                    FirstName = FName,
                    LastName = LName,
                    Email = $"mail{NewRand()}@gmail.com",
                    UserName = "username",
                },
                InvalidPassword
            );
        });
    }

    [Fact]
    public async void RegisterUser_InvalidCredentials_ThrowException()
    {
        // TODO: PASSWORD VALIDATION, USERNAME VALIDATIONS, EMAIL VALIDATIONS
        // invalid email
        await Assert.ThrowsAsync<DbUpdateException>(async () =>
        {
            await Service.Register(
                user: new User()
                {
                    FirstName = FName,
                    LastName = LName,
                    Email = $"mail{NewRand()}@gmail.com",
                    UserName = "username",
                },
                ValidPassword
            );
        });

        // invalid username
        await Assert.ThrowsAsync<DbUpdateException>(async () =>
        {
            var userWithInvalidUsername = await Service.Register(
                user: new User()
                {
                    FirstName = FName,
                    LastName = LName,
                    Email = $"mail{NewRand()}@gmail.com",
                    UserName = "1234",
                },
                ValidPassword
            );
        });

        // invalid password
        await Assert.ThrowsAsync<DbUpdateException>(async () =>
        {
            var userWithInvalidPassword = await Service.Register(
                user: new User()
                {
                    FirstName = FName,
                    LastName = LName,
                    Email = $"mail.com{NewRand()}",
                    UserName = $"Username{NewRand()}",
                },
                InvalidPassword
            );
        });
    }

    [Fact]
    public async void ResetPassword_ValidCredentials_ReturnUser()
    {
    }

    [Fact]
    public async void ResetPassword_InvalidCredentials_ThrowsException()
    {
    }
}