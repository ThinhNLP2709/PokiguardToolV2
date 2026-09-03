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

namespace System
{
	[Serializable]
	public sealed class TypeInitializationException : SystemException // TypeDefIndex: 2359
	{
		// Fields
		private string _typeName; // 0x90
	
		// Properties
		public string TypeName { get; } // 0x00000001816169E0-0x0000000181616A10 
	
		// Constructors
		private TypeInitializationException(); // 0x00000001816211E0-0x0000000181621250
		public TypeInitializationException(string fullTypeName, Exception innerException); // 0x0000000181621250-0x0000000181621300
		internal TypeInitializationException(string fullTypeName, string message, Exception innerException); // 0x00000001816213B0-0x0000000181621430
		internal TypeInitializationException(SerializationInfo info, StreamingContext context); // 0x0000000181621300-0x00000001816213B0
	
		// Methods
		public override void GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001816210F0-0x00000001816211E0
	}
}
