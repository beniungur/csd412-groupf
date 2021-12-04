
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
			int newId = 1;
			TradeEvent tradeReceivingPlant = new TradeEvent();

			tradeReceivingPlant.Id = newId;

			Assert.Equal(tradeReceivingPlant.Id, newId);
		}

		[Theory]
		[InlineData(1, 1)]
		[InlineData(2, 2)]
		[InlineData(3, 3)]
		public void TradeReceivingPlantAcceptsAllValues(int newId, int expected)
		{
			TradeEvent tradeReceivingPlant = new TradeEvent();

			tradeReceivingPlant.Id = newId;
			
			Assert.Equal(tradeReceivingPlant.Id, expected);
		}
	}
}