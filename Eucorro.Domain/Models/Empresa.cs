namespace EuCorro.Domain.Models
{
    public class Empresa 
    {
        public int EmpresaId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Responsavel { get; set; }
        public string Celular { get; set; }
        public string CEP { get; set; }
        public int PaisId { get; set; }
        public int EstadoId { get; set; }
        public int CidadeId { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Endereco { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Email { get; set; }
        public string CNPJ { get; set; }
        public string Avatar { get; set; }

        public virtual Pais Paises { get; set; }
        public virtual Cidade Cidades { get; set; }
        public virtual Estado Estados { get; set; }
    }
}
