﻿using System;
using ESX.Application.Interfaces;
using ESX.Domain.Entities;
using ESX.Domain.Exceptions;
using ESX.Domain.Interfaces.Repository;
using ESX.Domain.Interfaces.UnitWork;

namespace ESX.Application.AppService
{
    public class AppServicePatrimonio : AppServiceBase<Patrimonio>, IAppServicePatrimonio
    {
        private readonly IAppServiceMarca _appServiceMarca;
        public AppServicePatrimonio(IUnitOfWork unitOfWork, IRepositoryBase<Patrimonio> repositoryBase,
            IAppServiceMarca appServiceMarca)
               : base(unitOfWork, repositoryBase)
        {
            _appServiceMarca = appServiceMarca;
        }

        public override Patrimonio Obter(int id)
        {
            var obj = base.Obter(id);

            if (obj == null)
                throw new PatrimonioNaoEncontradoException();

            return obj;
        }

        public void Alterar(int id, string Nome, string Descricao, int IdMarca)
        {
            var obj = this.Obter(id);
            var objMarca = _appServiceMarca.Obter(IdMarca);

            if (obj == null)
                throw new PatrimonioNaoEncontradoException();

            if (objMarca == null)
                throw new MarcaNaoEncontradaException();

            if (ValidarPatrimonioExistente(Nome, IdMarca, id))
                throw new PatrimonioJaCadastradoException();

            obj.Nome = Nome;
            obj.Descricao = Descricao;
            obj.Marca = objMarca;

            this.Alterar(obj);
        }

        public void Cadastrar(string Nome, string Descricao, int IdMarca)
        {
            var obj = new Patrimonio();
            var objMarca = _appServiceMarca.Obter(IdMarca);

            if (objMarca == null)
                throw new MarcaNaoEncontradaException();

            if (ValidarPatrimonioExistente(Nome, IdMarca))
                throw new PatrimonioJaCadastradoException();

            obj.Nome = Nome;
            obj.Descricao = Descricao;
            obj.Marca = objMarca;
            obj.CriarNumeroTombo();

            this.Adicionar(obj);
        }

        public void Excluir(int id)
        {
            var obj = this.Obter(id);

            if (obj == null)
                throw new PatrimonioNaoEncontradoException();

            this.Remover(obj);
        }

        private bool ValidarPatrimonioExistente(string Nome, int IdMarca, int? Id = null)
        {
            return this.Any(x => x.Nome == Nome && x.Marca.Id == IdMarca && (!Id.HasValue || x.Id != Id));
        }
    }
}
