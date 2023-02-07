<template>
  <div>
    <MusicList></MusicList>
    <MusicForm></MusicForm>
  </div>

</template>

<script>
import MusicList from './components/MusicList.vue';
import MusicForm from './components/MusicForm.vue';

export default {
  name: 'App',
  components: {
    MusicList,
    MusicForm,
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
