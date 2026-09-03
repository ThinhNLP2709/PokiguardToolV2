/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting
{
	internal class SingleCallIdentity : ServerIdentity // TypeDefIndex: 2892
	{
		// Constructors
		public SingleCallIdentity(string objectUri, Context context, Type objectType); // 0x00000001814C6C90-0x00000001814C6D00
	
		// Methods
		public override IMessage SyncObjectProcessMessage(IMessage msg); // 0x00000001814C6EA0-0x00000001814C7020
		public override IMessageCtrl AsyncObjectProcessMessage(IMessage msg, IMessageSink replySink); // 0x00000001814C6D00-0x00000001814C6EA0
	}
}
