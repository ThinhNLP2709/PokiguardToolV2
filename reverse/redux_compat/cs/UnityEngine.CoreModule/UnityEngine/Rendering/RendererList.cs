/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting.APIUpdating;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[MovedFrom("UnityEngine.Rendering.RendererUtils")]
	[NativeHeader("Runtime/Graphics/ScriptableRenderLoop/RendererList.h")]
	public struct RendererList // TypeDefIndex: 8420
	{
		// Fields
		internal UIntPtr context; // 0x00
		internal uint index; // 0x08
		internal uint frame; // 0x0C
		internal uint type; // 0x10
		internal uint contextID; // 0x14
		public static readonly RendererList nullRendererList; // 0x00
	
		// Properties
		public bool isValid { get; } // 0x0000000182265420-0x0000000182265460 
	
		// Constructors
		internal RendererList(UIntPtr ctx, uint indx); // 0x0000000182265400-0x0000000182265420
		static RendererList(); // 0x00000001822653A0-0x0000000182265400
	}
}
