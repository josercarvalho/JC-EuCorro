using EuCorro.Domain.MetaData;
using System;
using System.ComponentModel.DataAnnotations;

namespace EuCorro.Domain.Models
{
    [MetadataType(typeof(ClientesMetaData))]
    public class Clientes
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Contato { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public int CidadeId { get; set; }
        public int EstadoId { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Observacao { get; set; }
        public bool Ativo { get; set; }
        public string Imagem { get; set; }
    }
}
