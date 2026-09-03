/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

// Image 31: UnityEngine.PhysicsCore2DModule.dll - Assembly: UnityEngine.PhysicsCore2DModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14601-14714

namespace Unity.U2D.Physics
{
	[IsReadOnly]
	[MovedFrom(true, "UnityEngine.LowLevelPhysics2D", "UnityEngine.Physics2DModule", null)]
	public struct PhysicsLayers // TypeDefIndex: 14672
	{
		// Nested types
		[Serializable]
		public class LayerNames : ISerializationCallbackReceiver // TypeDefIndex: 14673
		{
			// Fields
			[SerializeField]
			internal string[] m_Names; // 0x10
			private Dictionary<string, int> m_NameMap; // 0x18
	
			// Properties
			private string[] Names { get; } // 0x00000001822C5FB0-0x00000001822C6020 
			private Dictionary<string, int> NameMap { get; } // 0x00000001822C5F30-0x00000001822C5FB0 
			internal static LayerNames DefaultLayerNames { get; } // 0x00000001822C5E00-0x00000001822C5F30 
	
			// Constructors
			public LayerNames(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public void OnBeforeSerialize(); // 0x00000001802E76C0-0x00000001802E76D0
			public void OnAfterDeserialize(); // 0x00000001822C5CF0-0x00000001822C5E00
		}
	}
}
