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
	[Serializable]
	internal class CADMethodRef // TypeDefIndex: 2971
	{
		// Fields
		private bool ctor; // 0x10
		private string typeName; // 0x18
		private string methodName; // 0x20
		private string[] param_names; // 0x28
		private string[] generic_arg_names; // 0x30
	
		// Constructors
		public CADMethodRef(IMethodMessage msg); // 0x00000001814D2890-0x00000001814D2B70
	
		// Methods
		private Type[] GetTypes(string[] typeArray); // 0x00000001814D2220-0x00000001814D2370
		public MethodBase Resolve(); // 0x00000001814D2370-0x00000001814D2890
	}
}
