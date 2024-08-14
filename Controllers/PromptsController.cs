using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace PromptStorage.API.Controllers
{
    [ApiController]
    [Route("api/prompts")]
    public class PromptsController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetPrompts()
        {
            return new JsonResult(PromptsDataStore.Current.Prompts);
        }


        [HttpGet("{id}")]
        public JsonResult GetPrompt(int id)
        {
            return new JsonResult(
                PromptsDataStore.Current.Prompts.FirstOrDefault(x => x.Id.ToString() == id.ToString())
            );
        }
    }
}
