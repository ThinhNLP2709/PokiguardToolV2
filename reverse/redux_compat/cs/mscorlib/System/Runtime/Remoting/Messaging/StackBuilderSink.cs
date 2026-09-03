/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Proxies;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Messaging
{
	internal class StackBuilderSink : IMessageSink // TypeDefIndex: 3007
	{
		// Fields
		private MarshalByRefObject _target; // 0x10
		private RealProxy _rp; // 0x18
	
		// Constructors
		public StackBuilderSink(MarshalByRefObject obj, bool forceInternalExecute); // 0x00000001814ECBF0-0x00000001814ECCA0
	
		// Methods
		public IMessage SyncProcessMessage(IMessage msg); // 0x00000001814ECAE0-0x00000001814ECBD0
		public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink); // 0x00000001814EC3E0-0x00000001814EC530
		private void ExecuteAsyncMessage(object ob); // 0x00000001814EC910-0x00000001814ECAE0
		private void CheckParameters(IMessage msg); // 0x00000001814EC530-0x00000001814EC910
		[CompilerGenerated]
		private void _AsyncProcessMessage_b__4_0(object data); // 0x00000001814ECBD0-0x00000001814ECBF0
	}
}
