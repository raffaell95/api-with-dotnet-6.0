using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Services;

public class SessaoService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public SessaoService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ReadSessaoDto AdicionaSessao(CreateSessaoDto dto)
    {
        var sessao = _mapper.Map<Sessao>(dto);
        _context.Sessoes?.Add(sessao);
        _context.SaveChanges();
        return _mapper.Map<ReadSessaoDto>(sessao);
    }

    public ReadSessaoDto RecuperaSessoesPorId(int id)
    {
        var sessao = _context.Sessoes?.FirstOrDefault(sessao => sessao.Id == id);
        if (sessao != null)
        {
            var sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
            return sessaoDto;
        }
        return null!;
    }
}