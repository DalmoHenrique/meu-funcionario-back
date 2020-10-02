using meu_funcionario_back.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meu_funcionario_back.Data
{
    /**
     * Criação do DbContext. Classe para realizar a criação do banco de acordo com o DbSet referente aos Funcionarios
     */

    public class FuncionarioContext: DbContext
    {

        public FuncionarioContext(DbContextOptions<FuncionarioContext> options) : base(options)
        {

        }

        public DbSet<Funcionario> Funcionarios { get; set; }

    }
}
