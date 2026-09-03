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
	internal sealed class SerObjectInfoCache // TypeDefIndex: 3098
	{
		// Fields
		internal string fullTypeName; // 0x10
		internal string assemblyString; // 0x18
		internal bool hasTypeForwardedFrom; // 0x20
		internal MemberInfo[] memberInfos; // 0x28
		internal string[] memberNames; // 0x30
		internal Type[] memberTypes; // 0x38
	
		// Constructors
		internal SerObjectInfoCache(string typeName, string assemblyName, bool hasTypeForwardedFrom); // 0x00000001815014B0-0x0000000181501520
		internal SerObjectInfoCache(Type type); // 0x0000000181501520-0x00000001815015C0
	}
}
