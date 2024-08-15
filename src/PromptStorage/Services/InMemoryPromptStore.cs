using System.Collections.Concurrent;
using PromptStorage.Models;

namespace PromptStorage.Services;

/// <summary>
/// Provides an in-memory storage for message contents.
/// </summary>
public class InMemoryPromptStore : IPromptStore
{
    private readonly ConcurrentDictionary<string, MessageContentsDto> _prompts = new();

    public Task<MessageContentsDto> AddAsync(MessageContentsDto message)
    {
        if (string.IsNullOrWhiteSpace(message.Id))
        {
            message.Id = Guid.NewGuid().ToString();
        }

        _prompts[message.Id] = message;
        return Task.FromResult(message);
    }

    public Task<MessageContentsDto?> GetAsync(string id)
    {
        _prompts.TryGetValue(id, out var message);
        return Task.FromResult(message);
    }

    public Task<MessageContentsDto?> UpdateAsync(MessageContentsDto message)
    {
        if (_prompts.TryGetValue(message.Id, out var existingMessage))
        {
            _prompts[message.Id] = message;
            return Task.FromResult<MessageContentsDto?>(message);
        }

        return Task.FromResult<MessageContentsDto?>(null);
    }

    public Task<bool> DeleteAsync(string id)
    {
        return Task.FromResult(_prompts.TryRemove(id, out _));
    }

    public Task<IEnumerable<MessageContentsDto>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<MessageContentsDto>>(_prompts.Values);
    }
}

/// <summary>
/// Defines the interface for a prompt store.
/// </summary>
public interface IPromptStore
{
    Task<MessageContentsDto> AddAsync(MessageContentsDto message);
    Task<MessageContentsDto?> GetAsync(string id);
    Task<MessageContentsDto?> UpdateAsync(MessageContentsDto message);
    Task<bool> DeleteAsync(string id);
    Task<IEnumerable<MessageContentsDto>> GetAllAsync();
}
