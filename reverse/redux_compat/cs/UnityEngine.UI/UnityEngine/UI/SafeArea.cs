/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	[AddComponentMenu("UI (Canvas)/Safe Area")]
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	[UGUIHelpURL("SafeArea")]
	public class SafeArea : UIBehaviour // TypeDefIndex: 13101
	{
		// Fields
		private RectTransform m_RectTransform; // 0x20
		private DrivenRectTransformTracker m_Tracker; // 0x28
		[SerializeField]
		[Tooltip("The orientation that the Edges and Alignment directions are authored against. At runtime, the component remaps those directions to match the current device orientation.")]
		private ScreenOrientation m_ReferenceOrientation; // 0x2C
		[SerializeField]
		[Tooltip("Edges to inset to respect the safe area. Directions are with respect to the reference orientation.")]
		private SafeAreaMode m_Edges; // 0x30
		[SerializeField]
		[Tooltip("Align the inset to center the UI area. Directions are with respect to the reference orientation.")]
		private AlignmentMode m_Alignment; // 0x34
		[NonSerialized]
		private ScreenOrientation m_PreviousReferenceOrientation; // 0x38
		[NonSerialized]
		private SafeAreaMode m_PreviousEdges; // 0x3C
		[NonSerialized]
		private AlignmentMode m_PreviousAlignment; // 0x40
		[NonSerialized]
		private Rect m_PreviousSafeArea; // 0x44
		[NonSerialized]
		private Vector2Int m_PreviousResolution; // 0x54
		[NonSerialized]
		private ScreenOrientation m_PreviousOrientation; // 0x5C
	
		// Properties
		private int RotationsFromCurrentToReference { get; } // 0x000000018259D070-0x000000018259D0B0 
		private int RotationsFromReferenceToCurrent { get; } // 0x000000018259D0B0-0x000000018259D0F0 
		private ScreenOrientation CurrentOrientation { get; } // 0x000000018259CCF0-0x000000018259CD10 
		public bool RespectSafeAreaScreenLeft { get; } // 0x000000018259CEA0-0x000000018259CF40 
		public bool RespectSafeAreaScreenRight { get; } // 0x000000018259CF40-0x000000018259CFE0 
		public bool RespectSafeAreaScreenBottom { get; } // 0x000000018259CE00-0x000000018259CEA0 
		public bool RespectSafeAreaScreenTop { get; } // 0x000000018259CFE0-0x000000018259D070 
		public ScreenOrientation ReferenceOrientation { get; set; } // 0x000000018259CD10-0x000000018259CE00 0x000000018259D0F0-0x000000018259D110
		public SafeAreaMode Edges { get; set; } // 0x000000018033D100-0x000000018033D110 0x000000018033E780-0x000000018033E790
		public AlignmentMode Alignment { get; set; } // 0x000000018033D0F0-0x000000018033D100 0x000000018033E770-0x000000018033E780
	
		// Nested types
		[Flags]
		public enum SafeAreaMode // TypeDefIndex: 13102
		{
			Top = 1,
			Right = 2,
			Bottom = 4,
			Left = 8
		}
	
		[Flags]
		public enum AlignmentMode // TypeDefIndex: 13103
		{
			CenterHorizontally = 1,
			CenterVertically = 2
		}
	
		private enum ScreenOrientation // TypeDefIndex: 13104
		{
			Portrait = 0,
			LandscapeLeft = 1,
			PortraitUpsideDown = 2,
			LandscapeRight = 3
		}
	
		// Constructors
		public SafeArea(); // 0x00000001820502E0-0x00000001820502F0
	
		// Methods
		internal static SafeAreaMode RotateFlag(SafeAreaMode mode, int shift); // 0x000000018259C700-0x000000018259C750
		protected override void Awake(); // 0x000000018259C250-0x000000018259C2D0
		protected override void OnEnable(); // 0x000000018259C5D0-0x000000018259C700
		protected override void OnDisable(); // 0x000000018259C5B0-0x000000018259C5D0
		protected override void OnDestroy(); // 0x000000018259C5B0-0x000000018259C5D0
		private void SafeClearDrivenRectTransformTracker(); // 0x000000018259C750-0x000000018259C850
		private void Update(); // 0x000000018259CA90-0x000000018259CCF0
		private void ClaimRectTransformDrivenOwnership(); // 0x000000018259C430-0x000000018259C460
		private void ApplySafeArea(); // 0x000000018259BFB0-0x000000018259C250
		internal static ValueTuple<Vector2, Vector2> CalculateAnchors(int screenWidth, int screenHeight, Rect safeArea, SafeAreaMode respectSafeAreaScreenEdges, AlignmentMode alignmentMode, bool isAlignmentFlipped); // 0x000000018259C2D0-0x000000018259C430
		private void UpdatePreviousDataCache(); // 0x000000018259CA30-0x000000018259CA90
		private static ScreenOrientation ToLocalScreenOrientation(ScreenOrientation orientation); // 0x000000018259C850-0x000000018259C940
		private static ScreenOrientation ToUnityScreenOrientation(ScreenOrientation orientation); // 0x000000018259C940-0x000000018259CA30
		public SafeAreaMode GetReferenceOrientationMappedDirection(SafeAreaMode referenceOrientationDirection); // 0x000000018259C460-0x000000018259C500
		private bool HasNaNDrivenValues(); // 0x000000018259C500-0x000000018259C5B0
		private static bool HasFlag(SafeAreaMode value, SafeAreaMode flag); // 0x00000001814F3910-0x00000001814F3920
		private static bool HasFlag(AlignmentMode value, AlignmentMode flag); // 0x00000001814F3910-0x00000001814F3920
	}
}
