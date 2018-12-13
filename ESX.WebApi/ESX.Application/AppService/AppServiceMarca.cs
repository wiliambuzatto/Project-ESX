﻿using ESX.Application.Interfaces;
using ESX.Domain.Entities;
using ESX.Domain.Exceptions;
using ESX.Domain.Interfaces.Repository;
using ESX.Domain.Interfaces.UnitWork;
using System.Linq;

namespace ESX.Application.AppService
{
    public class AppServiceMarca : AppServiceBase<Marca>, IAppServiceMarca
    {
        public AppServiceMarca(IUnitOfWork unitOfWork, IRepositoryBase<Marca> repositoryBase)
               : base(unitOfWork, repositoryBase)
        {
        }

        public override Marca Obter(int id)
        {
            var obj = base.Obter(id);

            if (obj == null)
                throw new MarcaNaoEncontradaException();

            return obj;
        }

        public void Alterar(int id, string Nome)
        {
            if (ValidarCategoriaExistente(Nome, id))
                throw new CategoriaJaCadastradaException();

            var obj = this.Obter(id);

            if (obj == null)
                throw new MarcaNaoEncontradaException();

            obj.Nome = Nome;

            this.Alterar(obj);
        }

        public void Cadastrar(string Nome)
        {
            if (ValidarCategoriaExistente(Nome))
                throw new CategoriaJaCadastradaException();

            var obj = new Marca();
            obj.Nome = Nome;

            this.Adicionar(obj);
        }

        public void Excluir(int id)
        {
            var obj = this.Obter(id);

            if (obj == null)
                throw new MarcaNaoEncontradaException();

            if(ValidarReferenciaMarca(id))
                throw new ErroExcluirMarcaContemPatrimonios();

            this.Remover(obj);
        }

        private bool ValidarReferenciaMarca(int id)
        {
            return this.Any(x => x.Patrimonios.Any());
        }

        private bool ValidarCategoriaExistente(string Nome, int? Id = null)
        {
            return this.Any(x => x.Nome == Nome && (!Id.HasValue || x.Id != Id));
        }
    }
}
