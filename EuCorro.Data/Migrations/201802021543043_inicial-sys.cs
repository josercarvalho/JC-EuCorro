namespace EuCorro.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class inicialsys : DbMigration
    {
        public override void Up()
        {           
            
            CreateTable(
                "dbo.Modalidade",
                c => new
                    {
                        ModalidadeId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Distancia = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Categoria_CategoriaId = c.Int(),
                    })
                .PrimaryKey(t => t.ModalidadeId)
                .ForeignKey("dbo.Categoria", t => t.Categoria_CategoriaId)
                .Index(t => t.Categoria_CategoriaId);

            CreateTable(
                "dbo.Evento",
                c => new
                {
                    EventoId = c.Int(nullable: false, identity: true),
                    EventoTipoId = c.Int(nullable: false),
                    ModalidadeId = c.Int(nullable: false),
                    DataEvento = c.DateTime(nullable: false),
                    HoraEvento = c.String(maxLength: 100, unicode: false),
                    DataCadastro = c.DateTime(nullable: false),
                    Nome = c.String(maxLength: 100, unicode: false),
                    URL = c.String(maxLength: 100, unicode: false),
                    FoneContato = c.String(maxLength: 100, unicode: false),
                    EmailContato = c.String(maxLength: 100, unicode: false),
                    Instritos = c.Int(nullable: false),
                    DataEncerramento = c.DateTime(nullable: false),
                    HoraEncerramento = c.String(maxLength: 100, unicode: false),
                    Endereco = c.String(maxLength: 100, unicode: false),
                    EstadoId = c.Int(nullable: false),
                    CidadeId = c.Int(nullable: false),
                    DescricaoEvento = c.String(maxLength: 8000, unicode: false),
                    Regulamento = c.String(maxLength: 100, unicode: false),
                    InformacaoKit = c.String(maxLength: 100, unicode: false),
                    ImagemKit = c.String(maxLength: 100, unicode: false),
                    BannerEvento = c.String(maxLength: 100, unicode: false),
                    BannerPatrocinio = c.String(maxLength: 100, unicode: false),
                    Ativo = c.Boolean(nullable: false),
                    Status = c.Int(nullable: false),
                    PontoDeVendas_PontoDeVendasId = c.Int()
                })
                .PrimaryKey(t => t.EventoId)
                .ForeignKey("dbo.EventoTipo", t => t.EventoTipoId)
                .ForeignKey("dbo.Modalidade", t => t.ModalidadeId)
                .ForeignKey("dbo.PontoDeVendas", t => t.PontoDeVendas_PontoDeVendasId)
                .Index(t => t.EventoTipoId)
                .Index(t => t.ModalidadeId)
                .Index(t => t.PontoDeVendas_PontoDeVendasId);
            
            CreateTable(
                "dbo.EntregaKit",
                c => new
                    {
                        EntregaKitId = c.Int(nullable: false, identity: true),
                        EventoId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 100, unicode: false),
                        CPFRecebedor = c.String(maxLength: 100, unicode: false),
                        NomeRecebedor = c.String(maxLength: 100, unicode: false),
                        NumeroDoPeito = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Usuario_Id = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.EntregaKitId)
                .ForeignKey("dbo.Evento", t => t.EventoId)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id)
                .Index(t => t.EventoId)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 100, unicode: false),
                        PerfilUsuarioId = c.Int(nullable: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        Senha = c.String(maxLength: 100, unicode: false),
                        SecurityStamp = c.String(maxLength: 100, unicode: false),
                        Telefone = c.String(maxLength: 100, unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(maxLength: 100, unicode: false),
                        CPF = c.String(maxLength: 100, unicode: false),
                        Foto = c.String(maxLength: 100, unicode: false),
                        Brasileiro = c.Int(nullable: false),
                        Sexo = c.Int(nullable: false),
                        Camiseta = c.Int(nullable: false),
                        DataNascimento = c.DateTime(nullable: false),
                        Idade = c.Int(nullable: false),
                        Contato = c.String(maxLength: 100, unicode: false),
                        FoneContato = c.String(maxLength: 100, unicode: false),
                        Endereco = c.String(maxLength: 100, unicode: false),
                        Numero = c.String(maxLength: 100, unicode: false),
                        Complemento = c.String(maxLength: 100, unicode: false),
                        Bairro = c.String(maxLength: 100, unicode: false),
                        CEP = c.String(maxLength: 100, unicode: false),
                        PaisId = c.Int(nullable: false),
                        CidadeId = c.Int(nullable: false),
                        EstadoId = c.Int(nullable: false),
                        Celular = c.String(maxLength: 100, unicode: false),
                        WhatsApp = c.String(maxLength: 100, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Inscricoes_InscricoesId = c.Int(),
                        PontoDeVendas_PontoDeVendasId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Inscricoes", t => t.Inscricoes_InscricoesId)
                .ForeignKey("dbo.PontoDeVendas", t => t.PontoDeVendas_PontoDeVendasId)
                .ForeignKey("dbo.PerfilUsuario", t => t.PerfilUsuarioId)
                .Index(t => t.PerfilUsuarioId)
                .Index(t => t.Inscricoes_InscricoesId)
                .Index(t => t.PontoDeVendas_PontoDeVendasId);
            
            CreateTable(
                "dbo.EventoTipo",
                c => new
                    {
                        EventoTipoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.EventoTipoId);
            
            CreateTable(
                "dbo.Galeria",
                c => new
                    {
                        GaleriaId = c.Int(nullable: false, identity: true),
                        EventoId = c.Int(nullable: false),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                        Pasta = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.GaleriaId)
                .ForeignKey("dbo.Evento", t => t.EventoId)
                .Index(t => t.EventoId);
            
            CreateTable(
                "dbo.Inscricoes",
                c => new
                    {
                        InscricoesId = c.Int(nullable: false, identity: true),
                        EventoId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 100, unicode: false),
                        ModalidadeEventoId = c.Int(nullable: false),
                        Camiseta = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DescontoIdoso = c.Boolean(nullable: false),
                        ValorTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Numero = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Usuario_Id = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.InscricoesId)
                .ForeignKey("dbo.Evento", t => t.EventoId)
                .ForeignKey("dbo.ModalidadeEvento", t => t.ModalidadeEventoId)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id)
                .Index(t => t.EventoId)
                .Index(t => t.ModalidadeEventoId)
                .Index(t => t.Usuario_Id);

            CreateTable(
                "dbo.ModalidadeEvento",
                c => new
                {
                    ModalidadeEventoId = c.Int(nullable: false, identity: true),
                    EventoId = c.Int(nullable: false),
                    Reverzamento = c.Boolean(nullable: false),
                    AtletasPorEquipe = c.Int(nullable: false),
                    Vagas = c.Int(nullable: false),
                    NumeroInicial = c.Int(nullable: false),
                    NumeroFinal = c.Int(nullable: false),
                    IdadeMin = c.Int(nullable: false),
                    IdadeMax = c.Int(nullable: false),
                    Percurso = c.String(maxLength: 100, unicode: false),
                    PercursoImg = c.String(maxLength: 100, unicode: false),
                    DataCadastro = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ModalidadeEventoId)
                .ForeignKey("dbo.Evento", t => t.EventoId)
                .Index(t => t.EventoId);
            
            CreateTable(
                "dbo.ModalidadePreco",
                c => new
                    {
                        ModalidadePrecoId = c.Int(nullable: false, identity: true),
                        ModalidadeEventoId = c.Int(nullable: false),
                        TipoIncricao = c.Int(nullable: false),
                        DataIni = c.DateTime(nullable: false),
                        DataFin = c.DateTime(nullable: false),
                        HoraIni = c.String(maxLength: 100, unicode: false),
                        HoraFin = c.String(maxLength: 100, unicode: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Desconto = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ModalidadePrecoId)
                .ForeignKey("dbo.ModalidadeEvento", t => t.ModalidadeEventoId)
                .Index(t => t.ModalidadeEventoId);
            
            CreateTable(
                "dbo.PontoDeVendas",
                c => new
                    {
                        PontoDeVendasId = c.Int(nullable: false, identity: true),
                        EventoId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 100, unicode: false),
                        Local = c.String(maxLength: 100, unicode: false),
                        Evento_EventoId = c.Int(),
                        Usuario_Id = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.PontoDeVendasId)
                .ForeignKey("dbo.Evento", t => t.Evento_EventoId)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id)
                .Index(t => t.Evento_EventoId)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        CidadeId = c.Int(nullable: false, identity: true),
                        EstadoId = c.Int(nullable: false),
                        Nome = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.CidadeId)
                .ForeignKey("dbo.Estado", t => t.EstadoId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        EmpresaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Telefone = c.String(maxLength: 100, unicode: false),
                        Responsavel = c.String(maxLength: 100, unicode: false),
                        Celular = c.String(maxLength: 100, unicode: false),
                        CEP = c.String(maxLength: 100, unicode: false),
                        EstadoId = c.Int(nullable: false),
                        CidadeId = c.Int(nullable: false),
                        Bairro = c.String(maxLength: 100, unicode: false),
                        Logradouro = c.String(maxLength: 100, unicode: false),
                        Numero = c.String(maxLength: 100, unicode: false),
                        Complemento = c.String(maxLength: 100, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        CNPJ = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.EmpresaId)
                .ForeignKey("dbo.Cidade", t => t.CidadeId)
                .ForeignKey("dbo.Estado", t => t.EstadoId)
                .Index(t => t.EstadoId)
                .Index(t => t.CidadeId);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        EstadoId = c.Int(nullable: false, identity: true),
                        PaisId = c.Int(nullable: false),
                        Sigla = c.String(maxLength: 100, unicode: false),
                        Nome = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.EstadoId)
                .ForeignKey("dbo.Pais", t => t.PaisId)
                .Index(t => t.PaisId);
            
            CreateTable(
                "dbo.Pais",
                c => new
                    {
                        PaisId = c.Int(nullable: false, identity: true),
                        Sigla = c.String(maxLength: 100, unicode: false),
                        Nome = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.PaisId);
            
            //CreateTable(
            //    "dbo.AspNetClaims",
            //    c => new
            //        {
            //            Id = c.Guid(nullable: false),
            //            Name = c.String(nullable: false, maxLength: 128, unicode: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.AspNetClients",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            ClientKey = c.String(maxLength: 100, unicode: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EventoKit",
                c => new
                    {
                        EventoKitId = c.Int(nullable: false, identity: true),
                        EventoId = c.Int(nullable: false),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                        Tamanho_PP = c.Int(nullable: false),
                        Tamanho_P = c.Int(nullable: false),
                        Tamanho_M = c.Int(nullable: false),
                        Tamanho_G = c.Int(nullable: false),
                        Tamanho_GG = c.Int(nullable: false),
                        Tamanho_XG = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventoKitId)
                .ForeignKey("dbo.Evento", t => t.EventoId)
                .Index(t => t.EventoId);
            
            CreateTable(
                "dbo.NumeroDoPeito",
                c => new
                    {
                        NumeroDoPeitoId = c.Int(nullable: false, identity: true),
                        EventoId = c.Int(nullable: false),
                        ModalidadeEventoId = c.Int(nullable: false),
                        NumeroIni = c.Int(nullable: false),
                        NumeroFin = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        NumeroAtual = c.Long(nullable: false),
                        TipoNumeracao = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.NumeroDoPeitoId)
                .ForeignKey("dbo.Evento", t => t.EventoId)
                .ForeignKey("dbo.ModalidadeEvento", t => t.ModalidadeEventoId)
                .Index(t => t.EventoId)
                .Index(t => t.ModalidadeEventoId);
            
            CreateTable(
                "dbo.PerfilUsuario",
                c => new
                    {
                        PerfilUsuarioId = c.Int(nullable: false, identity: true),
                        NomPerfil = c.String(maxLength: 100, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        FlAdminMaster = c.Boolean(nullable: false),
                        FlUserMaster = c.Boolean(nullable: false),
                        FlOperador = c.Boolean(nullable: false),
                        FlAtivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PerfilUsuarioId);
            
            CreateTable(
                "dbo.PerguntasAdicionais",
                c => new
                    {
                        PerguntasAdicionaisId = c.Int(nullable: false, identity: true),
                        TipCampo = c.String(maxLength: 100, unicode: false),
                        EventoId = c.Int(nullable: false),
                        ModalidadeEventoId = c.Int(nullable: false),
                        Obrigatorio = c.Boolean(nullable: false),
                        Pergunta = c.String(maxLength: 100, unicode: false),
                        TextoAjuda = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.PerguntasAdicionaisId)
                .ForeignKey("dbo.Evento", t => t.EventoId)
                .ForeignKey("dbo.ModalidadeEvento", t => t.ModalidadeEventoId)
                .Index(t => t.EventoId)
                .Index(t => t.ModalidadeEventoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PerguntasAdicionais", "ModalidadeEventoId", "dbo.ModalidadeEvento");
            DropForeignKey("dbo.PerguntasAdicionais", "EventoId", "dbo.Evento");
            DropForeignKey("dbo.Usuario", "PerfilUsuarioId", "dbo.PerfilUsuario");
            DropForeignKey("dbo.NumeroDoPeito", "ModalidadeEventoId", "dbo.ModalidadeEvento");
            DropForeignKey("dbo.NumeroDoPeito", "EventoId", "dbo.Evento");
            DropForeignKey("dbo.EventoKit", "EventoId", "dbo.Evento");
            DropForeignKey("dbo.Estado", "PaisId", "dbo.Pais");
            DropForeignKey("dbo.Empresa", "EstadoId", "dbo.Estado");
            DropForeignKey("dbo.Cidade", "EstadoId", "dbo.Estado");
            DropForeignKey("dbo.Empresa", "CidadeId", "dbo.Cidade");
            DropForeignKey("dbo.Usuario", "PontoDeVendas_PontoDeVendasId", "dbo.PontoDeVendas");
            DropForeignKey("dbo.PontoDeVendas", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.Evento", "PontoDeVendas_PontoDeVendasId", "dbo.PontoDeVendas");
            DropForeignKey("dbo.PontoDeVendas", "Evento_EventoId", "dbo.Evento");
            DropForeignKey("dbo.Evento", "ModalidadeId", "dbo.Modalidade");
            DropForeignKey("dbo.Usuario", "Inscricoes_InscricoesId", "dbo.Inscricoes");
            DropForeignKey("dbo.Inscricoes", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.ModalidadePreco", "ModalidadeEventoId", "dbo.ModalidadeEvento");
            DropForeignKey("dbo.Inscricoes", "ModalidadeEventoId", "dbo.ModalidadeEvento");
            DropForeignKey("dbo.ModalidadeEvento", "EventoId", "dbo.Evento");
            DropForeignKey("dbo.Inscricoes", "EventoId", "dbo.Evento");
            DropForeignKey("dbo.Galeria", "EventoId", "dbo.Evento");
            DropForeignKey("dbo.Evento", "EventoTipoId", "dbo.EventoTipo");
            DropForeignKey("dbo.EntregaKit", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.EntregaKit", "EventoId", "dbo.Evento");
            DropIndex("dbo.PerguntasAdicionais", new[] { "ModalidadeEventoId" });
            DropIndex("dbo.PerguntasAdicionais", new[] { "EventoId" });
            DropIndex("dbo.NumeroDoPeito", new[] { "ModalidadeEventoId" });
            DropIndex("dbo.NumeroDoPeito", new[] { "EventoId" });
            DropIndex("dbo.EventoKit", new[] { "EventoId" });
            DropIndex("dbo.Estado", new[] { "PaisId" });
            DropIndex("dbo.Empresa", new[] { "CidadeId" });
            DropIndex("dbo.Empresa", new[] { "EstadoId" });
            DropIndex("dbo.Cidade", new[] { "EstadoId" });
            DropIndex("dbo.PontoDeVendas", new[] { "Usuario_Id" });
            DropIndex("dbo.PontoDeVendas", new[] { "Evento_EventoId" });
            DropIndex("dbo.ModalidadePreco", new[] { "ModalidadeEventoId" });
            DropIndex("dbo.ModalidadeEvento", new[] { "EventoId" });
            DropIndex("dbo.Inscricoes", new[] { "Usuario_Id" });
            DropIndex("dbo.Inscricoes", new[] { "ModalidadeEventoId" });
            DropIndex("dbo.Inscricoes", new[] { "EventoId" });
            DropIndex("dbo.Galeria", new[] { "EventoId" });
            DropIndex("dbo.Usuario", new[] { "PontoDeVendas_PontoDeVendasId" });
            DropIndex("dbo.Usuario", new[] { "Inscricoes_InscricoesId" });
            DropIndex("dbo.Usuario", new[] { "PerfilUsuarioId" });
            DropIndex("dbo.EntregaKit", new[] { "Usuario_Id" });
            DropIndex("dbo.EntregaKit", new[] { "EventoId" });
            DropIndex("dbo.Evento", new[] { "PontoDeVendas_PontoDeVendasId" });
            DropIndex("dbo.Evento", new[] { "ModalidadeId" });
            DropIndex("dbo.Evento", new[] { "EventoTipoId" });
            DropIndex("dbo.Modalidade", new[] { "Categoria_CategoriaId" });
            DropTable("dbo.PerguntasAdicionais");
            DropTable("dbo.PerfilUsuario");
            DropTable("dbo.NumeroDoPeito");
            DropTable("dbo.EventoKit");
            DropTable("dbo.AspNetClients");
            DropTable("dbo.AspNetClaims");
            DropTable("dbo.Pais");
            DropTable("dbo.Estado");
            DropTable("dbo.Empresa");
            DropTable("dbo.Cidade");
            DropTable("dbo.PontoDeVendas");
            DropTable("dbo.ModalidadePreco");
            DropTable("dbo.ModalidadeEvento");
            DropTable("dbo.Inscricoes");
            DropTable("dbo.Galeria");
            DropTable("dbo.EventoTipo");
            DropTable("dbo.Usuario");
            DropTable("dbo.EntregaKit");
            DropTable("dbo.Evento");
            DropTable("dbo.Modalidade");
            DropTable("dbo.Categoria");
        }
    }
}
