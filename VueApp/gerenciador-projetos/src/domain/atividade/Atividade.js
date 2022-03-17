export default class Atividade {

    constructor(atividadeID = 0, codigoIdentificador = '', descricao = '', observacao = '', numeroOrdenacao = '', valoresEsforco = '', esforcoEstimado = '', esforcoReal = '', projetoID = 0, SprintID = 0, colunaKanbanID = 0) {

        this.atividadeID = atividadeID;
        this.codigoIdentificador = codigoIdentificador;
        this.descricao = descricao;
        this.observacao = observacao;
        this.numeroOrdenacao = numeroOrdenacao;
        this.valoresEsforco = valoresEsforco;
        this.esforcoEstimado = esforcoEstimado;
        this.esforcoReal = esforcoReal;
        this.projetoID = projetoID;
        this.dprintID = dprintID;
        this.colunaKanbanID = colunaKanbanID;
    }

    entidadeDTO(atividade = { atividadeID: 0, codigoIdentificador: '', descricao: '', observacao: '', numeroOrdenacao: '', valoresEsforco: '', esforcoEstimado: '', esforcoReal: '', projetoID: 0, SprintID: 0, colunaKanbanID: 0 }) {

        this.atividadeID = atividade.atividadeID;
        this.codigoIdentificador = atividade.codigoIdentificador;
        this.descricao = atividade.descricao;
        this.observacao = atividade.observacao;
        this.numeroOrdenacao = atividade.numeroOrdenacao;
        this.valoresEsforco = atividade.valoresEsforco;
        this.esforcoEstimado = atividade.esforcoEstimado;
        this.esforcoReal = atividade.esforcoReal;
        this.projetoID = atividade.projetoID;
        this.dprintID = atividade.dprintID;
        this.colunaKanbanID = atividade.colunaKanbanID;
    }
}