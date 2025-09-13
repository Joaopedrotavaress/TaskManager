using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TaskManager.Data;
using TaskManager.Dto;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.Controllers
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
            return Ok(usuarioCriado);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            List<Usuario> usuarios = await _usuarioService.getUsuariosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuarioId(int id)
        {
            var Usuario = await _usuarioService.getUsuarioIdAsync(id);
            if (Usuario == null)
                return NotFound("Personagem não encontrado");
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
            var usuario = await _usuarioService.updateUsuarioAsync(id,novoUsuario);
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