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

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	[NativeHeader("Modules/TextCoreTextEngine/Native/IMGUI/MeshInfo.h")]
	[UsedByNativeCode("MeshInfo")]
	[VisibleToOtherModules(new string[1] {"UnityEngine.IMGUIModule" })]
	internal struct MeshInfoBindings // TypeDefIndex: 12651
	{
		// Fields
		public TextCoreVertex[] vertexData; // 0x00
		public Material material; // 0x08
		public int vertexCount; // 0x10
	
		// Methods
		[UsedByNativeCode]
		internal static void DeconstructArrayElementRaw(MeshInfoBindings[] array, int index, out object vertexData, out object material, out int vertexCount); // 0x0000000182305CF0-0x0000000182305D60
	}
}
