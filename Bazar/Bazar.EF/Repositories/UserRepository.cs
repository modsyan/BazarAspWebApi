using System.Linq.Expressions;
using Bazar.Core.Constants;
using Bazar.Core.Entities;
using Bazar.Core.Interfaces;
using Bazar.Core.Models;
using Bazar.EF.Data;
using Microsoft.AspNetCore.Identity;

namespace Bazar.EF.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}