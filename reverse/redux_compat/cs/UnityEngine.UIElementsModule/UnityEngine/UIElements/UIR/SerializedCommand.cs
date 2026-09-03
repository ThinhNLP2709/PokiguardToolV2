/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	[NativeHeader("Modules/UIElements/Core/Native/Renderer/PanelRenderer.h")]
	internal struct SerializedCommand // TypeDefIndex: 5016
	{
		// Fields
		public SerializedCommandType type; // 0x00
		public KickRangesReason kickReason; // 0x01
		public IntPtr vertexBuffer; // 0x08
		public IntPtr indexBuffer; // 0x10
		public int firstRange; // 0x18
		public int rangeCount; // 0x1C
		public int textureName; // 0x20
		public int gpuDataOffset; // 0x24
		public IntPtr textureRefPtr; // 0x28
		public Vector4 gpuData0; // 0x30
		public Vector4 gpuData1; // 0x40
		public IntPtr userProps; // 0x50
	}
}
