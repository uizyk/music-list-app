<template>
    <form id="filter-container" @submit.prevent="submitFilter">
        <h3>Song Filter</h3>
        <div id="artist-filter-container">
            <label>Artist</label>
            <input type="text" v-model="enteredArtistName"/>
        </div>
        <div id="date-filter-container">
            <div>
                <label>Start Date</label>
                <input type="date" v-model="startDate"/>
            </div>
            <div>
                <label>End Date</label>
                <input type="date" v-model="endDate"/>
            </div>
        </div>

        <button @click="filterArtistNames">Submit</button>

    </form>



</template>


<script>


export default {

    props: [

        'togglePopupFilter',
        'songs'

    ]
    ,

    data() {
        return{
            startDate: "",
            endDate: "",
            enteredArtistName: "",
        }
    },

    methods: {

        submitFilter(){
            let dateformat = /^(18[0-9]{2}|1[9][0-9]{2}|2[0-4][0-9]{2})-(0?[1-9]|1[012])-(0?[1-9]|[12][0-9]|3[01])$/;
            // e.evt.preventDefault()
            let artistNames = this.songs.map(song => song.Artist.toLowerCase())
            if(artistNames.includes(this.enteredArtistName.toLowerCase())){

                if( this.startDate.match(dateformat) && this.endDate.match(dateformat)){
    
                    this.$emit('submit-filter', {
                        startDate: this.startDate,
                        endDate: this.endDate,
                        enteredArtistName: this.enteredArtistName
                    });
                    this.togglePopupFilter();
                } else {
                    alert("enter a valid date");
                }
            } else {
                alert("enter a existing artist")
            }
            this.startDate = "";
            this.endDate = "";
            this.enteredArtistName = "";
        },
        
    }
}

</script>

<style>

#filter-container {
    background-color: white;
    width: 400px;
    height: 400px;
    display: flex;
    justify-content: space-around;
    flex-direction: column;
}

#filter-container button {
    width: 200px;
    align-self:center;
    height: 40px;
    border: none;
    border-radius: 5px;
    font-size: 20px;
    background-color: dodgerblue;
    color: white;
}

#date-filter-container{
    display: flex;
    justify-content: space-around;
}

#date-filter-container div{
    display: flex;
    flex-direction: column;
    text-align: center;
    margin-top: 20px;
}

</style>