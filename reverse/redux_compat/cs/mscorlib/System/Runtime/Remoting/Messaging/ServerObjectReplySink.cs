/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Messaging
{
	internal class ServerObjectReplySink : IMessageSink // TypeDefIndex: 3006
	{
		// Fields
		private IMessageSink _replySink; // 0x10
		private ServerIdentity _identity; // 0x18
	
		// Constructors
		public ServerObjectReplySink(ServerIdentity identity, IMessageSink replySink); // 0x00000001814CFB00-0x00000001814CFB50
	
		// Methods
		public IMessage SyncProcessMessage(IMessage msg); // 0x00000001814EBB00-0x00000001814EBB80
		public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink); // 0x00000001814EBAC0-0x00000001814EBB00
	}
}
