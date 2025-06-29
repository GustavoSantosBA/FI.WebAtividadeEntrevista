$(document).ready(function () {
    $("#btnAbrirModalBeneficiarios").click(function () {
        limparFormulario();
        $("#modalBeneficiarios").modal("show");
    });

    $("#btnSalvarBeneficiario").click(function () {
        let id = $("#beneficiarioId").val();
        let cpf = $("#cpfBeneficiario").val();
        let nome = $("#nomeBeneficiario").val();
        let idCliente = $("#Id").val();

        if (!cpf || !nome) {
            ModalDialog("Atenção", "Preencha todos os campos!");
            return;
        }

        let url = id && id > 0 ? "/Beneficiario/Alterar" : "/Beneficiario/Incluir";

        $.ajax({
            url: url,
            method: "POST",
            data: {
                Id: id,
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
