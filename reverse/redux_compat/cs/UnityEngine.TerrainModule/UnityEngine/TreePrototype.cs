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

// Image 51: UnityEngine.TerrainModule.dll - Assembly: UnityEngine.TerrainModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15533-15553

namespace UnityEngine
{
	[NativeAsStruct]
	[UsedByNativeCode]
	public sealed class TreePrototype // TypeDefIndex: 15540
	{
		// Fields
		[NativeName("prefab")]
		internal GameObject m_Prefab; // 0x10
		[NativeName("bendFactor")]
		internal float m_BendFactor; // 0x18
		[NativeName("navMeshLod")]
		internal int m_NavMeshLod; // 0x1C
	
		// Properties
		public GameObject prefab { get; } // 0x0000000180377550-0x0000000180377560 
		public float bendFactor { get; } // 0x00000001806CB0A0-0x00000001806CB0B0 
		public int navMeshLod { get; } // 0x0000000180B232F0-0x0000000180B23300 
	
		// Constructors
		public TreePrototype(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public override bool Equals(object obj); // 0x00000001822EDEE0-0x00000001822EE020
		public override int GetHashCode(); // 0x0000000181474D40-0x0000000181474D50
		private bool Equals(TreePrototype other); // 0x00000001822EE020-0x00000001822EE110
	}
}
