using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork.Architecture.Application.DTOs;
using UnitOfWork.Architecture.Domain.Entities;
using UnitOfWork.Architecture.Infrastructure.Persistence;

namespace UnitOfWork.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public PersonController(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<PersonDto>>> GetAll()
    {
        var persons = await _uow
            .BaseRepository()
            .GetListAsync<Person>();

        return Ok(_mapper.Map<List<PersonDto>>(persons));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PersonDto>> Get(int id)
    {
        var person = await _uow
            .BaseRepository()
            .GetSingleOrDefaultAsync<Person>(p => p.Id == id, $"{nameof(Person.Addresses)}");

        return Ok(_mapper.Map<PersonDto>(person));
    }

    [HttpPost]
    public async Task<ActionResult<Person>> Create(Person person)
    {
        var entity = _uow.BaseRepository().Add<Person>(person);
        await _uow.CommitAsync(default);

        return Ok(entity);
    }

    [HttpPut]
    public async Task<IActionResult> Update(Person person)
    {
        _uow.BaseRepository().Update<Person>(person);
        await _uow.CommitAsync(default);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var person = await _uow.BaseRepository().GetByIdAsync<Person>(id);

        if (person != null)
            _uow.BaseRepository().Delete<Person>(person);

        await _uow.CommitAsync(default);

        return Ok();
    }
}
