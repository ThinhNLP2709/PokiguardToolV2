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

namespace System
{
	[Serializable]
	public class UnhandledExceptionEventArgs : EventArgs // TypeDefIndex: 2364
	{
		// Fields
		private object _exception; // 0x10
		private bool _isTerminating; // 0x18
	
		// Properties
		public object ExceptionObject { get; } // 0x0000000180377550-0x0000000180377560 
		public bool IsTerminating { get; } // 0x0000000180F9E350-0x0000000180F9E360 
	
		// Constructors
		public UnhandledExceptionEventArgs(object exception, bool isTerminating); // 0x00000001816285F0-0x0000000181628670
	}
}
