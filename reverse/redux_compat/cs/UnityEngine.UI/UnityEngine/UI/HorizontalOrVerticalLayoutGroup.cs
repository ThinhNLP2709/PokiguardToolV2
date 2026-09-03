/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	[ExecuteAlways]
	public abstract class HorizontalOrVerticalLayoutGroup : LayoutGroup // TypeDefIndex: 13075
	{
		// Fields
		[SerializeField]
		protected float m_Spacing; // 0x68
		[SerializeField]
		protected bool m_ChildForceExpandWidth; // 0x6C
		[SerializeField]
		protected bool m_ChildForceExpandHeight; // 0x6D
		[SerializeField]
		protected bool m_ChildControlWidth; // 0x6E
		[SerializeField]
		protected bool m_ChildControlHeight; // 0x6F
		[SerializeField]
		protected bool m_ChildScaleWidth; // 0x70
		[SerializeField]
		protected bool m_ChildScaleHeight; // 0x71
		[SerializeField]
		protected bool m_ReverseArrangement; // 0x72
	
		// Properties
		public float spacing { get; set; } // 0x0000000180C245B0-0x0000000180C245C0 0x0000000182586010-0x0000000182586060
		public bool childForceExpandWidth { get; set; } // 0x00000001803002D0-0x00000001803002E0 0x0000000182585ED0-0x0000000182585F20
		public bool childForceExpandHeight { get; set; } // 0x0000000182585DD0-0x0000000182585DE0 0x0000000182585E80-0x0000000182585ED0
		public bool childControlWidth { get; set; } // 0x0000000182585DC0-0x0000000182585DD0 0x0000000182585E30-0x0000000182585E80
		public bool childControlHeight { get; set; } // 0x0000000182585DB0-0x0000000182585DC0 0x0000000182585DE0-0x0000000182585E30
		public bool childScaleWidth { get; set; } // 0x0000000180643BD0-0x0000000180643BE0 0x0000000182585F70-0x0000000182585FC0
		public bool childScaleHeight { get; set; } // 0x000000018030D9D0-0x000000018030D9E0 0x0000000182585F20-0x0000000182585F70
		public bool reverseArrangement { get; set; } // 0x00000001819C01B0-0x00000001819C01C0 0x0000000182585FC0-0x0000000182586010
	
		// Constructors
		protected HorizontalOrVerticalLayoutGroup(); // 0x0000000182584F70-0x0000000182584F80
	
		// Methods
		protected void CalcAlongAxis(int axis, bool isVertical); // 0x0000000182584F80-0x00000001825852E0
		protected void SetChildrenAlongAxis(int axis, bool isVertical); // 0x0000000182585550-0x0000000182585DB0
		private void GetChildSizes(RectTransform child, int axis, bool controlSize, bool childForceExpand, out float min, out float max, out float preferred, out float flexible); // 0x00000001825852E0-0x0000000182585550
	}
}
