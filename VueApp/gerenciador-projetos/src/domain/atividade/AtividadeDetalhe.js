export default class AtividadeDetalhe {

    constructor(atividadeID = 0, codigoIdentificador = '', descricao = '', observacao = '', numeroOrdenacao = '', valoresEsforco = '', esforcoEstimado = '', esforcoReal = '', projetoID = 0, projetoDescricao = '') {

        this.id = atividadeID; //trocar isso, mudar os paametros da funcao de detalhar para receber esse parametro
        this.atividadeID = atividadeID;
        this.codigoIdentificador = codigoIdentificador;
        this.descricao = descricao;
        this.observacao = observacao;
        this.numeroOrdenacao = numeroOrdenacao;
        this.valoresEsforco = valoresEsforco;
        this.esforcoEstimado = esforcoEstimado;
        this.esforcoReal = esforcoReal;
        this.projetoID = projetoID;
        this.projetoDescricao = projetoDescricao;
    }

    mapear(atividade = { atividadeID: 0, codigoIdentificador: '', descricao: '', observacao: '', numeroOrdenacao: '', valoresEsforco: '', esforcoEstimado: '', esforcoReal: '', projetoID: 0, projetoDescricao: '' }) {

        this.id = atividade.atividadeID;
        this.atividadeID = atividade.atividadeID;
        this.codigoIdentificador = atividade.codigoIdentificador;
        this.descricao = atividade.descricao;
        this.observacao = atividade.observacao;
        this.numeroOrdenacao = atividade.numeroOrdenacao;
        this.valoresEsforco = atividade.valoresEsforco;
        this.esforcoEstimado = atividade.esforcoEstimado;
        this.esforcoReal = atividade.esforcoReal;
        this.projetoID = atividade.projetoID;
        this.projetoDescricao = atividade.projetoDescricao;
    }
}