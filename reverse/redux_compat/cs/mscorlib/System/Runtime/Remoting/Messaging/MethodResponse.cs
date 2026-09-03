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
	public class MethodResponse : IMethodReturnMessage, ISerializable, IInternalMessage // TypeDefIndex: 2995
	{
		// Fields
		private string _methodName; // 0x10
		private string _uri; // 0x18
		private string _typeName; // 0x20
		private MethodBase _methodBase; // 0x28
		private object _returnValue; // 0x30
		private Exception _exception; // 0x38
		private Type[] _methodSignature; // 0x40
		private ArgInfo _inArgInfo; // 0x48
		private object[] _args; // 0x50
		private object[] _outArgs; // 0x58
		private IMethodCallMessage _callMsg; // 0x60
		private LogicalCallContext _callContext; // 0x68
		private Identity _targetIdentity; // 0x70
		protected IDictionary ExternalProperties; // 0x78
		protected IDictionary InternalProperties; // 0x80
	
		// Properties
		public int ArgCount { get; } // 0x00000001814E35F0-0x00000001814E3610 
		public object[] Args { get; } // 0x00000001806CCC00-0x00000001806CCC10 
		public Exception Exception { get; } // 0x00000001803272A0-0x00000001803272B0 
		public LogicalCallContext LogicalCallContext { get; } // 0x00000001814E3610-0x00000001814E3680 
		public MethodBase MethodBase { get; } // 0x00000001814E3680-0x00000001814E37E0 
		public string MethodName { get; } // 0x00000001814E37E0-0x00000001814E3850 
		public object MethodSignature { get; } // 0x00000001814E3850-0x00000001814E3930 
		public object[] OutArgs { get; } // 0x00000001814E3930-0x00000001814E3B40 
		public virtual IDictionary Properties { get; } // 0x00000001814D7C30-0x00000001814D7CF0 
		public object ReturnValue { get; } // 0x000000018031E110-0x000000018031E120 
		public string TypeName { get; } // 0x00000001814E3B40-0x00000001814E3BB0 
		public string Uri { get; set; } // 0x00000001814E2FA0-0x00000001814E3010 0x00000001802FAF70-0x00000001802FAF80
		string IInternalMessage.Uri { get; set; } // 0x00000001814E2FA0-0x00000001814E3010 0x00000001802FAF70-0x00000001802FAF80
		Identity IInternalMessage.TargetIdentity { get; set; } // 0x000000018033D4D0-0x000000018033D4E0 0x0000000180434A10-0x0000000180434A20
	
		// Constructors
		internal MethodResponse(Exception e, IMethodCallMessage msg); // 0x00000001814E3010-0x00000001814E3100
		internal MethodResponse(object returnValue, object[] outArgs, LogicalCallContext callCtx, IMethodCallMessage msg); // 0x00000001814E3100-0x00000001814E31D0
		internal MethodResponse(IMethodCallMessage msg, CADMethodReturnMessage retmsg); // 0x00000001814E31D0-0x00000001814E35F0
		internal MethodResponse(SerializationInfo info, StreamingContext context); // 0x00000001814D7B90-0x00000001814D7C30
	
		// Methods
		internal void InitMethodProperty(string key, object value); // 0x00000001814E2A30-0x00000001814E2FA0
		public object GetArg(int argNum); // 0x00000001814E2670-0x00000001814E26A0
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001814E26A0-0x00000001814E2A30
	}
}
