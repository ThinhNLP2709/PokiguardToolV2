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

namespace UnityEngine.UIElements
{
	[NativeHeader("Modules/UIElements/Core/Native/ProfilerUIToolkit.h")]
	[VisibleToOtherModules(new string[1] {"UnityEditor.UIElementsModule" })]
	internal struct UIToolkitBatchMetricsInfo // TypeDefIndex: 4232
	{
		// Fields
		public EntityId panelEntityId; // 0x00
		public uint drawCallCount; // 0x08
		public uint vertexCount; // 0x0C
		public uint indexCount; // 0x10
		public uint immediateDraws; // 0x14
		public uint drawRangeCount; // 0x18
		public byte kickRangesReason; // 0x1C
		public byte isRenderingNestedTreeRT; // 0x1D
		public uint ownerOffset; // 0x20
		public uint ownerCount; // 0x24
	}
}
