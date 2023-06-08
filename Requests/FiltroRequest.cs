namespace smarthintAPI.Requests
{
    public class FiltroRequest
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public double? Telefone { get; set; }
        public DateTime? DataCadastro { get; set; }
        public bool Bloqueado { get; set; }
    }
}
