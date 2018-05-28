<template>
  <div id="app">
  <app-header></app-header>
  <app-navigation></app-navigation>
  <router-view/>
  </div>
</template>

<script>
import AppHeader from '@/components/AppHeader'
import Navigation from '@/components/Navigation'

export default {
  name: 'App',
  components: {
    'app-header': AppHeader,
    'app-navigation': Navigation
  }
}
</script>

<style>
@import url("https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css");
@import url("http://fonts.googleapis.com/css?family=Roboto:400,500,700,300,100'");
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
