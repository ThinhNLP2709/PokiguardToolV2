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
	[AddComponentMenu("Layout/Canvas Scaler", 101)]
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[RequireComponent(typeof(Canvas))]
	[UGUIHelpURL("CanvasScaler")]
	public class CanvasScaler : UIBehaviour // TypeDefIndex: 13064
	{
		// Fields
		[SerializeField]
		[Tooltip("Determines how UI elements in the Canvas are scaled.")]
		private ScaleMode m_UiScaleMode; // 0x20
		[SerializeField]
		[Tooltip("If a sprite has this \'Pixels Per Unit\' setting, then one pixel in the sprite will cover one unit in the UI.")]
		protected float m_ReferencePixelsPerUnit; // 0x24
		[SerializeField]
		[Tooltip("Scales all UI elements in the Canvas by this factor.")]
		protected float m_ScaleFactor; // 0x28
		[SerializeField]
		[Tooltip("The resolution the UI layout is designed for. If the screen resolution is larger, the UI will be scaled up, and if it\'s smaller, the UI will be scaled down. This is done in accordance with the Screen Match Mode.")]
		protected Vector2 m_ReferenceResolution; // 0x2C
		[SerializeField]
		[Tooltip("A mode used to scale the canvas area if the aspect ratio of the current resolution doesn\'t fit the reference resolution.")]
		protected ScreenMatchMode m_ScreenMatchMode; // 0x34
		[Range(0f, 1f)]
		[SerializeField]
		[Tooltip("Determines if the scaling is using the width or height as reference, or a mix in between.")]
		protected float m_MatchWidthOrHeight; // 0x38
		private const float kLogBase = 2f; // Metadata: 0x006A774D
		[SerializeField]
		[Tooltip("The physical unit to specify positions and sizes in.")]
		protected Unit m_PhysicalUnit; // 0x3C
		[SerializeField]
		[Tooltip("The DPI to assume if the screen DPI is not known.")]
		protected float m_FallbackScreenDPI; // 0x40
		[SerializeField]
		[Tooltip("The pixels per inch to use for sprites that have a \'Pixels Per Unit\' setting that matches the \'Reference Pixels Per Unit\' setting.")]
		protected float m_DefaultSpriteDPI; // 0x44
		[SerializeField]
		[Tooltip("The amount of pixels per unit to use for dynamically created bitmaps in the UI, such as Text.")]
		protected float m_DynamicPixelsPerUnit; // 0x48
		private Canvas m_Canvas; // 0x50
		[NonSerialized]
		private float m_PrevScaleFactor; // 0x58
		[NonSerialized]
		private float m_PrevReferencePixelsPerUnit; // 0x5C
		[SerializeField]
		protected bool m_PresetInfoIsWorld; // 0x60
	
		// Properties
		public ScaleMode uiScaleMode { get; set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
		public float referencePixelsPerUnit { get; set; } // 0x0000000181CE2830-0x0000000181CE2840 0x0000000181CE28E0-0x0000000181CE28F0
		public float scaleFactor { get; set; } // 0x0000000180F99790-0x0000000180F997A0 0x00000001825837E0-0x0000000182583800
		public Vector2 referenceResolution { get; set; } // 0x00000001822D3020-0x00000001822D3040 0x0000000182583760-0x00000001825837E0
		public ScreenMatchMode screenMatchMode { get; set; } // 0x000000018033D0F0-0x000000018033D100 0x000000018033E770-0x000000018033E780
		public float matchWidthOrHeight { get; set; } // 0x0000000181C62E80-0x0000000181C62E90 0x0000000181C62E90-0x0000000181C62EA0
		public Unit physicalUnit { get; set; } // 0x00000001804EFAC0-0x00000001804EFAD0 0x00000001805D5550-0x00000001805D5560
		public float fallbackScreenDPI { get; set; } // 0x0000000181D8CC60-0x0000000181D8CC70 0x0000000181F56C00-0x0000000181F56C10
		public float defaultSpriteDPI { get; set; } // 0x0000000180349420-0x0000000180349430 0x0000000182583740-0x0000000182583760
		public float dynamicPixelsPerUnit { get; set; } // 0x000000018047EDF0-0x000000018047EE00 0x0000000181D8BEF0-0x0000000181D8BF00
	
		// Nested types
		public enum ScaleMode // TypeDefIndex: 13065
		{
			ConstantPixelSize = 0,
			ScaleWithScreenSize = 1,
			ConstantPhysicalSize = 2
		}
	
		public enum ScreenMatchMode // TypeDefIndex: 13066
		{
			MatchWidthOrHeight = 0,
			Expand = 1,
			Shrink = 2
		}
	
		public enum Unit // TypeDefIndex: 13067
		{
			Centimeters = 0,
			Millimeters = 1,
			Inches = 2,
			Points = 3,
			Picas = 4
		}
	
		// Constructors
		protected CanvasScaler(); // 0x00000001825836F0-0x0000000182583740
	
		// Methods
		protected override void OnEnable(); // 0x0000000182583570-0x0000000182583650
		private void Canvas_preWillRenderCanvases(); // 0x000000018152CA80-0x000000018152CAA0
		protected override void OnDisable(); // 0x0000000182583460-0x0000000182583570
		protected virtual void Handle(); // 0x0000000182583340-0x0000000182583460
		protected virtual void HandleWorldCanvas(); // 0x00000001825832C0-0x0000000182583340
		protected virtual void HandleConstantPixelSize(); // 0x0000000182583010-0x0000000182583090
		protected virtual void HandleScaleWithScreenSize(); // 0x0000000182583090-0x00000001825832C0
		protected virtual void HandleConstantPhysicalSize(); // 0x0000000182582F20-0x0000000182583010
		protected void SetScaleFactor(float scaleFactor); // 0x0000000182583690-0x00000001825836F0
		protected void SetReferencePixelsPerUnit(float referencePixelsPerUnit); // 0x0000000182583650-0x0000000182583690
	}
}
