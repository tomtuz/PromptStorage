using Microsoft.AspNetCore.Mvc;
using PromptStorage.Models;
using PromptStorage.Services;

namespace PromptStorage.Controllers;

/// <summary>
/// Controller for managing prompts.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class PromptsController : ControllerBase
{
    private readonly IPromptStore _promptStore;
    private readonly ILogger<PromptsController> _logger;

    public PromptsController(IPromptStore promptStore, ILogger<PromptsController> logger)
    {
        _promptStore = promptStore;
        _logger = logger;
    }

    /// <summary>
    /// Get all prompts.
    /// </summary>
    /// <returns>A collection of all prompts.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<MessageContentsDto>>> GetAll()
    {
        var prompts = await _promptStore.GetAllAsync();
        return Ok(prompts);
    }

    /// <summary>
    /// Get a specific prompt by ID.
    /// </summary>
    /// <param name="id">The ID of the prompt to retrieve.</param>
    /// <returns>The prompt with the specified ID.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MessageContentsDto>> Get(string id)
    {
        var prompt = await _promptStore.GetAsync(id);
        if (prompt == null)
        {
            return NotFound();
        }
        return Ok(prompt);
    }

    /// <summary>
    /// Create a new prompt.
    /// </summary>
    /// <param name="prompt">The prompt to create.</param>
    /// <returns>The created prompt.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MessageContentsDto>> Create(MessageContentsDto prompt)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdPrompt = await _promptStore.AddAsync(prompt);
        return CreatedAtAction(nameof(Get), new { id = createdPrompt.Id }, createdPrompt);
    }

    /// <summary>
    /// Update an existing prompt.
    /// </summary>
    /// <param name="id">The ID of the prompt to update.</param>
    /// <param name="prompt">The updated prompt data.</param>
    /// <returns>No content if successful.</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(string id, MessageContentsDto prompt)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (id != prompt.Id)
        {
            return BadRequest();
        }

        var updatedPrompt = await _promptStore.UpdateAsync(prompt);
        if (updatedPrompt == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Delete a prompt.
    /// </summary>
    /// <param name="id">The ID of the prompt to delete.</param>
    /// <returns>No content if successful.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _promptStore.DeleteAsync(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}
