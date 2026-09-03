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
	internal class CallContextRemotingData : ICloneable // TypeDefIndex: 2965
	{
		// Fields
		private string _logicalCallID; // 0x10
	
		// Properties
		internal string LogicalCallID { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		internal bool HasInfo { get; } // 0x00000001814B9A50-0x00000001814B9A60 
	
		// Constructors
		public CallContextRemotingData(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public object Clone(); // 0x00000001814D3540-0x00000001814D35B0
	}
}
