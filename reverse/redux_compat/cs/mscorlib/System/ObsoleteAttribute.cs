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
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate, Inherited = false)]
	public sealed class ObsoleteAttribute : Attribute // TypeDefIndex: 2318
	{
		// Fields
		private string _message; // 0x10
		private bool _error; // 0x18
	
		// Properties
		public string Message { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Constructors
		public ObsoleteAttribute(); // 0x0000000181616A10-0x0000000181616A40
		public ObsoleteAttribute(string message); // 0x0000000181616A90-0x0000000181616AD0
		public ObsoleteAttribute(string message, bool error); // 0x0000000181616A40-0x0000000181616A90
	}
}
