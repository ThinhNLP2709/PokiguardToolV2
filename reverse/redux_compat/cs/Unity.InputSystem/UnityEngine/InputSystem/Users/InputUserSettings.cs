/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Users
{
	[Serializable]
	internal class InputUserSettings // TypeDefIndex: 6296
	{
		// Fields
		[CompilerGenerated]
		private string _customBindings_k__BackingField; // 0x10
		[CompilerGenerated]
		private bool _invertMouseX_k__BackingField; // 0x18
		[CompilerGenerated]
		private bool _invertMouseY_k__BackingField; // 0x19
		[CompilerGenerated]
		private float? _mouseSmoothing_k__BackingField; // 0x1C
		[CompilerGenerated]
		private float? _mouseSensitivity_k__BackingField; // 0x24
		[CompilerGenerated]
		private bool _invertStickX_k__BackingField; // 0x2C
		[CompilerGenerated]
		private bool _invertStickY_k__BackingField; // 0x2D
		[CompilerGenerated]
		private bool _swapSticks_k__BackingField; // 0x2E
		[CompilerGenerated]
		private bool _swapBumpers_k__BackingField; // 0x2F
		[CompilerGenerated]
		private bool _swapTriggers_k__BackingField; // 0x30
		[CompilerGenerated]
		private bool _swapDpadAndLeftStick_k__BackingField; // 0x31
		[CompilerGenerated]
		private float _vibrationStrength_k__BackingField; // 0x34
		[SerializeField]
		private string m_CustomBindings; // 0x38
	
		// Properties
		public string customBindings { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public bool invertMouseX { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180F9E350-0x0000000180F9E360 0x00000001804C2E10-0x00000001804C2E20
		public bool invertMouseY { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181780E10-0x0000000181780E20 0x0000000181780E30-0x0000000181780E40
		public float? mouseSmoothing { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181DB5B70-0x0000000181DB5B80 0x0000000181DB5BB0-0x0000000181DB5BC0
		public float? mouseSensitivity { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181DB5B60-0x0000000181DB5B70 0x0000000181DB5BA0-0x0000000181DB5BB0
		public bool invertStickX { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181B20770-0x0000000181B20780 0x0000000181B20790-0x0000000181B207A0
		public bool invertStickY { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181B20760-0x0000000181B20770 0x0000000181B20780-0x0000000181B20790
		public bool swapSticks { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181DB5B90-0x0000000181DB5BA0 0x0000000181DB5BD0-0x0000000181DB5BE0
		public bool swapBumpers { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181DB5B80-0x0000000181DB5B90 0x0000000181DB5BC0-0x0000000181DB5BD0
		public bool swapTriggers { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802E8950-0x00000001802E8960 0x00000001802E8960-0x00000001802E8970
		public bool swapDpadAndLeftStick { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180634F10-0x0000000180634F20 0x0000000181B14860-0x0000000181B14870
		public float vibrationStrength { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181230A40-0x0000000181230A50 0x0000000181230A60-0x0000000181230A70
	
		// Constructors
		public InputUserSettings(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public virtual void Apply(IInputActionCollection actions); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
