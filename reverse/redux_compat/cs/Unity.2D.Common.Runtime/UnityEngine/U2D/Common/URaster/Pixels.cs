/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

// Image 36: Unity.2D.Common.Runtime.dll - Assembly: Unity.2D.Common.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14954-14996

namespace UnityEngine.U2D.Common.URaster
{
	internal struct Pixels // TypeDefIndex: 14992
	{
		// Fields
		internal int4 rect; // 0x00
		internal int4 minmax; // 0x10
		internal int4 texrect; // 0x20
		internal int2 size; // 0x30
		[NativeDisableContainerSafetyRestriction]
		internal NativeArray<byte> data; // 0x38
	}
}
