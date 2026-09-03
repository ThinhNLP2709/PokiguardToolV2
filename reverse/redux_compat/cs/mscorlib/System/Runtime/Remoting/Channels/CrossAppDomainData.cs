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

namespace System.Runtime.Remoting.Channels
{
	[Serializable]
	internal class CrossAppDomainData // TypeDefIndex: 2932
	{
		// Fields
		private object _ContextID; // 0x10
		private int _DomainID; // 0x18
		private string _processGuid; // 0x20
	
		// Properties
		internal int DomainID { get; } // 0x0000000180B23260-0x0000000180B23270 
		internal string ProcessID { get; } // 0x00000001802F8630-0x00000001802F8640 
	
		// Constructors
		internal CrossAppDomainData(int domainId); // 0x00000001814D85B0-0x00000001814D8650
	}
}
