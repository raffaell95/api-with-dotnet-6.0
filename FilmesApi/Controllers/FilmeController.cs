using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using FilmesApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
   
   private FilmeService _filmeService;

    public FilmeController(FilmeService filmeService)
    {
        _filmeService = filmeService;
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
        var readDto = _filmeService.AdicionaFilme(filmeDto);
        return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = readDto.Id }, readDto);
    }

    [HttpGet]
    [Authorize(Roles = "admin, regular", Policy = "IdadeMinima")]
    public IActionResult RecuperaFilmes([FromQuery] int? classificacaoEtaria = null)
    {
        var readDto = _filmeService.RecuperarFilmes(classificacaoEtaria);
        if(readDto != null) return Ok(readDto);
        return NotFound();
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmesPorId(int id)
    {
        var readDto = _filmeService.RecuperaFilmesPorId(id);
        if(readDto != null) return Ok(readDto);
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        var resultado = _filmeService.AtualizaFilme(id, filmeDto);
        if(resultado.IsFailed) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id)
    {
        var resultado = _filmeService.DeletaFilme(id);
        if(resultado.IsFailed) return NotFound();
        return NoContent();
    }

}