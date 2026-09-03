/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[AddComponentMenu("Miscellaneous/Volume")]
	[ExecuteAlways]
	public class Volume : MonoBehaviour // TypeDefIndex: 5797
	{
		// Fields
		[FormerlySerializedAs("isGlobal")]
		[SerializeField]
		private bool m_IsGlobal; // 0x20
		[Delayed]
		[FormerlySerializedAs("m_Priority")]
		public float priority; // 0x24
		[FormerlySerializedAs("m_BlendDistance")]
		public float blendDistance; // 0x28
		[FormerlySerializedAs("m_Weight")]
		[Range(0f, 1f)]
		public float weight; // 0x2C
		public VolumeProfile sharedProfile; // 0x30
		private readonly List<Collider> m_Colliders; // 0x38
		private GameObject m_CachedGameObject; // 0x40
		private int m_PreviousLayer; // 0x48
		private float m_PreviousPriority; // 0x4C
		private VolumeProfile m_InternalProfile; // 0x50
		[HideInInspector]
		[SerializeField]
		private VolumeSceneObjectReference m_SceneObjectReference; // 0x58
	
		// Properties
		public bool isGlobal { get; set; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 0x0000000181ED1AA0-0x0000000181ED1AF0
		public VolumeProfile profile { get; set; } // 0x0000000181ED1820-0x0000000181ED1AA0 0x00000001806CCE80-0x00000001806CCE90
		public List<Collider> colliders { get; } // 0x00000001803272A0-0x00000001803272B0 
		internal GameObject cachedGameObject { get; } // 0x0000000180377940-0x0000000180377950 
		internal VolumeProfile profileRef { get; } // 0x0000000181ED17A0-0x0000000181ED1820 
		internal VolumeSceneObjectReference sceneObjectReference { get; } // 0x00000001802F4000-0x00000001802F4010 
	
		// Constructors
		public Volume(); // 0x0000000181ED16E0-0x0000000181ED17A0
	
		// Methods
		public bool HasInstantiatedProfile(); // 0x0000000181ED12A0-0x0000000181ED12F0
		private void OnEnable(); // 0x0000000181ED1350-0x0000000181ED1410
		private void OnDisable(); // 0x0000000181ED12F0-0x0000000181ED1350
		private void Update(); // 0x0000000181ED15C0-0x0000000181ED16E0
		public void UpdateColliders(); // 0x0000000181ED1430-0x0000000181ED1470
		internal void UpdateLayer(); // 0x0000000181ED1470-0x0000000181ED1510
		internal void UpdatePriority(); // 0x0000000181ED1510-0x0000000181ED15C0
		private void OnValidate(); // 0x0000000181ED1410-0x0000000181ED1430
	}
}
