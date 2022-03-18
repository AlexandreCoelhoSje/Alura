import BaseService from "../_base/BaseService";
export default class TarefaService extends BaseService {

    constructor(vueInstance) {

        super(vueInstance);

        this._uri = this._uri + '/tarefa';
    }
}