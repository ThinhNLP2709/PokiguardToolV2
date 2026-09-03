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
	[Serializable]
	internal class EnvoyTerminatorSink : IMessageSink // TypeDefIndex: 2980
	{
		// Fields
		public static EnvoyTerminatorSink Instance; // 0x00
	
		// Constructors
		public EnvoyTerminatorSink(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static EnvoyTerminatorSink(); // 0x00000001814DA7E0-0x00000001814DA850
	
		// Methods
		public IMessage SyncProcessMessage(IMessage msg); // 0x00000001814DA780-0x00000001814DA7E0
		public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink); // 0x00000001814DA700-0x00000001814DA780
	}
}
