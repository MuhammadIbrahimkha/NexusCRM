using Microsoft.AspNetCore.Mvc;
using NexusCRM.Domain.Exceptions;

namespace NexusCRM.Api.Controllers;

/// <summary>
/// Temporary Day 1 helper that throws on purpose, to prove the global exception handler works.
/// It only answers in the Development environment. Delete this file once Day 1 is verified.
/// </summary>
[ApiController]
[Route("api/v1/debug")]
public class DebugController(IWebHostEnvironment env) : ControllerBase
{
    [HttpGet("boom")]
    public IActionResult Boom()
    {
        if (!env.IsDevelopment()) return NotFound();
        throw new InvalidOperationException("secret internal detail");
    }

    [HttpGet("not-found")]
    public IActionResult MissingRecord()
    {
        if (!env.IsDevelopment()) return NotFound();
        throw new NotFoundException("Deal 123 was not found.");
    }

    [HttpGet("conflict")]
    public IActionResult Conflicting()
    {
        if (!env.IsDevelopment()) return NotFound();
        throw new ConflictException("Deal was changed by someone else.");
    }

    [HttpGet("rule")]
    public IActionResult BrokenRule()
    {
        if (!env.IsDevelopment()) return NotFound();
        throw new BusinessRuleException("A deal cannot move from Lead to Won.");
    }
}
