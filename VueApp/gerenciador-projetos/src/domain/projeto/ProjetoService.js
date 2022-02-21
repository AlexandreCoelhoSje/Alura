export default class ProjetoService {

    constructor($jquery) {

        this._uri = '/api/projeto'; //'/projeto/api/projeto';
        this.$jquery = $jquery;
        this.$jquery.ajaxSetup({
            async: true,
            cache: false,
            dataType: 'json'
        });
    }

    lista(filtros) {

        return this.$jquery.ajax({
            method: "GET",
            url: this._uri,
            data: filtros
        });
    }

    detalha(id, sucesso, erro) {

        this.$jquery.ajax({
                method: "GET",
                url: this._uri + '/' + id,
                data: {}
            })
            .done(function(retorno) {

                console.log("ProjetoService.detalha Retorno: ", retorno);
                sucesso(retorno);
            })
            .fail(function(jqXHR, textStatus) {

                console.log('ProjetoService.detalha erro ' + textStatus);
                erro(textStatus);
            });
    }

    cadastra(entidade, sucesso, erro) {

        this.$jquery.ajax({
                method: "POST",
                url: this._uri,
                data: entidade
            })
            .done(function(retorno) {

                console.log("Retorno: ", retorno);
                sucesso(retorno);
            })
            .fail(function(jqXHR, textStatus) {

                console.log('ProjetoService.cadastra erro ' + textStatus);
            });

    }

    altera(entidade, sucesso, erro) {

        this.$jquery.ajax({
                method: "PUT",
                url: this._uri + '/' + entidade.id,
                data: entidade
            })
            .done(function(retorno) {

                console.log("Retorno: ", retorno);
                sucesso(retorno);
            })
            .fail(function(jqXHR, textStatus) {

                console.log('ProjetoService.altera erro ' + textStatus);
            });
    }

    apaga(id, sucesso, erro) {

        this.$jquery.ajax({
                method: "DELETE",
                url: this._uri + '/' + id,
                data: entidade
            })
            .done(function(retorno) {

                console.log("Retorno: ", retorno);
                sucesso(retorno);
            })
            .fail(function(jqXHR, textStatus) {

                console.log('ProjetoService.apaga erro ' + textStatus);
            });
    }

}