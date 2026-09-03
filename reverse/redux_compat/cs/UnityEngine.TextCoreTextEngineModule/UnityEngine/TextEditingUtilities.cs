/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.TextCore.Text;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine
{
	[VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "UnityEngine.IMGUIModule" })]
	internal class TextEditingUtilities // TypeDefIndex: 12617
	{
		// Fields
		private TextSelectingUtilities m_TextSelectingUtility; // 0x10
		[VisibleToOtherModules(new string[1] {"UnityEngine.IMGUIModule" })]
		internal TextHandle textHandle; // 0x18
		private int m_CursorIndexSavedState; // 0x20
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal bool isCompositionActive; // 0x24
		private bool m_UpdateImeWindowPosition; // 0x25
		[VisibleToOtherModules(new string[1] {"UnityEngine.IMGUIModule" })]
		internal Action OnTextChanged; // 0x28
		public bool multiline; // 0x30
		private string m_Text; // 0x38
		[TupleElementNames(new string[2] {"keyEvent", "operation" })]
		internal static readonly List<ValueTuple<KeyEvent, TextEditOp>> s_GlobalKeyMappings; // 0x00
		[TupleElementNames(new string[2] {"keyEvent", "operation" })]
		internal static readonly List<ValueTuple<KeyEvent, TextEditOp>> s_MacKeyMappings; // 0x08
		[TupleElementNames(new string[2] {"keyEvent", "operation" })]
		internal static readonly List<ValueTuple<KeyEvent, TextEditOp>> s_WindowsLinuxKeyMappings; // 0x10
		private char m_HighSurrogate; // 0x40
	
		// Properties
		private bool hasSelection { get; } // 0x000000018230C2B0-0x000000018230C2F0 
		[VisibleToOtherModules(new string[1] {"UnityEngine.IMGUIModule" })]
		internal bool revealCursor { get; set; } // 0x000000018230C310-0x000000018230C370 0x000000018230C600-0x000000018230C620
		private bool useAdvancedText { get; } // 0x000000018230C500-0x000000018230C520 
		private IntPtr nativeTgi { get; } // 0x000000018230C2F0-0x000000018230C310 
		[VisibleToOtherModules(new string[1] {"UnityEngine.IMGUIModule" })]
		internal int stringCursorIndex { get; } // 0x000000018230C390-0x000000018230C420 
		private int cursorIndex { get; set; } // 0x000000018230C290-0x000000018230C2B0 0x000000018230C5E0-0x000000018230C600
		private int cursorIndexNoValidation { get; set; } // 0x000000018230C230-0x000000018230C290 0x000000018230C520-0x000000018230C5E0
		private int selectIndexNoValidation { set; } // 0x000000018230C620-0x000000018230C6E0
		[VisibleToOtherModules(new string[1] {"UnityEngine.IMGUIModule" })]
		internal int stringSelectIndex { get; } // 0x000000018230C420-0x000000018230C4B0 
		private int selectIndex { get; set; } // 0x000000018230C370-0x000000018230C390 0x000000018230C6E0-0x000000018230C700
		public string text { get; set; } // 0x000000018230C4B0-0x000000018230C500 0x000000018230C700-0x000000018230C7D0
	
		// Nested types
		internal struct KeyEvent : IEquatable<KeyEvent> // TypeDefIndex: 12618
		{
			// Fields
			[CompilerGenerated]
			private KeyCode _key_k__BackingField; // 0x00
			[CompilerGenerated]
			private EventModifiers _modifiers_k__BackingField; // 0x04
	
			// Properties
			public KeyCode key { [IsReadOnly] [CompilerGenerated] get; } // 0x0000000180732D10-0x0000000180732D20 
			public EventModifiers modifiers { [IsReadOnly] [CompilerGenerated] get; } // 0x00000001802E7C60-0x00000001802E7DA0 
	
			// Constructors
			public KeyEvent(KeyCode key, EventModifiers modifiers); // 0x0000000180C55C70-0x0000000180C55C80
	
			// Methods
			[CompilerGenerated]
			[IsReadOnly]
			public override string ToString(); // 0x0000000182303A60-0x0000000182303C00
			[CompilerGenerated]
			[IsReadOnly]
			private bool PrintMembers(StringBuilder builder); // 0x0000000182303960-0x0000000182303A60
			[CompilerGenerated]
			public static bool operator ==(KeyEvent left, KeyEvent right); // 0x0000000182303C00-0x0000000182303C20
			[CompilerGenerated]
			[IsReadOnly]
			public override int GetHashCode(); // 0x00000001823038B0-0x0000000182303960
			[CompilerGenerated]
			[IsReadOnly]
			public override bool Equals(object obj); // 0x0000000182303820-0x00000001823038B0
			[CompilerGenerated]
			[IsReadOnly]
			public bool Equals(KeyEvent other); // 0x0000000182303760-0x0000000182303820
		}
	
		// Constructors
		public TextEditingUtilities(TextSelectingUtilities selectingUtilities, TextHandle textHandle, string text); // 0x000000018230C120-0x000000018230C230
		static TextEditingUtilities(); // 0x000000018230A950-0x000000018230C120
	
		// Methods
		private void NotifyFromFlags(int flags); // 0x0000000182309230-0x00000001823092D0
		[VisibleToOtherModules(new string[1] {"UnityEngine.IMGUIModule" })]
		internal void SyncStateToNative(int cursorIndex, int selectIndex, string text = null, bool revealCursor = false /* Metadata: 0x006A4882 */); // 0x000000018230A460-0x000000018230A4F0
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal void SyncStateToNative(); // 0x000000018230A4F0-0x000000018230A5C0
		[VisibleToOtherModules(new string[1] {"UnityEngine.IMGUIModule" })]
		internal void SetTextWithoutNotify(string value); // 0x000000018230A3E0-0x000000018230A460
		public bool UpdateImeState(string compositionString); // 0x000000018230A8D0-0x000000018230A950
		public bool ShouldUpdateImeWindowPosition(); // 0x0000000181705FC0-0x0000000181705FD0
		public Vector2 GetCurrentCursorPosition(); // 0x0000000182308FC0-0x0000000182309060
		public string GeneratePreviewString(bool richText, string compositionString); // 0x0000000182308E50-0x0000000182308FC0
		public void EnableCursorPreviewState(string compositionString); // 0x0000000182308D50-0x0000000182308E50
		public void RestoreCursorState(); // 0x000000018230A350-0x000000018230A3E0
		public bool HandleKeyEvent(KeyCode key, EventModifiers modifiers); // 0x0000000182309060-0x0000000182309110
		internal static TextEditOp? TextEditOpFromEnum(KeyCode key, EventModifiers modifiers, bool IsMacOsFamily); // 0x000000018230A5C0-0x000000018230A860
		private void PerformOperation(TextEditOp operation); // 0x00000001823094C0-0x000000018230A0C0
		public bool DeleteLineBack(); // 0x00000001823083E0-0x0000000182308590
		public bool DeleteWordBack(); // 0x0000000182308830-0x00000001823089C0
		public bool DeleteWordForward(); // 0x00000001823089C0-0x0000000182308B70
		public bool Delete(); // 0x0000000182308B70-0x0000000182308D50
		public bool Backspace(); // 0x0000000182308140-0x0000000182308320
		public bool DeleteSelection(); // 0x0000000182308590-0x0000000182308830
		public void ReplaceSelection(string replace); // 0x000000018230A180-0x000000018230A350
		public bool Insert(char c); // 0x0000000182309110-0x0000000182309230
		public bool CanPaste(); // 0x0000000182308320-0x0000000182308350
		public bool Cut(); // 0x0000000182308350-0x00000001823083E0
		public bool Paste(); // 0x0000000182309360-0x00000001823094C0
		private static string ReplaceNewlinesWithSpaces(string value); // 0x000000018230A0F0-0x000000018230A180
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal void OnBlur(); // 0x00000001823092D0-0x0000000182309360
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal bool TouchScreenKeyboardCanBeUsed(); // 0x000000018230A860-0x000000018230A8D0
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal bool PhysicalKeyboardCanBeUsed(); // 0x000000018230A0C0-0x000000018230A0F0
	}
}
