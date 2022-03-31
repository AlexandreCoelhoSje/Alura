export default class Projeto {

    constructor(projetoID = 0, descricao = '', resumo = '', dataInicial = '', dataFinal = '', situacaoProjetoID = 0, situacaoProjeto = { situacaoProjetoID: 0, descricao: '' }, totalAtividades = 0, atividadesAFazer = 0, atividadesFazendo = 0, atividadesFeitas = 0) {

        this.projetoID = projetoID;
        this.descricao = descricao;
        this.resumo = resumo;
        this.dataInicial = dataInicial;
        this.dataFinal = dataFinal;
        this.situacaoProjetoID = situacaoProjetoID;
        this.situacaoProjeto = {
            situacaoProjetoID: 1,
            descricao: Aberto
        };
        this.totalAtividades = totalAtividades;
        this.atividadesAFazer = atividadesAFazer;
        this.atividadesFazendo = atividadesFazendo;
        this.atividadesFeitas = atividadesFeitas;
    }

    mapear(projeto = { projetoID: 0, descricao: '', resumo: '', dataInicial: '', dataFinal: '', situacaoProjetoID: 0, situacaoProjeto: { situacaoProjetoID: 0, descricao: '' }, totalAtividades: 0, atividadesAFazer: 0, atividadesFazendo: 0, atividadesFeitas: 0 }) {

        this.projetoID = projeto.projetoID;
        this.descricao = projeto.descricao;
        this.resumo = projeto.resumo;
        this.dataInicial = projeto.dataInicial;
        this.dataFinal = projeto.dataFinal;
        this.situacaoProjetoID = projeto.situacaoProjetoID;
        this.situacaoProjeto = projeto.situacaoProjeto;
        this.totalAtividades = projeto.totalAtividades;
        this.atividadesAFazer = projeto.atividadesAFazer;
        this.atividadesFazendo = projeto.atividadesFazendo;
        this.atividadesFeitas = projeto.atividadesFeitas;
    }
}