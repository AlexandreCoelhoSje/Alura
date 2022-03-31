export default class Tarefa {

    constructor(tarefaID = 0, descricao = '', ordem = '', atividadeID = 0) {

        this.tarefaID = tarefaID;
        this.descricao = descricao;
        this.ordem = ordem;
        this.atividadeID = atividadeID;
    }

    mapear(tarefa = { tarefaID: 0, descricao: '', ordem: '', atividadeID: 0 }) {

        this.tarefaID = tarefa.tarefaID;
        this.descricao = tarefa.descricao;
        this.ordem = tarefa.ordem;
        this.atividadeID = tarefa.atividadeID;
    }
}