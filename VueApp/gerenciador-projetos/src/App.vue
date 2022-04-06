<script>
export default {
    data() {
        return {
        };
    },
    created() { },
    watch: {
        $route(to, from) {
            if (this.$jquery('#offcanvasNavbar').hasClass('show')) {
                this.$jquery('#btnToggleSide').trigger('click');
                this.$jquery('#body').blur();
            }
        }
    }
};
</script>

<template>
    <div id="app">
        <header class="fixed-top">
            <nav class="navbar navbar-dark bg-dark">
                <div class="container-fluid flex-nowrap justify-content-beetween">
                    <router-link class="navbar-brand" to="/">D&S</router-link>

                    <button
                        id="btnToggleSide"
                        class="navbar-toggler"
                        type="button"
                        data-bs-toggle="offcanvas"
                        data-bs-target="#offcanvasNavbar"
                        aria-controls="offcanvasNavbar"
                    >
                        <span class="navbar-toggler-icon"></span>
                    </button>

                    <div id="navTextoPrincipal" class="ps-4">
                        <span class="navbar-text">Bem Vindo, Alexandre</span>
                    </div>

                    <ul id="navMenuPrincipal" class="navbar-nav">
                        <li class="nav-item">
                            <a class="nav-link" href="#">Sair</a>
                        </li>
                    </ul>
                </div>
            </nav>
        </header>

        <aside
            class="offcanvas offcanvas-start"
            tabindex="-1"
            id="offcanvasNavbar"
            aria-labelledby="offcanvasNavbarLabel"
        >
            <div class="offcanvas-header">
                <h5 class="offcanvas-title" id="offcanvasNavbarLabel">Menu</h5>
                <button
                    type="button"
                    class="btn-close text-reset"
                    data-bs-dismiss="offcanvas"
                    aria-label="Close"
                ></button>
            </div>

            <hr />

            <div class="offcanvas-body">
                <ul class="navbar-nav justify-content-end flex-grow-1 pe-3">
                    <li class="nav-item">
                        <router-link class="nav-link" to="/">Painel Inicial</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link" to="/projeto">Projeto</router-link>
                    </li>
                     <li class="nav-item">
                        <router-link class="nav-link" :to="{ name:'Atividade'}">Atividade</router-link>
                    </li>
                </ul>
            </div>
        </aside>

        <div id="corpoPrincipal">
            <div class="container-fluid">
                <div class="row justify-content-center">
                    <div class="col-10">
                        <router-view></router-view>
                    </div>
                </div>
            </div>
        </div>

        <footer class="bg-dark">

        </footer>
    </div>
</template>

<style scoped>
header .navbar {
    padding-top: 0;
    padding-bottom: 0;
}

header .navbar-brand {
    width: 15%;
    padding-left: 45px;
}

header .navbar-toggler {
    padding: 0.1rem 0.5rem;
}

header #navTextoPrincipal {
    width: 70%;
}
header #navMenuPrincipal {
    width: 10%;
}

#corpoPrincipal {
    height: 97vh;
    width: 100%;
    padding: 50px;
    background-color: #fff;
}

footer {
    height: 3vh;
}

/* xs */

/* sm */
@media (min-width: 576px) {
}

/* md */
@media (min-width: 768px) {
}

/* lg */
@media (min-width: 992px) {
}

/* xl */
@media (min-width: 1200px) {
}

/* xxl */
@media (min-width: 1400px) {
}
</style>
