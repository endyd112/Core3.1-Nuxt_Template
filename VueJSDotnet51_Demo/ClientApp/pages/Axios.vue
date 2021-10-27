<template>

    <div>
        {{this.callbackData}}
    </div>


</template>

<script>
export default {

    data: function(){
        return{
            callbackData: [1,2,3]
        }
    },
    mounted(){
        console.log('axios page mounted')

        console.log(this)
        this.$axios.$get('/WeatherForecast').then(res =>{
            console.log(res)
            this.callbackData = res
        })
    }
}
</script>

<style>

</style>