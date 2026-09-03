/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.TextCore;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	[Serializable]
	public abstract class TMP_Asset : ScriptableObject // TypeDefIndex: 11783
	{
		// Fields
		[SerializeField]
		internal string m_Version; // 0x18
		[NonSerialized]
		internal EntityId m_EntityId; // 0x20
		internal int m_InstanceID; // 0x28
		internal int m_HashCode; // 0x2C
		[SerializeField]
		internal FaceInfo m_FaceInfo; // 0x30
		[FormerlySerializedAs("material")]
		[SerializeField]
		internal Material m_Material; // 0x90
		internal int m_MaterialHashCode; // 0x98
	
		// Properties
		public string version { get; internal set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public EntityId entityId { get; } // 0x000000018206F200-0x000000018206F250 
		public int hashCode { get; set; } // 0x000000018206F290-0x000000018206F300 0x00000001803FE010-0x00000001803FE020
		public FaceInfo faceInfo { get; set; } // 0x000000018206F250-0x000000018206F290 0x000000018206F3D0-0x000000018206F410
		public Material material { get; set; } // 0x00000001806CCBA0-0x00000001806CCBB0 0x0000000180664160-0x0000000180664180
		public int materialHashCode { get; set; } // 0x000000018206F300-0x000000018206F3D0 0x000000018033E7B0-0x000000018033E7C0
	
		// Constructors
		protected TMP_Asset(); // 0x00000001805F5FD0-0x00000001805F5FE0
	}
}
