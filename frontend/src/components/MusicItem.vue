<template>
    <div class="container">
        <!-- <p >{{ music.SongId }}</p> -->
        <p>{{music.SongName}}</p>
        <p>{{music.Artist}}</p>
        <p>{{music.Genre}}</p>
        <p>{{music.DateOfRelease}}</p>
        <div>
            <button @click="togglePopup(music)">Edit</button>
            <button @click="onDelete(music)">Delete</button>
        </div>

    </div>
</template>

<script>
export default {
    props: {
        music: Object,
        togglePopup: Function,
        onDelete: Function
    },
    
}

</script>

<style scoped>

    .container {
        display: flex;
        justify-content: space-around;
        width: 80vw;
        gap: 70px;
    
    
    }

    .container button{
        align-items: center;
        align-self: center;
    }
    .container p {
        width: 200px;
        text-align: left;
        font-size: 20px;
    }

</style>