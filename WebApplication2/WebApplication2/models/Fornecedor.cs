﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication2.models
{
    public class Fornecedor
    {
        public string NomeFantasia { get; set; }

        public string RazaoSocial { get; set; }

        public string CNPJ { get; set; }

        public string Endereco { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string Responsavel { get; set; }

    }
}
