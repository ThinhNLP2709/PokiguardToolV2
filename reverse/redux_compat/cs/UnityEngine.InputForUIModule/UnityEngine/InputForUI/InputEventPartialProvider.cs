/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.IntegerTime;
using UnityEngine;

// Image 43: UnityEngine.InputForUIModule.dll - Assembly: UnityEngine.InputForUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15251-15301

namespace UnityEngine.InputForUI
{
	internal class InputEventPartialProvider : IEventProviderImpl // TypeDefIndex: 15288
	{
		// Fields
		private Event _ev; // 0x10
		private OperatingSystemFamily _operatingSystemFamily; // 0x18
		private KeyEvent.ButtonsState _keyboardButtonsState; // 0x1C
		internal EventModifiers _eventModifiers; // 0x44
		internal bool _sendNavigationEventOnTabKey; // 0x48
		private IDictionary<string, CommandEvent.Command> _IMGUICommandToInputForUICommandType; // 0x50
	
		// Constructors
		public InputEventPartialProvider(); // 0x00000001822A6AC0-0x00000001822A6F30
	
		// Methods
		public void Initialize(); // 0x00000001822A5910-0x00000001822A5940
		public void Shutdown(); // 0x00000001802E76C0-0x00000001802E76D0
		public void Update(); // 0x00000001822A64A0-0x00000001822A6AC0
		public void OnFocusChanged(bool focus); // 0x00000001822A5940-0x00000001822A5960
		public bool RequestCurrentState(Event.Type type); // 0x00000001822A5960-0x00000001822A5B00
		private DiscreteTime GetTimestamp([IsReadOnly] in Event ev); // 0x0000000181CCF670-0x0000000181CCF6A0
		private void UpdateEventModifiers([IsReadOnly] in Event ev); // 0x00000001822A6170-0x00000001822A64A0
		private KeyEvent ToKeyEvent([IsReadOnly] in Event ev); // 0x00000001822A5F70-0x00000001822A60F0
		private TextInputEvent ToTextInputEvent([IsReadOnly] in Event ev); // 0x00000001822A60F0-0x00000001822A6170
		private IMECompositionEvent ToIMECompositionEvent([IsReadOnly] in Event ev); // 0x00000001822A5ED0-0x00000001822A5F70
		private void SendNextOrPreviousNavigationEventOnTabKeyDownEvent([IsReadOnly] in Event ev); // 0x00000001822A5B00-0x00000001822A5CE0
		private CommandEvent ToCommandEvent([IsReadOnly] in Event ev); // 0x00000001822A5CE0-0x00000001822A5ED0
	}
}
