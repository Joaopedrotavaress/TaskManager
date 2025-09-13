
using Microsoft.AspNetCore.Mvc;
using TaskManager.Codigo.Dto;
using TaskManager.Codigo.Models;
using TaskManager.Codigo.Services;


namespace TaskManager.Codigo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;


        public UsuariosController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;

        }

        [HttpPost]
        public async Task<IActionResult> AddUsuario(UsuarioCadastroDto usuarioDto)
        {
            var novoUsuario = new Usuario
            {
                Nome = usuarioDto.Nome,
                Email = usuarioDto.Email
            };

            Usuario usuarioCriado = await _usuarioService.AddUsuarioAsync(novoUsuario);
            if (usuarioCriado == null)
            {
                return Conflict("Já existe um usuário com o e-mail informado.");
            }
            return Ok(usuarioCriado);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            List<Usuario> usuarios = await _usuarioService.getUsuariosAsync();

             if (usuarios == null)
                return NotFound("Usuario não encontrado");
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuarioId(int id)
        {
            var Usuario = await _usuarioService.getUsuarioIdAsync(id);
            if (Usuario == null)
                return NotFound("Usuario não encontrado");
            return Ok(Usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> UpdateUsuario(int id, [FromBody] UsuarioCadastroDto usuarioAtualizado)
        {
            var novoUsuario = new Usuario
            {
                Nome = usuarioAtualizado.Nome,
                Email = usuarioAtualizado.Email
            };
            var usuario = await _usuarioService.updateUsuarioAsync(id, novoUsuario);
            if (usuario == null)
                return NotFound("Usuario não encotrado");


            return StatusCode(201, usuario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _usuarioService.deleteUsuarioAsync(id);
            if (usuario == null)
                return NotFound("Usuario não encotrado");


            return Ok(usuario);
        }
    }
}