export default {

    formatarData(data) {
        return new Date(data).toLocaleDateString();
    },

    gerarIdComDataHora() {

        // Obtém a data/hora atual
        var data = new Date();

        // Guarda cada pedaço em uma variável
        var dia = data.getDate(); // 1-31
        var mes = data.getMonth(); // 0-11 (zero=janeiro)
        var ano4 = data.getFullYear(); // 4 dígitos
        var hora = data.getHours(); // 0-23
        var min = data.getMinutes(); // 0-59
        var seg = data.getSeconds(); // 0-59
        var mseg = data.getMilliseconds(); // 0-999

        return ano4 + mes + dia + hora + min + seg + mseg;
    }
}