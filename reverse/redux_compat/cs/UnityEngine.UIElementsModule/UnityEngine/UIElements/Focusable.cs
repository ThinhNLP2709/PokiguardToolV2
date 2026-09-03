/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	public abstract class Focusable : CallbackEventHandler // TypeDefIndex: 4160
	{
		// Fields
		internal static readonly BindingId focusableProperty; // 0x00
		internal static readonly BindingId tabIndexProperty; // 0x98
		internal static readonly BindingId delegatesFocusProperty; // 0x130
		internal static readonly BindingId canGrabFocusProperty; // 0x1C8
		private bool m_Focusable; // 0x20
		private int m_TabIndex; // 0x24
		private bool m_DelegatesFocus; // 0x28
		private bool m_ExcludeFromFocusRing; // 0x29
		[CompilerGenerated]
		private bool _isEligibleToReceiveFocusFromDisabledChild_k__BackingField; // 0x2A
	
		// Properties
		public abstract FocusController focusController { get; }
		[CreateProperty]
		public virtual bool focusable { get; set; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 0x0000000182499790-0x0000000182499810
		[CreateProperty]
		public int tabIndex { get; set; } // 0x0000000180D17D10-0x0000000180D17D20 0x0000000182499810-0x0000000182499890
		[CreateProperty]
		public bool delegatesFocus { get; set; } // 0x0000000180327270-0x0000000180327280 0x0000000182499630-0x00000001824996B0
		internal bool excludeFromFocusRing { [VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })] get; set; } // 0x000000018052D500-0x000000018052D510 0x00000001824996B0-0x0000000182499790
		internal bool isEligibleToReceiveFocusFromDisabledChild { [CompilerGenerated] get; } // 0x000000018052D510-0x000000018052D520 
		[CreateProperty(ReadOnly = true)]
		public virtual bool canGrabFocus { get; } // 0x0000000181BB3260-0x0000000181BB3280 
	
		// Constructors
		protected Focusable(); // 0x0000000182499590-0x0000000182499630
		static Focusable(); // 0x0000000182499240-0x0000000182499590
	
		// Methods
		public virtual void Focus(); // 0x0000000182498E60-0x0000000182498FE0
		public virtual void Blur(); // 0x0000000182498E10-0x0000000182498E60
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal void BlurImmediately(); // 0x0000000182498DC0-0x0000000182498E10
		internal Focusable GetFocusDelegate(); // 0x0000000182499170-0x0000000182499240
		private static Focusable GetFirstFocusableChild(VisualElement ve); // 0x0000000182498FE0-0x0000000182499170
	}
}
