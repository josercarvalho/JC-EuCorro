$(function () {

    $("#wizard").steps({
        headerTag: "h3",
        bodyTag: "section",
        transitionEffect: "slideLeft",
        stepsOrientation: "vertical",
        labels: {
            cancel: "Cancelar",
            finish: "Finalizar",
            next: "Próximo",
            previous: "Anterior"
        },

        onStepChanging: function (event, currentIndex, newIndex) {
            //Permitindo que o usuário possa voltar, mesmo que o passo atual esteja inválido
            if (currentIndex > newIndex) {
                return true;
            }

            var form = $('#form-wizard');

            //Retirando as classes de erro caso o usuário volte o passo
            if (currentIndex < newIndex) {
                // To remove error styles
                $(".body:eq(" + newIndex + ") label.error", form).remove();
                $(".body:eq(" + newIndex + ") .error", form).removeClass("error");
                $(".body:eq(" + newIndex + ") .input-validation-error", form).removeClass("error");
            }

            //Desabilitando a validação de compos desabilitados ou escondidos
            form.validate().settings.ignore = ":disabled,:hidden";

            //Iniciando a validação, prevenindo que o usuário avançe de passo
            return form.valid();
        },
        onFinishing: function (event, currentIndex) {
            var form = $('#form-wizard');

            form.validate().settings.ignore = ":disabled,:hidden";

            return form.valid();
        },
        onFinished: function (event, currentIndex) {
            $('#form-wizard').submit();
            var nome = $("#Nome").val();
            $("#form-wizard").hide();
            $("#div-conclusao").show();
            $("#div-conclusao-nome").text(nome);
            setTimeout("Refresh()", 5000);
        }
    });


    $("#form-wizard").validate({
        rules: {
            Nome: {
                required: true,
            },
            Login: {
                required: true,
            },
            Senha: {
                required: true,
            },
            Sexo: {
                required: true,
            },
            DataNascimento: {
                required: true,
            },
            CPF: {
                required: true,
            },
            Email: {
                required: true,
            },
            Endereco: {
                required: true,
            },
            Numero: {
                required: true,
            },
            Bairro: {
                required: true,
            },
            CEP: {
                required: true,
            },
            CidadeId: {
                required: true,
            },
            EstadoId: {
                required: true,
            },
            Telefone: {
                required: true,
            },
            confirmasenha: {
                equalTo: "#Senha"
            },
            BancoId: {
                required: true,
            },
            Titular: {
                required: true,
            },
            TipoConta: {
                required: true,
            },
            Agencia: {
                required: true,
            },
            Conta: {
                required: true,
            },
            termosuso: {
                required: true,
            }
        },
        messages: {
            nome: "",
            email: "",
            usuario: "",
            senha: "",
            confirmasenha: "Senhas não conferem.",
            termosuso: "Você deve aceitar para finalizar.",
        },
        highlight: function (element) {
            //adicionar border-color direto no element.id
            $('#' + element.id).addClass('erro');
        },
        unhighlight: function (element) {
            $('#' + element.id).removeClass('erro');
        },
        errorElement: 'span',
        errorClass: 'help-block',
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length) {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        }
    });

    function Trim(str) {
        return str.replace(/^\s+|\s+$/g, "");
    };
})