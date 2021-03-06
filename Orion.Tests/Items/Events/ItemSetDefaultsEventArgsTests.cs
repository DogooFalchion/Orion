﻿using System;
using NUnit.Framework;
using Orion.Items.Events;

namespace Orion.Tests.Items.Events
{
	[TestFixture]
	public class ItemSetDefaultsEventArgsTests
	{
		[Test]
		public void Constructor_NullItem_ThrowsArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(() => new ItemSetDefaultsEventArgs(null));
		}
	}
}
