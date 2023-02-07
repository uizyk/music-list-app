<template>
    <div className="container">

        <p>{{music.SongName}}</p>
        <p>{{music.Artist}}</p>
        <p>{{music.Genre}}</p>
        <p>{{music.DateOfRelease}}</p>
        <div>
            <button>Edit</button>
            <button>Delete</button>
        </div>

    </div>
</template>

<script>

export default {
    props: {
        music: Object
    }
}

</script>

<style scoped>

    .container {
        display: flex;
        justify-content: space-around;

        
    }

</style>