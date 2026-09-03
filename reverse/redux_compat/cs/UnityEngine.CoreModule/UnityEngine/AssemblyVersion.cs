/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Scripting/Mono/AssemblyFullName.h")]
	[RequiredByNativeCode]
	internal struct AssemblyVersion // TypeDefIndex: 7735
	{
		// Fields
		public ushort major; // 0x00
		public ushort minor; // 0x02
		public ushort build; // 0x04
		public ushort revision; // 0x06
	
		// Methods
		public static bool operator ==(AssemblyVersion lhs, AssemblyVersion rhs); // 0x00000001821E1650-0x00000001821E1690
		public override string ToString(); // 0x00000001821E1450-0x00000001821E1650
		public override bool Equals(object other); // 0x00000001821E1310-0x00000001821E13C0
		public override int GetHashCode(); // 0x00000001821E13C0-0x00000001821E1450
	}
}
