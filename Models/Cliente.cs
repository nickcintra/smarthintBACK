using System.ComponentModel.DataAnnotations;

namespace smarthintAPI.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        [StringLength(150)]
        public string Email { get; set; }
        [StringLength(11)]
        public double Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        public string TipoPessoa { get; set; }
        [StringLength(14)]
        public string CpfCnpj { get; set; }
        [StringLength(12)]
        public string InscricaoEstadual { get; set; }
        public bool Isento { get; set; }
        public string Genero { get; set; }
        public bool Bloqueado { get; set; }
        [StringLength(15)]
        public string Senha { get; set; }

        public Cliente()
        {
            
        }

        public Cliente(string nome, string email, double telefone, DateTime dataCadastro, string tipoPessoa, string cpfCnpj, string inscricaoEstadual, bool isento, string genero, bool bloqueado, string senha)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            DataCadastro = dataCadastro;
            TipoPessoa = tipoPessoa;
            CpfCnpj = cpfCnpj;
            InscricaoEstadual = inscricaoEstadual;
            Isento = isento;
            Genero = genero;
            Bloqueado = bloqueado;
            Senha = senha;
        }
    }
}
