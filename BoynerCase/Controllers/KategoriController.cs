using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BoynerCase.Models;
using Microsoft.EntityFrameworkCore;

namespace BoynerCase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KategoriController : ControllerBase
    {

        public readonly UrunKategoriDbContext _dbcontext;
        public KategoriController(UrunKategoriDbContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Kategoriler")]
        public async Task<IActionResult> GetCategory()
        {
            try
            {
                List<Kategori> listKategori = _dbcontext.Kategoris.ToList();
                if (listKategori != null)
                {
                    return Ok(listKategori);
                }
                return Ok("There is no category in the db");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("KategorilerSayfa")]
        public async Task<IActionResult> GetCategories(int page = 1, int pageSize = 5)
        {
            try
            {
                var totalCategory = await _dbcontext.Kategoris.CountAsync();
                var totalPages = (int)Math.Ceiling((double)totalCategory / pageSize);

                if (page < 1)
                {
                    page = 1;
                }
                else if (page > totalPages)
                {
                    page = totalPages;
                }

                var categories = await _dbcontext.Kategoris
                    .OrderBy(p => p.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("Kategori/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                Kategori kategori = await _dbcontext.Kategoris.FindAsync(id);
                if (kategori != null)
                {
                    return Ok(kategori);
                }
                return NotFound("There is no category with that id");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("KategoriOlustur")]
        public async Task<IActionResult> CreateCategory([FromBody] Kategori yeniKategori)
        {
            try
            {
                if (yeniKategori != null)
                {
                    _dbcontext.Kategoris.Add(yeniKategori);
                    await _dbcontext.SaveChangesAsync();

                    return CreatedAtAction(nameof(GetCategoryById), new { id = yeniKategori.Id }, yeniKategori);
                }
                return BadRequest("Geçersiz kategori bilgileri");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("KategoriGuncelle/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Kategori guncelKategori)
        {
            try
            {
                Kategori eskiKategori = await _dbcontext.Kategoris.FindAsync(id);
                if (eskiKategori == null)
                {
                    return NotFound("There is no category with given id");
                }

                eskiKategori.KategoriIsmi = guncelKategori.KategoriIsmi;

                _dbcontext.Kategoris.Update(eskiKategori);
                await _dbcontext.SaveChangesAsync();

                return Ok("Category updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("KategoriSil/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                Kategori category = await _dbcontext.Kategoris.FindAsync(id);
                if (category != null)
                {
                    _dbcontext.Kategoris.Remove(category);
                    await _dbcontext.SaveChangesAsync();
                    return Ok("Category deleted successfully");
                }
                return NotFound("There is no category with that id");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
