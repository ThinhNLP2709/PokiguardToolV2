/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.U2D;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	[AddComponentMenu("UI (Canvas)/Image", 11)]
	[RequireComponent(typeof(CanvasRenderer))]
	[UGUIHelpURL("Image")]
	public class Image : MaskableGraphic, ISerializationCallbackReceiver, ILayoutElement, ICanvasRaycastFilter // TypeDefIndex: 13042
	{
		// Fields
		protected static Material s_ETC1DefaultUI; // 0x00
		private static SecondarySpriteTexture[] s_TempNewSecondaryTextures; // 0x08
		private static readonly List<Image> m_TrackedTexturelessImages; // 0x10
		private static bool s_Initialized; // 0x18
		[FormerlySerializedAs("m_Frame")]
		[SerializeField]
		private Sprite m_Sprite; // 0xE0
		[NonSerialized]
		private Sprite m_OverrideSprite; // 0xE8
		[SerializeField]
		private Type m_Type; // 0xF0
		[SerializeField]
		private bool m_PreserveAspect; // 0xF4
		[SerializeField]
		private bool m_FillCenter; // 0xF5
		[SerializeField]
		private FillMethod m_FillMethod; // 0xF8
		[Range(0f, 1f)]
		[SerializeField]
		private float m_FillAmount; // 0xFC
		[SerializeField]
		private bool m_FillClockwise; // 0x100
		[SerializeField]
		private int m_FillOrigin; // 0x104
		private float m_AlphaHitTestMinimumThreshold; // 0x108
		private bool m_Tracked; // 0x10C
		[SerializeField]
		private bool m_UseSpriteMesh; // 0x10D
		[SerializeField]
		private float m_PixelsPerUnitMultiplier; // 0x110
		private float m_CachedReferencePixelsPerUnit; // 0x114
		private SecondarySpriteTexture[] m_SecondaryTextures; // 0x118
		private static readonly Vector2[] s_VertScratch; // 0x20
		private static readonly Vector2[] s_UVScratch; // 0x28
		private static readonly Vector3[] s_Xy; // 0x30
		private static readonly Vector3[] s_Uv; // 0x38
	
		// Properties
		public Sprite sprite { get; set; } // 0x00000001806CCB80-0x00000001806CCB90 0x00000001823796F0-0x0000000182379A80
		public Sprite overrideSprite { get; set; } // 0x0000000182378CD0-0x0000000182378CE0 0x00000001823795A0-0x0000000182379650
		private Sprite activeSprite { get; } // 0x00000001823786E0-0x0000000182378760 
		public Type type { get; set; } // 0x0000000181C0F730-0x0000000181C0F740 0x0000000182379A80-0x0000000182379AF0
		public bool preserveAspect { get; set; } // 0x00000001823308B0-0x00000001823308C0 0x0000000182379680-0x00000001823796F0
		public bool fillCenter { get; set; } // 0x0000000182378870-0x0000000182378880 0x00000001823793E0-0x0000000182379450
		public FillMethod fillMethod { get; set; } // 0x0000000181F64590-0x0000000181F645A0 0x00000001823794C0-0x0000000182379530
		public float fillAmount { get; set; } // 0x0000000181E8FE00-0x0000000181E8FE10 0x0000000182379360-0x00000001823793E0
		public bool fillClockwise { get; set; } // 0x000000018170B140-0x000000018170B150 0x0000000182379450-0x00000001823794C0
		public int fillOrigin { get; set; } // 0x0000000181E8FE20-0x0000000181E8FE30 0x0000000182379530-0x00000001823795A0
		[Obsolete("eventAlphaThreshold has been deprecated. Use eventMinimumAlphaThreshold instead (UnityUpgradable) -> alphaHitTestMinimumThreshold", true)]
		public float eventAlphaThreshold { get; set; } // 0x0000000182378850-0x0000000182378870 0x00000001823791F0-0x0000000182379360
		public float alphaHitTestMinimumThreshold { get; set; } // 0x0000000181E8FE10-0x0000000181E8FE20 0x0000000182379090-0x00000001823791F0
		public bool useSpriteMesh { get; set; } // 0x0000000182379080-0x0000000182379090 0x0000000182379AF0-0x0000000182379B60
		public static Material defaultETC1GraphicMaterial { get; } // 0x0000000182378760-0x0000000182378850 
		public override Texture mainTexture { get; } // 0x0000000182378960-0x0000000182378AC0 
		public bool hasBorder { get; } // 0x0000000182378880-0x0000000182378960 
		public float pixelsPerUnitMultiplier { get; set; } // 0x0000000182378CE0-0x0000000182378CF0 0x0000000182379650-0x0000000182379680
		public float pixelsPerUnit { get; } // 0x0000000182378CF0-0x0000000182378E20 
		protected float multipliedPixelsPerUnit { get; } // 0x0000000182378CB0-0x0000000182378CD0 
		public override Material material { get; set; } // 0x0000000182378AC0-0x0000000182378CB0 0x0000000182371460-0x0000000182371500
		internal SecondarySpriteTexture[] secondaryTextures { get; } // 0x000000018171E0D0-0x000000018171E0E0 
		public virtual float minWidth { get; } // 0x00000001807185C0-0x00000001807185D0 
		public virtual float maxWidth { get; } // 0x00000001820939A0-0x00000001820939B0 
		public virtual float preferredWidth { get; } // 0x0000000182378F50-0x0000000182379080 
		public virtual float flexibleWidth { get; } // 0x0000000181D048F0-0x0000000181D04900 
		public virtual float minHeight { get; } // 0x00000001807185C0-0x00000001807185D0 
		public virtual float maxHeight { get; } // 0x00000001820939A0-0x00000001820939B0 
		public virtual float preferredHeight { get; } // 0x0000000182378E20-0x0000000182378F50 
		public virtual float flexibleHeight { get; } // 0x0000000181D048F0-0x0000000181D04900 
		public virtual int layoutPriority { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Nested types
		public enum Type // TypeDefIndex: 13043
		{
			Simple = 0,
			Sliced = 1,
			Tiled = 2,
			Filled = 3
		}
	
		public enum FillMethod // TypeDefIndex: 13044
		{
			Horizontal = 0,
			Vertical = 1,
			Radial90 = 2,
			Radial180 = 3,
			Radial360 = 4
		}
	
		public enum OriginHorizontal // TypeDefIndex: 13045
		{
			Left = 0,
			Right = 1
		}
	
		public enum OriginVertical // TypeDefIndex: 13046
		{
			Bottom = 0,
			Top = 1
		}
	
		public enum Origin90 // TypeDefIndex: 13047
		{
			BottomLeft = 0,
			TopLeft = 1,
			TopRight = 2,
			BottomRight = 3
		}
	
		public enum Origin180 // TypeDefIndex: 13048
		{
			Bottom = 0,
			Left = 1,
			Top = 2,
			Right = 3
		}
	
		public enum Origin360 // TypeDefIndex: 13049
		{
			Bottom = 0,
			Right = 1,
			Top = 2,
			Left = 3
		}
	
		// Constructors
		protected Image(); // 0x00000001823786A0-0x00000001823786E0
		static Image(); // 0x0000000182378470-0x00000001823786A0
	
		// Methods
		public void DisableSpriteOptimizations(); // 0x0000000182371CC0-0x0000000182371CD0
		public virtual void OnBeforeSerialize(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void OnAfterDeserialize(); // 0x00000001823768C0-0x0000000182376930
		private void PreserveSpriteAspectRatio(ref Rect rect, Vector2 spriteSize); // 0x0000000182376CC0-0x0000000182376E80
		private Vector4 GetDrawingDimensions(bool shouldPreserveAspect); // 0x00000001823759D0-0x0000000182375CD0
		public override void SetNativeSize(); // 0x0000000182377670-0x00000001823778B0
		protected override void OnPopulateMesh(VertexHelper toFill); // 0x0000000182376B70-0x0000000182376CC0
		private void TrackSprite(); // 0x0000000182377CA0-0x0000000182377EC0
		protected override void OnEnable(); // 0x0000000182376B50-0x0000000182376B70
		protected override void OnDisable(); // 0x0000000182376AE0-0x0000000182376B50
		private static void ClearArray(ref SecondarySpriteTexture[] array); // 0x0000000182371C40-0x0000000182371CC0
		private bool CheckSecondaryTexturesChanged(Sprite sprite); // 0x00000001823719A0-0x0000000182371A30
		private bool CheckSecondaryTexturesChanged(Sprite sprite, ref SecondarySpriteTexture[] newSecondaryTextures); // 0x0000000182371A30-0x0000000182371C40
		internal void SetSecondaryTextures(CanvasRenderer renderer); // 0x00000001823778B0-0x0000000182377B40
		protected override void UpdateMaterial(); // 0x00000001823782C0-0x0000000182378470
		protected override void OnCanvasHierarchyChanged(); // 0x0000000182376930-0x0000000182376A90
		private void GenerateSimpleSprite(VertexHelper vh, bool lPreserveAspect); // 0x0000000182372EC0-0x0000000182373230
		private void GenerateSprite(VertexHelper vh, bool lPreserveAspect); // 0x0000000182373B50-0x0000000182374180
		private void GenerateSlicedSprite(VertexHelper toFill); // 0x0000000182373230-0x0000000182373B50
		private void GenerateTiledSprite(VertexHelper toFill); // 0x0000000182374180-0x00000001823755D0
		private static void AddQuad(VertexHelper vertexHelper, Vector3[] quadPositions, Color32 color, Vector3[] quadUVs); // 0x0000000182371830-0x00000001823719A0
		private static void AddQuad(VertexHelper vertexHelper, Vector2 posMin, Vector2 posMax, Color32 color, Vector2 uvMin, Vector2 uvMax); // 0x0000000182371600-0x0000000182371830
		private Vector4 GetAdjustedBorders(Vector4 border, Rect adjustedRect); // 0x00000001823755D0-0x00000001823759D0
		private void GenerateFilledSprite(VertexHelper toFill, bool preserveAspect); // 0x0000000182371CD0-0x0000000182372EC0
		private static bool RadialCut(Vector3[] xy, Vector3[] uv, float fill, bool invert, int corner); // 0x0000000182376E80-0x0000000182376FD0
		private static void RadialCut(Vector3[] xy, float cos, float sin, bool invert, int corner); // 0x0000000182376FD0-0x00000001823774B0
		public virtual void CalculateLayoutInputHorizontal(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void CalculateLayoutInputVertical(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera); // 0x0000000182375CD0-0x0000000182376120
		private Vector2 MapCoordinate(Vector2 local, Rect rect); // 0x0000000182376120-0x00000001823768C0
		private static void RebuildImage(SpriteAtlas spriteAtlas); // 0x00000001823774B0-0x0000000182377670
		private static void TrackImage(Image g); // 0x0000000182377B40-0x0000000182377CA0
		private static void UnTrackImage(Image g); // 0x0000000182378240-0x00000001823782C0
		protected override void OnDidApplyAnimationProperties(); // 0x0000000182376A90-0x0000000182376AE0
		[CompilerGenerated]
		private void _set_sprite_g__ResetAlphaHitThresholdIfNeeded_14_0(); // 0x0000000182377F80-0x0000000182378110
		[CompilerGenerated]
		private bool _set_sprite_g__SpriteSupportsAlphaHitTest_14_1(); // 0x0000000182378110-0x0000000182378240
		[CompilerGenerated]
		internal static bool _CheckSecondaryTexturesChanged_g__Compare_95_0(SecondarySpriteTexture[] array1, SecondarySpriteTexture[] array2); // 0x0000000182377EC0-0x0000000182377F80
	}
}
