<template>
  <div class="container" >

    <v-stage
      ref="stageMain" style="background-color:#e7e7e7;"
      :config="stageSize">

      <v-layer ref="layer">

      </v-layer>
    </v-stage>


    <div :style="{ top: stageSize.height + 'px' }" style="width: 100%;height: 150px;background-color: aliceblue;padding: 10px;position: absolute;" >
      <div class="row" style="display:flex;">

        <div class="col-3" style="visibility: hidden;">
          포인트 이름 : {{testData[0].pId}} <br/><br/>
          포인트 값 : {{testData[0].pValue}} <br/>

          <div style="margin-top: 20px;">
            <label for="name">Setting Value : </label>
            <input type="text" id="name" name="name" v-model="settingVal" required minlength="4" maxlength="8" size="10" style="text-align: center;" >
            <button type="button" v-on:click="clickBtn" > SetValue </button>
          </div>
        </div>

        <div class="col-5" style="background-color: #eee; border: solid 2px #bbb; padding-top: 10px;">
          <div >
            <button type="button" @click="renderLayer"> Render 10400 Object </button>

            <p style="margin-top:10px;" >ms : {{ms}} </p>
          </div>
        </div>



      </div>
    </div>


  </div>
</template>

<script>
import Vue from 'vue';
import VueKonva from 'vue-konva'

Vue.use(VueKonva)

const width = window.innerWidth;
const height = 835;

var layer = null

export default {
  beforeMount(){
    this.testData.push({ pId: "-", pValue:0 } )
  },
  mounted() {
    const vm = this;

    const stage = vm.$refs.stageMain.getStage()
    stage.attrs.container.style.backgroundColor = "black"

    layer = vm.$refs.layer.getNode()



    console.log(stage)
    console.log(layer)


    let recrSize = 10

    for (let y = 0; y < 50; y= y+10) {

      for (let i = 0; i < 100; i++) {

        var rect = new Konva.Rect({
          x: 20 + this.offset,
          y: 20 + y,
          width: recrSize,
          height: recrSize,
          fill: 'red',
          stroke: 'white',
          strokeWidth: 1,
          pointId:'S0001'
        });

        layer.add(rect)

        this.offset += (1 + recrSize)
      }

      this.offset = 0

    }


    layer.draw()

  },
  created(){
    console.log("create!!")
  },

  data: function() {
    return {
      offset: 0,
      testData: [],
      testVal: null,
      pointName: '',
      settingVal:0,
      intervalNav: null,

      stageSize: {
        width: width,
        height: height,
      },
      rectX:50,
      rectY:50,
      rectangles: [
        {
          rotation: 0,
          x: 10,
          y: 10,
          width: 100,
          height: 100,
          scaleX: 1,
          scaleY: 1,
          fill: 'yellow',
          name: 'rect1',
          draggable: true
        },
        {
          rotation: 0,
          x: 150,
          y: 150,
          width: 100,
          height: 100,
          scaleX: 1,
          scaleY: 1,
          fill: 'blue',
          name: 'rect2',
          draggable: true,
        },
      ],
      statusFlag : true,
      ms: 0


    }
  },
  methods:{
    renderLayer() {

      //data
      let data = [
        {status:0},{status:0},{status:0},{status:0},{status:0},
        {status:0},{status:0},{status:0},{status:0},{status:0}
      ]


      let startProc1 = new Date();




      layer.draw()

      let endProc1 = new Date();

      this.ms = (endProc1 - startProc1)

      this.statusFlag = !this.statusFlag

    },
    handleTransformEnd(e) {

    },
    clickBtn: function(){
      console.log("set value click >>")

      console.log(this.settingVal)

      this.testData[0].pValue = this.settingVal
    }


  }
}
</script>

<style>
.container {
  margin: 0 auto;
  min-height: calc(100vh - 50px); /* Nav Height : 50px */
  display: flex;
  justify-content: center;
  align-items: baseline;
  text-align: center;
}

.title {
  font-family: 'Quicksand', 'Source Sans Pro', -apple-system, BlinkMacSystemFont,
    'Segoe UI', Roboto, 'Helvetica Neue', Arial, sans-serif;
  display: block;
  font-weight: 300;
  font-size: 100px;
  color: #35495e;
  letter-spacing: 1px;
}

.subtitle {
  font-weight: 300;
  font-size: 42px;
  color: #526488;
  word-spacing: 5px;
  padding-bottom: 15px;
}

.links {
  padding-top: 15px;
}
.nuxt-progress {
    visibility: hidden;
}

</style>
