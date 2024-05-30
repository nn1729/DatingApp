using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UsersController: BaseApiController
{
    private readonly DatingDbContext _dataContext;
    public UsersController(DatingDbContext dataContext)
    {
        _dataContext = dataContext;
    }


    [AllowAnonymous]
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
