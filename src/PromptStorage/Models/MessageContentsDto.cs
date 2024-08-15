namespace PromptStorage.Models;

public class MessageContentsDto
{
    public string Id { get; set; } = string.Empty;

    public string? Type { get; set; }

    public string? Role { get; set; }

    public string? Model { get; set; }

    public List<ContentItem> Content { get; set; } = new();

    public TokenInfo? Tokens { get; set; }
}

public class ContentItem
{
    public string? Type { get; set; }

    public string Text { get; set; } = string.Empty;
}

public class TokenInfo
{
    public int Input { get; set; }

    public int Output { get; set; }
}
