using API.Requests;
using APP.Core.Helpers;
using APP.Core.Models;
using APP.Core.Options;
using APP.Core.Services;
using DB;
using DB.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly AuthService _authService;

    public UserController(AppDbContext dbContext, AuthService authService)
    {
        _dbContext = dbContext;
        _authService = authService;
    }
    
    
    [HttpPost("Register")]
    public async Task<ActionResult<bool>> Register(RegisterUserRequest request)
    {
        try
        {
            var service = new UserService(_dbContext);
            return Ok(await service.Register(request.Email, request.Name, request.Password));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("Login")]
    public async Task<ActionResult<bool>> Login(LoginUserRequest request)
    {
        try
        {
            var service = new UserService(_dbContext);
            var user = await service.GetVerifiedUser(request.Email, request.Password);
            
            string jwt = _authService.GenerateJWT(user);
            HttpContext.Response.Cookies.Append("TBSCRT", jwt);

            return Ok(true);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}