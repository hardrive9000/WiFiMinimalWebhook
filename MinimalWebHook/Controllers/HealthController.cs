using Microsoft.AspNetCore.Mvc;
using MinimalWebhook.Application.DTOs;

namespace MinimalWebHook.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthController() : ControllerBase
{
    [HttpGet]
    public IActionResult CheckHealth()
    {
        return Ok(new WebhookResponseDto(
            IsSuccess: true,
            Message: "healthy",
            Timestamp: DateTime.Now,
            BodyLength: 0
        ));
    }
}
