using Microsoft.AspNetCore.Mvc;
using ProjetoPocchiniMakeup.Dominio.Entidade;
using ProjetoPocchiniMakeup.Api.Models.Requisicao;
using ProjetoPocchiniMakeup.Api.Models.Resposta;
using ProjetoPocchiniMakeup.Aplicacao;
using System.Threading.Tasks;

namespace ProjetoPocchiniMakeup.Api
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioAplicacao _usuarioAplicacao;

        public UsuarioController(IUsuarioAplicacao usuarioAplicacao)
        {
            _usuarioAplicacao = usuarioAplicacao;
        }

        [HttpGet]
        [Route("Obter/{usuarioId}")]
        public async Task<ActionResult> Obter([FromRoute] int usuarioId)
        {
            try
            {
                var usuarioDominio = await _usuarioAplicacao.ObterAsync(usuarioId);

                var usuarioResposta = new UsuarioResposta()
                {
                    Id = usuarioDominio.UsuarioId,
                    Nome = usuarioDominio.Nome,
                    Email = usuarioDominio.Email,
                };
                return Ok(usuarioResposta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login([FromBody] UsuarioLogar usuarioLogar)
        {
            try
            {
                var usuarioLogado = await _usuarioAplicacao.Login(usuarioLogar.Email, usuarioLogar.Senha);

                var usuarioResposta = new UsuarioResposta()
                {
                    Id = usuarioLogado.UsuarioId,
                    Nome = usuarioLogado.Nome,
                    Email = usuarioLogado.Email,
                };
                return Ok(usuarioResposta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Criar")]
        public ActionResult Criar([FromBody] UsuarioCriar usuarioCriar)
        {
            try
            {
                var usuarioDominio = new Usuario()
                {
                    Nome = usuarioCriar.Nome,
                    Email = usuarioCriar.Email,
                    Senha = usuarioCriar.Senha
                };

                var usuarioID = _usuarioAplicacao.CriarAsync(usuarioDominio);


                return Ok(usuarioID);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPut]
        [Route("Atualizar")]
        public async Task<ActionResult> AtualizarAsync([FromBody] UsuarioAtualizar usuario)
        {
            try
            {
                var usuarioDominio = new Usuario()
                {
                    UsuarioId = usuario.UsuarioId,
                    Nome = usuario.Nome,
                    Email = usuario.Email
                };

               await _usuarioAplicacao.AtualizarAsync(usuarioDominio);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        [Route("AlterarSenha")]
        public ActionResult AlterarSenha([FromBody] UsuarioAlterarSenha usuario)
        {
            try
            {
                var usuarioDominio = new Usuario()
                {
                    UsuarioId = usuario.ID,
                    Senha = usuario.Senha
                };

                _usuarioAplicacao.AlterarSenhaAsync(usuarioDominio, usuario.SenhaAntiga);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Deletar/{usuarioId}")]
        public ActionResult Deletar([FromRoute] int usuarioId)
        {
            try
            {
                _usuarioAplicacao.DeletarAsync(usuarioId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("Restaurar/{usuarioId}")]
        public ActionResult Restaurar([FromRoute] int usuarioId)
        {
            try
            {
                _usuarioAplicacao.RestaurarAsync(usuarioId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult> Listar([FromQuery] bool ativos)
        {
            try
            {
                var usuariosDominio = await _usuarioAplicacao.ListarAsync(ativos);

                var usuarios = usuariosDominio.Select(usuario => new UsuarioResposta()
                {
                    Id = usuario.UsuarioId,
                    Nome = usuario.Nome,
                    Email = usuario.Email
                }).ToList();

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }

}