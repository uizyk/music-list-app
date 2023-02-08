<template>
    <form>
        <div>
            <label>Song Title</label>
            <input required type="text" v-model="songTitle" name="songTitle"/>
        </div>
        <div>
            <label>Artist</label>
            <input required type="text" v-model="artist" name="artist"/>
        </div>
        <div>
            <label>Genre</label>
            <input required type="text" v-model="genre" name="genre"/>
        </div>
        <div>
            <label>Releast Date</label>
            <input required type="date" v-model="releaseDate" name="releaseDate"/>
        </div>
        <button v-if="clickedOnAdd" type="submit" @click="onCreate">Submit create</button>
        <button v-else type="submit" @click="onUpdate" @mousedown="clickedOnAddFalse">Submit edit</button>

    </form>
</template>

<script>
import axios from 'axios';


export default {
    data() {
        return{
            songTitle: '',
            artist: '',
            genre: '',
            releaseDate: '',
            APIUrl: 'http://localhost:55527/api/song/'

        }
    },
    props: {
        music: Object,
        clickedOnAdd: Boolean,
        clickedOnAddFalse: Function
    },
    created() {
        if(this.music){
            this.songId = this.music.SongId;
            this.songTitle = this.music.SongName;
            this.artist = this.music.Artist;
            this.genre = this.music.Genre;
            this.releaseDate = this.music.DateOfRelease;
        }
    },
    methods: {

        onCreate() {
            axios.post(this.APIUrl, 
            {
                SongName: this.songTitle,
                Artist: this.artist,
                Genre: this.genre,
                DateOfRelease: this.releaseDate
            })
            .then((response) => {
                alert(response.data);


            })
        },
        onUpdate() {
            axios.put(`${this.APIUrl}`, 
            {
                SongId: this.SongId,
                SongName: this.songTitle,
                Artist: this.artist,
                Genre: this.genre,
                DateOfRelease: this.releaseDate
            })
            .then((response) => {
                alert(response.data);
            })
        },


    }
}

</script>

<style scoped>

form{
    height: 400px;
    width: 400px;
    background-color: yellow;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: space-around;
}

form div{
    display: flex;
    flex-direction: column;
    text-align: center;
    width: 200px;
    gap: 8px;
}

div label{
    font-size: 1.5em;
}

</style>