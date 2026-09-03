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
	internal class CADMethodCallMessage : CADMessageBase // TypeDefIndex: 2973
	{
		// Fields
		private string _uri; // 0x38
	
		// Properties
		internal string Uri { get; } // 0x00000001803272A0-0x00000001803272B0 
		internal int PropertiesCount { get; } // 0x0000000180C4F680-0x0000000180C4F690 
	
		// Constructors
		internal CADMethodCallMessage(IMethodCallMessage callMsg); // 0x00000001814D1F50-0x00000001814D2220
	
		// Methods
		internal static CADMethodCallMessage Create(IMessage callMsg); // 0x00000001814D1CF0-0x00000001814D1D80
		internal ArrayList GetArguments(); // 0x00000001814D1D90-0x00000001814D1F50
		internal object[] GetArgs(ArrayList args); // 0x00000001814D1D80-0x00000001814D1D90
	}
}
