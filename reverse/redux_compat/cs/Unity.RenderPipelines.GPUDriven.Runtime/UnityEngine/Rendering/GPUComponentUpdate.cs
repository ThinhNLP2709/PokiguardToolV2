/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal struct GPUComponentUpdate // TypeDefIndex: 12956
	{
		// Fields
		private UnsafeList<byte> m_Data; // 0x00
		private GPUComponent m_Component; // 0x18
	
		// Properties
		public GPUComponent Component { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public int PropertyID { get; } // 0x0000000180B23260-0x0000000180B23270 
		public int StrideInBytes { get; } // 0x0000000180B232F0-0x0000000180B23300 
		public NativeArray<byte> Data { get; } // 0x0000000181302EF0-0x0000000181302F30 
	
		// Constructors
		public GPUComponentUpdate(GPUComponent component, NativeArray<byte> data); // 0x0000000181F34500-0x0000000181F34550
	
		// Methods
		public static GPUComponentUpdate FromArray<T>(GPUComponent component, NativeArray<T> data)
			where T : struct;
	}
}
