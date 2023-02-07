<template>

<div>

    <div>
        <h2>Title</h2>
        <h2>Artist</h2>
        <h2>Genre</h2>
        <h2>Release Date</h2>
        <button>Add new song</button>
    </div>
    <div v-for="song in songs" :key="song.id">
        <MusicItem :music="song"></MusicItem>
    </div>

</div>

</template>


<script>
import MusicItem from "./MusicItem.vue"
import musicService from "@/services/music.service";


export default {
    components: {
        MusicItem
    },

    data() {
        return{
          songs: []
        };
      },
      created() {
        this.fetchMusic();
      },
      methods: {
        fetchMusic() {
          musicService.getSong().then(response => {
            this.songs = response.data;
          });
        }
      }
    }



</script>