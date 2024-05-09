// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    
    $('#EstadoId').change(function (event) {
        var estadoId = $(this).val();
        if (estadoId) {
            $('#CidadeId').prop('disabled', false);
            $('#CidadeId').empty();
            $.ajax({
                url: '/Alunos/GetCidadesByEstado',
                type: 'GET',
                data: { estadoId: estadoId },
                success: function (response) {
                    $('#CidadeId').append($('<option>').text('Selecione a cidade').attr('value', ''));
                    $.each(response, function (i, cidade) {
                        $('#CidadeId').append($('<option>').text(cidade.nome).attr('value', cidade.cidadeId));
                    });
                },
                error: function (xhr, status, error) {
                    console.error(xhr.responseText);
                }
            });
        } else {
            $('#CidadeId').prop('disabled', true);
            $('#CidadeId').empty();
            $('#CidadeId').append($('<option>').text('Selecione o estado primeiro').attr('value', ''));
        }
    });

    $('#searchInput').on('input', function () {
        var searchText = $(this).val().toLowerCase();
        $('.table-body tr').each(function () {
            var rowData = $(this).text().toLowerCase();
            if (rowData.indexOf(searchText) === -1) {
                $(this).hide();
            } else {
                $(this).show();
            }
        });
    });

    $('#cpfInput').mask('000.000.000-00', { reverse: true });

    $('#cpfInput').on('blur', function () {
        var cpf = $(this).val().replace(/\D/g, '');

        if (!validateCPF(cpf)) {
           // alert('CPF inválido. Por favor, insira um CPF válido.');
            $(this).val('');
        }
    });

    function validateCPF(cpf) {
        var cpfRegex = /^[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}$/;

        return cpfRegex.test(cpf);
    }

});

