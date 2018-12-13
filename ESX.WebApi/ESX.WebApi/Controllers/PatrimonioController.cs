using AutoMapper;
using ESX.Application.Interfaces;
using ESX.WebApi.Models;
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
            var lst = _appServicePatrimonio.ObterTodos();

            var lstMap = Mapper.Map<PatrimonioObterModel>(lst);

            return Ok(lstMap);
        }

        [HttpGet]
        [Route("api/patrimonio/{id}")]
        public IHttpActionResult Get(int id)
        {
            var obj = _appServicePatrimonio.Obter(id);

            var objMap = Mapper.Map<PatrimonioObterModel>(obj);

            return Ok(objMap);
        }

        [HttpPost]
        [Route("api/patrimonio")]
        public IHttpActionResult Post([FromBody] PatrimonioCadastrarModel obj)
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

        [HttpPut]
        [Route("api/patrimonio")]
        public IHttpActionResult Put([FromBody] PatrimonioEditarModel obj)
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

        [HttpDelete]
        [Route("api/patrimonio/{id}")]
        public IHttpActionResult Delete(int id)
        {
            _appServicePatrimonio.Remover(id);

            return Ok("Excluido com sucesso");
        }
    }
}
