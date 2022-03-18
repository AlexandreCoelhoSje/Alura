import BaseService from "../_base/BaseService";
export default class ProjetoService extends BaseService {

    constructor(vueInstance) {

        super(vueInstance);

        this._uri = this._uri + '/projeto';
    }
}