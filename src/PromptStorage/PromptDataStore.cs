using PromptStorage.Models;

namespace PromptStorage
{
    public class PromptDataStore
    {
        public List<PromptDto> Prompts { get; set; }

        public static PromptDataStore Current { get; } = new PromptDataStore();

        public PromptDataStore() {

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
