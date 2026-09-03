/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Runtime/GfxDevice/FrameTiming.h")]
	public struct FrameTiming // TypeDefIndex: 7551
	{
		// Fields
		[NativeName("totalFrameTime")]
		public double cpuFrameTime; // 0x00
		[NativeName("mainThreadActiveTime")]
		public double cpuMainThreadFrameTime; // 0x08
		[NativeName("mainThreadPresentWaitTime")]
		public double cpuMainThreadPresentWaitTime; // 0x10
		[NativeName("renderThreadActiveTime")]
		public double cpuRenderThreadFrameTime; // 0x18
		[NativeName("gpuFrameTime")]
		public double gpuFrameTime; // 0x20
		[NativeName("frameStartTimestamp")]
		public ulong frameStartTimestamp; // 0x28
		[NativeName("firstSubmitTimestamp")]
		public ulong firstSubmitTimestamp; // 0x30
		[NativeName("presentFrameTimestamp")]
		public ulong cpuTimePresentCalled; // 0x38
		[NativeName("frameCompleteTimestamp")]
		public ulong cpuTimeFrameComplete; // 0x40
		[NativeName("heightScale")]
		public float heightScale; // 0x48
		[NativeName("widthScale")]
		public float widthScale; // 0x4C
		[NativeName("syncInterval")]
		public uint syncInterval; // 0x50
	}
}
