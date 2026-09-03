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
using System.Runtime.Remoting.Activation;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Messaging
{
	[Serializable]
	[CLSCompliant(false)]
	[ComVisible(true)]
	public class ConstructionResponse : MethodResponse, IConstructionReturnMessage // TypeDefIndex: 2979
	{
		// Properties
		public override IDictionary Properties { get; } // 0x00000001814D7C30-0x00000001814D7CF0 
	
		// Constructors
		internal ConstructionResponse(object resultObject, LogicalCallContext callCtx, IMethodCallMessage msg); // 0x00000001814D7AC0-0x00000001814D7B80
		internal ConstructionResponse(Exception e, IMethodCallMessage msg); // 0x00000001814D7B80-0x00000001814D7B90
		internal ConstructionResponse(SerializationInfo info, StreamingContext context); // 0x00000001814D7B90-0x00000001814D7C30
	}
}
