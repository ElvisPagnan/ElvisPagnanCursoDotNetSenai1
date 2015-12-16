$(document).ready(function () {
    $('.excluir-post').on('click',function(e){
        //alert ('Olá, este é um alerta do java Script');
        if (!confirm('Deseja realmente excluir esse post?')){
            e.preventDefault();
        }
    });

    $('.excluir-usuario').on('click', function (e) {
        //alert ('Olá, este é um alerta do java Script');
        if (!confirm('Deseja realmente excluir esse usuário?')) {
            e.preventDefault();
        }
    });
});