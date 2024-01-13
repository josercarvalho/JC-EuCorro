var eventoSalvo = false;
var modalidadeSalva = false;
var categoriaSalva = false;

//$(document).ready(function () {
$(function () {

    $(".btn-modalidade").on("click", function (e) {
        e.preventDefault();
        adicionaModalidade();
    });

    //Timepicker
    $(".timepicker").timepicker({
        showInputs: false,
        orientation: "bottom auto"
    });
    //$(".timepicker").mask('99:99');

    //$('#Ativo').bootstrapSwitch();
    $('#Ativo').checkboxpicker({
        offLabel: "Não",
        onLabel: "Sim",
        offCls: "btn-default",
        onCls: "btn-default"
    });

    $('#Reverzamento').checkboxpicker({
        offLabel: "Não",
        onLabel: "Sim",
        offCls: "btn-default",
        onCls: "btn-default"
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

    //$(".DataEvento").datepicker({
    //    format: "dd/mm/yyyy",
    //    //orientation: "bottom auto",
    //    todayBtn: true,
    //    language: "pt-BR"
    //});

    //$(".datas").datepicker({
    //    format: "dd/mm/yyyy",
    //    orientation: "bottom auto",
    //    todayBtn: true,
    //    language: "pt-BR"
    //});
    $(".datas").mask('99/99/9999');

    $("#ddlEstados").on("change", function () {
        var estadoId = $(this).val();
        //var url = '@Url.Action("LoadCidadeId", "Evento")';
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
                    //alert(estadosData);
                    //alert(itemData);
                    select.append($('<option/>', {
                        value: itemData.Value,
                        text: itemData.Text
                    }));
                });
            });
    });
    
    //$('#Vagas').change(function () {
    //    var value = $("#VAgas").val();
    //    alert(value);
    //})

    //function adicionaModalidade() {
    //    $("#divModalidade").slideToggle("slow");
    //};

    //function formatCurrency(value) {
    //    return "R$ " + value.toFixed(2);
    //}

});