export default class Projeto {

    constructor(projetoID = 0, descricao = '', resumo = '', dataInicial = '', dataFinal = '', situacaoProjeto = { situacaoProjetoID: 0, descricao: '' }) {

        this.projetoID = projetoID;
        this.descricao = descricao;
        this.resumo = resumo;
        this.dataInicial = dataInicial;
        this.dataFinal = dataFinal;
        this.situacaoProjeto = situacaoProjeto;
    }

    projetoDTO(projeto) {
        this.id = projeto.projetoID;
        this.projetoID = projeto.projetoID;
        this.descricao = projeto.descricao;
        this.resumo = projeto.resumo;
        this.dataInicial = projeto.dataInicial;
        this.dataFinal = projeto.dataFinal;
        this.situacaoProjeto.situacaoProjetoID = projeto.situacaoProjeto.situacaoProjetoID;
    }
}