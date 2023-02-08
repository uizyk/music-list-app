<template>
  <div id="container">
    <MusicList></MusicList>
  </div>

</template>

<script>
import MusicList from './components/MusicList.vue';

export default {
  name: 'App',
  components: {
    MusicList,
  }
}
</script>

<style scoped>

* {

  margin: 0;
  padding: 0;

}

#container{
  display: flex;
  justify-content: center;
  padding: 20px;
}

</style>
