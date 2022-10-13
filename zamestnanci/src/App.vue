<template>

<div class="navbar navbar-expand-lg navbar-light justify-content-center">
 <nav class="navbar navbar-expand navbar">
    <ul class="navbar-nav">
      <li class="nav-item">
        <router-link class="nav-link" to="/">Zoznam aktuálnych zamestnancov</router-link>
      </li>
      <li class="nav-item">
        <router-link class="nav-link" to="/archivovany">Zoznam predošlých zamestnancov</router-link>
      </li>
      <li class="nav-item">
        <router-link class="nav-link" to="/Pozicie">Zoznam pozícií vo firme</router-link>
      </li>
    </ul>
</nav>
</div>
<router-view/>

</template>


<style>

#app {
  font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif, -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  background: #fcfcfc;
  font-size: 18px;
}
nav a {
  font-weight:inherit;
  font-size: 26px;
}
</style>
