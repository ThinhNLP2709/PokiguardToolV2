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
	public class MissingFieldException : MissingMemberException, ISerializable // TypeDefIndex: 2389
	{
		// Properties
		public override string Message { get; } // 0x0000000181616140-0x0000000181616300 
	
		// Constructors
		public MissingFieldException(); // 0x0000000181615E80-0x0000000181615ED0
		public MissingFieldException(string message); // 0x0000000181615F60-0x0000000181615F80
		public MissingFieldException(string className, string fieldName); // 0x0000000181615ED0-0x0000000181615F60
		protected MissingFieldException(SerializationInfo info, StreamingContext context); // 0x0000000181615F80-0x0000000181616140
	}
}
