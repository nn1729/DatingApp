using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController: ControllerBase
{
    private readonly DatingDbContext _dataContext;
    public UsersController(DatingDbContext dataContext)
    {
        _dataContext = dataContext;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetAsync()
    {
        var users = await _dataContext.Users.ToListAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetAsync(int id)
    {
        var user = await _dataContext.Users.FindAsync(id);
        return Ok(user);
    }
}
