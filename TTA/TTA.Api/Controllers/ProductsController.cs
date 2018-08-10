using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTA.Api.Data;
using TTA.Api.Models;

namespace TTA.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        //public IEnumerable<Product> Get()
        //{
        //    return _context.Products.ToList();
        //}

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _context.Products.FindAsync(id));
        }

        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Product>> CreateAsync([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            product.Created = DateTime.Now;
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Product value)
        {
            _context.Products.Update(value);
            _context.SaveChangesAsync();
        }
    }
}