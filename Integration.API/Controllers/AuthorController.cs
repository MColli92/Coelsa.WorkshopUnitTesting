using System.Collections.Generic;
using System.Threading.Tasks;
using Integration.API.Interfaces;
using Integration.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Integration.API.Controllers
{
    [ApiController, Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var author = await _authorService.GetByIdAsync(id);
            if (author == null) return NotFound();

            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Author author)
        {
            await _authorService.AddAsync(author);
            return CreatedAtAction(nameof(Get), new {id = author.Id}, author);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var author = await _authorService.GetByIdAsync(id);
            if (author == null) return NotFound();

            await _authorService.RemoveAsync(author);

            return Ok();
        }
    }
}