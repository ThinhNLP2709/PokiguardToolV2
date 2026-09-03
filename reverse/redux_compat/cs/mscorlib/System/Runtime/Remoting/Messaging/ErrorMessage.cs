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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Messaging
{
	[Serializable]
	internal class ErrorMessage : IMethodCallMessage // TypeDefIndex: 2981
	{
		// Fields
		private string _uri; // 0x10
	
		// Properties
		public int ArgCount { get; } // 0x00000001802E7860-0x00000001802E7870 
		public object[] Args { get; } // 0x00000001802E7860-0x00000001802E7870 
		public MethodBase MethodBase { get; } // 0x00000001802E7860-0x00000001802E7870 
		public string MethodName { get; } // 0x00000001814DA8A0-0x00000001814DA8D0 
		public object MethodSignature { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual IDictionary Properties { get; } // 0x00000001802E7860-0x00000001802E7870 
		public string TypeName { get; } // 0x00000001814DA8D0-0x00000001814DA900 
		public string Uri { get; } // 0x0000000180377550-0x0000000180377560 
		public LogicalCallContext LogicalCallContext { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Constructors
		public ErrorMessage(); // 0x00000001814DA850-0x00000001814DA8A0
	
		// Methods
		public object GetArg(int arg_num); // 0x00000001802E7860-0x00000001802E7870
	}
}
