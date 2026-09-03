/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
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
	public class FocusController // TypeDefIndex: 4163
	{
		// Fields
		[CompilerGenerated]
		private readonly IFocusRing _focusRing_k__BackingField; // 0x10
		private TextElement m_SelectedTextElement; // 0x18
		private List<FocusedElement> m_FocusedElements; // 0x20
		private Focusable m_LastFocusedElement; // 0x28
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal Focusable m_LastPendingFocusedElement; // 0x30
		private int m_PendingFocusCount; // 0x38
		[CompilerGenerated]
		private int _imguiKeyboardControl_k__BackingField; // 0x3C
	
		// Properties
		private IFocusRing focusRing { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal TextElement selectedTextElement { set; } // 0x00000001824976F0-0x0000000182497790
		public Focusable focusedElement { get; } // 0x0000000182497690-0x00000001824976F0 
		internal int imguiKeyboardControl { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001804EFAC0-0x00000001804EFAD0 0x00000001805D5550-0x00000001805D5560
	
		// Nested types
		private struct FocusedElement // TypeDefIndex: 4164
		{
			// Fields
			public VisualElement m_SubTreeRoot; // 0x00
			public VisualElement m_FocusedElement; // 0x08
		}
	
		// Constructors
		public FocusController(IFocusRing focusRing); // 0x00000001824975F0-0x0000000182497690
	
		// Methods
		public void IgnoreEvent(EventBase evt); // 0x00000001824962A0-0x0000000182496360
		internal bool IsFocused(Focusable f); // 0x0000000182496360-0x0000000182496470
		internal Focusable GetRetargetedFocusedElement(VisualElement retargetAgainst); // 0x0000000182495D90-0x0000000182495F50
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal Focusable GetLeafFocusedElement(); // 0x0000000182495D00-0x0000000182495D90
		private bool IsLocalElement(Focusable f); // 0x0000000182496470-0x00000001824964C0
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal bool IsPendingFocus(Focusable f); // 0x00000001824964C0-0x0000000182496590
		internal void SetFocusToLastFocusedElement(); // 0x0000000182496C10-0x0000000182496C90
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal void BlurLastFocusedElement(); // 0x00000001824956A0-0x00000001824957C0
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal void DoFocusChange(Focusable f); // 0x00000001824958D0-0x0000000182495930
		internal void ProcessPendingFocusChange(Focusable f); // 0x0000000182496590-0x0000000182496800
		private static void GetFocusTargets(Focusable f, List<FocusedElement> outTargets); // 0x0000000182495A40-0x0000000182495BA0
		internal Focusable FocusNextInDirection(Focusable currentFocusable, FocusChangeDirection direction); // 0x0000000182495930-0x0000000182495A40
		private void AboutToReleaseFocus(Focusable focusable, Focusable willGiveFocusTo, FocusChangeDirection direction, DispatchMode dispatchMode); // 0x0000000182495570-0x00000001824956A0
		private void ReleaseFocus(Focusable focusable, Focusable willGiveFocusTo, FocusChangeDirection direction, DispatchMode dispatchMode); // 0x00000001824968D0-0x0000000182496C10
		private void AboutToGrabFocus(Focusable focusable, Focusable willTakeFocusFrom, FocusChangeDirection direction, DispatchMode dispatchMode); // 0x0000000182495440-0x0000000182495570
		private void GrabFocus(Focusable focusable, Focusable willTakeFocusFrom, FocusChangeDirection direction, bool bIsFocusDelegated, DispatchMode dispatchMode); // 0x0000000182495F50-0x00000001824962A0
		internal void Blur(Focusable focusable, bool bIsFocusDelegated = false /* Metadata: 0x00660512 */, DispatchMode dispatchMode = DispatchMode.Default /* Metadata: 0x00660513 */); // 0x00000001824957C0-0x00000001824958D0
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal void SwitchFocus(Focusable newFocusedElement, bool bIsFocusDelegated = false /* Metadata: 0x00660514 */, DispatchMode dispatchMode = DispatchMode.Default /* Metadata: 0x00660515 */); // 0x0000000182496F90-0x0000000182497070
		internal void SwitchFocus(Focusable newFocusedElement, FocusChangeDirection direction, bool bIsFocusDelegated = false /* Metadata: 0x00660516 */, DispatchMode dispatchMode = DispatchMode.Default /* Metadata: 0x00660517 */); // 0x0000000182497070-0x00000001824974B0
		internal void SwitchFocusOnEvent(Focusable currentFocusable, EventBase e); // 0x0000000182496C90-0x0000000182496F90
		internal void ReevaluateFocus(); // 0x0000000182496800-0x00000001824968D0
		internal bool GetFocusableParentForPointerEvent(Focusable target, out Focusable effectiveTarget); // 0x0000000182495BA0-0x0000000182495D00
		internal void SyncIMGUIFocus(int imguiKeyboardControlID, Focusable imguiContainerHavingKeyboardControl, bool forceSwitch); // 0x00000001824974B0-0x00000001824975F0
	}
}
