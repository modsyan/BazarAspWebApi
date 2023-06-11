using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bazar.Api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        
        
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            
        }
    }
}
