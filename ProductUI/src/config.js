module.exports = (function () {
  var URL = 'http://localhost:50152/';

  var config = {
    API: {
      getProducts: URL + 'product/products',
      getProductDetails: URL + 'product/details/productId/',
      getCart: URL + 'cart',
      addCartItem: URL + 'cart/add/productId/',
      removeCartItem: URL + 'cart/remove/productId/',
      updateCartItemProduct: URL + 'cart/update/productId/',
      updateCartItemQuantity: '/quantity/'   
    }
  }
  return config;
})();