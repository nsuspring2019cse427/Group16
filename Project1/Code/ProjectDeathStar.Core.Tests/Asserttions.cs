using NUnit.Framework;
using System;

namespace DeathStar.Core.Tests
{
	internal class Assertions
	{
		public void AssertThrows<TException>(TestDelegate test, string message = "")
			where TException : Exception
			=> Assert.Multiple(() =>
			{
				var ex = Assert.Throws<TException>(test);
				if (!string.IsNullOrEmpty(message))
					Assert.AreEqual(message.Trim(), ex.Message);
			});

		public void AssertCatch<TException>(TestDelegate test, string message = "")
			where TException : Exception
			=> Assert.Multiple(() =>
			{
				var ex = Assert.Catch<TException>(test);
				if (!string.IsNullOrEmpty(message))
					Assert.AreEqual(message.Trim(), ex.Message);
			});
	}
}
