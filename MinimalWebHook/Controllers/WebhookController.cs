using Microsoft.AspNetCore.Mvc;
using MinimalWebhook.Application.DTOs;
using MinimalWebhook.Application.Interfaces;

namespace MinimalWebHook.Controllers;

[ApiController]
[Route("[controller]")]
public class WebhookController(IWebhookService webhookService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> ProcessWebhook()
    {
        using StreamReader reader = new(Request.Body);
        string body = await reader.ReadToEndAsync();

        WebhookResponseDto response = await webhookService.ProcessWebhookAsync(body);

        if (response.IsSuccess)
            return Ok(response);
        else
            return StatusCode(StatusCodes.Status500InternalServerError, response);
    }
}
