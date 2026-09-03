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

namespace System.Runtime.Serialization.Formatters.Binary
{
	internal sealed class BinaryMethodCall // TypeDefIndex: 3076
	{
		// Fields
		private string methodName; // 0x10
		private string typeName; // 0x18
		private object[] args; // 0x20
		private object callContext; // 0x28
		private Type[] argTypes; // 0x30
		private bool bArgsPrimitive; // 0x38
		private MessageEnum messageEnum; // 0x3C
	
		// Constructors
		public BinaryMethodCall(); // 0x00000001814EFCC0-0x00000001814EFCD0
	
		// Methods
		internal void Write(__BinaryWriter sout); // 0x00000001814EF920-0x00000001814EFCC0
		internal void Dump(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
