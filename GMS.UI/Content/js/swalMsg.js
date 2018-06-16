function Mensagem(titulo, texto, url, msgsuccess) {
    swal({
        title: titulo,
        text: texto,
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#00a65a",
        cancelButtonColor: "#dd4b39",
        confirmButtonText: "Sim",
        cancelButtonText: "Não",
        preConfirm: function (value) {
            return new Promise(function (resolve) {
                swal.enableLoading();

                $.ajax({
                    url: url,
                    type: 'POST',
                    contentType: 'application/json; charset=utf-8',
                    success: function (data) {
                        resolve(data);
                    },
                    error: function (xhr, status, error) {
                        resolve({ status: "error" });
                    }
                });
            });
        }
    }).then(function (retorno) {
        if (retorno) {
            if (retorno.status !== "error") {
                swal(msgsuccess, "", "success").then(function () {
                    window.location.reload();
                });

                return;
            }

            swal("Ocorreu um erro", "Não foi possível excluir o registro.", "error");
        }
    });
}