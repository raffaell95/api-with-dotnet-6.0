using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using FluentResults;

namespace FilmesApi.Services;
public class EnderecoService
{
    private AppDbContext _context;
    private IMapper _mapper;

    public EnderecoService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ReadEnderecoDto AdicionaEndereco(CreateEnderecoDto enderecoDto)
    {
        var endereco = _mapper.Map<Endereco>(enderecoDto);
        _context.Enderecos?.Add(endereco);
        _context.SaveChanges();
        return _mapper.Map<ReadEnderecoDto>(endereco);
    }

    public List<ReadEnderecoDto> RecuperaEnderecos()
    {
        var enderecos = _context.Enderecos?.ToList();
        if (enderecos == null)
        {
            return null!;
        }
        return _mapper.Map<List<ReadEnderecoDto>>(enderecos);
    }

    public ReadEnderecoDto RecuperaEnderecosPorId(int id)
    {
        var endereco = _context.Enderecos?.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco != null)
        {
            var enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
            return enderecoDto;
        }
        return null!;
    }

    public Result AtualizaEndereco(int id, UpdateEnderecoDto enderecoDto)
    {
        var endereco = _context.Enderecos?.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null)
        {
            return Result.Fail("Endereço não encontrado");
        }
        _mapper.Map(enderecoDto, endereco);
        _context.SaveChanges();
        return Result.Ok();
    }

    public Result DeletaEndereco(int id)
    {
        var endereco = _context.Enderecos?.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null)
        {
            return Result.Fail("Endereco não encontrado");
        }
        _context.Remove(endereco);
        _context.SaveChanges();
        return Result.Ok();
    }
}