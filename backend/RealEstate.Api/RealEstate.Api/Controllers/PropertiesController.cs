using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.DTOs.Property;
using RealEstate.Application.Interfaces;

namespace RealEstate.Api.Controllers;

[ApiController]
[Route("properties/")]
public class PropertiesController : ControllerBase
{
    private readonly IPropertyService _svc;

    public PropertiesController(IPropertyService svc) => _svc = svc;

    [HttpGet]
    public async Task<IActionResult> Search([FromQuery] PropertySearchRequest rq)
        => Ok(await _svc.SearchAsync(rq));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var dto = await _svc.GetByIdAsync(id);
        return dto == null ? NotFound() : Ok(dto);
    }
}
