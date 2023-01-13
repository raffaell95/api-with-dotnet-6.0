using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using FluentResults;

namespace FilmesApi.Services;

public class GerenteService
{
    private AppDbContext _context;
    private IMapper _mapper;

    public GerenteService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ReadGerenteDto AdicionaGerente(CreateGerenteDto dto)
    {
        var gerente = _mapper.Map<Gerente>(dto);
        _context.Gerentes?.Add(gerente);
        _context.SaveChanges();
        return _mapper.Map<ReadGerenteDto>(gerente);
    }

    public ReadGerenteDto RecuperaGerentesPorId(int id)
    {
        var gerente = _context.Gerentes?.FirstOrDefault(gerente => gerente.Id == id);
        if (gerente != null)
        {
            ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);

            return gerenteDto;
        }
        return null!;
    }

    internal Result DeleteGerente(int id)
    {
        var gerente = _context.Gerentes?.FirstOrDefault(gerente => gerente.Id == id);
        if (gerente == null)
        {
            return Result.Fail("Gerente não encontrado");
        }
        _context.Remove(gerente);
        _context.SaveChanges();
        return Result.Ok();
    }
}
