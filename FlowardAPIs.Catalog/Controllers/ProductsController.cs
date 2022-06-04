using Microsoft.AspNetCore.Mvc;
using FlowardEntities.Catalog.Models;
using FlowardServices.Catalog.Interfaces;

namespace FlowardAPIs.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public ProductsController(ICatalogService catalogService) => _catalogService = catalogService;

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            try
            {
                var products = await _catalogService.GetAllAsync();
                if (products == null)
                {
                    return NotFound();
                }

                return products;
            }
            catch { throw; }
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var product = await _catalogService.GetByIdAsync(id);
                if (product == null)
                {
                    return NotFound();
                }

                return product;
            }
            catch { throw; }
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            try
            {
                if (id != product.Id)
                {
                    return BadRequest();
                }

                await _catalogService.UpdateAsync(product);

                return NoContent();
            }
            catch { throw; }
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            try
            {
                await _catalogService.InsertAsync(product);

                return CreatedAtAction("GetProduct", new { id = product.Id }, product);
            }
            catch { throw; }
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Product product)
        {
            try
            {
                var targetProduct = await _catalogService.GetByIdAsync(product.Id);
                if (targetProduct == null)
                {
                    return NotFound();
                }

                await _catalogService.DeleteAsync(product);

                return NoContent();
            }
            catch { throw; }
        }
    }
}
