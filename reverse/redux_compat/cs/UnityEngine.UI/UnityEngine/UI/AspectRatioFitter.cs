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
	[AddComponentMenu("Layout/Aspect Ratio Fitter", 142)]
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	[UGUIHelpURL("AspectRatioFitter")]
	public class AspectRatioFitter : UIBehaviour, ILayoutSelfController // TypeDefIndex: 13062
	{
		// Fields
		[SerializeField]
		private AspectMode m_AspectMode; // 0x20
		[SerializeField]
		private float m_AspectRatio; // 0x24
		[NonSerialized]
		private RectTransform m_Rect; // 0x28
		private bool m_DelayedSetDirty; // 0x30
		private bool m_DoesParentExist; // 0x31
		private DrivenRectTransformTracker m_Tracker; // 0x32
	
		// Properties
		public AspectMode aspectMode { get; set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000182582E60-0x0000000182582EC0
		public float aspectRatio { get; set; } // 0x0000000181CE2830-0x0000000181CE2840 0x0000000182582EC0-0x0000000182582F20
		private RectTransform rectTransform { get; } // 0x0000000182582DD0-0x0000000182582E60 
	
		// Nested types
		public enum AspectMode // TypeDefIndex: 13063
		{
			None = 0,
			WidthControlsHeight = 1,
			HeightControlsWidth = 2,
			FitInParent = 3,
			EnvelopeParent = 4
		}
	
		// Constructors
		protected AspectRatioFitter(); // 0x0000000182582DC0-0x0000000182582DD0
	
		// Methods
		protected override void OnEnable(); // 0x0000000182582800-0x0000000182582890
		protected override void Start(); // 0x0000000182582930-0x0000000182582980
		protected override void OnDisable(); // 0x0000000182582780-0x0000000182582800
		protected override void OnTransformParentChanged(); // 0x00000001825828A0-0x0000000182582930
		protected virtual void Update(); // 0x0000000182582DA0-0x0000000182582DC0
		protected override void OnRectTransformDimensionsChange(); // 0x0000000182582890-0x00000001825828A0
		private void UpdateRect(); // 0x0000000182582980-0x0000000182582DA0
		private float GetSizeDeltaToProduceSize(float size, int axis); // 0x00000001825824E0-0x00000001825826B0
		private Vector2 GetParentSize(); // 0x00000001825823D0-0x00000001825824E0
		public virtual void SetLayoutHorizontal(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void SetLayoutVertical(); // 0x00000001802E76C0-0x00000001802E76D0
		protected void SetDirty(); // 0x0000000182582890-0x00000001825828A0
		public bool IsComponentValidOnObject(); // 0x00000001825826D0-0x0000000182582780
		public bool IsAspectModeValid(); // 0x00000001825826B0-0x00000001825826D0
		private bool DoesParentExists(); // 0x0000000180634F10-0x0000000180634F20
	}
}
