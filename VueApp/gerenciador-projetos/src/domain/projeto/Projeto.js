export default class Projeto {

    constructor(projetoID = '', descricao = '', resumo = '', dataInicial = '', dataFinal = '', situacaoProjeto = '') {

        this.projetoID = projetoID;
        this.descricao = descricao;
        this.resumo = resumo;
        this.dataInicial = dataInicial;
        this.dataFinal = dataFinal;
        this.situacaoProjeto = situacaoProjeto;
    }

    projetoDTO(projeto) {
        this.projetoID = projeto.projetoID;
        this.descricao = projeto.descricao;
        this.resumo = projeto.resumo;
        this.dataInicial = projeto.dataInicial;
        this.dataFinal = projeto.dataFinal;
        this.situacaoProjetoID = projeto.situacaoProjetoID;
    }
}