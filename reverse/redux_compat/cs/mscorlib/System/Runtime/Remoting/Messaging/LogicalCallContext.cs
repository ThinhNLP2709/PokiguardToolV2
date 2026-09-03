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
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Messaging
{
	[Serializable]
	[ComVisible(true)]
	public sealed class LogicalCallContext : ISerializable, ICloneable // TypeDefIndex: 2962
	{
		// Fields
		private static Type s_callContextType; // 0x00
		private Hashtable m_Datastore; // 0x10
		private CallContextRemotingData m_RemotingData; // 0x18
		private CallContextSecurityData m_SecurityData; // 0x20
		private object m_HostContext; // 0x28
		private bool m_IsCorrelationMgr; // 0x30
	
		// Properties
		public bool HasInfo { get; } // 0x00000001814DF060-0x00000001814DF0C0 
		private bool HasUserData { get; } // 0x00000001814DD840-0x00000001814DD880 
		private Hashtable Datastore { get; } // 0x00000001814DEFF0-0x00000001814DF060 
	
		// Nested types
		internal struct Reader // TypeDefIndex: 2963
		{
			// Fields
			private LogicalCallContext m_ctx; // 0x00
	
			// Properties
			public bool IsNull { get; } // 0x0000000180E87410-0x0000000180E87420 
			public bool HasInfo { get; } // 0x00000001814E9740-0x00000001814E97C0 
	
			// Constructors
			public Reader(LogicalCallContext ctx); // 0x0000000180E02C90-0x0000000180E02CA0
	
			// Methods
			public LogicalCallContext Clone(); // 0x00000001814E9620-0x00000001814E9690
			public object GetData(string name); // 0x00000001814E9690-0x00000001814E9740
		}
	
		// Constructors
		internal LogicalCallContext(); // 0x00000001802E5CB0-0x00000001802E5CC0
		internal LogicalCallContext(SerializationInfo info, StreamingContext context); // 0x00000001814DE8E0-0x00000001814DEFF0
		static LogicalCallContext(); // 0x00000001814DE860-0x00000001814DE8E0
	
		// Methods
		public void GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001814DE0C0-0x00000001814DE470
		public object Clone(); // 0x00000001814DD880-0x00000001814DE020
		internal void Merge(LogicalCallContext lc); // 0x00000001814DE470-0x00000001814DE770
		public object GetData(string name); // 0x00000001814DE020-0x00000001814DE0C0
		public void SetData(string name, object data); // 0x00000001814DE770-0x00000001814DE860
	}
}
