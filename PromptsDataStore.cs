using PromptStorage.API.Models;

namespace PromptStorage.API
{
    public class PromptsDataStore
    {
        public List<PromptDto> Prompts { get; set; }

        public static PromptsDataStore Current { get; } = new PromptsDataStore();

        public PromptsDataStore() {
        
            Prompts = new List<PromptDto>
            {
                new PromptDto
                {
                    Prompt = "Test prompt 1",
                    Description = "Test description 1"
                },
                new PromptDto
                {
                    Prompt = "Test prompt 2",
                    Description = "Test description 2"
                }
            };
        }
    }
}
