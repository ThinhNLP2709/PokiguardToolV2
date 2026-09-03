/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	[NativeHeader("Modules/TextCoreTextEngine/Native/TextInfo.h")]
	[VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "UnityEngine.IMGUIModule" })]
	internal struct NativeTextInfo // TypeDefIndex: 12654
	{
		// Fields
		private IntPtr m_MeshInfosPtr; // 0x00
		public int meshInfoCount; // 0x08
		public int totalWidth; // 0x0C
		public int totalHeight; // 0x10
		public bool isElided; // 0x14
		public bool hasMultipleColors; // 0x15
	
		// Properties
		public Span<ATGMeshInfo> meshInfos { get; } // 0x0000000182308070-0x00000001823080C0 
	}
}
