/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	public abstract class LayoutGroup : UIBehaviour, ILayoutElement, ILayoutGroup // TypeDefIndex: 13082
	{
		// Fields
		[SerializeField]
		protected RectOffset m_Padding; // 0x20
		[SerializeField]
		protected TextAnchor m_ChildAlignment; // 0x28
		[NonSerialized]
		private RectTransform m_Rect; // 0x30
		protected DrivenRectTransformTracker m_Tracker; // 0x38
		private Vector2 m_TotalMinSize; // 0x3C
		private Vector2 m_TotalMaxSize; // 0x44
		private Vector2 m_TotalPreferredSize; // 0x4C
		private Vector2 m_TotalFlexibleSize; // 0x54
		[NonSerialized]
		private List<RectTransform> m_RectChildren; // 0x60
	
		// Properties
		public RectOffset padding { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x0000000182592FF0-0x0000000182593040
		public TextAnchor childAlignment { get; set; } // 0x0000000180377930-0x0000000180377940 0x0000000182592FA0-0x0000000182592FF0
		protected RectTransform rectTransform { get; } // 0x0000000182592F10-0x0000000182592FA0 
		protected List<RectTransform> rectChildren { get; } // 0x0000000180333260-0x0000000180333490 
		public virtual float minWidth { get; } // 0x0000000182592EE0-0x0000000182592EF0 
		public virtual float maxWidth { get; } // 0x0000000182592EC0-0x0000000182592ED0 
		public virtual float preferredWidth { get; } // 0x0000000182592F00-0x0000000182592F10 
		public virtual float flexibleWidth { get; } // 0x0000000182592DB0-0x0000000182592DC0 
		public virtual float minHeight { get; } // 0x0000000182592ED0-0x0000000182592EE0 
		public virtual float maxHeight { get; } // 0x0000000182592EB0-0x0000000182592EC0 
		public virtual float preferredHeight { get; } // 0x0000000182592EF0-0x0000000182592F00 
		public virtual float flexibleHeight { get; } // 0x0000000182592DA0-0x0000000182592DB0 
		public virtual int layoutPriority { get; } // 0x00000001802E7860-0x00000001802E7870 
		private bool isRootLayoutGroup { get; } // 0x0000000182592DC0-0x0000000182592EB0 
	
		// Nested types
		[CompilerGenerated]
		private sealed class _DelayedSetDirty_d__63 : IEnumerator<object> // TypeDefIndex: 13083
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public RectTransform rectTransform; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _DelayedSetDirty_d__63(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x0000000182596AB0-0x0000000182596B40
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000182596B40-0x0000000182596B80
		}
	
		// Constructors
		protected LayoutGroup(); // 0x0000000182592C30-0x0000000182592DA0
	
		// Methods
		public virtual void CalculateLayoutInputHorizontal(); // 0x0000000182591C30-0x0000000182591F50
		public abstract void CalculateLayoutInputVertical();
		public abstract void SetLayoutHorizontal();
		public abstract void SetLayoutVertical();
		protected override void OnEnable(); // 0x0000000182592300-0x0000000182592350
		protected override void OnDisable(); // 0x0000000182592260-0x0000000182592300
		protected override void OnDidApplyAnimationProperties(); // 0x0000000182592250-0x0000000182592260
		protected float GetTotalMinSize(int axis); // 0x00000001825921D0-0x00000001825921E0
		protected float GetTotalMaxSize(int axis); // 0x00000001825921C0-0x00000001825921D0
		protected float GetTotalPreferredSize(int axis); // 0x00000001825921E0-0x00000001825921F0
		protected float GetTotalFlexibleSize(int axis); // 0x00000001825921B0-0x00000001825921C0
		protected float GetStartOffset(int axis, float requiredSpaceWithoutPadding); // 0x0000000182592010-0x00000001825921B0
		protected float GetAlignmentOnAxis(int axis); // 0x0000000182591FC0-0x0000000182592010
		protected void SetLayoutInputForAxis(float totalMin, float totalMax, float totalPreferred, float totalFlexible, int axis); // 0x0000000182592B80-0x0000000182592C30
		protected void SetChildAlongAxis(RectTransform rect, int axis, float pos); // 0x0000000182592900-0x00000001825929A0
		protected void SetChildAlongAxisWithScale(RectTransform rect, int axis, float pos, float scaleFactor); // 0x00000001825926F0-0x0000000182592900
		protected void SetChildAlongAxis(RectTransform rect, int axis, float pos, float size); // 0x00000001825929A0-0x0000000182592A50
		protected void SetChildAlongAxisWithScale(RectTransform rect, int axis, float pos, float size, float scaleFactor); // 0x0000000182592460-0x00000001825926F0
		protected override void OnRectTransformDimensionsChange(); // 0x0000000182592350-0x0000000182592460
		protected virtual void OnTransformChildrenChanged(); // 0x0000000182592250-0x0000000182592260
		protected virtual void OnChildRectTransformDimensionsChange(); // 0x00000001825921F0-0x0000000182592250
		protected void SetProperty<T>(ref ref T currentValue, T newValue);
		protected void SetDirty(); // 0x0000000182592A50-0x0000000182592B80
		[IteratorStateMachine(typeof(_DelayedSetDirty_d__63))]
		private IEnumerator DelayedSetDirty(RectTransform rectTransform); // 0x0000000182591F50-0x0000000182591FC0
	}
}
