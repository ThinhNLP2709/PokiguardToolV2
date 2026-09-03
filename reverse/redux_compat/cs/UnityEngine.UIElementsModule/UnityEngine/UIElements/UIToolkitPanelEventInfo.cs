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
	internal struct UIToolkitPanelEventInfo // TypeDefIndex: 4234
	{
		// Fields
		public EntityId panelEntityId; // 0x00
		public EntityId targetEntityId; // 0x08
		public byte eventKind; // 0x10
		public byte _padding; // 0x11
		public ushort eventNameIndex; // 0x12
		public ushort targetTypeNameIndex; // 0x14
		public ushort targetElementNameIndex; // 0x16
		public uint buttonOrKeyCode; // 0x18
		public float positionX; // 0x1C
		public float positionY; // 0x20
		public float positionZ; // 0x24
		public uint keyCharAndModifiers; // 0x28
	}
}
