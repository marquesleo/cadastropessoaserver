using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        public IPessoaRepository Pessoa { get; set; }
      

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            this.Pessoa = new PessoaRepository(repositoryContext);
            
        }
    }
}
