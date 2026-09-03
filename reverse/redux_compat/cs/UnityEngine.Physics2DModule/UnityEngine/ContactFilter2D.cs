/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;

// Image 54: UnityEngine.Physics2DModule.dll - Assembly: UnityEngine.Physics2DModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15597-15610

namespace UnityEngine
{
	[Serializable]
	[NativeClass("ContactFilter", "struct ContactFilter;")]
	[NativeHeader("Modules/Physics2D/Public/Collider2D.h")]
	public struct ContactFilter2D // TypeDefIndex: 15602
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static ContactFilter2D _noFilter; // 0x00
		[NativeName("m_UseTriggers")]
		public bool useTriggers; // 0x00
		[NativeName("m_UseLayerMask")]
		public bool useLayerMask; // 0x01
		[NativeName("m_UseDepth")]
		public bool useDepth; // 0x02
		[NativeName("m_UseOutsideDepth")]
		public bool useOutsideDepth; // 0x03
		[NativeName("m_UseNormalAngle")]
		public bool useNormalAngle; // 0x04
		[NativeName("m_UseOutsideNormalAngle")]
		public bool useOutsideNormalAngle; // 0x05
		[NativeName("m_LayerMask")]
		public LayerMask layerMask; // 0x08
		[NativeName("m_MinDepth")]
		public float minDepth; // 0x0C
		[NativeName("m_MaxDepth")]
		public float maxDepth; // 0x10
		[NativeName("m_MinNormalAngle")]
		public float minNormalAngle; // 0x14
		[NativeName("m_MaxNormalAngle")]
		public float maxNormalAngle; // 0x18
	
		// Constructors
		static ContactFilter2D(); // 0x00000001822C0F90-0x00000001822C1010
	
		// Methods
		private void CheckConsistency(); // 0x00000001822C0D80-0x00000001822C0DC0
		public void SetLayerMask(LayerMask layerMask); // 0x00000001822C0F80-0x00000001822C0F90
		public void SetDepth(float minDepth, float maxDepth); // 0x00000001822C0EF0-0x00000001822C0F80
		internal static ContactFilter2D CreateLegacyFilter(int layerMask, float minDepth, float maxDepth); // 0x00000001822C0DC0-0x00000001822C0EF0
	}
}
