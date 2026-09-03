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
	public class MissingMemberException : MemberAccessException // TypeDefIndex: 2390
	{
		// Fields
		protected string ClassName; // 0x90
		protected string MemberName; // 0x98
		protected byte[] Signature; // 0xA0
	
		// Properties
		public override string Message { get; } // 0x0000000181616510-0x0000000181616600 
	
		// Constructors
		public MissingMemberException(); // 0x00000001816164A0-0x00000001816164F0
		public MissingMemberException(string message); // 0x00000001816164F0-0x0000000181616510
		protected MissingMemberException(SerializationInfo info, StreamingContext context); // 0x0000000181615F80-0x0000000181616140
	
		// Methods
		public override void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181616300-0x00000001816164A0
		internal static string FormatSignature(byte[] signature); // 0x00000001815B1550-0x00000001815B1570
	}
}
