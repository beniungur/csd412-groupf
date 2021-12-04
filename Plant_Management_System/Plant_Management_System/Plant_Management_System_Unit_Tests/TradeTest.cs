
using Plant_Management_System.Models;
using System;
using Xunit;

namespace Plant_Management_System_Unit_Tests
{
	public class TradeTest
	{
		// Trade Model Tests
		[Fact]
		public void TradeReceivingPlantCheck()
		{
			string newReceivingPlant = "Special Plant";
			Trade tradeReceivingPlant = new Trade();

			tradeReceivingPlant.ReceivingPlant = newReceivingPlant;

			Assert.Equal(tradeReceivingPlant.ReceivingPlant, newReceivingPlant);
		}

		[Theory]
		[InlineData("Special Plant", "Special Plant")]
		[InlineData("Fern", "Fern")]
		[InlineData("", "")]
		public void TradeReceivingPlantAcceptsAllValues(String newReceivingPlant, string expected)
		{
			Trade tradeReceivingPlant = new Trade();

			tradeReceivingPlant.ReceivingPlant = newReceivingPlant;

			Assert.Equal(tradeReceivingPlant.ReceivingPlant, expected);
		}
	}
}