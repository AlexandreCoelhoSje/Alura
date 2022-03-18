import BaseService from "../_base/BaseService";
export default class AtividadeService extends BaseService {

    constructor(vueInstance) {

        super(vueInstance);

        this._uri = this._uri + '/atividade';
    }
}