﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookSamsys.Data;
using BookSamsys.Models;
using BookSamsys.DTO;



[ApiController]
[Route("api/[controller]")]
public class AutorsController : ControllerBase
{

    private readonly IAuthorService _service1;

    public AutorsController(IAuthorService service1)
    {
        _service1 = service1;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var autores = await _service1.GetAllAsync();
        return Ok(autores);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var autor = await _service1.GetByIdAsync(id);
        if (autor == null) return NotFound();
        return Ok(autor);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddAutordto autor)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await _service1.AddAsync(autor);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update( [FromBody] AtualizarAutorDTO autor)
    {


        // if (id != autor.id || !ModelState.IsValid) return BadRequest();
        //var existingAuthor = await _service1.GetByIdAsync(id);
        //if (existingAuthor == null) return NotFound();

        if (!ModelState.IsValid) return BadRequest(ModelState);

        await _service1.UpdateAsync(autor);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service1.DeleteAsync(id);
        return NoContent();
    }
}
