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
	[AddComponentMenu("Layout/Layout Element", 140)]
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	[UGUIHelpURL("LayoutElement")]
	public class LayoutElement : UIBehaviour, ILayoutElement, ILayoutIgnorer // TypeDefIndex: 13081
	{
		// Fields
		[SerializeField]
		private bool m_IgnoreLayout; // 0x20
		[SerializeField]
		private float m_MinWidth; // 0x24
		[SerializeField]
		private float m_MinHeight; // 0x28
		[SerializeField]
		private float m_PreferredWidth; // 0x2C
		[SerializeField]
		private float m_PreferredHeight; // 0x30
		[SerializeField]
		private float m_FlexibleWidth; // 0x34
		[SerializeField]
		private float m_FlexibleHeight; // 0x38
		[SerializeField]
		private int m_LayoutPriority; // 0x3C
		[SerializeField]
		private float m_MaxWidth; // 0x40
		[SerializeField]
		private float m_MaxHeight; // 0x44
	
		// Properties
		public virtual bool ignoreLayout { get; set; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 0x0000000182591930-0x0000000182591990
		public virtual float minWidth { get; set; } // 0x0000000181CE2830-0x0000000181CE2840 0x0000000182591B10-0x0000000182591B70
		public virtual float minHeight { get; set; } // 0x0000000180F99790-0x0000000180F997A0 0x0000000182591AB0-0x0000000182591B10
		public virtual float maxWidth { get; set; } // 0x0000000181D8CC60-0x0000000181D8CC70 0x0000000182591A50-0x0000000182591AB0
		public virtual float maxHeight { get; set; } // 0x0000000180349420-0x0000000180349430 0x00000001825919F0-0x0000000182591A50
		public virtual float preferredWidth { get; set; } // 0x000000018206CB50-0x000000018206CB60 0x0000000182591BD0-0x0000000182591C30
		public virtual float preferredHeight { get; set; } // 0x00000001806CCB40-0x00000001806CCB50 0x0000000182591B70-0x0000000182591BD0
		public virtual float flexibleWidth { get; set; } // 0x0000000181230A40-0x0000000181230A50 0x00000001825918D0-0x0000000182591930
		public virtual float flexibleHeight { get; set; } // 0x0000000181C62E80-0x0000000181C62E90 0x0000000182591870-0x00000001825918D0
		public virtual int layoutPriority { get; set; } // 0x00000001804EFAC0-0x00000001804EFAD0 0x0000000182591990-0x00000001825919F0
	
		// Constructors
		protected LayoutElement(); // 0x0000000182591820-0x0000000182591870
	
		// Methods
		public virtual void CalculateLayoutInputHorizontal(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void CalculateLayoutInputVertical(); // 0x00000001802E76C0-0x00000001802E76D0
		protected override void OnEnable(); // 0x0000000182591760-0x0000000182591780
		protected override void OnTransformParentChanged(); // 0x0000000182591730-0x0000000182591740
		protected override void OnDisable(); // 0x0000000182591740-0x0000000182591760
		protected override void OnDidApplyAnimationProperties(); // 0x0000000182591730-0x0000000182591740
		protected override void OnBeforeTransformParentChanged(); // 0x0000000182591730-0x0000000182591740
		protected void SetDirty(); // 0x0000000182591780-0x0000000182591820
	}
}
