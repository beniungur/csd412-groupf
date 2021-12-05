
using Plant_Management_System.Models;
using System;
using Xunit;

namespace Plant_Management_System_Unit_Tests
{
	public class CareLogTest
	{
		// CareLog Model Tests
		[Fact]
		public void CareLogCareCheck()
		{
			CareTasks newCareDone = CareTasks.Water;
			CareLogEvent careDone = new CareLogEvent();

			careDone.CareDone = newCareDone;

			Assert.Equal(careDone.CareDone, newCareDone);
		}

		[Theory]
		[InlineData(CareTasks.Water, CareTasks.Water)]
		[InlineData(CareTasks.Clean, CareTasks.Clean)]
		[InlineData(CareTasks.Prune, CareTasks.Prune)]
		public void CareLogAcceptsAllValues(CareTasks newCareDone, CareTasks expected)
		{
			CareLogEvent careDone = new CareLogEvent();

			careDone.CareDone = newCareDone;

			Assert.Equal(careDone.CareDone, expected);
		}
	}
}