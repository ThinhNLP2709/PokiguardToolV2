/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.CompilerServices
{
	[Serializable]
	public sealed class RuntimeWrappedException : Exception // TypeDefIndex: 3208
	{
		// Fields
		private object _wrappedException; // 0x90
	
		// Properties
		public object WrappedException { get; } // 0x00000001806CCBA0-0x00000001806CCBB0 
	
		// Constructors
		public RuntimeWrappedException(object thrownObject); // 0x000000018151A2C0-0x000000018151A340
		private RuntimeWrappedException(SerializationInfo info, StreamingContext context); // 0x000000018151A1F0-0x000000018151A2C0
		internal RuntimeWrappedException(); // 0x000000018151A1C0-0x000000018151A1F0
	
		// Methods
		public override void GetObjectData(SerializationInfo info, StreamingContext context); // 0x000000018151A100-0x000000018151A1C0
	}
}
