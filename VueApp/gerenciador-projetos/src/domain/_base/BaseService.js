export default class BaseService {

    constructor(vueInstance) {

        this.$jquery = vueInstance.$jquery;
        this.$constHttp = vueInstance.$constHttp;
        this._uri = this.$constHttp.urlApi();

        this.$jquery.ajaxSetup({
            async: true,
            cache: false,
            headers: {
                'Content-Type': 'application/json'
            }
        });
    }

    lista(filtros) {

        return this.$jquery.ajax({
            method: "GET",
            url: this._uri,
            data: filtros
        });
    }

    detalha(id) {

        return this.$jquery.ajax({
            method: "GET",
            url: this._uri + '/' + id,
            data: {}
        });
    }

    cadastra(entidade) {

        return this.$jquery.ajax({
            method: "POST",
            url: this._uri,
            data: JSON.stringify(entidade)
        });
    }

    altera(entidade) {
        return this.$jquery.ajax({
            method: "PUT",
            url: this._uri + '/' + entidade.id,
            data: JSON.stringify(entidade)
        });
    }

    apaga(id) {

        return this.$jquery.ajax({
            method: "DELETE",
            url: this._uri + '/' + id,
            data: {}
        });
    }
}