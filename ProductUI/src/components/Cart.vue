  <template>
  <div id="cart" style="width: 50em; margin:0 67em;">
    <div id="content">     
      <h1>Shopping Cart</h1>
      <p  class="text-muted">You currently have {{cart.cartItems.length}} item(s) in your cart.</p>
        <div class="table-responsive">
          <table class="table">
            <thead>
              <tr> 
               <th colspan="1">Product</th>
               <th colspan="1">Quantity</th>
               <th colspan="2">Item price</th>
               <th colspan="2">Total Price</th>
               <th colspan="2">Discount</th>
               <th colspan="1">Update</th>
               <th colspan="1">Remove</th>
             </tr>
             </thead>
             <tbody>
              <tr valign="middle" align="left" v-for="item in cart.cartItems" :key="item.ProductId">
               <td colspan="1" style="width: 2em;">{{ item.name }}</td>
               <td colspan="1"><input min="1" style="width: 4em;" type="number" class="form-control" v-model="item.quantity"></td>
               <td colspan="2" style="width: 7em;">{{ item.currencyCode }} {{ item.itemPrice }}.00</td>
               <td colspan="2" style="width: 4em;">{{ item.currencyCode }} {{ item.totalItemPrice }}.00</td>
               <td colspan="2" style="width: 4em;">{{ item.currencyCode }} {{ item.discount }}.00</td>
               <td colspan="1" style="width: 6em;"><button class="btn btn-info" @click="updateCartItem(item.productId,item.quantity)"><h5 class="glyphicon glyphicon-plus"></h5></button></td>
               <td colspan="1" style="width: 6em;"><button class="btn btn-info" @click="removeItemFromCart(item.productId)"><h5 class="glyphicon glyphicon-remove"></h5></button></td>		    
             </tr>
            </tbody>
            <tfoot>
             <tr>
              <th colspan="2"><h4>Cart Total: R {{ cart.totalCartPrice }}.00</h4></th>
              <th colspan="8"></th>
             </tr>
             <div class="pull-right">
              <router-link :to="'/'" class="btn btn-default"><i class="fa fa-chevron-left"></i>Continue Shopping</router-link>
             </div>
            </tfoot>
          </table>
        </div>
    </div>
    <app-showrestrictionerror v-if="showRestrictionError">
	  </app-showrestrictionerror>	
  </div>
</template>

<script>
import axios from 'axios'
var config = require('../config.js')
import ShowRestrictionError from '@/components/ShowRestrictionError'

export default {
  components: {   	
	'app-showrestrictionerror': ShowRestrictionError
	},  
  data () {
    return {
    cart: {
    cartItems: []},
    showRestrictionError: false
    }
  }, 
  created () {
	this.getCart();
	},
	methods:
	{
	  getCart()
	  {        
      axios.get(config.API.getCart).then((response) => {
        this.cart = response.data;
      }).catch( error => {console.log(error); });    
    },
    removeItemFromCart(productId)
	  {  
      axios.post(config.API.removeCartItem + productId).then((response) => {	 	
        axios.get(config.API.getCart).then((response) => {
        this.cart = response.data;
        }).catch( error => {console.log(error); });    
      }).catch( error => {console.log(error); });					
    },
    updateCartItem(productId, quantity)
	  {  
		axios.post(config.API.updateCartItemProduct + productId + config.API.updateCartItemQuantity + quantity).then((response) => {
      response.status;
       axios.get(config.API.getCart).then((response) => {
       this.cart = response.data;
       }).catch( error => {console.log(error); });       	
    }).catch((error) => {
          if (error.response) {
          this.showRestrictionError = true;
          setTimeout(() => { this.showRestrictionError = false;	}, 500);
          }
        });
    }
  }	
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
