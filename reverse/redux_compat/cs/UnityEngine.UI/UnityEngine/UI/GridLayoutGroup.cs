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
	[AddComponentMenu("Layout/Grid Layout Group", 152)]
	[UGUIHelpURL("GridLayoutGroup")]
	public class GridLayoutGroup : LayoutGroup // TypeDefIndex: 13070
	{
		// Fields
		[SerializeField]
		protected Corner m_StartCorner; // 0x68
		[SerializeField]
		protected Axis m_StartAxis; // 0x6C
		[SerializeField]
		protected Vector2 m_CellSize; // 0x70
		[SerializeField]
		protected Vector2 m_Spacing; // 0x78
		[SerializeField]
		protected Constraint m_Constraint; // 0x80
		[SerializeField]
		protected int m_ConstraintCount; // 0x84
		[CompilerGenerated]
		private int _generatedRowCount_k__BackingField; // 0x88
		[CompilerGenerated]
		private int _generatedColumnCount_k__BackingField; // 0x8C
	
		// Properties
		public Corner startCorner { get; set; } // 0x00000001803002C0-0x00000001803002D0 0x0000000182584EC0-0x0000000182584F10
		public Axis startAxis { get; set; } // 0x0000000180C55C40-0x0000000180C55C50 0x0000000182584E70-0x0000000182584EC0
		public Vector2 cellSize { get; set; } // 0x0000000182584CC0-0x0000000182584CE0 0x0000000182584D00-0x0000000182584D60
		public Vector2 spacing { get; set; } // 0x0000000182584CE0-0x0000000182584D00 0x0000000182584E10-0x0000000182584E70
		public Constraint constraint { get; set; } // 0x0000000180CC3A10-0x0000000180CC3A20 0x0000000182584DC0-0x0000000182584E10
		public int constraintCount { get; set; } // 0x0000000180BE5CE0-0x0000000180BE5CF0 0x0000000182584D60-0x0000000182584DC0
		public int generatedRowCount { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D620-0x000000018033D630 0x000000018033EC00-0x000000018033EC10
		public int generatedColumnCount { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D640-0x000000018033D650 0x000000018033EC20-0x000000018033EC30
	
		// Nested types
		public enum Corner // TypeDefIndex: 13071
		{
			UpperLeft = 0,
			UpperRight = 1,
			LowerLeft = 2,
			LowerRight = 3
		}
	
		public enum Axis // TypeDefIndex: 13072
		{
			Horizontal = 0,
			Vertical = 1
		}
	
		public enum Constraint // TypeDefIndex: 13073
		{
			Flexible = 0,
			FixedColumnCount = 1,
			FixedRowCount = 2
		}
	
		// Constructors
		protected GridLayoutGroup(); // 0x0000000182584C80-0x0000000182584CC0
	
		// Methods
		public override void CalculateLayoutInputHorizontal(); // 0x0000000182584020-0x0000000182584260
		public override void CalculateLayoutInputVertical(); // 0x0000000182584260-0x0000000182584590
		public override void SetLayoutHorizontal(); // 0x0000000182584C50-0x0000000182584C70
		public override void SetLayoutVertical(); // 0x0000000182584C70-0x0000000182584C80
		private void SetCellsAlongAxis(int axis); // 0x00000001825845A0-0x0000000182584C50
		private void ResetGeneratedCounts(); // 0x0000000182584590-0x00000001825845A0
	}
}
