
using Plant_Management_System.Models;
using System;
using Xunit;

namespace Plant_Management_System_Unit_Tests
{
	public class PlantTest
	{
		// Plant Model Tests
		[Fact]
		public void PlantNameCheck()
		{
			string newName = "Special Plant";
			Plant plantName = new Plant();

			plantName.Name = newName;

			Assert.Equal(plantName.Name, newName);
		}

		[Theory]
		[InlineData("Special Plant", "Special Plant")]
		[InlineData("Fern", "Fern")]
		[InlineData("", "")]
		public void PlantNameAcceptsAllValues(String newName, string expected)
		{
			Plant plantName = new Plant();

			plantName.Name = newName;

			Assert.Equal(plantName.Name, expected);
		}
	}
}