using Microsoft.AspNetCore.Mvc;
using ProjetoPocchiniMakeup.Dominio.Entidade;
using ProjetoPocchiniMakeup.Api.Models.Requisicao;
using ProjetoPocchiniMakeup.Api.Models.Resposta;
using ProjetoPocchiniMakeup.Aplicacao;

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
        public ActionResult Obter([FromRoute] int usuarioId)
        {
            try
            {
                var usuarioDominio = _usuarioAplicacao.Obter(usuarioId);

                var UsuarioResposta = new UsuarioResposta()
                {
                    Id = usuarioDominio.ID,
                    Nome = usuarioDominio.Nome,
                    Email = usuarioDominio.Email,
                };
                return Ok(UsuarioResposta);
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

                var usuarioID = _usuarioAplicacao.Criar(usuarioDominio);


                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPut]
        [Route("Atualizar")]
        public ActionResult Atualizar([FromBody] UsuarioAtualizar usuario)
        {
            try
            {
                var usuarioDominio = new Usuario()
                {
                    ID = usuario.ID,
                    Nome = usuario.Nome,
                    Email = usuario.Email
                };

                _usuarioAplicacao.Atualizar(usuarioDominio);

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
                    ID = usuario.ID,
                    Senha = usuario.Senha
                };

                _usuarioAplicacao.AlterarSenha(usuarioDominio, usuario.SenhaAntiga);

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
                _usuarioAplicacao.Deletar(usuarioId);

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
                _usuarioAplicacao.Restaurar(usuarioId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Listar")]
        public ActionResult Listar([FromQuery] bool ativos)
        {
            try
            {
                var usuariosDominio = _usuarioAplicacao.Listar(ativos);

                var usuarios = usuariosDominio.Select(usuario => new UsuarioResposta()
                {
                    Id = usuario.ID,
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