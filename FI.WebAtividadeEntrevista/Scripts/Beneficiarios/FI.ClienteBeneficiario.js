$(document).ready(function () {
    $("#btnAbrirModalBeneficiarios").click(function () {
        limparFormulario();
        $("#modalBeneficiarios").modal("show");
    });

    $("#btnSalvarBeneficiario").click(function () {
        let cpf = $("#cpfBeneficiario").val();
        let nome = $("#nomeBeneficiario").val();
        let idCliente = $("#Id").val();

        if (!cpf || !nome) {
            ModalDialog("Atenção", "Preencha todos os campos!");
            return;
        }

        $.ajax({
            url: "/Beneficiario/Incluir",
            method: "POST",
            data: {
                CPF: cpf,
                Nome: nome,
                IdCliente: idCliente
            },
            success: function (msg) {
                ModalDialog("Sucesso", msg);
                carregarBeneficiarios();
                limparFormulario();
            },
            error: function (r) {
                ModalDialog("Erro", r.responseText);
            }
        });
    });

    carregarBeneficiarios();
});
