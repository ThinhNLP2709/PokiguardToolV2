/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 38: UnityEngine.U2DRuntimeModule.dll - Assembly: UnityEngine.U2DRuntimeModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15050-15086

namespace UnityEngine.U2D.Runtime
{
	internal class Geometry // TypeDefIndex: 15085
	{
		// Nested types
		internal struct GenerateParams // TypeDefIndex: 15086
		{
			// Fields
			public IntPtr points; // 0x00
			public int pointCount; // 0x08
			public IntPtr edges; // 0x10
			public int edgeCount; // 0x18
			public IntPtr vertices; // 0x20
			public int maxVertexCount; // 0x28
			public IntPtr indices; // 0x30
			public int maxIndexCount; // 0x38
			public float areaFactor; // 0x3C
			public int refineIterations; // 0x40
			public int smoothenIterations; // 0x44
		}
	
		// Methods
		[RequiredByNativeCode]
		internal static int Generate(ref GenerateParams _params); // 0x0000000182355A30-0x0000000182355F30
	}
}
