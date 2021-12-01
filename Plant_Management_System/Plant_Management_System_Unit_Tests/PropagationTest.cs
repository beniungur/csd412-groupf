using Plant_Management_System.Models;
using System;
using Xunit;

namespace Plant_Management_System_Unit_Tests
{
	public class PropagationTest
	{
		// Plant Model Tests
		[Fact]
		public void PropagationTypeCheck()
		{
			string newType = "Special Plant Prop";
			Propogation propagationType = new Propogation();

			propagationType.Type = newType;

			Assert.Equal(propagationType.Type, newType);
		}

		[Theory]
		[InlineData("Special Plant Prop", "Special Plant Prop")]
		[InlineData("Fern prop", "Fern prop")]
		[InlineData("", "")]
		public void PropagationTypeAcceptsAllValues(String newType, string expected)
		{
			Propogation propagationType = new Propogation();

            propagationType.Type = newType;

			Assert.Equal(propagationType.Type, expected);
		}
	}
}