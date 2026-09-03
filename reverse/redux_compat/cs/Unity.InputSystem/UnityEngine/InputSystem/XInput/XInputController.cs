/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.XInput
{
	[InputControlLayout(displayName = "Xbox Controller")]
	public class XInputController : Gamepad // TypeDefIndex: 6276
	{
		// Fields
		[CompilerGenerated]
		private ButtonControl _menu_k__BackingField; // 0x210
		[CompilerGenerated]
		private ButtonControl _view_k__BackingField; // 0x218
		private bool m_HaveParsedCapabilities; // 0x220
		private DeviceSubType m_SubType; // 0x224
		private DeviceFlags m_Flags; // 0x228
	
		// Properties
		[InputControl(name = "buttonSouth", displayName = "A")]
		[InputControl(name = "buttonEast", displayName = "B")]
		[InputControl(name = "buttonWest", displayName = "X")]
		[InputControl(name = "buttonNorth", displayName = "Y")]
		[InputControl(name = "leftShoulder", displayName = "Left Bumper", shortDisplayName = "LB")]
		[InputControl(name = "rightShoulder", displayName = "Right Bumper", shortDisplayName = "RB")]
		[InputControl(name = "leftTrigger", shortDisplayName = "LT")]
		[InputControl(name = "rightTrigger", shortDisplayName = "RT")]
		[InputControl(name = "start", displayName = "Menu", alias = "menu")]
		[InputControl(name = "select", displayName = "View", alias = "view")]
		public ButtonControl menu { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000180BB3F80-0x0000000180BB3F90 0x0000000181380190-0x00000001813801B0
		public ButtonControl view { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC2910-0x0000000181CC2920 0x00000001813801D0-0x00000001813801F0
		public DeviceSubType subType { get; } // 0x0000000181DA5AD0-0x0000000181DA5B10 
		public DeviceFlags flags { get; } // 0x0000000181DA5A90-0x0000000181DA5AD0 
	
		// Nested types
		internal enum DeviceType // TypeDefIndex: 6277
		{
			Gamepad = 0
		}
	
		public enum DeviceSubType // TypeDefIndex: 6278
		{
			Unknown = 0,
			Gamepad = 1,
			Wheel = 2,
			ArcadeStick = 3,
			FlightStick = 4,
			DancePad = 5,
			Guitar = 6,
			GuitarAlternate = 7,
			DrumKit = 8,
			GuitarBass = 11,
			ArcadePad = 19
		}
	
		[Flags]
		public enum DeviceFlags // TypeDefIndex: 6279
		{
			ForceFeedbackSupported = 1,
			Wireless = 2,
			VoiceSupported = 4,
			PluginModulesSupported = 8,
			NoNavigation = 16
		}
	
		[Serializable]
		internal struct Capabilities // TypeDefIndex: 6280
		{
			// Fields
			public DeviceType type; // 0x00
			public DeviceSubType subType; // 0x04
			public DeviceFlags flags; // 0x08
		}
	
		// Constructors
		public XInputController(); // 0x0000000181CC2A30-0x0000000181CC2A40
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181DA59A0-0x0000000181DA59F0
		private void ParseCapabilities(); // 0x0000000181DA59F0-0x0000000181DA5A90
	}
}
