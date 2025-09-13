using Microsoft.AspNetCore.Mvc;
using TaskManager.Codigo.Dto;
using TaskManager.Codigo.Models;
using TaskManager.Codigo.Services;


namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly TarefaService _tarefaService;

        public TarefaController(TarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpPost]
        public async Task<IActionResult> addTarefa(TarefaCadastroDto tarefa)
        {
            var tarefaNova = new Tarefas
            {
                Titulo = tarefa.titulo,
                Descricao = tarefa.descricao,
                UsuarioId = tarefa.UsuarioId
            };
            Tarefas tarefaCriada = await _tarefaService.addTarefaAsync(tarefaNova);
            return Ok(tarefaCriada);

        }
        [HttpGet]
        public async Task<IActionResult> getTarefas()
        {
            List<Tarefas> tarefas = await _tarefaService.GetTarefasAsync();
            if (tarefas == null)
                return NotFound("Tarefa não existe");

            return Ok(tarefas);
        }

        [HttpGet("por-id/{id}")]
        public async Task<IActionResult> getTarefasId(int id)
        {
            List<Tarefas> tarefas = await _tarefaService.getTarefasIdAsync(id);
            if (tarefas == null)
                return NotFound("Tarefa não existe");

            return Ok(tarefas);
        }

        [HttpGet("por-status/{status}")]
        public async Task<IActionResult> getTarefasStatus(String status)
        {
            List<Tarefas> tarefas = await _tarefaService.getTarefasStatusAsync(status);
            if (tarefas == null)
                return NotFound("Tarefa não existe");

            return Ok(tarefas);
        }
        [HttpGet("por-periodo")]
        public async Task<IActionResult> getTarefasPeriodo([FromQuery] DateTime dataInicial,
    [FromQuery] DateTime dataFinal)
        {
            if (dataFinal < dataInicial)
            {
                return BadRequest("A data final não pode ser anterior à data inicial.");
            }
            List<Tarefas> tarefas = await _tarefaService.getTarefasPeriodoAsync(dataInicial, dataFinal);
            if (tarefas == null)
                return NotFound("Tarefa não existe");

            return Ok(tarefas);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> putTarefa(int id, [FromBody] TarefaCadastroDto tarefaAtualizada)
        {
            var tarefaNova = new Tarefas
            {
                Titulo = tarefaAtualizada.titulo,
                Descricao = tarefaAtualizada.descricao,
                UsuarioId = tarefaAtualizada.UsuarioId
            };

            Tarefas tarefa = await _tarefaService.putTarefaAsync(id, tarefaNova);
            if (tarefa == null)
                return NotFound("Tarefa não existe");

            return StatusCode(200, tarefa);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteTarefa(int id)
        {
            var tarefa = await _tarefaService.deleteTarefaAsync(id);
            if (tarefa == null)
                return NotFound("Tarefa não existe");

            return Ok(tarefa);
        }

    }
}