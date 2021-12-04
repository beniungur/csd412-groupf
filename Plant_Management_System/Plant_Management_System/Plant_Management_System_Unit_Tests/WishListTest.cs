
using Plant_Management_System.Models;
using System;
using Xunit;

namespace Plant_Management_System_Unit_Tests
{
	public class WishListTest
	{
		// WishList Model Tests
		[Fact]
		public void WishListBudgetCheck()
		{
			double newBudget = 20.00;
			WishList wishListBudget = new WishList();

			wishListBudget.Budget = newBudget;

			Assert.Equal(wishListBudget.Budget, newBudget);
		}

		[Theory]
		[InlineData(20.00, 20.00)]
		[InlineData(.42, .42)]
		[InlineData(0,0 )]
		public void WishListBudgetAcceptsAllValues(double newBudget, double expected)
		{
			WishList wishListBudget = new WishList();

			wishListBudget.Budget = newBudget;

			Assert.Equal(wishListBudget.Budget, expected);
		}
	}
}