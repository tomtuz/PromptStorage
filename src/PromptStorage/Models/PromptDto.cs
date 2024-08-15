namespace PromptStorage.Models
{
    public class PromptDto
    {
        public Guid Id { get; set; }
        public string Prompt { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
