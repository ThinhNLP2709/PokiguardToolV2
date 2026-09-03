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

namespace System.Runtime.Remoting
{
	internal class DisposerReplySink : IMessageSink // TypeDefIndex: 2893
	{
		// Fields
		private IMessageSink _next; // 0x10
		private IDisposable _disposable; // 0x18
	
		// Constructors
		public DisposerReplySink(IMessageSink next, IDisposable disposable); // 0x0000000180CB0730-0x0000000180CB0780
	
		// Methods
		public IMessage SyncProcessMessage(IMessage msg); // 0x00000001814B90C0-0x00000001814B9140
		public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink); // 0x00000001814B9080-0x00000001814B90C0
	}
}
