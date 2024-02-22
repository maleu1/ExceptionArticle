using System.ComponentModel.DataAnnotations;
using AutoMapper;
using ExceptionArticle.Models;
using ExceptionArticle.Models.Contracts;
using ExceptionArticle.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionArticle.Controllers;

[ApiController]
[Route("[controller]")]
public class YourEntityController : ControllerBase
{
    private readonly IYourEntityService _service;
    private readonly IMapper _mapper;

    public YourEntityController(IYourEntityService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost("YourEntity")]
    public async Task<IActionResult> Create(CreateYourEntityRequest request)
    {
        var yourEntity = _mapper.Map<YourEntity>(request);

        try
        {
            yourEntity = await _service.CreateAsync(yourEntity);
        }
        catch (ValidationException exception) // bad practice. Use Middleware instead!
        {
            Console.WriteLine("Caught Exception.");
        }

        var yourEntityResponse = _mapper.Map<YourEntityResponse>(yourEntity);

        return Ok(yourEntityResponse);
    }
}