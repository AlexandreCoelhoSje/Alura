export default class Projeto {

    constructor(projetoID = 0, descricao = '', resumo = '', dataInicial = '', dataFinal = '', situacaoProjetoID = 0, situacaoProjeto = { situacaoProjetoID: 0, descricao: '' }) {

        this.projetoID = projetoID;
        this.descricao = descricao;
        this.resumo = resumo;
        this.dataInicial = dataInicial;
        this.dataFinal = dataFinal;
        this.situacaoProjetoID = situacaoProjetoID;
        this.situacaoProjeto = {
            situacaoProjetoID: 1,
            descricao: "Aberto"
        }
    }

    projetoDTO(projeto = { projetoID: 0, descricao: '', resumo: '', dataInicial: '', dataFinal: '', situacaoProjetoID: 0, situacaoProjeto: { situacaoProjetoID: 0, descricao: '' } }) {

        this.projetoID = projeto.projetoID;
        this.descricao = projeto.descricao;
        this.resumo = projeto.resumo;
        this.dataInicial = projeto.dataInicial;
        this.dataFinal = projeto.dataFinal;
        this.situacaoProjetoID = situacaoProjetoID;
        this.situacaoProjeto = {
            situacaoProjetoID: 1,
            descricao: "Aberto"
        }
    }
}