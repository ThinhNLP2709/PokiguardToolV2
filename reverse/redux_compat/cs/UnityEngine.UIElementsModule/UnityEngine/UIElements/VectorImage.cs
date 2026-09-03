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
	[Serializable]
	[HelpURL("ui-systems/work-with-vector-graphics")]
	public sealed class VectorImage : ScriptableObject, ISerializationCallbackReceiver // TypeDefIndex: 4932
	{
		// Fields
		[SerializeField]
		[VisibleToOtherModules(new string[1] {"UnityEngine.VectorGraphicsModule" })]
		internal int version; // 0x18
		[SerializeField]
		[VisibleToOtherModules(new string[2] {"UnityEngine.VectorGraphicsModule", "UnityEditor.VectorGraphicsModule" })]
		internal Texture2D atlas; // 0x20
		[SerializeField]
		[VisibleToOtherModules(new string[2] {"UnityEngine.VectorGraphicsModule", "UnityEditor.VectorGraphicsModule" })]
		internal VectorImageVertex[] vertices; // 0x28
		[SerializeField]
		[VisibleToOtherModules(new string[1] {"UnityEngine.VectorGraphicsModule" })]
		internal ushort[] indices; // 0x30
		[SerializeField]
		[VisibleToOtherModules(new string[1] {"UnityEngine.VectorGraphicsModule" })]
		internal GradientSettings[] settings; // 0x38
		[SerializeField]
		[VisibleToOtherModules(new string[1] {"UnityEngine.VectorGraphicsModule" })]
		internal Vector2 size; // 0x40
	
		// Properties
		public float width { get; } // 0x0000000181D8CC60-0x0000000181D8CC70 
		public float height { get; } // 0x0000000180349420-0x0000000180349430 
	
		// Constructors
		public VectorImage(); // 0x00000001823E2B20-0x00000001823E2B50
	
		// Methods
		void ISerializationCallbackReceiver.OnBeforeSerialize(); // 0x00000001823E2B10-0x00000001823E2B20
		void ISerializationCallbackReceiver.OnAfterDeserialize(); // 0x00000001823E2A40-0x00000001823E2B10
		private static VertexFlags DecodeLegacyFlags(Color32 oldFlags); // 0x00000001823E2970-0x00000001823E29B0
		private void OnDestroy(); // 0x00000001823E29B0-0x00000001823E2A40
	}
}
