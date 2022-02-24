<script>
import ProjetoService from "@/domain/projeto/ProjetoService";

export default {
  data() {
    return {
      projetos: []
    };
  },
  created() {

    var self = this;
    this.service = new ProjetoService(this.$jquery);

    this.service
      .lista({})
      .done(function (projetos) {

        self.projetos = projetos;  
        console.log("ProjetoService.Lista sucesso ", projetos);      
      })
      .fail(function (jqXHR, textStatus) {
        console.log("ProjetoService.Lista erro " + textStatus);
      });
  },
  methods: {
    formatarData(data) {
      return new Date(data).toLocaleDateString();
    }
  }
};
</script>

<template>
  <div class="row">
    <div class="col-10">
      <form>
        <div class="row mb-3">
          <label
            for="inputDescricao"
            class="col-sm-2 col-md-1 col-form-label col-form-label-sm"
          >
            Descrição
          </label>
          <div class="col-sm-8 col-md-3">
            <input
              type="text"
              class="form-control form-control-sm"
              id="inputDescricao"
              placeholder="digite parte da descrição"
            />
          </div>
          <div class="col-sm-2 col-md-2">
            <button type="submit" class="btn btn-primary">Filtrar</button>
            <router-link class="btn btn-primary ms-1" to="/projeto/novo"
              >Novo</router-link
            >
          </div>
        </div>
      </form>
    </div>
  </div>

  <table class="table table-striped table-hover">
    <thead class="table-dark">
      <tr>
        <th></th>
        <th>Descrição</th>
        <th>Data Inicio</th>
        <th>Situação</th>
        <th>A Fazer</th>
        <th>Fazendo</th>
        <th>Feitas</th>
        <th></th>
        <th></th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="projeto in projetos" :key="projeto.projetoID">
        <td>
          <img class="icone-proj" src="src/assets/projeto.png" />
        </td>
        <td>{{ projeto.descricao }}</td>
        <td>{{ formatarData(projeto.dataInicial) }}</td>
        <td>{{ projeto.situacaoProjeto.descricao }}</td>
        <td class="text-center"></td>
        <td class="text-center"></td>
        <td class="text-center"></td>
        <td class="text-primary">
          <router-link :to="{ name: 'ProjetoEditar', params: { id: projeto.projetoID } }"
            >Editar</router-link
          >
        </td>
        <td class="text-danger">Excluir</td>
      </tr>
    </tbody>
  </table>
</template>

<style scoped>
.icone-proj {
  width: 30px;
}
</style>
