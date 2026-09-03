/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	[InputControlLayout(stateType = typeof(KeyboardState), isGenericTypeOfDevice = true)]
	public class Keyboard : InputDevice, ITextInputReceiver, IEventPreProcessor // TypeDefIndex: 6164
	{
		// Fields
		public const int KeyCount = 110; // Metadata: 0x00698B49
		internal const int ExtendedKeyCount = 126; // Metadata: 0x00698B4B
		[CompilerGenerated]
		private AnyKeyControl _anyKey_k__BackingField; // 0x190
		[CompilerGenerated]
		private ButtonControl _shiftKey_k__BackingField; // 0x198
		[CompilerGenerated]
		private ButtonControl _ctrlKey_k__BackingField; // 0x1A0
		[CompilerGenerated]
		private ButtonControl _altKey_k__BackingField; // 0x1A8
		[CompilerGenerated]
		private ButtonControl _imeSelected_k__BackingField; // 0x1B0
		[CompilerGenerated]
		private static Keyboard _current_k__BackingField; // 0x00
		private InlinedArray<Action<char>> m_TextInputListeners; // 0x1B8
		private string m_KeyboardLayoutName; // 0x1D0
		private KeyControl[] m_Keys; // 0x1D8
		private InlinedArray<Action<IMECompositionString>> m_ImeCompositionListeners; // 0x1E0
	
		// Properties
		public string keyboardLayout { get; protected set; } // 0x0000000181D83B70-0x0000000181D83B90 0x0000000181380150-0x0000000181380170
		public AnyKeyControl anyKey { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181C4BDF0-0x0000000181C4BE00 0x0000000181380110-0x0000000181380130
		public KeyControl spaceKey { get; } // 0x0000000181D83F10-0x0000000181D83F20 
		public KeyControl enterKey { get; } // 0x0000000181D83940-0x0000000181D83950 
		public KeyControl tabKey { get; } // 0x0000000181D83F30-0x0000000181D83F40 
		public KeyControl backquoteKey { get; } // 0x0000000181D837A0-0x0000000181D837B0 
		public KeyControl quoteKey { get; } // 0x0000000181D83E50-0x0000000181D83E60 
		public KeyControl semicolonKey { get; } // 0x0000000181D83EF0-0x0000000181D83F00 
		public KeyControl commaKey { get; } // 0x0000000181D837F0-0x0000000181D83800 
		public KeyControl periodKey { get; } // 0x0000000181D83E20-0x0000000181D83E30 
		public KeyControl slashKey { get; } // 0x0000000181D83F00-0x0000000181D83F10 
		public KeyControl backslashKey { get; } // 0x0000000181D837B0-0x0000000181D837C0 
		public KeyControl leftBracketKey { get; } // 0x0000000181D83BD0-0x0000000181D83BE0 
		public KeyControl rightBracketKey { get; } // 0x0000000181D83EA0-0x0000000181D83EB0 
		public KeyControl minusKey { get; } // 0x0000000181D83C40-0x0000000181D83C50 
		public KeyControl equalsKey { get; } // 0x0000000181D83950-0x0000000181D83960 
		public KeyControl aKey { get; } // 0x0000000181D83750-0x0000000181D83760 
		public KeyControl bKey { get; } // 0x0000000181D83790-0x0000000181D837A0 
		public KeyControl cKey { get; } // 0x0000000181D837D0-0x0000000181D837E0 
		public KeyControl dKey { get; } // 0x0000000181D83850-0x0000000181D83860 
		public KeyControl eKey { get; } // 0x0000000181D83920-0x0000000181D83930 
		public KeyControl fKey { get; } // 0x0000000181D83AF0-0x0000000181D83B00 
		public KeyControl gKey { get; } // 0x0000000181D83B00-0x0000000181D83B10 
		public KeyControl hKey { get; } // 0x0000000181D83B10-0x0000000181D83B20 
		public KeyControl iKey { get; } // 0x0000000181D83B30-0x0000000181D83B40 
		public KeyControl jKey { get; } // 0x0000000181D83B50-0x0000000181D83B60 
		public KeyControl kKey { get; } // 0x0000000181D83B60-0x0000000181D83B70 
		public KeyControl lKey { get; } // 0x0000000181D83B90-0x0000000181D83BA0 
		public KeyControl mKey { get; } // 0x0000000181D83C00-0x0000000181D83C10 
		public KeyControl nKey { get; } // 0x0000000181D83C50-0x0000000181D83C60 
		public KeyControl oKey { get; } // 0x0000000181D83D80-0x0000000181D83D90 
		public KeyControl pKey { get; } // 0x0000000181D83DE0-0x0000000181D83DF0 
		public KeyControl qKey { get; } // 0x0000000181D83E40-0x0000000181D83E50 
		public KeyControl rKey { get; } // 0x0000000181D83E60-0x0000000181D83E70 
		public KeyControl sKey { get; } // 0x0000000181D83ED0-0x0000000181D83EE0 
		public KeyControl tKey { get; } // 0x0000000181D83F20-0x0000000181D83F30 
		public KeyControl uKey { get; } // 0x0000000181D83F40-0x0000000181D83F50 
		public KeyControl vKey { get; } // 0x0000000181D83F60-0x0000000181D83F70 
		public KeyControl wKey { get; } // 0x0000000181D83F70-0x0000000181D83F80 
		public KeyControl xKey { get; } // 0x0000000181D83F80-0x0000000181D83F90 
		public KeyControl yKey { get; } // 0x0000000181D83F90-0x0000000181D83FA0 
		public KeyControl zKey { get; } // 0x0000000181D83FA0-0x0000000181D83FB0 
		public KeyControl digit1Key { get; } // 0x0000000181D83880-0x0000000181D83890 
		public KeyControl digit2Key { get; } // 0x0000000181D83890-0x0000000181D838A0 
		public KeyControl digit3Key { get; } // 0x0000000181D838A0-0x0000000181D838B0 
		public KeyControl digit4Key { get; } // 0x0000000181D838B0-0x0000000181D838C0 
		public KeyControl digit5Key { get; } // 0x0000000181D838C0-0x0000000181D838D0 
		public KeyControl digit6Key { get; } // 0x0000000181D838D0-0x0000000181D838E0 
		public KeyControl digit7Key { get; } // 0x0000000181D838E0-0x0000000181D838F0 
		public KeyControl digit8Key { get; } // 0x0000000181D838F0-0x0000000181D83900 
		public KeyControl digit9Key { get; } // 0x0000000181D83900-0x0000000181D83910 
		public KeyControl digit0Key { get; } // 0x0000000181D83870-0x0000000181D83880 
		public KeyControl leftShiftKey { get; } // 0x0000000181D83BF0-0x0000000181D83C00 
		public KeyControl rightShiftKey { get; } // 0x0000000181D83EC0-0x0000000181D83ED0 
		public KeyControl leftAltKey { get; } // 0x0000000181D83BA0-0x0000000181D83BB0 
		public KeyControl rightAltKey { get; } // 0x0000000181D83E70-0x0000000181D83E80 
		public KeyControl leftCtrlKey { get; } // 0x0000000181D83BE0-0x0000000181D83BF0 
		public KeyControl rightCtrlKey { get; } // 0x0000000181D83EB0-0x0000000181D83EC0 
		public KeyControl leftMetaKey { get; } // 0x0000000181D83BB0-0x0000000181D83BC0 
		public KeyControl rightMetaKey { get; } // 0x0000000181D83E80-0x0000000181D83E90 
		public KeyControl leftWindowsKey { get; } // 0x0000000181D83BB0-0x0000000181D83BC0 
		public KeyControl rightWindowsKey { get; } // 0x0000000181D83E80-0x0000000181D83E90 
		public KeyControl leftAppleKey { get; } // 0x0000000181D83BB0-0x0000000181D83BC0 
		public KeyControl rightAppleKey { get; } // 0x0000000181D83E80-0x0000000181D83E90 
		public KeyControl leftCommandKey { get; } // 0x0000000181D83BB0-0x0000000181D83BC0 
		public KeyControl rightCommandKey { get; } // 0x0000000181D83E80-0x0000000181D83E90 
		public KeyControl contextMenuKey { get; } // 0x0000000181D83800-0x0000000181D83810 
		public KeyControl escapeKey { get; } // 0x0000000181D83960-0x0000000181D83970 
		public KeyControl leftArrowKey { get; } // 0x0000000181D83BC0-0x0000000181D83BD0 
		public KeyControl rightArrowKey { get; } // 0x0000000181D83E90-0x0000000181D83EA0 
		public KeyControl upArrowKey { get; } // 0x0000000181D83F50-0x0000000181D83F60 
		public KeyControl downArrowKey { get; } // 0x0000000181D83910-0x0000000181D83920 
		public KeyControl backspaceKey { get; } // 0x0000000181D837C0-0x0000000181D837D0 
		public KeyControl pageDownKey { get; } // 0x0000000181D83DF0-0x0000000181D83E00 
		public KeyControl pageUpKey { get; } // 0x0000000181D83E00-0x0000000181D83E10 
		public KeyControl homeKey { get; } // 0x0000000181D83B20-0x0000000181D83B30 
		public KeyControl endKey { get; } // 0x0000000181D83930-0x0000000181D83940 
		public KeyControl insertKey { get; } // 0x0000000181D83B40-0x0000000181D83B50 
		public KeyControl deleteKey { get; } // 0x0000000181D83860-0x0000000181D83870 
		public KeyControl capsLockKey { get; } // 0x0000000181D837E0-0x0000000181D837F0 
		public KeyControl scrollLockKey { get; } // 0x0000000181D83EE0-0x0000000181D83EF0 
		public KeyControl numLockKey { get; } // 0x0000000181D83C60-0x0000000181D83C70 
		public KeyControl printScreenKey { get; } // 0x0000000181D83E30-0x0000000181D83E40 
		public KeyControl pauseKey { get; } // 0x0000000181D83E10-0x0000000181D83E20 
		public KeyControl numpadEnterKey { get; } // 0x0000000181D83D20-0x0000000181D83D30 
		public KeyControl numpadDivideKey { get; } // 0x0000000181D83D10-0x0000000181D83D20 
		public KeyControl numpadMultiplyKey { get; } // 0x0000000181D83D50-0x0000000181D83D60 
		public KeyControl numpadMinusKey { get; } // 0x0000000181D83D40-0x0000000181D83D50 
		public KeyControl numpadPlusKey { get; } // 0x0000000181D83D70-0x0000000181D83D80 
		public KeyControl numpadPeriodKey { get; } // 0x0000000181D83D60-0x0000000181D83D70 
		public KeyControl numpadEqualsKey { get; } // 0x0000000181D83D30-0x0000000181D83D40 
		public KeyControl numpad0Key { get; } // 0x0000000181D83C70-0x0000000181D83C80 
		public KeyControl numpad1Key { get; } // 0x0000000181D83C80-0x0000000181D83C90 
		public KeyControl numpad2Key { get; } // 0x0000000181D83C90-0x0000000181D83CA0 
		public KeyControl numpad3Key { get; } // 0x0000000181D83CA0-0x0000000181D83CB0 
		public KeyControl numpad4Key { get; } // 0x0000000181D83CB0-0x0000000181D83CC0 
		public KeyControl numpad5Key { get; } // 0x0000000181D83CC0-0x0000000181D83CD0 
		public KeyControl numpad6Key { get; } // 0x0000000181D83CD0-0x0000000181D83CE0 
		public KeyControl numpad7Key { get; } // 0x0000000181D83CE0-0x0000000181D83CF0 
		public KeyControl numpad8Key { get; } // 0x0000000181D83CF0-0x0000000181D83D00 
		public KeyControl numpad9Key { get; } // 0x0000000181D83D00-0x0000000181D83D10 
		public KeyControl f1Key { get; } // 0x0000000181D83A10-0x0000000181D83A20 
		public KeyControl f2Key { get; } // 0x0000000181D83A70-0x0000000181D83A80 
		public KeyControl f3Key { get; } // 0x0000000181D83A80-0x0000000181D83A90 
		public KeyControl f4Key { get; } // 0x0000000181D83A90-0x0000000181D83AA0 
		public KeyControl f5Key { get; } // 0x0000000181D83AA0-0x0000000181D83AB0 
		public KeyControl f6Key { get; } // 0x0000000181D83AB0-0x0000000181D83AC0 
		public KeyControl f7Key { get; } // 0x0000000181D83AC0-0x0000000181D83AD0 
		public KeyControl f8Key { get; } // 0x0000000181D83AD0-0x0000000181D83AE0 
		public KeyControl f9Key { get; } // 0x0000000181D83AE0-0x0000000181D83AF0 
		public KeyControl f10Key { get; } // 0x0000000181D83970-0x0000000181D83980 
		public KeyControl f11Key { get; } // 0x0000000181D83980-0x0000000181D83990 
		public KeyControl f12Key { get; } // 0x0000000181D83990-0x0000000181D839A0 
		public KeyControl oem1Key { get; } // 0x0000000181D83D90-0x0000000181D83DA0 
		public KeyControl oem2Key { get; } // 0x0000000181D83DA0-0x0000000181D83DB0 
		public KeyControl oem3Key { get; } // 0x0000000181D83DB0-0x0000000181D83DC0 
		public KeyControl oem4Key { get; } // 0x0000000181D83DC0-0x0000000181D83DD0 
		public KeyControl oem5Key { get; } // 0x0000000181D83DD0-0x0000000181D83DE0 
		public KeyControl f13Key { get; } // 0x0000000181D839A0-0x0000000181D839B0 
		public KeyControl f14Key { get; } // 0x0000000181D839B0-0x0000000181D839C0 
		public KeyControl f15Key { get; } // 0x0000000181D839C0-0x0000000181D839D0 
		public KeyControl f16Key { get; } // 0x0000000181D839D0-0x0000000181D839E0 
		public KeyControl f17Key { get; } // 0x0000000181D839E0-0x0000000181D839F0 
		public KeyControl f18Key { get; } // 0x0000000181D839F0-0x0000000181D83A00 
		public KeyControl f19Key { get; } // 0x0000000181D83A00-0x0000000181D83A10 
		public KeyControl f20Key { get; } // 0x0000000181D83A20-0x0000000181D83A30 
		public KeyControl f21Key { get; } // 0x0000000181D83A30-0x0000000181D83A40 
		public KeyControl f22Key { get; } // 0x0000000181D83A40-0x0000000181D83A50 
		public KeyControl f23Key { get; } // 0x0000000181D83A50-0x0000000181D83A60 
		public KeyControl f24Key { get; } // 0x0000000181D83A60-0x0000000181D83A70 
		public KeyControl mediaPlayPause { get; } // 0x0000000181D83C20-0x0000000181D83C30 
		public KeyControl mediaRewind { get; } // 0x0000000181D83C30-0x0000000181D83C40 
		public KeyControl mediaForward { get; } // 0x0000000181D83C10-0x0000000181D83C20 
		public ButtonControl shiftKey { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC2A40-0x0000000181CC2A50 0x0000000181CC2A60-0x0000000181CC2A80
		public ButtonControl ctrlKey { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC2A50-0x0000000181CC2A60 0x0000000181CC2A80-0x0000000181CC2AA0
		public ButtonControl altKey { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000180E224F0-0x0000000180E22500 0x000000018033A5B0-0x000000018033A5D0
		public ButtonControl imeSelected { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22F0-0x0000000181CB2300 0x0000000181380130-0x0000000181380150
		public KeyControl this[Key key] { get => default; } // 0x0000000181D83660-0x0000000181D83750 
		public ReadOnlyArray<KeyControl> allKeys { get; } // 0x0000000181D83760-0x0000000181D83790 
		public static Keyboard current { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D83810-0x0000000181D83850 0x0000000181D84050-0x0000000181D840B0
		protected KeyControl[] keys { get; set; } // 0x0000000181CB2290-0x0000000181CB22A0 0x0000000181380210-0x0000000181380230
	
		// Events
		public event Action<char> onTextInput {
			add; // 0x0000000181D83580-0x0000000181D83660
			remove; // 0x0000000181D84000-0x0000000181D84050
		}
		public event Action<IMECompositionString> onIMECompositionChange {
			add; // 0x0000000181D834A0-0x0000000181D83580
			remove; // 0x0000000181D83FB0-0x0000000181D84000
		}
	
		// Constructors
		public Keyboard(); // 0x0000000181CC2A30-0x0000000181CC2A40
	
		// Methods
		public void SetIMEEnabled(bool enabled); // 0x0000000181D833B0-0x0000000181D83400
		public void SetIMECursorPosition(Vector2 position); // 0x0000000181D83370-0x0000000181D833B0
		public override void MakeCurrent(); // 0x0000000181D82FF0-0x0000000181D83050
		protected override void OnRemoved(); // 0x0000000181D83160-0x0000000181D831F0
		protected override void FinishSetup(); // 0x0000000181D815C0-0x0000000181D82FF0
		protected override void RefreshConfiguration(); // 0x0000000181D83280-0x0000000181D83370
		public void OnTextInput(char character); // 0x0000000181D831F0-0x0000000181D83280
		public KeyControl FindKeyOnCurrentKeyboardLayout(string displayName); // 0x0000000181D814D0-0x0000000181D815C0
		public void OnIMECompositionChanged(IMECompositionString compositionString); // 0x0000000181D83050-0x0000000181D83160
		bool IEventPreProcessor.PreProcessEvent(InputEventPtr currentEventPtr); // 0x0000000181D83400-0x0000000181D834A0
	}
}
