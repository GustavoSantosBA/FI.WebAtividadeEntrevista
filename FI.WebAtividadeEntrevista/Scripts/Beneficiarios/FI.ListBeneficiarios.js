function carregarBeneficiarios() {
    let idCliente = $("#Id").val();

    $.ajax({
        debugger
        url: "/Beneficiario/Listar?idCliente=" + idCliente,
        method: "GET",
        success: function (data) {
            let tbody = $("#tbodyBeneficiarios");
            tbody.empty();

            data.forEach(function (item) {
                tbody.append(`
                    <tr>
                        <td>${item.CPF}</td>
                        <td>${item.Nome}</td>
                        <td>
                            <button class="btn btn-sm btn-warning" onclick="editarBeneficiario(${item.Id}, '${item.CPF}', '${item.Nome}')">Editar</button>
                            <button class="btn btn-sm btn-danger" onclick="excluirBeneficiario(${item.Id})">Excluir</button>
                        </td>
                    </tr>
                `);
            });
        },
        error: function () {
            ModalDialog("Erro", "Erro ao carregar beneficiários");
        }
    });
}

function editarBeneficiario(id, cpf, nome) {
    $("#beneficiarioId").val(id);
    $("#cpfBeneficiario").val(cpf);
    $("#nomeBeneficiario").val(nome);
    $("#modalBeneficiarios").modal("show");
}

function excluirBeneficiario(id) {
    if (confirm("Deseja realmente excluir este beneficiário?")) {
        $.ajax({
            url: "/Beneficiario/Excluir",
            method: "POST",
            data: { id: id },
            success: function (msg) {
                ModalDialog("Sucesso", msg);
                carregarBeneficiarios();
            },
            error: function (r) {
                ModalDialog("Erro", r.responseText);
            }
        });
    }
}

function limparFormulario() {
    $("#beneficiarioId").val(0);
    $("#cpfBeneficiario").val('');
    $("#nomeBeneficiario").val('');
}
