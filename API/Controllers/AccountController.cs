using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Controllers;
using API.Data;
using API.DTOs;
using API.Entites;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;

public class AccountController: BaseApiController
{
    private readonly DatingDbContext _dataContext;
    private readonly ITokenService _tokenService;
    public AccountController(DatingDbContext dataContext, ITokenService tokenService) {

        _dataContext = dataContext;
        _tokenService = tokenService;
    }

    [HttpPost("register")] //POST: api/users/register
    public async Task<ActionResult<AppUser>> Register([FromBody] RegisterDto registerDto) {
        
        var isUserExists = await IsUserExists(registerDto.UserName);
        if(isUserExists) {
            return BadRequest("User name already taken!");
        }
        using var hmac = new HMACSHA512();

        var user = new AppUser {
            Name = registerDto.UserName.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt =  hmac.Key
        };
        _dataContext.Add(user);
        await _dataContext.SaveChangesAsync();

        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> LoginUser(LoginDto loginDto) {

        var user = await _dataContext.Users.SingleOrDefaultAsync(x => x.Name.ToLower() == loginDto.UserName.ToLower());
        if(user == null) {
            return Unauthorized("User not exist!");
        }

        using var hmac = new HMACSHA512(user.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        for(int i = 0; i < computedHash.Length; ++i) {
            if(computedHash[i] != user.PasswordHash[i]) {
                return Unauthorized("UserName/Password not exist!!!");
            }
        }

        return Ok(new UserDto {
            UserName = user.Name,
            Token = _tokenService.CreateToken(user)
        });
    } 

    private Task<bool> IsUserExists(string userName) {
        return _dataContext.Users.AnyAsync(x => x.Name.ToLower() == userName.ToLower());
    }
}
