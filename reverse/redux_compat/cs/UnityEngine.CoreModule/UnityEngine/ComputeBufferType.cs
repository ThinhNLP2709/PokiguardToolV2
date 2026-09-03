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
	[Flags]
	[NativeHeader("Runtime/Export/Graphics/GraphicsBuffer.bindings.h")]
	public enum ComputeBufferType // TypeDefIndex: 7586
	{
		Default = 0,
		Raw = 1,
		Append = 2,
		Counter = 4,
		Constant = 8,
		Structured = 16,
		DrawIndirect = 256,
		IndirectArguments = 256,
		GPUMemory = 512
	}
}
