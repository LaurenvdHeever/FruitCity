<template>
<transition name="modal">
 <div class="modal" style="display: block"> 
  <div   class="modal-dialog" role="document">
    <div class="modal-content">    
      <div class="modal-body">  
        <div class="modal-close" align="right">
          <slot name="close"></slot>        
        </div>      
        <div class="row">                             
          <div class="col-sm-15">          
           <div class="panel-heading">                                      
             <h1> {{ details.product.name }} </h1>
             <h4> {{ details.product.description}} </h4>
             <h3> {{ details.product.currencyCode }} {{ details.product.price }}.00 </h3>
           </div>         
          </div>          
         </div>                                  
        <div class="col-sm-15" v-if="details.special" :key="details.special">         
         <div class="panel-heading">
          <h2> Current Special </h2>
          <h4> {{ details.special.specialText}} </h4>
        </div>           
        </div>        
        <div class="col-sm-15" v-if="details.restriction" :key="details.restriction">         
         <div class="panel-heading">
          <h2> We're Sorry </h2>
          <h4> {{ details.restriction.restrictionText}} </h4>
         </div>           
        </div>
          <div>
          <a href="img"><img :src="'/static/img/' + details.product.productId + '.png'" class="img-responsive" style="width:20%" alt="Image"></a>	   
        </div>
    </div>          
  </div>
 </div>
 </div>
</transition>
</template>

<script>
export default {
 props: ['details']
}
</script>

<style scoped>
.modal-dialog {
 position: absolute;
        top: 45%;
        left: 50%;
        transform: translate(-50%, -50%);
height: 700px;
width: 300px;
display: inline-block;
vertical-align: middle;
}
</style>
