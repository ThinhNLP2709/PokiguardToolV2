/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting
{
	[Serializable]
	[ComVisible(true)]
	public class ObjRef : IObjectReference, ISerializable // TypeDefIndex: 2880
	{
		// Fields
		private IChannelInfo channel_info; // 0x10
		private string uri; // 0x18
		private IRemotingTypeInfo typeInfo; // 0x20
		private IEnvoyInfo envoyInfo; // 0x28
		private int flags; // 0x30
		private Type _serverType; // 0x38
		private static int MarshalledObjectRef; // 0x00
		private static int WellKnowObjectRef; // 0x04
	
		// Properties
		internal bool IsReferenceToWellKnow { get; } // 0x00000001814BCB40-0x00000001814BCBA0 
		public virtual IChannelInfo ChannelInfo { [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)] get; } // 0x0000000180377550-0x0000000180377560 
		public virtual IEnvoyInfo EnvoyInfo { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		public virtual IRemotingTypeInfo TypeInfo { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public virtual string URI { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		internal Type ServerType { get; } // 0x00000001814BCBA0-0x00000001814BCC50 
	
		// Constructors
		public ObjRef(); // 0x00000001814BCB20-0x00000001814BCB40
		internal ObjRef(string uri, IChannelInfo cinfo); // 0x00000001814BCAD0-0x00000001814BCB20
		internal ObjRef(Type type, string url, object remoteChannelData); // 0x00000001814BC450-0x00000001814BC570
		protected ObjRef(SerializationInfo info, StreamingContext context); // 0x00000001814BC570-0x00000001814BCAD0
		static ObjRef(); // 0x00000001814BC400-0x00000001814BC450
	
		// Methods
		internal ObjRef DeserializeInTheCurrentDomain(int domainId, byte[] tInfo); // 0x00000001814BBF20-0x00000001814BC060
		internal byte[] SerializeType(); // 0x00000001814BC2C0-0x00000001814BC350
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001814BC060-0x00000001814BC1E0
		public virtual object GetRealObject(StreamingContext context); // 0x00000001814BC1E0-0x00000001814BC2C0
		internal void UpdateChannelInfo(); // 0x00000001814BC350-0x00000001814BC400
	}
}
