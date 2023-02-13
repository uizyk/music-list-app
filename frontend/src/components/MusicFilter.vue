<template>
    <form id="filter-container" @submit.prevent="submitFilter">

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

        <button>Submit</button>

    </form>



</template>


<script>

export default {

    props: {
        togglePopupFilter: Function,
    },

    data() {
        return{
            startDate: "",
            endDate: ""
        }
    },

    methods: {

        submitFilter(){
            let dateformat = /^(18[0-9]{2}|1[9][0-9]{2}|2[0-4][0-9]{2})-(0?[1-9]|1[012])-(0?[1-9]|[12][0-9]|3[01])$/;
            // e.evt.preventDefault()
            if( this.startDate.match(dateformat) && this.endDate.match(dateformat)){

                this.$emit('submit-filter', {
                    startDate: this.startDate,
                    endDate: this.endDate
                });
                this.togglePopupFilter();
            } else {
                alert("enter a valid date");
            }
            this.startDate = "";
            this.endDate = "";
        }
        
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