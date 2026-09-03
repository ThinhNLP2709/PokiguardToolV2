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

namespace System.Runtime.Remoting.Contexts
{
	internal class CrossContextChannel : IMessageSink // TypeDefIndex: 2919
	{
		// Nested types
		private class ContextRestoreSink : IMessageSink // TypeDefIndex: 2920
		{
			// Fields
			private IMessageSink _next; // 0x10
			private Context _context; // 0x18
			private IMessage _call; // 0x20
	
			// Constructors
			public ContextRestoreSink(IMessageSink next, Context context, IMessage call); // 0x00000001803A7D10-0x00000001803A7D80
	
			// Methods
			public IMessage SyncProcessMessage(IMessage msg); // 0x00000001814D7F70-0x00000001814D8160
			public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink); // 0x00000001814D7F30-0x00000001814D7F70
		}
	
		// Constructors
		public CrossContextChannel(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public IMessage SyncProcessMessage(IMessage msg); // 0x00000001814D9530-0x00000001814D9880
		public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink); // 0x00000001814D9150-0x00000001814D9530
	}
}
