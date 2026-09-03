/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine
{
	[AddComponentMenu("Rendering/Light Anchor")]
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	public class LightAnchor : MonoBehaviour // TypeDefIndex: 5305
	{
		// Fields
		private const float k_ArcRadius = 5f; // Metadata: 0x00661471
		private const float k_AxisLength = 10f; // Metadata: 0x00661475
		internal const float k_MaxDistance = 10000f; // Metadata: 0x00661479
		[Min(0f)]
		[SerializeField]
		private float m_Distance; // 0x20
		[SerializeField]
		private UpDirection m_FrameSpace; // 0x24
		[SerializeField]
		private Transform m_AnchorPositionOverride; // 0x28
		[SerializeField]
		private Vector3 m_AnchorPositionOffset; // 0x30
		[SerializeField]
		private float m_Yaw; // 0x3C
		[SerializeField]
		private float m_Pitch; // 0x40
		[SerializeField]
		private float m_Roll; // 0x44
	
		// Properties
		public float yaw { get; set; } // 0x0000000181C58AB0-0x0000000181C58AC0 0x0000000181E25D00-0x0000000181E25D50
		public float pitch { get; set; } // 0x0000000181D8CC60-0x0000000181D8CC70 0x0000000181E25C60-0x0000000181E25CB0
		public float roll { get; set; } // 0x0000000180349420-0x0000000180349430 0x0000000181E25CB0-0x0000000181E25D00
		public float distance { get; set; } // 0x0000000181CE2820-0x0000000181CE2830 0x0000000181E25C40-0x0000000181E25C60
		public UpDirection frameSpace { get; set; } // 0x0000000180D17D10-0x0000000180D17D20 0x0000000180E02560-0x0000000180E02570
		public Vector3 anchorPosition { get; } // 0x0000000181E25A80-0x0000000181E25C30 
		public Transform anchorPositionOverride { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		public Vector3 anchorPositionOffset { get; set; } // 0x0000000181E25A60-0x0000000181E25A80 0x0000000181E25C30-0x0000000181E25C40
	
		// Nested types
		public enum UpDirection // TypeDefIndex: 5306
		{
			World = 0,
			Local = 1
		}
	
		private struct Axes // TypeDefIndex: 5307
		{
			// Fields
			public Vector3 up; // 0x00
			public Vector3 right; // 0x0C
			public Vector3 forward; // 0x18
		}
	
		// Constructors
		public LightAnchor(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		public static float NormalizeAngleDegree(float angle); // 0x0000000181E24840-0x0000000181E24890
		public void SynchronizeOnTransform(Camera camera); // 0x0000000181E24990-0x0000000181E25210
		public void UpdateTransform(Camera camera, Vector3 anchor); // 0x0000000181E25210-0x0000000181E25300
		private Axes GetWorldSpaceAxes(Camera camera, Vector3 anchor); // 0x0000000181E23BC0-0x0000000181E24840
		private void Update(); // 0x0000000181E25880-0x0000000181E25A60
		private void OnDrawGizmosSelected(); // 0x0000000181E24890-0x0000000181E24990
		private void UpdateTransform(Vector3 up, Vector3 right, Vector3 forward, Vector3 anchor); // 0x0000000181E25300-0x0000000181E25880
	}
}
