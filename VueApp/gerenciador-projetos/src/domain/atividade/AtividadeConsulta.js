export default class AtividadeConsulta {

    constructor(atividadeID = 0, codigoIdentificador = '', descricao = '', numeroOrdenacao = '', valoresEsforco = '', esforcoEstimado = '', esforcoReal = '', projetoID = 0, projetoDescricao = '') {

        this.atividadeID = atividadeID;
        this.codigoIdentificador = codigoIdentificador;
        this.descricao = descricao;
        this.numeroOrdenacao = numeroOrdenacao;
        this.valoresEsforco = valoresEsforco;
        this.esforcoEstimado = esforcoEstimado;
        this.esforcoReal = esforcoReal;
        this.projetoID = projetoID;
        this.projetoDescricao = projetoDescricao;
    }

    mapear(atividade = { atividadeID: 0, codigoIdentificador: '', descricao: '', numeroOrdenacao: '', valoresEsforco: '', esforcoEstimado: '', esforcoReal: '', projetoID: 0, projetoDescricao: '' }) {

        this.atividadeID = atividadeID;
        this.codigoIdentificador = codigoIdentificador;
        this.descricao = descricao;
        this.numeroOrdenacao = numeroOrdenacao;
        this.valoresEsforco = valoresEsforco;
        this.esforcoEstimado = esforcoEstimado;
        this.esforcoReal = esforcoReal;
        this.projetoID = projetoID;
        this.projetoDescricao = projetoDescricao;
    }
}