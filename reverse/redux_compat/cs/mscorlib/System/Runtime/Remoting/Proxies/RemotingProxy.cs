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
using System.Runtime.Remoting.Messaging;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Proxies
{
	internal class RemotingProxy : RealProxy, IRemotingTypeInfo // TypeDefIndex: 2906
	{
		// Fields
		private static MethodInfo _cache_GetTypeMethod; // 0x00
		private static MethodInfo _cache_GetHashCodeMethod; // 0x08
		private IMessageSink _sink; // 0x50
		private bool _hasEnvoySink; // 0x58
		private ConstructionCall _ctorCall; // 0x60
	
		// Properties
		public string TypeName { get; } // 0x00000001814C1D10-0x00000001814C1E30 
	
		// Constructors
		internal RemotingProxy(Type type, ClientIdentity identity); // 0x00000001814C1B10-0x00000001814C1C20
		internal RemotingProxy(Type type, string activationUrl, object[] activationAttributes); // 0x00000001814C1C20-0x00000001814C1D10
		static RemotingProxy(); // 0x00000001814C1A10-0x00000001814C1B10
	
		// Methods
		public override IMessage Invoke(IMessage request); // 0x00000001814C14C0-0x00000001814C1A10
		internal void AttachIdentity(Identity identity); // 0x00000001814C0E80-0x00000001814C1170
		internal IMessage ActivateRemoteObject(IMethodMessage request); // 0x00000001814C0DA0-0x00000001814C0E80
		public bool CanCastTo(Type fromType, object o); // 0x00000001814C1170-0x00000001814C13D0
		~RemotingProxy(); // 0x00000001814C13D0-0x00000001814C14C0
	}
}
