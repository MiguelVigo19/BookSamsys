using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookSamsys.Models;
using BookSamsys;


[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _service;

    public BooksController(IBookService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> ListarLivros(int page = 1, int pageSize = 10)
    {
        var livros = await _service.ListarLivrosAsync(page, pageSize);
        return Ok(livros);
       
        
    }






    [HttpGet("{isbn}")]
    public async Task<IActionResult> ObterPorISBN(string isbn)
    {
        var livro = await _service.ObterPorISBNAsync(isbn);
        if (livro == null) return NotFound("Livro não encontrado.");
        return Ok(livro);
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarLivro(Book livro)
    {
        try
        {
            await _service.AdicionarLivroAsync(livro);
            return CreatedAtAction(nameof(ObterPorISBN), new { isbn = livro.ISBN }, livro);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{isbn}")]
    public async Task<IActionResult> AtualizarLivro(string isbn, Book livro)
    {
        if (isbn != livro.ISBN)
            return BadRequest("ISBN não pode ser alterado.");

        try
        {
            await _service.AtualizarLivroAsync(livro);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{isbn}")]
    public async Task<IActionResult> ExcluirLivro(string isbn)
    {
        await _service.ExcluirLivroAsync(isbn);
        return NoContent();
    }

}


   

   