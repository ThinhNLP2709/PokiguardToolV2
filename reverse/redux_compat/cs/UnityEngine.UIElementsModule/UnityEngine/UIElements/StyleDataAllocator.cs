/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[NativeHeader("Modules/UIElements/Core/Native/Unmanaged/StyleDataAllocator.bindings.h")]
	internal static class StyleDataAllocator // TypeDefIndex: 4622
	{
		// Methods
		internal static StyleDataType GetType<T>()
			where T : struct;
		internal static IntPtr Allocate(StyleDataType type); // 0x00000001825464E0-0x0000000182546520
		internal static void Free(IntPtr ptr, StyleDataType type); // 0x0000000182546520-0x0000000182546560
	}
}
