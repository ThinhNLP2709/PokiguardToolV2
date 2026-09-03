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

namespace Mono
{
	internal static class RuntimeStructs // TypeDefIndex: 2081
	{
		// Nested types
		internal struct RemoteClass // TypeDefIndex: 2082
		{
			// Fields
			internal IntPtr default_vtable; // 0x00
			internal IntPtr xdomain_vtable; // 0x08
			internal unsafe MonoClass* proxy_class; // 0x10
			internal IntPtr proxy_class_name; // 0x18
			internal uint interface_count; // 0x20
		}
	
		internal struct MonoClass // TypeDefIndex: 2083
		{
		}
	
		internal struct GenericParamInfo // TypeDefIndex: 2084
		{
			// Fields
			internal unsafe MonoClass* pklass; // 0x00
			internal IntPtr name; // 0x08
			internal ushort flags; // 0x10
			internal uint token; // 0x14
			internal unsafe MonoClass** constraints; // 0x18
		}
	
		internal struct GPtrArray // TypeDefIndex: 2085
		{
			// Fields
			internal unsafe IntPtr* data; // 0x00
			internal int len; // 0x08
		}
	}
}
