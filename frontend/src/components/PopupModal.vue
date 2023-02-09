<template>
    <div class="popup">
        <div class="popup-inner">
            <slot></slot>
            <button class="popup-close" @click="togglePopup">
                Close 
            </button>
        </div>
    </div>
</template>

<script>

export default {

    props: [

        'togglePopup'

    ]

}

</script>


<style scoped>

    .popup{
        position: fixed;
        top: 0;
        left: 0;
        right: 0;
        bottom: 0;
        z-index: 100;
        background-color: rgba(0,0,0,0.2);
        display: flex;
        align-items: center;
        justify-content: center;
    }

    .popup-inner{

        background-color: white;
        height: 500px;
        width: 500px;
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
        border-radius: 10px;
    }

    button {
        margin-bottom: -15px;
        margin-top: 20px;
        height: 30px;
        width: 150px;
        font-size: 15px;
        border: none;
        background-color:dodgerblue;
        border-radius: 5px;
        color: white;
        cursor: pointer;
    }


</style>