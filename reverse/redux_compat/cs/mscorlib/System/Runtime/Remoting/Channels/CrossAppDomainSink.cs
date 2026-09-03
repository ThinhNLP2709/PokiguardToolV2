/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Channels
{
	[MonoTODO("Handle domain unloading?")]
	internal class CrossAppDomainSink : IMessageSink // TypeDefIndex: 2934
	{
		// Fields
		private static Hashtable s_sinks; // 0x00
		private static MethodInfo processMessageMethod; // 0x08
		private int _domainID; // 0x10
	
		// Properties
		internal int TargetDomainId { get; } // 0x00000001802E64B0-0x00000001802E64C0 
	
		// Nested types
		private struct ProcessMessageRes // TypeDefIndex: 2935
		{
			// Fields
			public byte[] arrResponse; // 0x00
			public CADMethodReturnMessage cadMrm; // 0x08
		}
	
		// Constructors
		internal CrossAppDomainSink(int domainID); // 0x00000001802F9040-0x00000001802F9070
		static CrossAppDomainSink(); // 0x00000001814D9050-0x00000001814D9150
	
		// Methods
		internal static CrossAppDomainSink GetSink(int domainID); // 0x00000001814D8730-0x00000001814D89F0
		private static ProcessMessageRes ProcessMessageInDomain(byte[] arrRequest, CADMethodCallMessage cadMsg); // 0x00000001814D89F0-0x00000001814D8AF0
		public virtual IMessage SyncProcessMessage(IMessage msgRequest); // 0x00000001814D8BB0-0x00000001814D8F90
		public virtual IMessageCtrl AsyncProcessMessage(IMessage reqMsg, IMessageSink replySink); // 0x00000001814D8650-0x00000001814D8730
		public void SendAsyncMessage(object data); // 0x00000001814D8AF0-0x00000001814D8BB0
		[CompilerGenerated]
		private void _AsyncProcessMessage_b__10_0(object data); // 0x00000001814D8F90-0x00000001814D9050
	}
}
