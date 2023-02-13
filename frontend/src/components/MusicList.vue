<template>

<div id="musicList">

    <div className="header">
        <h2>Title</h2>
        <h2>Artist</h2>
        <h2>Genre</h2>
        <h2 id="release-date" @click="arrangeByDate">Release Date</h2>
        <div className="buttonDiv">
          <button class="addSongButton" @click="togglePopup" @mousedown="clickedOnAdd = true"><i class="fa-solid fa-plus"></i></button>
          <button @click="togglePopupFilter"><i class="fa-solid fa-filter"></i></button>
        </div>
    </div>
    <div v-if="filteredSongs.length === 0">
      <div v-for="song in songs" :key="song.SongId">
          <MusicItem :music="song" :togglePopup="togglePopup" :onDelete="onDelete"></MusicItem>
      </div>
    </div>
    <div v-else>
      <div v-for="song in filteredSongs" :key="song.SongId">
          <MusicItem :music="song" :togglePopup="togglePopup" :onDelete="onDelete"></MusicItem>
      </div>
    </div>

    <PopupModal v-if="formIsVisible" :togglePopup="togglePopup" :formIsVisible="formIsVisible">
      
      <MusicForm :music="selectedSong" :clickedOnAdd="clickedOnAdd" :clickedOnAddFalse="clickedOnAddFalse"></MusicForm>

    </PopupModal>
    <PopupModal v-if="filterIsVisible" :togglePopupFilter="togglePopupFilter" :filterisVisible="filterIsVisible">

      <MusicFilter 
        @submit-filter="applyFilter" 
        :togglePopupFilter="togglePopupFilter" 
        :songs="songs">
      </MusicFilter>

    </PopupModal>
    

</div>

</template>


<script>
import axios from "axios";
import MusicItem from "./MusicItem.vue";
import MusicForm from "./MusicForm.vue";
import PopupModal from "./PopupModal.vue";
import MusicFilter from "./MusicFilter.vue";



export default {
    components: {
        MusicItem,
        MusicForm,
        PopupModal,
        MusicFilter
    },
    data() {
      return{
        filteredSongs: [],
        songs: [],
        formIsVisible: false,
        filterIsVisible: false,
        selectedSong: null,
        APIUrl: 'http://localhost:55527/api/song',
        clickedOnAdd: false,

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
          this.songs = response.data.sort((a, b) => a.SongId - b.SongId)
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
      },
      togglePopupFilter(){
        this.filterIsVisible = !this.filterIsVisible
      },


       applyFilter(filter){
        let songsToFilter = this.songs.sort((a, b) => new Date(a.DateOfRelease) - new Date(b.DateOfRelease))
        this.filteredSongs = songsToFilter.filter(song => {
          return (song.DateOfRelease >= filter.startDate && song.DateOfRelease <= filter.endDate) && (song.Artist.toLowerCase() === filter.enteredArtistName.toLowerCase());
        });
        if (this.filteredSongs.length === 0) {
          alert("no match found")
        }
      },

      
      arrangeByDate(){
        this.songs.sort((a, b) => new Date(a.DateOfRelease) - new Date(b.DateOfRelease))
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

  .buttonDiv {

    align-self: center;
    display: flex;
    justify-content: space-around;
    width: 100px;

  }

  .header button {
    border: none;
    border-radius: 5px;
    font-size: 15px;
    font-weight:600;
    background-color: white; 
    color: black;
    height: 35px;
    width: 40px;
    cursor: pointer;
  }

  #release-date{
    cursor: pointer;
  }


</style>