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
	[Serializable]
	[NativeClass("RenderingLayerMask", "struct RenderingLayerMask;")]
	[NativeHeader("Runtime/BaseClasses/TagManager.h")]
	[NativeHeader("Runtime/Graphics/RenderingLayerMask.h")]
	[RequiredByNativeCode(Optional = true, GenerateProxy = true)]
	public struct RenderingLayerMask // TypeDefIndex: 7697
	{
		// Fields
		[NativeName("m_Bits")]
		private uint m_Bits; // 0x00
		[CompilerGenerated]
		private static readonly RenderingLayerMask _defaultRenderingLayerMask_k__BackingField; // 0x00
	
		// Properties
		public static RenderingLayerMask defaultRenderingLayerMask { [CompilerGenerated] get; } // 0x00000001821F7FB0-0x00000001821F8000 
	
		// Constructors
		static RenderingLayerMask(); // 0x00000001821F7F70-0x00000001821F7FB0
	
		// Methods
		public static implicit operator uint(RenderingLayerMask mask); // 0x0000000180815D70-0x0000000180815D80
		public static implicit operator RenderingLayerMask(uint intVal); // 0x0000000180815D70-0x0000000180815D80
		public static implicit operator int(RenderingLayerMask mask); // 0x0000000180815D70-0x0000000180815D80
		[NativeMethod("RenderingLayerToString")]
		[StaticAccessor("GetTagManager()", StaticAccessorType.Dot)]
		public static string RenderingLayerToName(int layer); // 0x00000001821F7E70-0x00000001821F7F70
		[StaticAccessor("GetTagManager()", StaticAccessorType.Dot)]
		public static int GetDefinedRenderingLayerCount(); // 0x00000001821F7D70-0x00000001821F7DA0
		[StaticAccessor("GetTagManager()", StaticAccessorType.Dot)]
		public static uint GetDefinedRenderingLayersCombinedMaskValue(); // 0x00000001821F7DD0-0x00000001821F7E00
		[StaticAccessor("GetTagManager()", StaticAccessorType.Dot)]
		public static string[] GetDefinedRenderingLayerNames(); // 0x00000001821F7DA0-0x00000001821F7DD0
		[StaticAccessor("GetTagManager()", StaticAccessorType.Dot)]
		public static int GetRenderingLayerCount(); // 0x00000001821F7E00-0x00000001821F7E30
		private static void RenderingLayerToName_Injected(int layer, ); // 0x00000001821F7E30-0x00000001821F7E70
	}
}
