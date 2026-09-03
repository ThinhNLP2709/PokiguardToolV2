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
	internal struct AssemblyFullName // TypeDefIndex: 7736
	{
		// Fields
		[NativeName("name")]
		public string Name; // 0x00
		[NativeName("version")]
		public AssemblyVersion Version; // 0x08
		[NativeName("publicKeyToken")]
		public string PublicKeyToken; // 0x10
		[NativeName("culture")]
		public string Culture; // 0x18
	
		// Methods
		public override bool Equals(object other); // 0x00000001821E0F40-0x00000001821E1060
		public override int GetHashCode(); // 0x00000001821E1060-0x00000001821E1100
		public override string ToString(); // 0x00000001821E1100-0x00000001821E1310
	}
}
