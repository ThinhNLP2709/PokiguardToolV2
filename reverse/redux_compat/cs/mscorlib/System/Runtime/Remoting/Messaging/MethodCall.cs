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
using System.Runtime.Remoting;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Messaging
{
	[Serializable]
	[CLSCompliant(false)]
	[ComVisible(true)]
	public class MethodCall : IMethodCallMessage, ISerializable, IInternalMessage // TypeDefIndex: 2991
	{
		// Fields
		private string _uri; // 0x10
		private string _typeName; // 0x18
		private string _methodName; // 0x20
		private object[] _args; // 0x28
		private Type[] _methodSignature; // 0x30
		private MethodBase _methodBase; // 0x38
		private LogicalCallContext _callContext; // 0x40
		private Identity _targetIdentity; // 0x48
		private Type[] _genericArguments; // 0x50
		protected IDictionary ExternalProperties; // 0x58
		protected IDictionary InternalProperties; // 0x60
	
		// Properties
		public int ArgCount { get; } // 0x000000018062F200-0x000000018062F220 
		public object[] Args { get; } // 0x000000018033D240-0x000000018033D250 
		public LogicalCallContext LogicalCallContext { get; } // 0x00000001814E23A0-0x00000001814E2410 
		public MethodBase MethodBase { get; } // 0x00000001814E2410-0x00000001814E2440 
		public string MethodName { get; } // 0x00000001814E2440-0x00000001814E2490 
		public object MethodSignature { get; } // 0x00000001814E2490-0x00000001814E2600 
		public virtual IDictionary Properties { get; } // 0x00000001814D79D0-0x00000001814D7A10 
		public string TypeName { get; } // 0x00000001814E2600-0x00000001814E2670 
		public string Uri { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		string IInternalMessage.Uri { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		Identity IInternalMessage.TargetIdentity { get; set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
		private Type[] GenericArguments { get; } // 0x00000001814E2330-0x00000001814E23A0 
	
		// Constructors
		internal MethodCall(SerializationInfo info, StreamingContext context); // 0x00000001814D7780-0x00000001814D7840
		internal MethodCall(CADMethodCallMessage msg); // 0x00000001814E1FF0-0x00000001814E2330
		internal MethodCall(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal void CopyFrom(IMethodMessage call); // 0x00000001814E0DC0-0x00000001814E0FA0
		internal virtual void InitMethodProperty(string key, object value); // 0x00000001814E1460-0x00000001814E1950
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001814E0FD0-0x00000001814E1320
		internal virtual void InitDictionary(); // 0x00000001814E13B0-0x00000001814E1460
		public object GetArg(int argNum); // 0x00000001814E0FA0-0x00000001814E0FD0
		public virtual void Init(); // 0x00000001802E76C0-0x00000001802E76D0
		public void ResolveMethod(); // 0x00000001814E1950-0x00000001814E1FF0
		private Type CastTo(string clientType, Type serverType); // 0x00000001814E0BC0-0x00000001814E0DC0
		private static string GetTypeNameFromAssemblyQualifiedName(string aqname); // 0x00000001814E1320-0x00000001814E13B0
	}
}
