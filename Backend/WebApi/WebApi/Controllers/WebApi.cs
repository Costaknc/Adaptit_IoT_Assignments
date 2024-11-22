using Microsoft.AspNetCore.Mvc;
using IoT_Backend_Assignment;
using Microsoft.Extensions.Caching.Memory;

[ApiController]
[Route("[controller]")]
public class WebApi : ControllerBase
{
    private readonly IMemoryCache _memoryCache;

    public WebApi(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    [HttpGet("{ip}")]
    public IActionResult GetMessage([FromRoute] string ip)
    {
        if (_memoryCache.TryGetValue(ip, out var cachedData))
        {
            return Ok(new { Message = cachedData });
        }

        var provider = new IPInfoProvider();
        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
        };

        try
        {
            var details = provider.GetDetails(ip);
            _memoryCache.Set(ip, details, cacheEntryOptions);
            return Ok(new { Message = details });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                Error = $"Error: {ex.Message}"
            });
        }
    }
}
