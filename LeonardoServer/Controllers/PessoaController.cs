using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AccountOwnerServer.Controllers
{
    [Produces("application/json")]
    [Route("api/Pessoa")]
    public class PessoaController : Controller
    {

        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public PessoaController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllPessoas()
        {
            try
            {
                var pessoas = _repository.Pessoa.GetAllPessoas();

                _logger.LogInfo($"Returned all pessoas from database.");

                return Ok(pessoas);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllPessoas action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("{id}", Name = "GetPessoaById")]
        public IActionResult GetPessoaById(Guid id)
        {
            try
            {
                var pessoa = _repository.Pessoa.GetPessoaById(id);

                return Ok(pessoa);
                

               
                            
             
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetPessoaById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

     

        [HttpPost]
        public IActionResult CreatePessoa([FromBody]Pessoa pessoa)
        {
            try
            {
              

                _repository.Pessoa.CreatePessoa(pessoa);

                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreatePessoa action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdatePessoa(Guid id, [FromBody]Pessoa pessoa)
        {
            try
            {
               

                var dbPessoa = _repository.Pessoa.GetPessoaById(id);
                if (Entities.Extensions.IEntityExtensions.IsEmptyObject(dbPessoa))
                {
                    _logger.LogError($"Pessoa with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Pessoa.Update(dbPessoa, pessoa);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdatePessoa action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePessoa(Guid id)
        {
            try
            {
                var pessoa = _repository.Pessoa.GetPessoaById(id);
               
                _repository.Pessoa.DeletePessoa(pessoa);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeletePessoa action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}