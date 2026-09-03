/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Messaging
{
	internal class ServerObjectTerminatorSink : IMessageSink // TypeDefIndex: 3005
	{
		// Fields
		private IMessageSink _nextSink; // 0x10
	
		// Constructors
		public ServerObjectTerminatorSink(IMessageSink nextSink); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public IMessage SyncProcessMessage(IMessage msg); // 0x00000001814EBD20-0x00000001814EBE40
		public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink); // 0x00000001814EBB80-0x00000001814EBD20
	}
}
