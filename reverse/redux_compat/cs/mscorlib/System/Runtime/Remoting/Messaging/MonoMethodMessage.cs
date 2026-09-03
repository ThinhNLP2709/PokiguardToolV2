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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Messaging
{
	[Serializable]
	internal class MonoMethodMessage : IMethodCallMessage, IMethodReturnMessage, IInternalMessage // TypeDefIndex: 2997
	{
		// Fields
		private RuntimeMethodInfo method; // 0x10
		private object[] args; // 0x18
		private string[] names; // 0x20
		private byte[] arg_types; // 0x28
		public LogicalCallContext ctx; // 0x30
		public object rval; // 0x38
		public Exception exc; // 0x40
		private AsyncResult asyncResult; // 0x48
		private CallType call_type; // 0x50
		private string uri; // 0x58
		private MCMDictionary properties; // 0x60
		private Identity identity; // 0x68
		private Type[] methodSignature; // 0x70
	
		// Properties
		public IDictionary Properties { get; } // 0x00000001814E4C70-0x00000001814E4CE0 
		public int ArgCount { get; } // 0x00000001814E4780-0x00000001814E4810 
		public object[] Args { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public LogicalCallContext LogicalCallContext { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		public MethodBase MethodBase { get; } // 0x0000000180377550-0x0000000180377560 
		public string MethodName { get; } // 0x00000001814E4880-0x00000001814E48E0 
		public object MethodSignature { get; } // 0x00000001814E48E0-0x00000001814E4A40 
		public string TypeName { get; } // 0x00000001814E4CE0-0x00000001814E4D60 
		public string Uri { get; set; } // 0x00000001802F4000-0x00000001802F4010 0x00000001802F4050-0x00000001802F4060
		public Exception Exception { get; } // 0x0000000180377940-0x0000000180377950 
		public int OutArgCount { get; } // 0x00000001814E4A40-0x00000001814E4AA0 
		public object[] OutArgs { get; } // 0x00000001814E4AA0-0x00000001814E4C70 
		public object ReturnValue { get; } // 0x00000001803272A0-0x00000001803272B0 
		Identity IInternalMessage.TargetIdentity { get; set; } // 0x0000000180316960-0x0000000180316970 0x0000000180316A40-0x0000000180316A50
		public AsyncResult AsyncResult { get; } // 0x00000001803272B0-0x00000001803272C0 
		internal CallType CallType { get; } // 0x00000001814E4810-0x00000001814E4880 
	
		// Constructors
		public MonoMethodMessage(MethodBase method, object[] out_args); // 0x00000001814E46B0-0x00000001814E4780
		internal MonoMethodMessage(MethodInfo minfo, object[] in_args, object[] out_args); // 0x00000001814E4550-0x00000001814E46B0
		public MonoMethodMessage(Type type, string methodName, object[] in_args); // 0x00000001814E4350-0x00000001814E4550
	
		// Methods
		internal void InitMessage(RuntimeMethodInfo method, object[] out_args); // 0x00000001814E3F90-0x00000001814E42D0
		private static MethodInfo GetMethodInfo(Type type, string methodName); // 0x00000001814E3ED0-0x00000001814E3F90
		public object GetArg(int arg_num); // 0x00000001814E3EA0-0x00000001814E3ED0
		public bool NeedsOutProcessing(out int outCount); // 0x00000001814E42D0-0x00000001814E4350
	}
}
