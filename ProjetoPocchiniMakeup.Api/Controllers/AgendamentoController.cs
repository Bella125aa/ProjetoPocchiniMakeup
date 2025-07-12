using Microsoft.AspNetCore.Mvc;
using ProjetoPocchiniMakeup.Dominio.Entidade;
using ProjetoPocchiniMakeup.Api.Models.Requisicao;
using ProjetoPocchiniMakeup.Api.Models.Resposta;
using ProjetoPocchiniMakeup.Aplicacao;
using System.Threading.Tasks;
using Domain.Entidade;
using ProjetoPocchiniMakeup.Dominio.Enumeradores;


namespace ProjetoPocchiniMakeup.Api
{
    [ApiController]
    [Route("[controller]")]
    public class AgendamentoController : ControllerBase
    {

        private readonly IAgendamentoAplicacao _agendamentoAplicacao;

        public AgendamentoController(IAgendamentoAplicacao agendamentoAplicacao)
        {
            _agendamentoAplicacao = agendamentoAplicacao;
        }


        [HttpGet]
        [Route("Obter/{agendamentoId}")]
        public async Task<ActionResult> ObterAsync([FromRoute] int agendamentoId)
        {
            try
            {
                var agendamentoDominio = await _agendamentoAplicacao.ObterAsync(agendamentoId);

                var agendamentoResposta = new AgendamentoResposta()
                {
                    Id = agendamentoDominio.Id,
                    DataHora = agendamentoDominio.DataHora,
                    Nome = agendamentoDominio.Nome,
                    Status = agendamentoDominio.Status.ToString(),
                    Observacao = agendamentoDominio.Observacoes
                };
                return Ok(agendamentoResposta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Criar")]
        public async Task<ActionResult> CriarAsync([FromBody] AgendamentoCriar agendamentoCriar)
        {
            try
            {
                var agendamentoDominio = new Agendamento()
                {
                    DataHora = agendamentoCriar.DataHora,
                    Nome = agendamentoCriar.Nome,
                    Email = agendamentoCriar.Email,
                    Observacoes = agendamentoCriar.Observacao,
                    Telefone = agendamentoCriar.Telefone,
                    TipoMaquiagem = agendamentoCriar.TipoMaquiagem,
                    Local = agendamentoCriar.Local,

                };

                var agendamentoId = await _agendamentoAplicacao.CriarAsync(agendamentoDominio);


                return Ok(agendamentoId);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("ListarPorStatus")]
        public async Task<ActionResult> ListarAsync([FromQuery] StatusAgendamento status)
        {
            try
            {
                var agendamentosDominio = await _agendamentoAplicacao.ListarAsync(status);

                var agendamentos = agendamentosDominio.Select(agendamento => new AgendamentoResposta()
                {
                    Id = agendamento.Id,
                    DataHora = agendamento.DataHora,
                    TipoMaquiagem = agendamento.TipoMaquiagem,
                    Nome = agendamento.Nome,
                    Status = agendamento.Status.ToString(),
                    Local = agendamento.Local,
                    Telefone = agendamento.Telefone,
                    Email = agendamento.Email,
                    Observacao = agendamento.Observacoes
                });

                return Ok(agendamentos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ListarTodos")]
        public async Task<ActionResult> ListarTodosAsync()
        {
            try
            {
                var agendamentosDominio = await _agendamentoAplicacao.ListarAsync();

                var agendamentos = agendamentosDominio.Select(agendamento => new AgendamentoResposta()
                {
                    Id = agendamento.Id,
                    DataHora = agendamento.DataHora,
                    TipoMaquiagem = agendamento.TipoMaquiagem,
                    Nome = agendamento.Nome,
                    Status = agendamento.Status.ToString(),
                    Local = agendamento.Local,
                    Telefone = agendamento.Telefone,
                    Email = agendamento.Email,
                    Observacao = agendamento.Observacoes
                });

                return Ok(agendamentos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<ActionResult> AtualizarAsync([FromBody] AgendamentoAtualizar agendamento)
        {
            try
            {
                var agendamentoDominio = new Agendamento()
                {
                    Id = agendamento.agendamentoId,
                    Status = agendamento.Status
                };

                await _agendamentoAplicacao.AtualizarAsync(agendamentoDominio);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
