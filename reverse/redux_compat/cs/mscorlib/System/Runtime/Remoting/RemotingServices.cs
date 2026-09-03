/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting
{
	[ComVisible(true)]
	public static class RemotingServices // TypeDefIndex: 2887
	{
		// Fields
		private static Hashtable uri_hash; // 0x00
		private static BinaryFormatter _serializationFormatter; // 0x08
		private static BinaryFormatter _deserializationFormatter; // 0x10
		private static string app_id; // 0x18
		private static readonly object app_id_lock; // 0x20
		private static int next_id; // 0x28
		private static readonly MethodInfo FieldSetterMethod; // 0x30
		private static readonly MethodInfo FieldGetterMethod; // 0x38
	
		// Nested types
		[Serializable]
		private class CACD // TypeDefIndex: 2888
		{
			// Fields
			public object d; // 0x10
			public object c; // 0x18
	
			// Constructors
			public CACD(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		// Constructors
		static RemotingServices(); // 0x00000001814C6020-0x00000001814C63A0
	
		// Methods
		internal static object InternalExecute(MethodBase method, object obj, object[] parameters, out object[] out_args); // 0x00000001814C4F80-0x00000001814C4F90
		internal static MethodBase GetVirtualMethod(Type type, MethodBase method); // 0x00000001814C4830-0x00000001814C4840
		public static bool IsTransparentProxy(object proxy); // 0x00000001814C5000-0x00000001814C5040
		internal static IMethodReturnMessage InternalExecuteMessage(MarshalByRefObject target, IMethodCallMessage reqMsg); // 0x00000001814C4840-0x00000001814C4F80
		[ComVisible(true)]
		public static object Connect(Type classToProxy, string url); // 0x00000001814C1F30-0x00000001814C2020
		[ComVisible(true)]
		public static object Connect(Type classToProxy, string url, object data); // 0x00000001814C1E30-0x00000001814C1F30
		public static Type GetServerTypeForUri(string URI); // 0x00000001814C4790-0x00000001814C4830
		public static object Unmarshal(ObjRef objectRef); // 0x00000001814C5BD0-0x00000001814C5C20
		public static object Unmarshal(ObjRef objectRef, bool fRefine); // 0x00000001814C5C20-0x00000001814C5F20
		public static ObjRef Marshal(MarshalByRefObject Obj); // 0x00000001814C50D0-0x00000001814C5130
		public static ObjRef Marshal(MarshalByRefObject Obj, string ObjURI, Type RequestedType); // 0x00000001814C5040-0x00000001814C50D0
		private static string NewUri(); // 0x00000001814C5130-0x00000001814C5440
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static RealProxy GetRealProxy(object proxy); // 0x00000001814C46B0-0x00000001814C4720
		public static MethodBase GetMethodBaseFromMethodMessage(IMethodMessage msg); // 0x00000001814C3720-0x00000001814C3AB0
		internal static MethodBase GetMethodBaseFromName(Type type, string methodName, Type[] signature); // 0x00000001814C3AB0-0x00000001814C3CA0
		private static MethodBase FindInterfaceMethod(Type type, string methodName, Type[] signature); // 0x00000001814C2DF0-0x00000001814C2F40
		public static void GetObjectData(object obj, SerializationInfo info, StreamingContext context); // 0x00000001814C3D10-0x00000001814C3DC0
		public static bool IsOneWay(MethodBase method); // 0x00000001814C4F90-0x00000001814C5000
		internal static object CreateClientProxy(ActivatedClientTypeEntry entry, object[] activationAttributes); // 0x00000001814C25E0-0x00000001814C26F0
		internal static object CreateClientProxy(Type objectType, string url, object[] activationAttributes); // 0x00000001814C2280-0x00000001814C24B0
		internal static object CreateClientProxy(WellKnownClientTypeEntry entry); // 0x00000001814C24B0-0x00000001814C25E0
		internal static object CreateClientProxyForContextBound(Type type, object[] activationAttributes); // 0x00000001814C20F0-0x00000001814C2280
		internal static Identity GetIdentityForUri(string uri); // 0x00000001814C3070-0x00000001814C33C0
		private static string RemoveAppNameFromUri(string uri); // 0x00000001814C5680-0x00000001814C5790
		internal static ClientIdentity GetOrCreateClientIdentity(ObjRef objRef, Type proxyType, out object clientProxy); // 0x00000001814C3DC0-0x00000001814C45C0
		private static IMessageSink GetClientChannelSinkChain(string url, object channelData, out string objectUri); // 0x00000001814C2F40-0x00000001814C3070
		internal static ClientActivatedIdentity CreateContextBoundObjectIdentity(Type objectType); // 0x00000001814C26F0-0x00000001814C2800
		internal static ClientActivatedIdentity CreateClientActivatedServerIdentity(MarshalByRefObject realObject, Type objectType, string objectUri); // 0x00000001814C2020-0x00000001814C20F0
		internal static ServerIdentity CreateWellKnownServerIdentity(Type objectType, string objectUri, WellKnownObjectMode mode); // 0x00000001814C2800-0x00000001814C2930
		private static void RegisterServerIdentity(ServerIdentity identity); // 0x00000001814C5480-0x00000001814C5680
		internal static object GetProxyForRemoteObject(ObjRef objref, Type classToProxy); // 0x00000001814C45C0-0x00000001814C46B0
		internal static object GetRemoteObject(ObjRef objRef, Type proxyType); // 0x00000001814C4720-0x00000001814C4790
		internal static byte[] SerializeCallData(object obj); // 0x00000001814C5790-0x00000001814C59F0
		internal static object DeserializeCallData(byte[] array); // 0x00000001814C2930-0x00000001814C2BB0
		internal static byte[] SerializeExceptionData(Exception ex); // 0x00000001814C59F0-0x00000001814C5B10
		private static void RegisterInternalChannels(); // 0x00000001814C5440-0x00000001814C5480
		internal static void DisposeIdentity(Identity ident); // 0x00000001814C2BB0-0x00000001814C2DF0
		internal static Identity GetMessageTargetIdentity(IMessage msg); // 0x00000001814C33C0-0x00000001814C3720
		internal static void SetMessageTargetIdentity(IMessage msg, Identity ident); // 0x00000001814C5B10-0x00000001814C5BD0
		internal static bool UpdateOutArgObject(ParameterInfo pi, object local, object remote); // 0x00000001814C5F20-0x00000001814C6020
		private static string GetNormalizedUri(string uri); // 0x00000001814C3CA0-0x00000001814C3D10
	}
}
