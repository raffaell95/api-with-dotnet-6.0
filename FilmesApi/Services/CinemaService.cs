using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using FluentResults;

namespace FilmesApi.Services;

public class CinemaService
{
    private AppDbContext _context;
    private IMapper _mapper;
    public CinemaService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ReadCinemaDto AdicionaCinema(CreateCinemaDto cinemaDto)
    {
        var cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.Cinemas?.Add(cinema);
        _context.SaveChanges();
        return _mapper.Map<ReadCinemaDto>(cinema);
    }

    public List<ReadCinemaDto> RecuperaCinemas(string nomeDoFilme)
    {
        var cinemas = _context.Cinemas?.ToList();
        if(cinemas == null)
        {
            return null!;
        }
        if(string.IsNullOrEmpty(nomeDoFilme))
        {
            var query = from cinema in cinemas where cinema.Sessoes!.Any(sessao => 
                sessao.Filme?.Titulo == nomeDoFilme) select cinema;
            cinemas = query.ToList();
        }
        return _mapper.Map<List<ReadCinemaDto>>(cinemas);
    }

    public ReadCinemaDto RecuperaCinemasPorId(int id)
    {
        var cinema = _context.Cinemas?.FirstOrDefault(cinema => cinema.Id == id);
        if(cinema != null)
        {
            ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
            return cinemaDto;
        }
        return null!;
    }

    public Result AtualizaCinema(int id, UpdateCinemaDto cinemaDto)
    {
        var cinema = _context.Cinemas?.FirstOrDefault(cinema => cinema.Id == id);
        if(cinema == null)
        {
            return Result.Fail("Cinema não encontrado");
        }
        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();
        return Result.Ok();
    }

    public Result DeleteCinema(int id)
    {
        var cinema = _context.Cinemas?.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null)
        {
            return Result.Fail("Cinema não encontrado");
        }
        _context.Remove(cinema);
        _context.SaveChanges();
        return Result.Ok();
    }
}