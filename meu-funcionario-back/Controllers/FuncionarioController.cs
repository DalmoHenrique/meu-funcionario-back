using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using meu_funcionario_back.Data;
using meu_funcionario_back.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace meu_funcionario_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors()]
    public class FuncionarioController : ControllerBase
    {

        /**
         * Inicialização do contexto do Funcionário na Controller
         */
        private readonly FuncionarioContext _context;

        public FuncionarioController(FuncionarioContext context)
        {
            _context = context;
        }


        /**
         * Todas as requisições REST para realizar um GET, POST, PUT ou DELETE
         */

        // GET: api/funcionario
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Funcionarios);
        }

        // GET api/funcionario/2
        [HttpGet("consultar/{id}")]
        public IActionResult GetById(int id)
        {
            var funcionario = _context.Funcionarios.FirstOrDefault(t => t.Id == id);
            if (funcionario == null) return BadRequest("Funcionário não localizado");
            return Ok(funcionario);
        }

        // POST
        [HttpPost("cadastrar/sucesso")]
        public IActionResult Post(Funcionario funcionario)
        {
            _context.Add(funcionario);
            _context.SaveChanges();
            return Ok(funcionario);
        }

        // PUT
        [HttpPut("alterar/{id}")]
        public IActionResult Put(int id, Funcionario funcionario)
        {
            var func = _context.Funcionarios.AsNoTracking().FirstOrDefault(t => t.Id == id);
            if (func == null) return BadRequest("Funcionário não localizado");

            _context.Update(funcionario);
            _context.SaveChanges();
            return Ok(funcionario);
        }

        // DELETE
        [HttpDelete("deletar/{id}")]
        public IActionResult Delete(int id)
        {
            var funcionario = _context.Funcionarios.FirstOrDefault(t => t.Id == id);
            if (funcionario == null) return BadRequest("Funcionário não localizado");
            _context.Remove(funcionario);
            _context.SaveChanges();
            return Ok();
        }
    }
}
