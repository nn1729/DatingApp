using System;
using API.Data;
using API.Entites;

namespace API.Services;

public interface ITokenService
{
    string CreateToken (AppUser appUser);
}
