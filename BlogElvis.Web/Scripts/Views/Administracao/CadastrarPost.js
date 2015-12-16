﻿$(document).ready(function () {
    Tags = new Array();
    $("#adicionar").on('click', function () {
        var textoTag = $('#Tag').val();

        if (textoTag.trim() === '') {
            alert('O campo TAG é obrigatório.');
            $('#Tag').focus();
            return;
        }

        var existe = Tags.filter(function (v) {
            return v.Tag.toLowerCase() === textoTag.toLowerCase();
        })[0];
        if (existe != undefined) {
            alert('Esta TAG já foi informada.');
            return;
        }

        Tags.push(new Object({ Tag: textoTag }));
        montaListaPeloArray();

        $('#Tag').val('');
        $('#Tag').focus();
    });

    function montaListaPeloArray() {
        var form = $('form');
        $('input[Name="Tags"]').remove();
        $('#resultado').empty();
        $(Tags).each(function () {
            $('#resultado').append('<li><span>' + this.Tag + '</span><a tag="' + this.Tag + '" class="remover-tag icone-excluir" title="Remover"></a></li>');
            form.append('<input name="Tags" type="hidden" value="' + this.Tag + '" />')
        });
    }

    $('body').on('click', '.remover-tag', function () {
        var tag = $(this).attr('tag');

        Tags = $.grep(Tags, function (e) {
            return e.Tag !== tag;
        });

        montaListaPeloArray();
    });

    $("input[Name='Tags']")
    .map(function () {
        var tag = $(this).val();
        Tags.push(new Object({ Tag: tag }));
    }).get();
});
