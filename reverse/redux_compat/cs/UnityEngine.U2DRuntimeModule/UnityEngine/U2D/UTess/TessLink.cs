/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using UnityEngine;

// Image 38: UnityEngine.U2DRuntimeModule.dll - Assembly: UnityEngine.U2DRuntimeModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15050-15086

namespace UnityEngine.U2D.UTess
{
	internal struct TessLink // TypeDefIndex: 15083
	{
		// Fields
		internal NativeArray<int> roots; // 0x00
		internal NativeArray<int> ranks; // 0x10
	
		// Methods
		internal static TessLink CreateLink(int count, Allocator allocator); // 0x0000000181C3B2D0-0x0000000181C3B390
		internal static void DestroyLink(TessLink link); // 0x000000018235C210-0x000000018235C260
		internal int Find(int x); // 0x0000000181C3B3E0-0x0000000181C3B440
		internal void Link(int x, int y); // 0x0000000181C3B440-0x0000000181C3B560
	}
}
