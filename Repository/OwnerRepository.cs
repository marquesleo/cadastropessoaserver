using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class OwnerRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {

        public OwnerRepository(RepositoryContext repositoryContext)
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

        public IEnumerable<Pessoa> GetAllPessoa()
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

       

        public void UpdatePessoa(Pessoa dbPessoa, Pessoa pessoa)
        {
            Entities.Extensions.PessoaExtensions.Map(dbPessoa, pessoa);
            Update(dbPessoa);
            Save();
        }
    }
}
