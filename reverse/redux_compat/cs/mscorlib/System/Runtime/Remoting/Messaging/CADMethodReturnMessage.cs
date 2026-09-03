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
	internal class CADMethodReturnMessage : CADMessageBase // TypeDefIndex: 2974
	{
		// Fields
		private object _returnValue; // 0x38
		private CADArgHolder _exception; // 0x40
		private Type[] _sig; // 0x48
	
		// Properties
		internal int PropertiesCount { get; } // 0x0000000180C4F680-0x0000000180C4F690 
	
		// Constructors
		internal CADMethodReturnMessage(IMethodReturnMessage retMsg); // 0x00000001814D2E50-0x00000001814D30E0
	
		// Methods
		internal static CADMethodReturnMessage Create(IMessage callMsg); // 0x00000001814D2B70-0x00000001814D2C00
		internal ArrayList GetArguments(); // 0x00000001814D2C00-0x00000001814D2DC0
		internal object[] GetArgs(ArrayList args); // 0x00000001814D1D80-0x00000001814D1D90
		internal object GetReturnValue(ArrayList args); // 0x00000001814D2E40-0x00000001814D2E50
		internal Exception GetException(ArrayList args); // 0x00000001814D2DC0-0x00000001814D2E40
	}
}
