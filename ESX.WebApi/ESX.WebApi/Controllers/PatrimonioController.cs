using AutoMapper;
using ESX.Application.Interfaces;
using ESX.Domain.Exceptions;
using ESX.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ESX.WebApi.Controllers
{
    public class PatrimonioController : ApiController
    {
        private readonly IAppServicePatrimonio _appServicePatrimonio;
        public PatrimonioController(IAppServicePatrimonio appServicePatrimonio)
        {
            _appServicePatrimonio = appServicePatrimonio;
        }

        [HttpGet]
        [Route("api/patrimonio")]
        public IHttpActionResult Get()
        {
            try
            {
                var lst = _appServicePatrimonio.ObterTodos();

                var lstMap = Mapper.Map<List<PatrimonioObterModel>>(lst);

                return Ok(lstMap);
            }
            catch (AplicacaoExceptionBase appEx)
            {
                return BadRequest(appEx.MensagemErro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/patrimonio/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var obj = _appServicePatrimonio.Obter(id);

                var objMap = Mapper.Map<PatrimonioObterModel>(obj);

                return Ok(objMap);
            }
            catch (AplicacaoExceptionBase appEx)
            {
                return BadRequest(appEx.MensagemErro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/patrimonio")]
        public IHttpActionResult Post([FromBody] PatrimonioCadastrarModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _appServicePatrimonio.Cadastrar(obj.Nome, obj.Descricao, obj.IdMarca);

                    return Ok("Incluido com sucesso");
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch(AplicacaoExceptionBase appEx)
            {
                return BadRequest(appEx.MensagemErro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("api/patrimonio")]
        public IHttpActionResult Put([FromBody] PatrimonioEditarModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _appServicePatrimonio.Alterar(obj.Id, obj.Nome, obj.Descricao, obj.IdMarca);

                    return Ok("Alterado com sucesso");
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (AplicacaoExceptionBase appEx)
            {
                return BadRequest(appEx.MensagemErro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/patrimonio/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _appServicePatrimonio.Excluir(id);

                return Ok("Excluido com sucesso");
            }
            catch (AplicacaoExceptionBase appEx)
            {
                return BadRequest(appEx.MensagemErro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
