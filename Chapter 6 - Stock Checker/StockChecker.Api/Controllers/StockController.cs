using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockChecker.Api.DataAccess;
using StockChecker.Api.Models;

namespace StockChecker.Api.Controllers
{
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IDbContext dbContext;

        public StockController(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public ActionResult<int> Get(int id)
        {
            Product product = dbContext.Products.FirstOrDefault(a => a.Id == id);
            if (product == null) return NotFound();

            return Ok(product.StockCount);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]int stockCount)
        {
            Product product = dbContext.Products.FirstOrDefault(a => a.Id == id);
            if (product == null) return NotFound();

            product.StockCount = stockCount;
            dbContext.SaveChanges();

            return NoContent();
        }
    }
}
