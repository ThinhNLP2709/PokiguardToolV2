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
using UnityEngine.Serialization;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[Serializable]
	[VisibleToOtherModules(new string[2] {"UnityEngine.VectorGraphicsModule", "UnityEditor.VectorGraphicsModule" })]
	internal struct VectorImageVertex // TypeDefIndex: 4930
	{
		// Fields
		public Vector3 position; // 0x00
		public Color32 tint; // 0x0C
		public Vector2 uv; // 0x10
		public uint settingIndex; // 0x18
		public Vector4 circle; // 0x1C
		public VertexFlags vertexFlags; // 0x2C
		[FormerlySerializedAs("flags")]
		[SerializeField]
		internal Color32 oldFlags; // 0x30
	}
}
