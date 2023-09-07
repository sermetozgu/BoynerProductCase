using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BoynerCase.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace BoynerCase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrunController : ControllerBase
    {

        public readonly UrunKategoriDbContext _dbcontext;
        private readonly IMapper _mapper;

        public UrunController(UrunKategoriDbContext _context, IMapper mapper)
        {
            _dbcontext = _context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Urunler")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                List<Urun> listProducts = _dbcontext.Uruns.ToList();
                var urunDTOs = _mapper.Map<List<UrunDTO>>(listProducts);
                if (urunDTOs != null)
                {
                    return Ok(urunDTOs);
                }
                return Ok("There is no product in the db");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("UrunlerSayfa")]
        public async Task<IActionResult> GetProducts(int page = 1, int pageSize = 5)
        {
            try
            {
                var totalProducts = await _dbcontext.Uruns.CountAsync();
                var totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);

                if (page < 1)
                {
                    page = 1;
                }
                else if (page > totalPages)
                {
                    page = totalPages;
                }

                var products = await _dbcontext.Uruns
                    .OrderBy(p => p.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("Urun/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                Urun product = await _dbcontext.Uruns.FindAsync(id);
                if (product != null)
                {
                    return Ok(product);
                }
                return NotFound("There is no product with that id");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("UrunOlustur")]
        public async Task<IActionResult> CreateProduct([FromBody] Urun yeniUrun)
        {
            try
            {
                if (yeniUrun != null)
                {
                    Kategori kategori = await _dbcontext.Kategoris.FindAsync(yeniUrun.KategoriId);

                    if (kategori != null)
                    {
                        _dbcontext.Uruns.Add(yeniUrun);
                        await _dbcontext.SaveChangesAsync();

                        return CreatedAtAction(nameof(GetProductById), new { id = yeniUrun.Id }, yeniUrun);
                    }
                    return BadRequest("Geçersiz kategori ID'si");
                }
                return BadRequest("Geçersiz ürün bilgileri");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UrunGuncelle/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Urun guncelUrun)
        {
            try
            {
                Urun eskiUrun = await _dbcontext.Uruns.FindAsync(id);
                if (eskiUrun == null)
                {
                    return NotFound("There is no product with given id");
                }

                eskiUrun.UrunIsmi = guncelUrun.UrunIsmi;
                eskiUrun.Aciklama = guncelUrun.Aciklama;
                eskiUrun.KategoriId = guncelUrun.KategoriId;

                _dbcontext.Uruns.Update(eskiUrun);
                await _dbcontext.SaveChangesAsync();

                return Ok("Product updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("UrunSil/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                Urun product = await _dbcontext.Uruns.FindAsync(id);
                if (product != null)
                {
                    _dbcontext.Uruns.Remove(product);
                    await _dbcontext.SaveChangesAsync();
                    return Ok("Product deleted successfully");
                }
                return NotFound("There is no product with that id");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("KategoriUrunleri")]
        public async Task<IActionResult> GetProductsByCategory(int categoryId, int page = 1, int pageSize = 5)
        {
            try
            {
                var totalProducts = await _dbcontext.Uruns
                    .Where(u => u.KategoriId == categoryId)
                    .CountAsync();

                var totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);

                if (page < 1)
                {
                    page = 1;
                }
                else if (page > totalPages)
                {
                    page = totalPages;
                }

                var products = await _dbcontext.Uruns
                    .Where(u => u.KategoriId == categoryId)
                    .OrderBy(u => u.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                if (products != null)
                {
                    return Ok(products);
                }
                return NotFound("There is no product for given category");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
