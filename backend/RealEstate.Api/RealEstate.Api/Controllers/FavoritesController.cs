using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Interfaces;

namespace RealEstate.Api.Controllers;

[ApiController]
[Route("favorites/")]
[Authorize]
public class FavoritesController : ControllerBase
{
    private readonly IFavoriteService _svc;

    public FavoritesController(IFavoriteService svc) => _svc = svc;

    private int GetUserId() =>
        int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)
                  ?? User.FindFirstValue(ClaimTypes.Name)
                  ?? User.FindFirstValue("sub")!);

    [HttpPost("{propertyId:int}")]
    public async Task<IActionResult> Toggle(int propertyId)
    {
        var added = await _svc.ToggleAsync(GetUserId(), propertyId);
        return Ok(new { added });
    }

    [HttpGet]
    public async Task<IActionResult> GetMine()
        => Ok(await _svc.GetMineAsync(GetUserId()));
}
