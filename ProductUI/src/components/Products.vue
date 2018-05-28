<template>
<div class="container">	
	<app-productdetails v-if="showModal"  v-bind:details="details">
		<div slot="close">
			<button type="button" class="btn btn-outline-info" @click="closeModal()"> X </button>
		</div>
	</app-productdetails>
	<div class="row">
		<div class="col-sm-3" style="width: 16em; margin:80px; 50px" v-for="product in products" :key="product.productId">
			<a href="img"><img :src="'/static/img/' + product.productId + '.png'" class="img-responsive" style="width:50em" alt="Image"></a>				
			<div class="panel-heading">
				<h1> {{ product.name}} </h1>
				<h4> {{ product.description}} </h4>
			</div>
			<div class="panel-price">
				<h3> {{ product.currencyCode }} {{ product.price }}.00 </h3>
				</div>
			<div class="panel-footer">
				<button class="btn btn-info" @click="openModal(product.productId)"><h5 class="glyphicon glyphicon-eye-open"></h5></button>
				<button class="btn btn-info" @click="addItemToCart(product.productId)"><h5 class="glyphicon glyphicon-shopping-cart"></h5></button>
			</div>
		</div>		
	</div>
	<app-showaddtocart v-if="showAddToCart">
	</app-showaddtocart>	
</div>
</template>

<script>
import axios from 'axios'
var config = require('../config.js')
import ProductDetails from '@/components/ProductDetails'
import ShowAddToCart from '@/components/ShowAddToCart'

export default {
  components: {   
	'app-productdetails': ProductDetails,
	'app-showaddtocart': ShowAddToCart
	},
  data () {			
	  return {
		products: [],
		details: [],
		showModal: false,
		showAddToCart: false
	  }
  },  
  created () {
	this.getProducts(config.API.getProducts);
	},
	methods:
	{
	  getProducts(section)
	  {        
			axios.get(section).then((response) => {
				this.products = response.data;
			}).catch( error => {console.log(error); });    
		},		
	  openModal (productId)
	  {
			axios.get(config.API.getProductDetails + productId).then((response) => {
				this.details = response.data;
				this.showModal = true;
			}).catch( error => {console.log(error); });
		},
		addItemToCart(productId)
	  {  
			axios.post(config.API.addCartItem + productId).then((response) => {
				this.showAddToCart = true;
				setTimeout(() => { this.showAddToCart = false; }, 500);
			}).catch( error => {console.log(error); });
			},
	  closeModal ()
	  {
	 		this.showModal = false;
	  }
	}
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.modal-mask {
  position: fixed;
  z-index: 2000;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, .5);
  display: table;
  transition: opacity .3s ease;
}
</style>
