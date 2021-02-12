using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Extensions
{
    public static class PessoaExtensions
    {
        public static void Map(this Pessoa dbPessoa, Pessoa pessoa)
        {
            dbPessoa.nome = pessoa.nome;
            dbPessoa.CPF = pessoa.CPF;
            dbPessoa.email = pessoa.email;
            dbPessoa.dataNascimento = pessoa.dataNascimento;
            dbPessoa.sexo = pessoa.sexo;
            dbPessoa.telefone = pessoa.telefone;
            
        }
    }
}
