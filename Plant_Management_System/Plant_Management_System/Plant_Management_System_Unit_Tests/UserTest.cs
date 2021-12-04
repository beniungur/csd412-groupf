
using Plant_Management_System.Models;
using System;
using Xunit;

namespace Plant_Management_System_Unit_Tests
{
	public class UserTest
	{
		// User Model Tests
		[Fact]
		public void UserNameCheck()
		{
			string newFirstName = "Bobloblaw";
			User userFirstName = new User();

			userFirstName.FirstName = newFirstName;

			Assert.Equal(userFirstName.FirstName, newFirstName);
		}

		[Theory]
		[InlineData("Bobloblaw", "Bobloblaw")]
		[InlineData("Answer", "Answer")]
		[InlineData("", "")]
		public void UserFirstNameAcceptsAllValues(String newFirstName, string expected)
		{
			User userFirstName = new User();

			userFirstName.FirstName = newFirstName;

			Assert.Equal(userFirstName.FirstName, expected);
		}
	}
}