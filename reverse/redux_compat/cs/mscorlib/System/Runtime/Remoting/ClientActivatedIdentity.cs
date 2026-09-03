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
	internal class ClientActivatedIdentity : ServerIdentity // TypeDefIndex: 2890
	{
		// Fields
		private MarshalByRefObject _targetThis; // 0x70
	
		// Constructors
		public ClientActivatedIdentity(string objectUri, Type objectType); // 0x00000001814B3450-0x00000001814B34C0
	
		// Methods
		public MarshalByRefObject GetServerObject(); // 0x00000001806CCC00-0x00000001806CCC10
		public void SetClientProxy(MarshalByRefObject obj); // 0x0000000180434A10-0x0000000180434A20
		public override void OnLifetimeExpired(); // 0x00000001814B3350-0x00000001814B33B0
		public override IMessage SyncObjectProcessMessage(IMessage msg); // 0x00000001814B33B0-0x00000001814B3450
		public override IMessageCtrl AsyncObjectProcessMessage(IMessage msg, IMessageSink replySink); // 0x00000001814B3290-0x00000001814B3350
	}
}
