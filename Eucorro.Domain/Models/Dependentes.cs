using EuCorro.Domain.Enum;
using EuCorro.Domain.MetaData;
using System;
using System.ComponentModel.DataAnnotations;

namespace EuCorro.Domain.Models
{
    [MetadataType(typeof(DependentesMetaData))]
    public class Dependentes
    {
        public int DependenteId { get; set; }
        public string UserId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Documento { get; set; }
        public string Telefone { get; set; }
        public Sexo Sexo { get; set; }
        public string Contato { get; set; }
        public string FoneContato { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
