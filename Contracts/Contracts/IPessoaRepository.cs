using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace Contracts
{
    public interface IPessoaRepository : IRepositoryBase<Pessoa>
    {
        IEnumerable<Pessoa> GetAllPessoas();
        Pessoa GetPessoaById(Guid pessoaId);
       
        void CreatePessoa(Pessoa pessoa);
        void Update(Pessoa dbPessoa, Pessoa pessoa);
        void DeletePessoa(Pessoa pessoa);
    }
}
