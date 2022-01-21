function confirmToSubmit(titulo, mensaje, idFormToSubmit) {
    $('#confirmModal').remove();
    $('body').append('<div class="modal fade" id="confirmModal" tabindex="-1" role="dialog" aria-hidden="true"></div>');
    $('#confirmModal').append('<div class="modal-dialog">' +
        '<div class="modal-content">' +
        '<div class="modal-header">' +
        '<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button><br />' +
        '</div>' +

        '<div class="modal-header">' +
        '<div><h4 >' + titulo + '</h4></div><br />' +
        '<div><p>' + mensaje + '</p></div>' +
        '</div>' +
        '<div class="modal-footer">' +
        '<button data-dismiss="modal" class="btn btn-default">Cancelar</button>' +
        '<a href="javascript:void(0);" onclick="ProgressShow(); $(\'#' + idFormToSubmit + '\').submit();" data-dismiss="modal" class="btn btn-success">Confirmar</a>' +
        '</div>' +
        '</div>');
    $('#confirmModal').modal('toggle');
}



function url2modal(url, element, isStaticBackdrop = false) {
    ProgressShow();
    $('#' + element).remove();
    $('body').append('<div class="modal fade" id="' + element + '" tabindex="-1" role="dialog" aria-hidden="true" ' + (isStaticBackdrop ? 'data-backdrop="static" data-keyboard="false"' : '') + '></div>');
    $("#" + element).load(url, function (response, status, xhr) {
        try {
            if (JSON.parse(response).Url) {
                window.parent.location.href = JSON.parse(response).Url;
                return false;
            }
        }
        catch (e) {
            console.log("errooooor");
        }

        ProgressHide();
        if (status !== "error") {
            $('[data-toggle="tooltip"]').tooltip();

            $("form").submit(function () {
                $(this).find(":submit").attr('disabled', 'disabled');
            });

            $('#' + element).on('hidden.bs.modal', function () {
                $('#' + element).remove();
            });

            $('#' + element).modal('show');
        }
    });
}


function ProgressShow() {
    $('#cargandoModal').remove();
    $('body').append('<div class="modal" id="cargandoModal" tabindex="-1" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="false">' +
        '<div class= "modal-dialog modal-sm" style="width: 150px" > ' +
        '<div class="modal-content">' +
        '<div class="modal-body text-center">' +
        '<i class="la la-refresh la-spin la-5x la-fw" style="color:#FDD306"></i>' +
        '<h4 style="font-size:16px; padding-top:5px">Cargando...</h4>' +
        '</div>' +
        '</div>' +
        '</div>' +
        '</div>');
    $('#cargandoModal').modal('show');
}

function ProgressHide() {
    $('#cargandoModal').modal('hide');
}