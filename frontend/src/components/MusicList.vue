<template>

<div id="musicList">

    <div className="header">
        <h2>Title</h2>
        <h2>Artist</h2>
        <h2>Genre</h2>
        <h2>Release Date</h2>
        <button class="addSongButton" @click="togglePopup" @mousedown="clickedOnAdd = true">Add new song</button>
    </div>
    <div v-for="song in songs" :key="song.SongId">
        <MusicItem :music="song" :togglePopup="togglePopup" :onDelete="onDelete"></MusicItem>
    </div>
    <PopupModal v-if="formIsVisible" :togglePopup="togglePopup">
      
      <MusicForm :music="selectedSong" :clickedOnAdd="clickedOnAdd" :clickedOnAddFalse="clickedOnAddFalse"></MusicForm>

      <!-- <MusicForm v-else></MusicForm> -->

    </PopupModal>
    

</div>

</template>


<script>
import axios from "axios";
import MusicItem from "./MusicItem.vue";
import MusicForm from "./MusicForm.vue";
import PopupModal from "./PopupModal.vue";



export default {
    components: {
        MusicItem,
        MusicForm,
        PopupModal
    },
    data() {
      return{
        songs: [],
        formIsVisible: false,
        selectedSong: null,
        APIUrl: 'http://localhost:55527/api/song',
        clickedOnAdd: false

      };
    },
    setup () {
      return {
        PopupModal
      }
    },
    created() {
      this.fetchMusic();
    },
    methods: {
      fetchMusic() {
        axios.get(this.APIUrl)
        .then(response => {
          this.songs = response.data;
        });
      },
      togglePopup(song){
        this.formIsVisible = !this.formIsVisible
          this.selectedSong = song;
      },
      onDelete(song){
        this.selectedSong = song;
        axios.delete(`${this.APIUrl}/${song.SongId}`)
        .then(response => {
          alert(response.data)
          window.location.reload();
        })
      },

      clickedOnAddFalse(){
        this.clickedOnAdd = false;
      }
      
      
    }
  }



</script>

<style scoped>


  #musicList{
    display: flex;
    flex-direction: column;
    align-items: center;

  }

  .header {
    width: 100vw;
    display: flex;
    justify-content: space-evenly;
    /* border: 0.5px solid black; */
    padding: 10px;
    background: #222831;
    margin-bottom: 40px;
  }

  .header h2 {
    color: white;
  }

  .header button {
    border: none;
    border-radius: 5px;
    font-size: 15px;
    font-weight:600;
    background-color: white; 
    color: black;
    height: 35px;
    width: 130px;
    align-self: center;
    cursor: pointer;
  }


</style>