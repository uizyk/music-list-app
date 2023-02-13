<template>
    <form>
        <div>
            <label>Song Title</label>
            <input ref="title" type="text" v-model="songTitle" name="songTitle"/>
        </div>
        <div>
            <label>Artist</label>
            <input ref="artist" type="text" v-model="artist" name="artist"/>
        </div>
        <div>
            <label>Genre</label>
            <input ref="genre" type="text" v-model="genre" name="genre"/>
        </div>
        <div>
            <label>Releast Date</label>
            <input ref="releaseDate" type="date" v-model="releaseDate" name="releaseDate"/>
        </div>
        <button v-if="clickedOnAdd" type="submit" @click="onCreate">Submit</button>
        <button v-else type="submit" @click="onUpdate" @mousedown="clickedOnAddFalse">Submit</button>

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
            APIUrl: 'http://localhost:55527/api/song'

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

        onCreate(e) {
            let dateformat = /^(18[0-9]{2}|1[9][0-9]{2}|2[0-4][0-9]{2})-(0?[1-9]|1[012])-(0?[1-9]|[12][0-9]|3[01])$/;
            let x = this.$refs
            if(x.title.value.length !== 0 
                && x.artist.value.length !== 0
                && x.genre.value.length !== 0
                ) {
                    if( x.releaseDate.value.match(dateformat)){
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
                        .catch((error) => {
                            alert(error)
                        })

                        console.log("Created successfully")
                    } else {
                        e.preventDefault();
                        alert("Please enter a valid date")
                    }
                } else {
                    e.preventDefault();
                    alert("Please enter all the inputs before submitting")
                }

        },
        onUpdate(e) {
            let dateformat = /^(18[0-9]{2}|1[9][0-9]{2}|2[0-4][0-9]{2})-(0?[1-9]|1[012])-(0?[1-9]|[12][0-9]|3[01])$/;
            let x = this.$refs
            if(x.title.value.length !== 0 
                && x.artist.value.length !== 0
                && x.genre.value.length !== 0){
                    if( x.releaseDate.value.match(dateformat)){

                        axios.put(`${this.APIUrl}?songId=${this.music.SongId}`, 
                        {
                            SongId: this.music.SongId,
                            SongName: this.songTitle,
                            Artist: this.artist,
                            Genre: this.genre,
                            DateOfRelease: this.releaseDate
                        })
                        .then((response) => {
                            alert(response.data);
                        })
                        .catch(error => {
                            console.error(error)
                        })

                        console.log("Updated successfully")

                    } else {
                        e.preventDefault();
                        alert("Please enter a valid date")
                    }
                } else {
                    e.preventDefault();
                    alert("Please enter all the inputs before submitting");
                }
        },


    }
}

</script>

<style scoped>

form{
    height: 400px;
    width: 400px;
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

button {
    width: 180px;
    height: 40px;
    font-size: 20px;
    margin-top: 5px;
    border: none;
    border-radius: 5px;
    background-color: dodgerblue;
    color: white;
    cursor: pointer;
}

input {
    width: 300px;
    align-self: center;
    text-align: center;
    height: 25px;
    font-size: 20px;
}

</style>