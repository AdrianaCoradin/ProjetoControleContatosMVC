﻿// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

const { get } = require("jquery");

// Write your JavaScript code.

$(document).ready(function () {
    getDataTable('#table-contatos');
    getDataTable('#table-usuarios');

    $('.btn-total-contatos').click(function () {
        var usuario = $(this).attr('usuario-id')

        $.ajax({
            type: 'GET',
            url: '/Usuario/listarContatosPorUsuarioId/' + usuarioId,
            success: function (result) {
                $("#listaContatosUsuario").html(result);
                $('#modalContatosUsuario').modal();
                getDataTable('#table-contatos-usuario');
            }
        });    
    });
});

function getDataTable(id)
{
    $(id).DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Proximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Último"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
}

//let table = new DataTable('#table-contatos');

$('.close-alert').click(function () {
    $('.alert').hide('hide');
})