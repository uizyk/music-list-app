<template>
    <form id="filter-container">

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

        <button @click="submitFilter">Submit</button>

    </form>



</template>


<script>

export default {

    data() {
        return{
            startDate: "",
            endDate: ""
        }
    },

    methods: {

        submitFilter(){
            // e.evt.preventDefault()
            this.$emit('submit-filter', {
                startDate: this.startDate,
                endDate: this.endDate
            });
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