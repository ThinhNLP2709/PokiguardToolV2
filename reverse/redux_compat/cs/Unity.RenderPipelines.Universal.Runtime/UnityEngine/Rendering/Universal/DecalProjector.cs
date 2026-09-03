/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[AddComponentMenu("Rendering/URP Decal Projector")]
	[ExecuteAlways]
	public class DecalProjector : MonoBehaviour, ISerializationCallbackReceiver // TypeDefIndex: 9415
	{
		// Fields
		[CompilerGenerated]
		private static DecalProjectorAction onDecalAdd; // 0x00
		[CompilerGenerated]
		private static DecalProjectorAction onDecalRemove; // 0x08
		[CompilerGenerated]
		private static DecalProjectorAction onDecalPropertyChange; // 0x10
		[CompilerGenerated]
		private static Action onAllDecalPropertyChange; // 0x18
		[CompilerGenerated]
		private static DecalProjectorAction onDecalMaterialChange; // 0x20
		[CompilerGenerated]
		private static Material _defaultMaterial_k__BackingField; // 0x28
		[CompilerGenerated]
		private DecalEntity _decalEntity_k__BackingField; // 0x20
		[SerializeField]
		private Material m_Material; // 0x28
		[SerializeField]
		private float m_DrawDistance; // 0x30
		[Range(0f, 1f)]
		[SerializeField]
		private float m_FadeScale; // 0x34
		[Range(0f, 180f)]
		[SerializeField]
		private float m_StartAngleFade; // 0x38
		[Range(0f, 180f)]
		[SerializeField]
		private float m_EndAngleFade; // 0x3C
		[SerializeField]
		private Vector2 m_UVScale; // 0x40
		[SerializeField]
		private Vector2 m_UVBias; // 0x48
		[SerializeField]
		private RenderingLayerMask m_RenderingLayerMask; // 0x50
		[SerializeField]
		private DecalScaleMode m_ScaleMode; // 0x54
		[SerializeField]
		internal Vector3 m_Offset; // 0x58
		[SerializeField]
		internal Vector3 m_Size; // 0x64
		[Range(0f, 1f)]
		[SerializeField]
		private float m_FadeFactor; // 0x70
		private Material m_OldMaterial; // 0x78
		private float m_OldDrawDistance; // 0x80
		private float m_OldFadeScale; // 0x84
		private float m_OldStartAngleFade; // 0x88
		private float m_OldEndAngleFade; // 0x8C
		private Vector2 m_OldUVScale; // 0x90
		private Vector2 m_OldUVBias; // 0x98
		private DecalScaleMode m_OldScaleMode; // 0xA0
		private Vector3 m_OldOffset; // 0xA4
		private Vector3 m_OldSize; // 0xB0
		private float m_OldFadeFactor; // 0xBC
		[SerializeField]
		private Version version; // 0xC0
		[Obsolete("This field is only kept for migration purpose. Use m_RenderingLayersMask instead. #from(6000.2)")]
		[SerializeField]
		private uint m_DecalLayerMask; // 0xC4
	
		// Properties
		internal static Material defaultMaterial { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181F7C250-0x0000000181F7C290 0x0000000181F7C7C0-0x0000000181F7C820
		internal static bool isSupported { get; } // 0x0000000181F7C320-0x0000000181F7C360 
		internal DecalEntity decalEntity { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8630-0x00000001802F8640 0x0000000181727440-0x0000000181727450
		public Material material { get; set; } // 0x000000018033D240-0x000000018033D250 0x0000000181F7C8B0-0x0000000181F7C8E0
		public float drawDistance { get; set; } // 0x00000001806CCB40-0x00000001806CCB50 0x0000000181F7C820-0x0000000181F7C840
		public float fadeScale { get; set; } // 0x0000000181230A40-0x0000000181230A50 0x0000000181F7C890-0x0000000181F7C8B0
		public float startAngleFade { get; set; } // 0x0000000181C62E80-0x0000000181C62E90 0x0000000181F7C930-0x0000000181F7C950
		public float endAngleFade { get; set; } // 0x0000000181C58AB0-0x0000000181C58AC0 0x0000000181F7C840-0x0000000181F7C870
		public Vector2 uvScale { get; set; } // 0x0000000181F7C3E0-0x0000000181F7C400 0x0000000181F7C960-0x0000000181F7C970
		public Vector2 uvBias { get; set; } // 0x0000000181F7C3A0-0x0000000181F7C3C0 0x0000000181F7C950-0x0000000181F7C960
		public RenderingLayerMask renderingLayerMask { get; set; } // 0x000000018033D660-0x000000018033D670 0x000000018033EC40-0x000000018033EC50
		public DecalScaleMode scaleMode { get; set; } // 0x0000000180CC1EB0-0x0000000180CC1EC0 0x0000000181F7C900-0x0000000181F7C910
		public Vector3 pivot { get; set; } // 0x0000000181F7C360-0x0000000181F7C380 0x0000000181F7C8E0-0x0000000181F7C900
		public Vector3 size { get; set; } // 0x0000000181F7C380-0x0000000181F7C3A0 0x0000000181F7C910-0x0000000181F7C930
		public float fadeFactor { get; set; } // 0x0000000181F7C310-0x0000000181F7C320 0x0000000181F7C870-0x0000000181F7C890
		internal Vector3 effectiveScale { get; } // 0x0000000181F7C290-0x0000000181F7C310 
		internal Vector3 decalSize { get; } // 0x0000000181F7C230-0x0000000181F7C250 
		internal Vector3 decalOffset { get; } // 0x0000000181F7C210-0x0000000181F7C230 
		internal Vector4 uvScaleBias { get; } // 0x0000000181F7C3C0-0x0000000181F7C3E0 
	
		// Events
		internal static event DecalProjectorAction onDecalAdd {
			add; // 0x0000000181F7BF10-0x0000000181F7BFD0
			remove; // 0x0000000181F7C4C0-0x0000000181F7C580
		}
		internal static event DecalProjectorAction onDecalRemove {
			add; // 0x0000000181F7C150-0x0000000181F7C210
			remove; // 0x0000000181F7C700-0x0000000181F7C7C0
		}
		internal static event DecalProjectorAction onDecalPropertyChange {
			add; // 0x0000000181F7C090-0x0000000181F7C150
			remove; // 0x0000000181F7C640-0x0000000181F7C700
		}
		internal static event Action onAllDecalPropertyChange {
			add; // 0x0000000181F7BE50-0x0000000181F7BF10
			remove; // 0x0000000181F7C400-0x0000000181F7C4C0
		}
		internal static event DecalProjectorAction onDecalMaterialChange {
			add; // 0x0000000181F7BFD0-0x0000000181F7C090
			remove; // 0x0000000181F7C580-0x0000000181F7C640
		}
	
		// Nested types
		internal delegate void DecalProjectorAction(DecalProjector decalProjector); // TypeDefIndex: 9416; 0x00000001804A78A0-0x00000001804A78B0
	
		private enum Version // TypeDefIndex: 9417
		{
			Initial = 0,
			RenderingLayerMask = 1,
			Count = 2
		}
	
		// Constructors
		public DecalProjector(); // 0x0000000181F7BCB0-0x0000000181F7BE50
	
		// Methods
		private void InitMaterial(); // 0x0000000181F7B580-0x0000000181F7B5D0
		private void OnEnable(); // 0x0000000181F7B990-0x0000000181F7BA40
		private void OnDisable(); // 0x0000000181F7B930-0x0000000181F7B990
		internal void OnValidate(); // 0x0000000181F7BA40-0x0000000181F7BBB0
		private void OnDidApplyAnimationProperties(); // 0x0000000181F7B6F0-0x0000000181F7B930
		public bool IsValid(); // 0x0000000181F7B5D0-0x0000000181F7B6F0
		internal static void UpdateAllDecalProperties(); // 0x0000000181F7BC60-0x0000000181F7BCB0
		void ISerializationCallbackReceiver.OnBeforeSerialize(); // 0x0000000181F7BC40-0x0000000181F7BC60
		void ISerializationCallbackReceiver.OnAfterDeserialize(); // 0x0000000181F7BBB0-0x0000000181F7BC40
	}
}
