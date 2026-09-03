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
	[ComVisible(true)]
	public class ReturnMessage : IMethodReturnMessage, IInternalMessage // TypeDefIndex: 3003
	{
		// Fields
		private object[] _outArgs; // 0x10
		private object[] _args; // 0x18
		private LogicalCallContext _callCtx; // 0x20
		private object _returnValue; // 0x28
		private string _uri; // 0x30
		private Exception _exception; // 0x38
		private MethodBase _methodBase; // 0x40
		private string _methodName; // 0x48
		private Type[] _methodSignature; // 0x50
		private string _typeName; // 0x58
		private MethodReturnDictionary _properties; // 0x60
		private Identity _targetIdentity; // 0x68
		private ArgInfo _inArgInfo; // 0x70
	
		// Properties
		public int ArgCount { get; } // 0x00000001814EA450-0x00000001814EA470 
		public object[] Args { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public LogicalCallContext LogicalCallContext { get; } // 0x00000001814EA470-0x00000001814EA4E0 
		public MethodBase MethodBase { get; } // 0x0000000180377940-0x0000000180377950 
		public string MethodName { get; } // 0x00000001814EA4E0-0x00000001814EA540 
		public object MethodSignature { get; } // 0x00000001814EA540-0x00000001814EA6B0 
		public virtual IDictionary Properties { get; } // 0x00000001814EA770-0x00000001814EA7E0 
		public string TypeName { get; } // 0x00000001814EA7E0-0x00000001814EA860 
		public string Uri { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		string IInternalMessage.Uri { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		public Exception Exception { get; } // 0x00000001803272A0-0x00000001803272B0 
		public object[] OutArgs { get; } // 0x00000001814EA6B0-0x00000001814EA770 
		public virtual object ReturnValue { get; } // 0x000000018033D240-0x000000018033D250 
		Identity IInternalMessage.TargetIdentity { get; set; } // 0x0000000180316960-0x0000000180316970 0x0000000180316A40-0x0000000180316A50
	
		// Constructors
		public ReturnMessage(object ret, object[] outArgs, int outArgsCount, LogicalCallContext callCtx, IMethodCallMessage mcm); // 0x00000001814EA340-0x00000001814EA450
		public ReturnMessage(Exception e, IMethodCallMessage mcm); // 0x00000001814EA260-0x00000001814EA340
	
		// Methods
		public object GetArg(int argNum); // 0x00000001814EA230-0x00000001814EA260
	}
}
