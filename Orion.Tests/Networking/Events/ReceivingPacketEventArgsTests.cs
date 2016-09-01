﻿using System;
using Multiplicity.Packets;
using NUnit.Framework;
using Orion.Networking.Events;

namespace Orion.Tests.Networking.Events
{
	[TestFixture]
	public class ReceivingPacketEventArgsTests
	{
		[Test]
		public void Constructor_NullSender_ThrowsArgumentNullException()
		{
			var packet = new ConnectRequest();
			Assert.Throws<ArgumentNullException>(() => new ReceivingPacketEventArgs(null, packet));
		}

		[Test]
		public void Constructor_NullPacket_ThrowsArgumentNullException()
		{
			var sender = new Terraria.RemoteClient();
			Assert.Throws<ArgumentNullException>(() => new ReceivingPacketEventArgs(sender, null));
		}
	}
}
