using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Models;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private static List<ModelTask> modelTasks =
            new List<ModelTask>();


        [HttpGet]
        public ActionResult<List<ModelTask>> BuscaTask()
        {
            return Ok(modelTasks);
        }

        [HttpPost]
        public ActionResult<List<ModelTask>> AdicionaTask(ModelTask novo)
        {
            if (novo.Description.Length < 10)
                return BadRequest("Necessario minimo 10 caracteres");

            novo.Id = modelTasks.Count > 0 ? modelTasks[modelTasks.Count - 1].Id + 1 : 1;

            modelTasks.Add(novo);

            return Ok(modelTasks);
        }

        [HttpDelete("{Id}")]
        public ActionResult<List<ModelTask>>
                ApagarTask(int Id)
        {
            var apagar = modelTasks.Find(x => x.Id == Id);
            if (apagar is null)
                return NotFound("Id da Task não encontrado");
                modelTasks.Remove(apagar);
            return Ok(apagar);
        }
    }
}
