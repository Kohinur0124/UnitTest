using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using StackExchange.Redis;
using TestAllThemes.Application.Abstractions;
using TestAllThemes.Application.UseCases.User.Commands;
using TestAllThemes.Application.UseCases.User.Queries;
namespace TestAllThemess.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    private readonly StackExchange.Redis.IDatabase _distributedCache;

    public IApplicationDbContext _context { get; set; }


    public UsersController(IMediator mediator, IApplicationDbContext context)
    {
        var redis = ConnectionMultiplexer.Connect("redis,6379");
        _distributedCache = redis.GetDatabase();

        _mediator = mediator;
        _context = context;
    }

    [HttpGet]

    public async ValueTask<IActionResult> GetAllUsers()
    {
        var users = await _mediator.Send(new GetUserCommand());

        await _distributedCache.StringSetAsync(
                            "GetAllUsers",
                            JsonConvert.SerializeObject( await _context.Users.ToListAsync())
                          ) ;
        return Ok(users);
    }

    [HttpPost]

    public async ValueTask<IActionResult> CreateUser(PostUserCommand postUser)
    {
        var t = await _mediator.Send(postUser);
        await _distributedCache.StringSetAsync(
                           "GetAllUsers",
                           JsonConvert.SerializeObject(await _context.Users.ToListAsync())
                         );
        return Ok(t);
    }

    [HttpPut]

    public async ValueTask<IActionResult> UpdateUser(PutUserCommand postUser)
    {
        var t = await _mediator.Send(postUser);
        await _distributedCache.StringSetAsync(
                           "GetAllUsers",
                           JsonConvert.SerializeObject(await _context.Users.ToListAsync())
                         );
        return Ok(t);
    }

    [HttpDelete]

    public async ValueTask<IActionResult> DeleteUser(DeleteUserCommand postUser)
    {
        var t = await _mediator.Send(postUser);
        await _distributedCache.StringSetAsync(
                           "GetAllUsers",
                           JsonConvert.SerializeObject(await _context.Users.ToListAsync())
                         );
        return Ok(t);
    }


}
