/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[NativeHeader("Runtime/Graphics/Texture.h")]
	[NativeHeader("Runtime/Shaders/ComputeShader.h")]
	[NativeHeader("Runtime/Graphics/AsyncGPUReadbackManaged.h")]
	[UsedByNativeCode]
	public struct AsyncGPUReadbackRequest // TypeDefIndex: 8248
	{
		// Fields
		internal IntPtr m_Ptr; // 0x00
		internal int m_Version; // 0x08
	
		// Properties
		public bool done { get; } // 0x000000018222A490-0x000000018222A4D0 
		public bool hasError { get; } // 0x000000018222A420-0x000000018222A460 
		public int layerCount { get; } // 0x000000018222A3A0-0x000000018222A3E0 
		public int layerDataSize { get; } // 0x000000018222A3E0-0x000000018222A420 
	
		// Methods
		public void WaitForCompletion(); // 0x000000018222A520-0x000000018222A560
		public NativeArray<T> GetData<T>(int layer = 0 /* Metadata: 0x0069D99E */)
			where T : struct;
		private bool IsDone(); // 0x000000018222A490-0x000000018222A4D0
		private bool HasError(); // 0x000000018222A420-0x000000018222A460
		private int GetLayerCount(); // 0x000000018222A3A0-0x000000018222A3E0
		private int GetLayerDataSize(); // 0x000000018222A3E0-0x000000018222A420
		internal void SetScriptingCallback(Action<AsyncGPUReadbackRequest> callback); // 0x000000018222A4D0-0x000000018222A520
		private IntPtr GetDataRaw(int layer); // 0x000000018222A360-0x000000018222A3A0
		[RequiredByNativeCode]
		private static void InvokeCallback(Action<AsyncGPUReadbackRequest> callback, AsyncGPUReadbackRequest obj); // 0x000000018222A460-0x000000018222A490
	}
}
