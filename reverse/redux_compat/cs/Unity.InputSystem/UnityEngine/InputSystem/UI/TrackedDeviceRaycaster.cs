/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.Serialization;
using UnityEngine.UI;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.UI
{
	[AddComponentMenu("Event/Tracked Device Raycaster")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.inputsystem@1.19/manual/TrackedInputDevices.html#tracked-device-raycaster")]
	[RequireComponent(typeof(Canvas))]
	public class TrackedDeviceRaycaster : BaseRaycaster // TypeDefIndex: 6312
	{
		// Fields
		[NonSerialized]
		private List<RaycastHitData> m_RaycastResultsCache; // 0x28
		internal static InlinedArray<TrackedDeviceRaycaster> s_Instances; // 0x00
		private static readonly List<RaycastHitData> s_SortedGraphics; // 0x18
		[FormerlySerializedAs("ignoreReversedGraphics")]
		[SerializeField]
		private bool m_IgnoreReversedGraphics; // 0x30
		[FormerlySerializedAs("checkFor2DOcclusion")]
		[SerializeField]
		private bool m_CheckFor2DOcclusion; // 0x31
		[FormerlySerializedAs("checkFor3DOcclusion")]
		[SerializeField]
		private bool m_CheckFor3DOcclusion; // 0x32
		[SerializeField]
		[Tooltip("Maximum distance (in 3D world space) that rays are traced to find a hit.")]
		private float m_MaxDistance; // 0x34
		[SerializeField]
		private LayerMask m_BlockingMask; // 0x38
		[NonSerialized]
		private Canvas m_Canvas; // 0x40
	
		// Properties
		public override Camera eventCamera { get; } // 0x0000000181DBCA30-0x0000000181DBCAB0 
		public LayerMask blockingMask { get; set; } // 0x000000018047EDE0-0x000000018047EDF0 0x00000001805D5570-0x00000001805D5580
		public bool checkFor3DOcclusion { get; set; } // 0x0000000181B14850-0x0000000181B14860 0x0000000181B14870-0x0000000181B14880
		public bool checkFor2DOcclusion { get; set; } // 0x0000000180634F10-0x0000000180634F20 0x0000000181B14860-0x0000000181B14870
		public bool ignoreReversedGraphics { get; set; } // 0x00000001802E8950-0x00000001802E8960 0x00000001802E8960-0x00000001802E8970
		public float maxDistance { get; set; } // 0x0000000181230A40-0x0000000181230A50 0x0000000181230A60-0x0000000181230A70
		private Canvas canvas { get; } // 0x0000000181DBC9A0-0x0000000181DBCA30 
	
		// Nested types
		private struct RaycastHitData // TypeDefIndex: 6313
		{
			// Fields
			[CompilerGenerated]
			private readonly Graphic _graphic_k__BackingField; // 0x00
			[CompilerGenerated]
			private readonly Vector3 _worldHitPosition_k__BackingField; // 0x08
			[CompilerGenerated]
			private readonly Vector2 _screenPosition_k__BackingField; // 0x14
			[CompilerGenerated]
			private readonly float _distance_k__BackingField; // 0x1C
	
			// Properties
			public Graphic graphic { [IsReadOnly] [CompilerGenerated] get; } // 0x00000001808BADD0-0x00000001808BADE0 
			public Vector3 worldHitPosition { [IsReadOnly] [CompilerGenerated] get; } // 0x0000000181325DC0-0x0000000181325DE0 
			public Vector2 screenPosition { [IsReadOnly] [CompilerGenerated] get; } // 0x000000018112F6D0-0x000000018112F6F0 
			public float distance { [IsReadOnly] [CompilerGenerated] get; } // 0x0000000181CE2A30-0x0000000181CE2A40 
	
			// Constructors
			public RaycastHitData(Graphic graphic, Vector3 worldHitPosition, Vector2 screenPosition, float distance); // 0x0000000181DB9620-0x0000000181DB9680
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 6314
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Comparison<RaycastHitData> __9__25_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181DBCD00-0x0000000181DBCD70
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal int _SortedRaycastGraphics_b__25_0(RaycastHitData g1, RaycastHitData g2); // 0x0000000181DBCCB0-0x0000000181DBCD00
		}
	
		// Constructors
		public TrackedDeviceRaycaster(); // 0x0000000181DBC920-0x0000000181DBC9A0
		static TrackedDeviceRaycaster(); // 0x0000000181DBC890-0x0000000181DBC920
	
		// Methods
		protected override void OnEnable(); // 0x0000000181DBB6E0-0x0000000181DBB760
		protected override void OnDisable(); // 0x0000000181DBB620-0x0000000181DBB6E0
		public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList); // 0x0000000181DBC2E0-0x0000000181DBC370
		internal void PerformRaycast(ExtendedPointerEventData eventData, List<RaycastResult> resultAppendList); // 0x0000000181DBB760-0x0000000181DBBD50
		private void SortedRaycastGraphics(Canvas canvas, Ray ray, List<RaycastHitData> results); // 0x0000000181DBC370-0x0000000181DBC890
		private static bool RayIntersectsRectTransform(RectTransform transform, Ray ray, out Vector3 worldPosition, out float distance); // 0x0000000181DBBD50-0x0000000181DBC2E0
	}
}
