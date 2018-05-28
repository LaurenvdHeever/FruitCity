using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAPI.Models
{
	public class ProductDetails
	{
		/// <summary>
		///   The details of the product.
		/// </summary>
		public Product Product { get; set; }
		
		/// <summary>
		///   The details of the restrictions applied to the product, if any.
		/// </summary>
		public Restriction Restriction { get; set; }

		/// <summary>
		///   The details of the special applied to the product, if any.
		/// </summary>
		public Special Special { get; set; }
	}
}