
var masks = ['(00) 00000-0000', '(00) 0000-00009'];

//Código para contornar o conflito do jquery mask com o jquery validate
$(function () {

    $('.Fone').mask(masks[1], {
        onKeyPress: function (val, e, field, options) {
            field.mask(val.length > 14 ? masks[0] : masks[1], options);
        }
    });

    $("#CPF").mask("999.999.999-99");
    $("#CEP").mask("99.999-999");
    $("#DataNascimento").mask("99/99/9999");

    $("#ddlEstados").on("change", function () {
        var estadoId = $(this).val();
        //var url = '@Url.Action("LoadCidadeId", "Cadastro")';
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

});
