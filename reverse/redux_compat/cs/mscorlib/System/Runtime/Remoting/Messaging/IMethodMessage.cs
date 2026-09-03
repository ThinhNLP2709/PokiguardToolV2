/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Messaging
{
	[ComVisible(true)]
	public interface IMethodMessage : IMessage // TypeDefIndex: 2989
	{
		// Properties
		int ArgCount { get; }
		object[] Args { get; }
		LogicalCallContext LogicalCallContext { get; }
		MethodBase MethodBase { get; }
		string MethodName { get; }
		object MethodSignature { get; }
		string TypeName { get; }
		string Uri { get; }
	
		// Methods
		object GetArg(int argNum);
	}
}
