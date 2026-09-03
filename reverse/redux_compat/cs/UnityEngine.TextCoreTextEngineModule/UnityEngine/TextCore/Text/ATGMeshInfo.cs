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
	[NativeHeader("Modules/TextCoreTextEngine/Native/ATGMeshInfo.h")]
	[VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "UnityEngine.IMGUIModule" })]
	internal struct ATGMeshInfo // TypeDefIndex: 12635
	{
		// Fields
		private IntPtr m_TextElementInfosPtr; // 0x00
		private int m_TextElementCount; // 0x08
		public EntityId textAssetId; // 0x10
	
		// Properties
		public Span<NativeTextElementInfo> textElementInfos { get; } // 0x00000001822F4300-0x00000001822F4370 
	}
}
