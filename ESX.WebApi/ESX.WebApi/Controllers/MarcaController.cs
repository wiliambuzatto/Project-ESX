using AutoMapper;
using ESX.Application.Interfaces;
using ESX.WebApi.Models;
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
            var lst = _appServiceMarca.ObterTodos();

            var lstMap = Mapper.Map<MarcaObterModel>(lst);

            return Ok(lstMap);
        }

        [HttpGet]
        [Route("api/marca/{id}")]
        public IHttpActionResult Get(int id)
        {
            var obj = _appServiceMarca.Obter(id);

            var objMap = Mapper.Map<MarcaObterModel>(obj);

            return Ok(objMap);
        }

        [HttpPost]
        [Route("api/marca")]
        public IHttpActionResult Post([FromBody] MarcaCadastrarModel obj)
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

        [HttpPut]
        [Route("api/marca")]
        public IHttpActionResult Put([FromBody] MarcaEditarModel obj)
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

        [HttpDelete]
        [Route("api/marca/{id}")]
        public IHttpActionResult Delete(int id)
        {
            _appServiceMarca.Remover(id);

            return Ok("Excluido com sucesso");
        }
    }
}
