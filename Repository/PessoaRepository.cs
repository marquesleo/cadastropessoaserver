using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreatePessoa(Pessoa pessoa)
        {
            pessoa.Id = Guid.NewGuid();
            Create(pessoa);
            Save();
        }

        public void DeletePessoa(Pessoa owner)
        {
            Delete(owner);
            Save();
        }

        public IEnumerable<Pessoa> GetAllPessoas()
        {
            return FindAll()
                .OrderBy(ow => ow.nome);
        }

        public Pessoa GetPessoaById(Guid pessoaId)
        {
            return (Pessoa)FindByCondition(owner => owner.Id.Equals(pessoaId))
                .DefaultIfEmpty(new Pessoa())
                .FirstOrDefault();

        }



        public void Update(Pessoa dbPessoa, Pessoa pessoa)
        {
            Entities.Extensions.PessoaExtensions.Map(dbPessoa, pessoa);
            Update(dbPessoa);
            Save();
        }
    }
}
