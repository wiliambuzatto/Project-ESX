using AutoMapper;
using ESX.Application.Interfaces;
using ESX.Domain.Exceptions;
using ESX.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ESX.WebApi.Controllers
{
    public class MarcaController : ApiController
    {
        private readonly IAppServiceMarca _appServiceMarca;
        public MarcaController(IAppServiceMarca appServiceMarca)
        {
            _appServiceMarca = appServiceMarca;
        }

        [HttpGet]
        [Route("api/marca")]
        public IHttpActionResult Get()
        {
            try
            {
                var lst = _appServiceMarca.ObterTodos();

                var lstMap = Mapper.Map<List<MarcaObterModel>>(lst);

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
        [Route("api/marca/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var obj = _appServiceMarca.Obter(id);

                var objMap = Mapper.Map<MarcaObterModel>(obj);

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
        [Route("api/marca")]
        public IHttpActionResult Post([FromBody] MarcaCadastrarModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _appServiceMarca.Cadastrar(obj.Nome);

                    return Ok("Incluido com sucesso");
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

        [HttpPut]
        [Route("api/marca")]
        public IHttpActionResult Put([FromBody] MarcaEditarModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _appServiceMarca.Alterar(obj.Id, obj.Nome);

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
        [Route("api/marca/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _appServiceMarca.Excluir(id);

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
