using Plant_Management_System.Models;
using System;
using Xunit;

namespace Plant_Management_System_Unit_Tests
{
	public class PropagationTest
	{
		// Propagation Model Tests
		[Fact]
		public void PropagationTypeCheck()
		{
			DateTime newDate = new DateTime(2010, 3, 11);
			PropagationEvent dateCheck = new PropagationEvent();

			dateCheck.PropDate = newDate;

			Assert.Equal(dateCheck.PropDate, newDate);
		}

		[Theory]
		
		[InlineData("2000, 1, 1", "2000, 1, 1")]
		[InlineData("2001, 1, 1", "2001, 1, 1")]
		[InlineData("2003, 1, 1", "2003, 1, 1")]
		public void PropagationTypeAcceptsAllValues(DateTime newDate, DateTime expected)
		{
			PropagationEvent dateCheck = new PropagationEvent();

			dateCheck.PropDate = newDate;

			Assert.Equal(dateCheck.PropDate, expected);
		}
	}
}