using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class OrnekController : ControllerBase
{
    private readonly OrnekService _service;

    public OrnekController(OrnekService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var ornekler = await _service.GetAllAsync();
        return Ok(ornekler);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var ornek = await _service.GetByIdAsync(id);
        if (ornek == null) return NotFound();
        return Ok(ornek);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Ornek ornek)
    {
        if (string.IsNullOrEmpty(ornek.Id))
        {
            await _service.CreateAsync(ornek);
            return CreatedAtAction(nameof(GetById), new { id = ornek.Id }, ornek);
        }

        return BadRequest("Id should not be provided when creating a new record.");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] Ornek ornek)
    {
        if (ornek.Id != id)
        {
            return BadRequest("Id in the URL and in the body must match.");
        }

        var success = await _service.UpdateAsync(id, ornek);
        if (!success) return NotFound();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var success = await _service.DeleteAsync(id);
        if (!success) return NotFound();
        return NoContent();
    }
}
