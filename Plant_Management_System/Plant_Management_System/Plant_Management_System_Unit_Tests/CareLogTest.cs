
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
			string newCareDone = "Changed Soil";
			CareLog careDone = new CareLog();

			careDone.CareDone = newCareDone;

			Assert.Equal(careDone.CareDone, newCareDone);
		}

		[Theory]
		[InlineData("Changed Soil", "Changed Soil")]
		[InlineData("Watered Plant", "Watered Plant")]
		[InlineData("", "")]
		public void CareLogAcceptsAllValues(String newCareDone, string expected)
		{
			CareLog careDone = new CareLog();

			careDone.CareDone = newCareDone;

			Assert.Equal(careDone.CareDone, expected);
		}
	}
}