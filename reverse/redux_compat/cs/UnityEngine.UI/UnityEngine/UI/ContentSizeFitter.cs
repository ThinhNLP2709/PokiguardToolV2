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
	[AddComponentMenu("Layout/Content Size Fitter", 141)]
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	[UGUIHelpURL("ContentSizeFitter")]
	public class ContentSizeFitter : UIBehaviour, ILayoutSelfController // TypeDefIndex: 13068
	{
		// Fields
		private static readonly DrivenTransformProperties[] k_DrivenPropertyByAxis; // 0x00
		[SerializeField]
		[Tooltip("Controls how the width of this RectTransform automatically resizes based on its content.")]
		protected FitMode m_HorizontalFit; // 0x20
		[SerializeField]
		[Tooltip("Controls how the height of this RectTransform automatically resizes based on its content.")]
		protected FitMode m_VerticalFit; // 0x24
		[NonSerialized]
		private RectTransform m_Rect; // 0x28
		private DrivenRectTransformTracker m_Tracker; // 0x30
	
		// Properties
		public FitMode horizontalFit { get; set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000182583F60-0x0000000182583FC0
		public FitMode verticalFit { get; set; } // 0x0000000180D17D10-0x0000000180D17D20 0x0000000182583FC0-0x0000000182584020
		private RectTransform rectTransform { get; } // 0x0000000182583ED0-0x0000000182583F60 
	
		// Nested types
		public enum FitMode // TypeDefIndex: 13069
		{
			Unconstrained = 0,
			MinSize = 1,
			PreferredSize = 2,
			Clamped = 3
		}
	
		// Constructors
		protected ContentSizeFitter(); // 0x00000001820502E0-0x00000001820502F0
		static ContentSizeFitter(); // 0x0000000182583E30-0x0000000182583ED0
	
		// Methods
		protected override void OnEnable(); // 0x0000000182583D40-0x0000000182583D60
		protected override void OnDisable(); // 0x0000000182583CC0-0x0000000182583D40
		protected override void OnRectTransformDimensionsChange(); // 0x0000000182583D60-0x0000000182583D70
		private void HandleSelfFittingAlongAxis(int axis); // 0x0000000182583960-0x0000000182583CC0
		private void HandleClampedFittingAlongAxis(int axis); // 0x0000000182583800-0x0000000182583960
		public virtual void SetLayoutHorizontal(); // 0x0000000182583DF0-0x0000000182583E20
		public virtual void SetLayoutVertical(); // 0x0000000182583E20-0x0000000182583E30
		protected void SetDirty(); // 0x0000000182583D70-0x0000000182583DF0
	}
}
