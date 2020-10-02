﻿using meu_funcionario_back.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meu_funcionario_back.Data
{
    public class FuncionarioContext: DbContext
    {

        public FuncionarioContext(DbContextOptions<FuncionarioContext> options) : base(options)
        {

        }

        public DbSet<Funcionario> Funcionarios { get; set; }

    }
}
