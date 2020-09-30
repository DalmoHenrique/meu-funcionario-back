using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meu_funcionario_back.Models
{
    public class Funcionario
    {
        public Funcionario(){}

        public Funcionario(int id, string nome, string endereco, DateTime dataNascimento, double salario, string genero)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
            DataNascimento = dataNascimento;
            Salario = salario;
            Genero = genero;
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Endereco { get; set; }

        public DateTime DataNascimento { get; set; }

        public double Salario { get; set; }

        public string Genero { get; set; }

    }
}
