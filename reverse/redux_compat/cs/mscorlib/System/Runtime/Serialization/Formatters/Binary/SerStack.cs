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
	internal sealed class SerStack // TypeDefIndex: 3106
	{
		// Fields
		internal object[] objects; // 0x10
		internal string stackId; // 0x18
		internal int top; // 0x20
	
		// Constructors
		internal SerStack(string stackId); // 0x000000018151ADD0-0x000000018151AE50
	
		// Methods
		internal void Push(object obj); // 0x000000018151ACA0-0x000000018151ADD0
		internal object Pop(); // 0x000000018151AC20-0x000000018151ACA0
		internal void IncreaseCapacity(); // 0x000000018151AAF0-0x000000018151AB90
		internal object Peek(); // 0x000000018151ABE0-0x000000018151AC20
		internal object PeekPeek(); // 0x000000018151ABA0-0x000000018151ABE0
		internal bool IsEmpty(); // 0x000000018151AB90-0x000000018151ABA0
	}
}
