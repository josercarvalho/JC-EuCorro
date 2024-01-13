var urlEvento = "/Painel/Evento";
var ModalidadeData;
var PrecoModalidadeData;
var url = window.location.pathname;
var profileId = url.substring(url.lastIndexOf('/') + 1);

//$.ajax({
//    url: urlEvento + '/InitializePageData',
//    async: false,
//    dataType: 'json',
//    success: function (json) {
//        ModalidadeData = json.lstModalidadeDTO;
//        PrecoModalidadeData = json.lstPrecoDTO;
//    }
//});

$(function () {

    var ModalidadeEvento = function (modalidadeEvento) {
        var self = this;
        self.modalidadeEventoId = ko.observable(modalidadeEvento ? modalidadeEvento.modalidadeEventoId : 0);
        self.eventoId = ko.observable(modalidadeEvento ? modalidadeEvento.eventoId : 0);
        self.tipoModalidade = ko.observable(modalidadeEvento ? modalidadeEvento.tipoModalidade : 0);
        self.modalidadeId = ko.observable(modalidadeEvento ? modalidadeEvento.modalidadeId : 0);
        self.reverzamento = ko.observable(modalidadeEvento ? modalidadeEvento.reverzamento : false);
        self.atletasPorEquipe = ko.observable(modalidadeEvento ? modalidadeEvento.atletasPorEquipe : 0);
        self.vagas = ko.observable(modalidadeEvento ? modalidadeEvento.vagas : 0);
        self.numeroInicial = ko.observable(modalidadeEvento ? modalidadeEvento.numeroInicial : 0);
        self.numeroFinal = ko.observable(modalidadeEvento ? modalidadeEvento.numeroFinal : 0);
        self.idadeMin = ko.observable(modalidadeEvento ? modalidadeEvento.idadeMin : 0);
        self.idadeMax = ko.observable(modalidadeEvento ? modalidadeEvento.idadeMax : 0);
        self.descricaoPercurso = ko.observable(modalidadeEvento ? modalidadeEvento.descricaoPercurso : '');
        self.percursoImg = ko.observable(modalidadeEvento ? modalidadeEvento.percursoImg : '');
        self.PrecoDTO = ko.observableArray(modalidadeEvento ? modalidadeEvento.PrecoDTO : []);
    };

    var PrecoLine = function (modalidadePreco) {
        var self = this;
        self.dataIni = ko.observable(modalidadePreco ? modalidadePreco.dataIni : '');
        self.dataFin = ko.observable(modalidadePreco ? modalidadePreco.dataFin : '');
        self.horaIni = ko.observable(modalidadePreco ? modalidadePreco.horaIni : '');
        self.horaFin = ko.observable(modalidadePreco ? modalidadePreco.horaFin : '');
        self.valor = ko.observable(modalidadePreco ? modalidadePreco.valor : 0);
    };

    var eventoCollection = function () {
        var self = this;
                
        // Lista de Preços da Modalidade
        //var modalidadeVM = {
        //    ModalidadeEventoId: self.ModalidadeEventoId,
        //    EventoId: self.EventoId,
        //    TipoModalidade: self.TipoModalidade,
        //    ModalidadeId: self.ModalidadeId,
        //    Reverzamento: self.Reverzamento,
        //    AtletasPorEquipe: self.AtletasPorEquipe,
        //    Vagas: self.Vagas,
        //    NumeroInicial: self.NumeroInicial,
        //    NumeroFinal: self.NumeroFinal,
        //    IdadeMin: self.IdadeMin,
        //    IdadeMax: self.IdadeMax,
        //    DescricaoPercurso: self.DescricaoPercurso,
        //    PercursoImg: self.PercursoImg,
        //    PrecoDTO: ko.observableArray([])
        //};

        //var PrecoLineVM = {
        //    dataIni: self.dataIni,
        //    dataFin: self.dataFin,
        //    horaIni: self.horaIni,
        //    horaFin: self.horaFin,
        //    valor: self.valor
        //};

        //if eventoId is 0, It means Create new Profile
        if (self.eventoId === 0) {
            self.precos = ko.observableArray([new precos()]);
            self.modalidade = ko.observableArray([new ModalidadeEvento()]);
        }
        else {
            $.ajax({
                url: urlEvento + '/GetEventoById/' + self.eventoId,
                async: false,
                dataType: 'json',
                success: function (json) {
                    self.modalidade = ko.observable(new ModalidadeVM(json));
                    self.precos = ko.observableArray(ko.utils.arrayMap(json.PrecoDTO, function (preco) {
                        return preco;
                    }));
                }
            });
        }

        self.addPreco = function () { self.precos.push(new PrecoLine()); };

        self.removePreco = function (preco) { self.precos.remove(preco); };

        self.backToProfileList = function () { window.location.href = '/Painel/Evento'; };

        //self.precoErrors = ko.validation.group(self.precos(), { deep: true });
        //self.modalidadeErrors = ko.validation.group(self.modalidade(), { deep: true });

        self.saveEvento = function () {

            var isValid = true;

            //if (self.eventoErrors().length !== 0) {
            //    self.eventoErrors.showAllMessages();
            //    isValid = false;
            //}

            //if (self.precoErrors().length !== 0) {
            //    self.precoErrors.showAllMessages();
            //    isValid = false;
            //}

            //if (self.modalidadeErrors().length !== 0) {
            //    self.modalidadeErrors.showAllMessages();
            //    isValid = false;
            //}

            if (isValid) {
                self.modalidade().PrecoDTO = self.precos;
                self.evento.ModalidadeDTO = self.modalidade;

                $.ajax({
                    type: (self.evento().ModalidadeEventoId > 0 ? 'GET' : 'POST'),
                    cache: false,
                    dataType: 'json',
                    url: urlEvento + (self.evento().ModalidadeEventoId > 0 ? '/UpdateEvento?id=' + self.evento().eventoId : '/SalveEvento'),
                    data: JSON.stringify(ko.toJS(self.evento())),
                    contentType: 'application/json; charset=utf-8',
                    async: false,
                    success: function () {
                        window.location.href = '/evento';
                    },
                    error: function (erro) {
                        var err = JSON.parse(erro.responseText);
                        var errors = "";
                        for (var key in err) {
                            if (err.hasOwnProperty(key)) {
                                errors += key.replace("evento.", "") + " : " + err[key];
                            }
                        }
                        $("<div></div>").html(errors).dialog({ modal: true, title: JSON.parse(err.responseText).Message, buttons: { "Ok": function () { $(this).dialog("close"); } } }).show();
                    },
                    complete: function () {
                    }
                });
            }
        };

        self.cacelModalidade = function () {
            ModalidadeVM(null);
        }
    };

    ko.applyBindings(new eventoCollection());
});

var clone = (function () {
    return function (obj) {
        clone.prototype = obj;
        return new clone();
    };
    function clone() { }
}());