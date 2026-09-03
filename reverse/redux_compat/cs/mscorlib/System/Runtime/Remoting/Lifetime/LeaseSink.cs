/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Lifetime
{
	internal class LeaseSink : IMessageSink // TypeDefIndex: 2912
	{
		// Fields
		private IMessageSink _nextSink; // 0x10
	
		// Constructors
		public LeaseSink(IMessageSink nextSink); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public IMessage SyncProcessMessage(IMessage msg); // 0x00000001814BAAB0-0x00000001814BAB20
		public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink); // 0x00000001814BA870-0x00000001814BA8F0
		private void RenewLease(IMessage msg); // 0x00000001814BA8F0-0x00000001814BAAB0
	}
}
