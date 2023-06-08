using System;
using System.Text.Json.Serialization;

namespace smarthintAPI.Requests
{
    public record ClienteRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public double Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        public string TipoPessoa { get; set; }
        public string CpfCnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public bool Isento { get; set; }
        public string Genero { get; set; }
        public bool Bloqueado { get; set; }
        public string Senha { get; set; }
    }
}