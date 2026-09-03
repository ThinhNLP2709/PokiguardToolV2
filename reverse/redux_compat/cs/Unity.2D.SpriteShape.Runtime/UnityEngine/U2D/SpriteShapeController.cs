/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

// Image 24: Unity.2D.SpriteShape.Runtime.dll - Assembly: Unity.2D.SpriteShape.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13957-14022

namespace UnityEngine.U2D
{
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.2d.spriteshape@latest/index.html?subfolder=/manual/SSController.html")]
	[RequireComponent(typeof(SpriteShapeRenderer))]
	public class SpriteShapeController : MonoBehaviour // TypeDefIndex: 13998
	{
		// Fields
		private const float s_DistanceTolerance = 0.001f; // Metadata: 0x006A916C
		private SpriteShape m_ActiveSpriteShape; // 0x20
		private EdgeCollider2D m_EdgeCollider2D; // 0x28
		private PolygonCollider2D m_PolygonCollider2D; // 0x30
		private SpriteShapeRenderer m_SpriteShapeRenderer; // 0x38
		private SpriteShapeGeometryCache m_SpriteShapeGeometryCache; // 0x40
		private Sprite[] m_SpriteArray; // 0x48
		private Sprite[] m_EdgeSpriteArray; // 0x50
		private Sprite[] m_CornerSpriteArray; // 0x58
		private AngleRangeInfo[] m_AngleRangeInfoArray; // 0x60
		private NativeArray<float2> m_ColliderData; // 0x68
		private NativeArray<float2> m_ShadowData; // 0x78
		private NativeArray<Vector4> m_TangentData; // 0x88
		private NativeArray<SpriteShapeGeneratorStats> m_Statistics; // 0x98
		private bool m_DynamicOcclusionLocal; // 0xA8
		private bool m_DynamicOcclusionOverriden; // 0xA9
		private bool m_TessellationNeedsFallback; // 0xAA
		private bool m_WaitForBake; // 0xAB
		private int m_ActiveSplineHash; // 0xAC
		private int m_ActiveSpriteShapeHash; // 0xB0
		private int m_MaxArrayCount; // 0xB4
		private JobHandle m_JobHandle; // 0xB8
		private SpriteShapeParameters m_ActiveShapeParameters; // 0xC8
		[SerializeField]
		private Spline m_Spline; // 0x130
		[SerializeField]
		private SpriteShape m_SpriteShape; // 0x138
		[SerializeField]
		private float m_FillPixelPerUnit; // 0x140
		[SerializeField]
		private float m_StretchTiling; // 0x144
		[SerializeField]
		private int m_SplineDetail; // 0x148
		[SerializeField]
		private bool m_AdaptiveUV; // 0x14C
		[SerializeField]
		private bool m_StretchUV; // 0x14D
		[SerializeField]
		private bool m_WorldSpaceUV; // 0x14E
		[SerializeField]
		private float m_CornerAngleThreshold; // 0x150
		[SerializeField]
		private int m_ColliderDetail; // 0x154
		[Range(-0.5f, 0.5f)]
		[SerializeField]
		private float m_ColliderOffset; // 0x158
		[SerializeField]
		private bool m_UpdateCollider; // 0x15C
		[SerializeField]
		private bool m_EnableTangents; // 0x15D
		[HideInInspector]
		[SerializeField]
		private bool m_GeometryCached; // 0x15E
		[SerializeField]
		private bool m_UTess2D; // 0x15F
		[SerializeField]
		private bool m_UpdateShadow; // 0x160
		[SerializeField]
		private int m_ShadowDetail; // 0x164
		[Range(-0.5f, 0.5f)]
		[SerializeField]
		private float m_ShadowOffset; // 0x168
		[SerializeField]
		private float m_BoundsScale; // 0x16C
		[SerializeField]
		private bool m_UpdateGeometry; // 0x170
		[SerializeField]
		private SpriteShapeGeometryCreator m_Creator; // 0x178
		[SerializeField]
		private List<SpriteShapeGeometryModifier> m_Modifiers; // 0x180
		[SerializeField]
		private List<Vector2> m_ColliderSegment; // 0x188
		[SerializeField]
		private List<Vector2> m_ShadowSegment; // 0x190
		internal static readonly ProfilerMarker generateGeometry; // 0x00
		internal static readonly ProfilerMarker generateCollider; // 0x08
	
		// Properties
		internal int maxArrayCount { get; set; } // 0x000000018158AD40-0x000000018158AD50 0x0000000181C4C370-0x0000000181C4C380
		internal bool geometryCached { get; set; } // 0x0000000181C4BC30-0x0000000181C4BC40 0x0000000181C4C360-0x0000000181C4C370
		internal int splineHashCode { get; } // 0x000000018158AF80-0x000000018158AF90 
		internal Sprite[] spriteArray { get; } // 0x00000001803272B0-0x00000001803272C0 
		internal SpriteShapeParameters spriteShapeParameters { get; } // 0x0000000181C4C0F0-0x0000000181C4C150 
		internal SpriteShapeGeometryCache spriteShapeGeometryCache { get; } // 0x0000000181C4BFE0-0x0000000181C4C0F0 
		internal Sprite[] cornerSpriteArray { get; } // 0x00000001802F4000-0x00000001802F4010 
		internal Sprite[] edgeSpriteArray { get; } // 0x00000001806CCC00-0x00000001806CCC10 
		internal NativeArray<float2> shadowData { get; } // 0x0000000181C4BDC0-0x0000000181C4BDD0 
		public AngleRangeInfo[] angleRangeInfoArray { get; } // 0x0000000180333260-0x0000000180333490 
		public SpriteShapeGeometryCreator spriteShapeCreator { get; set; } // 0x0000000181C4BE00-0x0000000181C4BFE0 0x0000000181C4C3B0-0x0000000181C4C430
		public List<SpriteShapeGeometryModifier> modifiers { get; } // 0x0000000181C4BCD0-0x0000000181C4BCE0 
		public int spriteShapeHashCode { get; } // 0x000000018158ACB0-0x000000018158ACC0 
		public bool worldSpaceUVs { get; set; } // 0x0000000181C4C270-0x0000000181C4C280 0x0000000181C4C460-0x0000000181C4C470
		public float fillPixelsPerUnit { get; set; } // 0x0000000181C4BC20-0x0000000181C4BC30 0x0000000181C4C350-0x0000000181C4C360
		public bool enableTangents { get; set; } // 0x0000000181C4BC10-0x0000000181C4BC20 0x0000000181C4C340-0x0000000181C4C350
		public float stretchTiling { get; set; } // 0x0000000181C4C250-0x0000000181C4C260 0x0000000181C4C450-0x0000000181C4C460
		public int splineDetail { get; set; } // 0x0000000180531AE0-0x0000000180531AF0 0x0000000181C4C3A0-0x0000000181C4C3B0
		public int colliderDetail { get; set; } // 0x0000000181C4BB00-0x0000000181C4BB10 0x0000000181C4C310-0x0000000181C4C320
		public float colliderOffset { get; set; } // 0x0000000181C4BB10-0x0000000181C4BB20 0x0000000181C4C320-0x0000000181C4C330
		public float cornerAngleThreshold { get; set; } // 0x0000000181C4BB20-0x0000000181C4BB30 0x0000000181C4C330-0x0000000181C4C340
		public bool autoUpdateCollider { get; set; } // 0x0000000181C4BAD0-0x0000000181C4BAE0 0x0000000181C4C290-0x0000000181C4C2A0
		public bool optimizeCollider { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public bool optimizeGeometry { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public bool hasCollider { get; } // 0x0000000181C4BC40-0x0000000181C4BCD0 
		public Spline spline { get; } // 0x0000000181C2D460-0x0000000181C2D470 
		public float boundsScale { get; set; } // 0x0000000181C4BAF0-0x0000000181C4BB00 0x0000000181C4C2E0-0x0000000181C4C310
		public SpriteShape spriteShape { get; set; } // 0x0000000181974820-0x0000000181974830 0x0000000181C4C430-0x0000000181C4C450
		public EdgeCollider2D edgeCollider { get; } // 0x0000000181C4BB30-0x0000000181C4BC10 
		public PolygonCollider2D polygonCollider { get; } // 0x0000000181C4BCE0-0x0000000181C4BDC0 
		public SpriteShapeRenderer spriteShapeRenderer { get; } // 0x0000000181C4C150-0x0000000181C4C1E0 
		internal bool updateShadow { get; set; } // 0x0000000181C4C260-0x0000000181C4C270 0x0000000181C486D0-0x0000000181C486E0
		internal int shadowDetail { get; set; } // 0x0000000181C4BDD0-0x0000000181C4BDE0 0x0000000181C4C380-0x0000000181C4C390
		internal float shadowOffset { get; set; } // 0x0000000181C4BDE0-0x0000000181C4BDF0 0x0000000181C4C390-0x0000000181C4C3A0
		internal List<Vector2> shadowSegment { get; } // 0x0000000181C4BDF0-0x0000000181C4BE00 
		internal NativeArray<SpriteShapeGeneratorStats> stats { get; } // 0x0000000181C4C1E0-0x0000000181C4C250 
		public bool WaitForBake { get; set; } // 0x0000000181C4BAC0-0x0000000181C4BAD0 0x0000000181C4C280-0x0000000181C4C290
		internal bool autoUpdateGeometry { get; set; } // 0x0000000181C4BAE0-0x0000000181C4BAF0 0x0000000181C4C2A0-0x0000000181C4C2E0
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 13999
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Comparison<AngleRange> __9__166_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181C60700-0x0000000181C60770
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal int _UpdateSpriteData_b__166_0(AngleRange a, AngleRange b); // 0x0000000181C606C0-0x0000000181C60700
		}
	
		// Constructors
		public SpriteShapeController(); // 0x0000000181C4B840-0x0000000181C4BAC0
		static SpriteShapeController(); // 0x0000000181C4B7A0-0x0000000181C4B840
	
		// Methods
		private void DisposeInternal(); // 0x0000000181C48610-0x0000000181C486D0
		private void OnApplicationQuit(); // 0x0000000181C497B0-0x0000000181C497C0
		private void OnEnable(); // 0x0000000181C49890-0x0000000181C49900
		private void OnDisable(); // 0x0000000181C497E0-0x0000000181C49890
		private void OnDestroy(); // 0x00000001802E76C0-0x00000001802E76D0
		private void Reset(); // 0x0000000181C49970-0x0000000181C49B90
		private static void SmartDestroy(UnityEngine.Object o); // 0x0000000181C4A320-0x0000000181C4A380
		internal Bounds InitBounds(); // 0x0000000181C49170-0x0000000181C497A0
		public void RefreshSpriteShape(); // 0x0000000181C49960-0x0000000181C49970
		private bool ValidateSpline(); // 0x0000000181C4B220-0x0000000181C4B550
		private bool ValidateSpriteShapeTexture(); // 0x0000000181C4B550-0x0000000181C4B700
		internal bool ValidateUTess2D(); // 0x0000000181C4B700-0x0000000181C4B7A0
		private bool HasSpriteShapeChanged(); // 0x0000000181C48EE0-0x0000000181C48F80
		private bool HasSpriteShapeDataChanged(); // 0x0000000181C48F80-0x0000000181C49170
		private int GetCustomScriptHashCode(); // 0x0000000181C486E0-0x0000000181C48880
		private bool HasSplineDataChanged(); // 0x0000000181C48D00-0x0000000181C48EE0
		private void OnBecameInvisible(); // 0x0000000181C497C0-0x0000000181C497E0
		private void LateUpdate(); // 0x0000000181C497A0-0x0000000181C497B0
		private void OnWillRenderObject(); // 0x0000000181C49900-0x0000000181C49960
		public JobHandle BakeMesh(); // 0x0000000181C48240-0x0000000181C48360
		internal void UpdateGeometryCache(); // 0x0000000181C4A380-0x0000000181C4A420
		public bool UpdateSpriteShapeParameters(); // 0x0000000181C4ADE0-0x0000000181C4B220
		private void UpdateSpriteData(); // 0x0000000181C4A420-0x0000000181C4ADE0
		internal NativeArray<ShapeControlPoint> GetShapeControlPoints(); // 0x0000000181C48970-0x0000000181C48BC0
		internal NativeArray<SplinePointMetaData> GetSplinePointMetaData(); // 0x0000000181C48BC0-0x0000000181C48D00
		internal int CalculateMaxArrayCount(NativeArray<ShapeControlPoint> shapePoints); // 0x0000000181C48480-0x0000000181C48610
		private JobHandle ScheduleBake(); // 0x0000000181C49B90-0x0000000181C4A320
		internal void BakeShadow(); // 0x0000000181C48360-0x0000000181C48480
		public void BakeCollider(); // 0x0000000181C47AE0-0x0000000181C48090
		internal void BakeMeshForced(); // 0x0000000181C48090-0x0000000181C48240
		internal void ForceShadowShapeUpdate(bool forceUpdate); // 0x0000000181C486D0-0x0000000181C486E0
		internal NativeArray<float2> GetShadowShapeData(); // 0x0000000181C48880-0x0000000181C48970
	}
}
