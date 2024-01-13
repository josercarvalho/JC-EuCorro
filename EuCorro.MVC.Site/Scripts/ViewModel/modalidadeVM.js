var url = window.location.pathname;
var profileId = url.substring(url.lastIndexOf('/') + 1);

$(function () {
    $(".btn-modalidade").on("click", function (e) {
        e.preventDefault();
        adicionaModalidade();
    });

    $('.textarea-wysihtml5').wysihtml5();

    //Timepicker
    $(".timepicker").timepicker({
        showInputs: false,
        orientation: "bottom auto"
    });

    $('#Ativo').checkboxpicker({
        offLabel: "Não",
        onLabel: "Sim",
        offCls: "btn-default",
        onCls: "btn-default"
    });

    $('.DescontoEspecial').checkboxpicker({
        offLabel: "Não",
        onLabel: "Sim",
        offCls: "btn-primary",
        onCls: "btn-primary"
    }).on('change', function () {
        $('.desconto').toggle(200);
    });

    $('#Reverzamento').checkboxpicker({
        offLabel: "Não",
        onLabel: "Sim",
        offCls: "btn-primary",
        onCls: "btn-primary"
    }).on('change', function () {
        $('#equipe').toggle(200);
    });

    $('.textarea-wysihtml5').wysihtml5();

    $("input.dinheiro").maskMoney({
        showSymbol: true,
        symbol: "R$",
        decimal: ",",
        thousands: "."
    });

    $("input.desconto").maskMoney({
        symbol: false,
        decimal: '.'
    });

    $(".DataEvento").datepicker({
        format: "dd/mm/yyyy",
        autoclose: true,
        language: "pt-BR"
    });

    $("#ddlEstados").on("change", function () {
        var estadoId = $(this).val();
        var url = '/Cadastro/LoadCidadeId/';
        $.getJSON(url, { estadoId: estadoId },
            function (estadosData) {
                $("#ddlCidades :gt(0)").remove();
                var select = $("#ddlCidades");
                select.attr('disabled', false);
                select.empty();
                select.append($('<option/>', {
                    value: 0,
                    text: "Selecione a Cidade... "
                }));
                $.each(estadosData, function (index, itemData) {
                    select.append($('<option/>', {
                        value: itemData.Value,
                        text: itemData.Text
                    }));
                });
            });
    });

    function adicionaModalidade() {
        $("#divModalidade").slideToggle("slow");
    };

    function formatCurrency(value) {
        return value.toFixed(2);
    };

    function checaPrecos() {
        var retorno = true;
        if ($("#DtInicial").val() === '') { retorno = false; };
        if ($("#DtFinal").val() === '') { retorno = false; };
        if ($("#HoraIni").val() === '') { retorno = false; };
        if ($("#HoraFin").val() === '') { retorno = false; };
        if ($("#Valor").val() === '') { retorno = false; };
        if ($("#Desconto").val() !== '') {
            if ($("#CodigoDesconto").val() === '') { retorno = false; };
            if ($("#ValidadeDesconto").val() === '') { retorno = false; };
        }

        return retorno;
    };

    function checaCategoria() {
        var retorno = true;
        if ($('#CategoriaDescricao').val() === '') { retorno = false; };
        if ($('#CategoriaDesconto').val() === '') { retorno = false; };
        return retorno;
    };

    //var ModalidadeEvento = function (modalidadeEvento) {
    //    var self = this;
    //    self.ModalidadeEventoId = ko.observable(modalidadeEvento);
    //    self.EventoId = ko.observable(modalidadeEvento);
    //    self.ModalidadeId = ko.observable(modalidadeEvento);
    //    self.Reverzamento = ko.observable(modalidadeEvento);
    //    self.AtletasPorEquipe = ko.observable(modalidadeEvento);
    //    self.Vagas = ko.observable(modalidadeEvento);
    //    self.NumeroInicial = ko.observable(modalidadeEvento);
    //    self.NumeroFinal = ko.observable(modalidadeEvento);
    //    self.IdadeMin = ko.observable(modalidadeEvento);
    //    self.IdadeMax = ko.observable(modalidadeEvento);
    //    self.DescricaoPercurso = ko.observable(modalidadeEvento);
    //    self.PercursoImg = ko.observable(modalidadeEvento);
    //};

    //var PrecoLine = function (modalidadePreco) {
    //    var self = this;
    //    self.DtInicial = ko.observable(modalidadePreco);
    //    self.DtFinal = ko.observable(modalidadePreco);
    //    self.HoraIni = ko.observable(modalidadePreco);
    //    self.HoraFin = ko.observable(modalidadePreco);
    //    self.Valor = ko.observable(modalidadePreco);
    //    self.Desconto = ko.observable(modalidadePreco);
    //    self.TipoDesconto = ko.observable(modalidadePreco);
    //    self.CodigoDesconto = ko.observable(modalidadePreco);
    //    self.ValidadeDesconto = ko.observable(modalidadePreco);
    //    self.ValorDesconto = ko.computed(function () {
    //        return self.Valor() ? (parseFloat("0" + self.Valor()) * parseInt("0" + self.Desconto(), 10) / 100) : 0;
    //    });
    //};

    var ModalidadeViewModel = function () {
        var self = this;

        self.TipoModalidade = ko.observable('Nova Modalidade');

        // Modalidade
        self.ModalidadeEventoId = ko.observable();
        self.EventoId = ko.observable();
        self.ModalidadeId = ko.observable();
        self.Reverzamento = ko.observable();
        self.AtletasPorEquipe = ko.observable();
        self.Vagas = ko.observable();
        self.NumeroInicial = ko.observable();
        self.NumeroFinal = ko.observable();
        self.IdadeMin = ko.observable();
        self.IdadeMax = ko.observable();
        self.DescricaoPercurso = ko.observable();
        self.PercursoImg = ko.observable();

        // Preços e Descontos
        self.DtInicial = ko.observable();
        self.DtFinal = ko.observable();
        self.HoraIni = ko.observable();
        self.HoraFin = ko.observable();
        self.Valor = ko.observable();
        self.TipoDesconto = ko.observable();
        self.Desconto = ko.observable();
        self.CodigoDesconto = ko.observable();
        self.ValidadeDesconto = ko.observable();
        self.ValorDesconto = ko.computed(function () {
            return self.Valor() ? (parseFloat("0" + self.Valor()) * parseInt("0" + self.Desconto(), 10) / 100) : 0;
        });

        // Categoria e Desconto da categoria
        self.CategoriaDescricao = ko.observable();
        self.CategoriaDesconto = ko.observable();
        
        // Lista de Preços da Modalidade
        var modalidade = {
            ModalidadeEventoId: self.ModalidadeEventoId,
            EventoId: self.EventoId,
            TipoModalidade: self.TipoModalidade,
            ModalidadeId: self.ModalidadeId,
            Reverzamento: self.Reverzamento,
            AtletasPorEquipe: self.AtletasPorEquipe,
            Vagas: self.Vagas,
            NumeroInicial: self.NumeroInicial,
            NumeroFinal: self.NumeroFinal,
            IdadeMin: self.IdadeMin,
            IdadeMax: self.IdadeMax,
            DescricaoPercurso: self.DescricaoPercurso,
            PercursoImg: self.PercursoImg
        };

        var categoria = {
            CategoriaDescricao: self.CategoriaDescricao,
            CategoriaDesconto: self.CategoriaDesconto
        };

        var preco = {
            DtInicial: self.DtInicial,
            DtFinal: self.DtFinal,
            HoraIni: self.HoraIni,
            HoraFin: self.HoraFin,
            Valor: self.Valor,
            Desconto: self.Desconto,
            TipoDesconto: self.TipoDesconto,
            CodigoDesconto: self.CodigoDesconto,
            ValidadeDesconto: self.ValidadeDesconto,
            ValorDesconto: self.ValorDesconto
        };

        self.modalidade = ko.observable();
        self.categoria = ko.observable();
        self.preco = ko.observable();
        self.lstPrecos = ko.observableArray([]);
        self.lstCategorias = ko.observableArray([]);
        self.listaModalidade = ko.observableArray([]);

        //Initialize the view-model  
        //$.ajax({
        //    url: "/Admin/Evento/GetEventoById",
        //    cache: false,
        //    type: 'GET',
        //    contentType: 'application/json; charset=utf-8',
        //    data: {},
        //    success: function (data) {
        //        self.listaModalidade(data); //Put the response in ObservableArray
        //    }
        //});

        self.addPreco = function () {
            if (!checaPrecos()) {
                bootbox.alert("Faltando dados Obrigatórios. Verifique!")
            } else {
                self.lstPrecos.push({
                    DtInicial: self.DtInicial(),
                    DtFinal: self.DtFinal(),
                    HoraIni: self.HoraIni(),
                    HoraFin: self.HoraFin(),
                    Valor: self.Valor(),
                    Desconto: self.Desconto(),
                    TipoDesconto: self.TipoDesconto(),
                    CodigoDesconto: self.CodigoDesconto(),
                    ValidadeDesconto: self.ValidadeDesconto(),
                    ValorDesconto: self.ValorDesconto()
                });
                self.limparPreco();
            }
        };
        
        self.removePreco = function (item) {
            self.lstPrecos.remove(item);
        };

        self.addCategoria = function () {
            if (!checaCategoria()) {
                bootbox.alert("Faltando dados Obrigatórios. Verifique!")
            } else {
                self.lstCategorias.push({
                    CategoriaDescricao: self.CategoriaDescricao(),
                    CategoriaDesconto: self.CategoriaDesconto()
                });
                self.limparCategoria();
            }
        };

        self.removeCategoria = function (item) {
            self.lstCategorias.remove(item);
        };

        //self.cancela = function () {
        //    var id = modalidade.EventoId;
        //    var nome = modali.nome;
        //    $.get("/Admin/Evento/Modalidades", { "id": id, "nome": nome });
        //};

        self.limparPreco = function () {
            $('#DtInicial').val('');
            $('#DtFinal').val('');
            $('#HoraIni').val('');
            $('#HoraFin').val('');
            $('#Valor').val('');
            $('#Desconto').val('');
            $('#CodigoDesconto').val('');
            $('#ValidadeDesconto').val('');
            $('#ValorDesconto').val('');
        };

        self.limparCategoria = function () {
            $('#CategoriaDesconto').val('');
            $('#CategoriaDescricao').val('');
        };

        self.SaveModalidade = function () {
            var modalidadeEvento = ko.toJS({
                ModalidadeEventoId: self.ModalidadeEventoId,
                EventoId: self.EventoId,
                TipoModalidade: self.TipoModalidade,
                ModalidadeId: self.ModalidadeId,
                Reverzamento: self.Reverzamento,
                AtletasPorEquipe: self.AtletasPorEquipe,
                Vagas: self.Vagas,
                NumeroInicial: self.NumeroInicial,
                NumeroFinal: self.NumeroFinal,
                IdadeMin: self.IdadeMin,
                IdadeMax: self.IdadeMax,
                Percurso: self.DescricaoPercurso,
                PercursoImg: self.PercursoImg
            });

            //var modalidadeCategoria = ko.toJS(self.lstCategorias);
            //var modalidadePrecos = ko.toJS(self.lstPrecos);

            $.ajax({
                type: "POST",
                //cache: false,
                //dataType: 'json',
                url: "/Admin/Evento/SaveModalidade",
                data: JSON.stringify({ modalidade: modalidadeEvento, modalidadeCategorias: self.lstCategorias, modalidadePrecos: self.lstPrecos() }),
                //contentType: 'application/json; charset=utf-8',
                contentType: "application/json",
                //async: false,
                success: function () {
                    self.listaModalidade.removeAll();
                    self.listaModalidade(data);
                    self.modalidade(null);
                    self.precos(null);
                    bootbox.alert("Dados salvos com sucesso!")
                },
                error: function (erro) {
                    var err = JSON.parse(erro.responseText);
                    var errors = "";
                    for (var key in err) {
                        if (err.hasOwnProperty(key)) {
                            errors += key.replace("modalidade.", "") + " : " + err[key];
                        }
                    }
                    $("<div></div>").html(errors).dialog({ modal: true, title: JSON.parse(err.responseText).Message, buttons: { "Ok": function () { $(this).dialog("close"); } } }).show();
                },
                complete: function (data) {
                    self.ListaModalidade.push(modadlidade);
                    self.cancel();
                    adicionaModalidade();
                }
            });
        };

        // Edita detailhes da Modadlidade
        self.editModadlidade = function (modalidade) {
            self.modalidade(modalidade);
        };

        // Delete Modadlidade details
        self.deleteModadlidade = function (modalidade) {
            if (bootbox.confirm('Tem certeza que deseja excluir "' + modalidade.Name + '" deste Evento ??')) {
                var id = modalidade.ModalidadeEventoId;

                $.ajax({
                    url: "/Admin/Evento/DelModalidade",
                    cache: false,
                    type: 'POST',
                    contentType: 'application/json; charset=utf-8',
                    data: ko.toJSON(id),
                    success: function (data) {
                        self.modalidade.remove(modalidade);
                        Bootbox.alert(data);
                    }
                }).fail(
                    function (xhr, textStatus, err) {
                        alert(err);
                    });
            }
        };
    };

    ko.applyBindings(new ModalidadeViewModel());

});