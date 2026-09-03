/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI.CoroutineTween;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	public abstract class Graphic : UIBehaviour, ICanvasElement // TypeDefIndex: 13035
	{
		// Fields
		protected static Material s_DefaultUI; // 0x00
		protected static Texture2D s_WhiteTexture; // 0x08
		protected static Mesh s_Mesh; // 0x10
		private static readonly VertexHelper s_VertexHelper; // 0x18
		private static readonly ProfilerMarker s_OnPopulateMeshMarker; // 0x20
		private static readonly ProfilerMarker s_ModifyMeshMarker; // 0x28
		[FormerlySerializedAs("m_Mat")]
		[SerializeField]
		protected Material m_Material; // 0x20
		[SerializeField]
		private Color m_Color; // 0x28
		[NonSerialized]
		protected bool m_SkipLayoutUpdate; // 0x38
		[NonSerialized]
		protected bool m_SkipMaterialUpdate; // 0x39
		[SerializeField]
		private bool m_RaycastTarget; // 0x3A
		private bool m_RaycastTargetCache; // 0x3B
		[SerializeField]
		private Vector4 m_RaycastPadding; // 0x3C
		[NonSerialized]
		private RectTransform m_RectTransform; // 0x50
		[NonSerialized]
		private CanvasRenderer m_CanvasRenderer; // 0x58
		[NonSerialized]
		private Canvas m_Canvas; // 0x60
		[NonSerialized]
		private bool m_VertsDirty; // 0x68
		[NonSerialized]
		private bool m_MaterialDirty; // 0x69
		[NonSerialized]
		protected UnityAction m_OnDirtyLayoutCallback; // 0x70
		[NonSerialized]
		protected UnityAction m_OnDirtyVertsCallback; // 0x78
		[NonSerialized]
		protected UnityAction m_OnDirtyMaterialCallback; // 0x80
		[NonSerialized]
		protected Mesh m_CachedMesh; // 0x88
		[NonSerialized]
		protected Vector2[] m_CachedUvs; // 0x90
		[NonSerialized]
		private readonly TweenRunner<ColorTween> m_ColorTweenRunner; // 0x98
		[CompilerGenerated]
		private bool _useLegacyMeshGeneration_k__BackingField; // 0xA0
	
		// Properties
		public static Material defaultGraphicMaterial { get; } // 0x0000000182370DC0-0x0000000182370EB0 
		public virtual Color color { get; set; } // 0x0000000180C46B90-0x0000000180C46BA0 0x0000000182371410-0x0000000182371460
		public virtual bool raycastTarget { get; set; } // 0x00000001814CFF20-0x00000001814CFF30 0x0000000182371500-0x0000000182371600
		public Vector4 raycastPadding { get; set; } // 0x0000000181FA2B30-0x0000000181FA2B40 0x0000000181FA2B40-0x0000000181FA2B50
		[Obsolete("useLegacyMeshGeneration is deprecated now that the legacy mesh generation is no longer supported.")]
		protected bool useLegacyMeshGeneration { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018165FFF0-0x0000000181660000 0x0000000181727470-0x0000000181727480
		public int depth { get; } // 0x0000000182370FD0-0x0000000182371000 
		public RectTransform rectTransform { get; } // 0x0000000182371290-0x00000001823712F0 
		public Canvas canvas { get; } // 0x0000000182370D50-0x0000000182370DC0 
		public CanvasRenderer canvasRenderer { get; } // 0x0000000182370CB0-0x0000000182370D50 
		public virtual Material defaultMaterial { get; } // 0x0000000182370EB0-0x0000000182370FD0 
		public virtual Material material { get; set; } // 0x0000000182371200-0x0000000182371290 0x0000000182371460-0x0000000182371500
		public virtual Material materialForRendering { get; } // 0x0000000182371050-0x0000000182371200 
		public virtual Texture mainTexture { get; } // 0x0000000182371000-0x0000000182371050 
		protected static Mesh workerMesh { get; } // 0x00000001823712F0-0x0000000182371410 
		Transform ICanvasElement.transform { get; } // 0x0000000182091C50-0x0000000182091C60 
	
		// Constructors
		protected Graphic(); // 0x0000000182370BF0-0x0000000182370CB0
		static Graphic(); // 0x0000000182370AA0-0x0000000182370BF0
	
		// Methods
		public virtual void SetAllDirty(); // 0x0000000182370370-0x00000001823703E0
		public virtual void SetLayoutDirty(); // 0x00000001823703E0-0x00000001823704C0
		public virtual void SetVerticesDirty(); // 0x0000000182370680-0x0000000182370760
		public virtual void SetMaterialDirty(); // 0x00000001823704C0-0x00000001823705A0
		public void SetRaycastDirty(); // 0x00000001823705A0-0x0000000182370680
		protected override void OnRectTransformDimensionsChange(); // 0x000000018236F7C0-0x000000018236F8B0
		protected override void OnBeforeTransformParentChanged(); // 0x000000018236ED40-0x000000018236EE60
		protected override void OnTransformParentChanged(); // 0x000000018236F8B0-0x000000018236F970
		private void CacheCanvas(); // 0x000000018236DFC0-0x000000018236E110
		protected override void OnEnable(); // 0x000000018236F370-0x000000018236F4E0
		protected override void OnDisable(); // 0x000000018236F1B0-0x000000018236F370
		protected override void OnDestroy(); // 0x000000018236F070-0x000000018236F1B0
		protected override void OnCanvasHierarchyChanged(); // 0x000000018236EE60-0x000000018236EFA0
		public virtual void OnCullingChanged(); // 0x000000018236EFA0-0x000000018236F070
		public virtual void Rebuild(CanvasUpdate update); // 0x00000001823700A0-0x0000000182370180
		public virtual void LayoutComplete(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void GraphicUpdateComplete(); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void UpdateMaterial(); // 0x00000001823709D0-0x0000000182370AA0
		protected virtual void UpdateGeometry(); // 0x0000000182370950-0x00000001823709D0
		private void DoMeshGeneration(); // 0x000000018236E520-0x000000018236EB50
		[Obsolete("Use OnPopulateMesh(VertexHelper vh) instead.", true)]
		protected virtual void OnPopulateMesh(Mesh m); // 0x000000018236F4E0-0x000000018236F580
		protected virtual void OnPopulateMesh(VertexHelper vh); // 0x000000018236F580-0x000000018236F7C0
		protected override void OnDidApplyAnimationProperties(); // 0x0000000181AE8230-0x0000000181AE8250
		public virtual void SetNativeSize(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual bool Raycast(Vector2 sp, Camera eventCamera); // 0x0000000182370080-0x00000001823700A0
		protected bool Raycast(Vector2 sp, Camera eventCamera, bool ignoreMasks); // 0x000000018236FB00-0x0000000182370080
		public Vector2 PixelAdjustPoint(Vector2 point); // 0x000000018236F970-0x000000018236FB00
		public Rect GetPixelAdjustedRect(); // 0x000000018236EB50-0x000000018236ED40
		public virtual void CrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha); // 0x000000018236E4E0-0x000000018236E520
		public virtual void CrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha, bool useRGB); // 0x000000018236E200-0x000000018236E4E0
		private static Color CreateColorFromAlpha(float alpha); // 0x000000018236E110-0x000000018236E130
		public virtual void CrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale); // 0x000000018236E130-0x000000018236E200
		public void RegisterDirtyLayoutCallback(UnityAction action); // 0x0000000182370180-0x0000000182370220
		public void UnregisterDirtyLayoutCallback(UnityAction action); // 0x0000000182370760-0x0000000182370800
		public void RegisterDirtyVerticesCallback(UnityAction action); // 0x00000001823702D0-0x0000000182370370
		public void UnregisterDirtyVerticesCallback(UnityAction action); // 0x00000001823708B0-0x0000000182370950
		public void RegisterDirtyMaterialCallback(UnityAction action); // 0x0000000182370220-0x00000001823702D0
		public void UnregisterDirtyMaterialCallback(UnityAction action); // 0x0000000182370800-0x00000001823708B0
	}
}
