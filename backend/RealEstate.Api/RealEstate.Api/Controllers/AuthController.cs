using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.DTOs.Auth;
using RealEstate.Application.Interfaces;
using FluentValidation;

namespace RealEstate.Api.Controllers;

[ApiController]
[Route("auth/")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _auth;
    private readonly IValidator<RegisterRequest> _registerValidator;
    private readonly IValidator<LoginRequest> _loginValidator;

    public AuthController(
        IAuthService auth,
        IValidator<RegisterRequest> registerValidator,
        IValidator<LoginRequest> loginValidator)
    {
        _auth = auth;
        _registerValidator = registerValidator;
        _loginValidator = loginValidator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var vr = await _registerValidator.ValidateAsync(request);
        if (!vr.IsValid) return BadRequest(vr.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));

        try
        {
            var res = await _auth.RegisterAsync(request);
            return Ok(res);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var vr = await _loginValidator.ValidateAsync(request);
        if (!vr.IsValid) return BadRequest(vr.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));

        try
        {
            var res = await _auth.LoginAsync(request);
            return Ok(res);
        }
        catch (InvalidOperationException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }
}
