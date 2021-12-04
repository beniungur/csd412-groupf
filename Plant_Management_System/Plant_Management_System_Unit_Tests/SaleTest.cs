using Plant_Management_System.Models;
using System;
using Xunit;

namespace Plant_Management_System_Unit_Tests
{
	public class SaleTest
	{
		// Sale Model Tests
		[Fact]
		public void SalePriceCheck()
		{
			double newListPrice = 20.00;
			SaleEvent SaleListPrice = new SaleEvent();

			SaleListPrice.ListPrice = newListPrice;

			Assert.Equal(SaleListPrice.ListPrice, newListPrice);
		}

		[Theory]
		[InlineData(20.00, 20.00)]
		[InlineData(.42, .42)]
		[InlineData(0,0 )]
		public void SaleListPriceAcceptsAllNumbers(double newListPrice, double expected)
		{
			SaleEvent SaleListPrice = new SaleEvent();

			SaleListPrice.ListPrice = newListPrice;

			Assert.Equal(SaleListPrice.ListPrice, expected);
		}
	}
}