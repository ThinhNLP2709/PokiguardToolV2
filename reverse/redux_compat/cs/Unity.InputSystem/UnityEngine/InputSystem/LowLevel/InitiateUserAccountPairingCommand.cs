/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	public struct InitiateUserAccountPairingCommand : IInputDeviceCommandInfo // TypeDefIndex: 6399
	{
		// Fields
		internal const int kSize = 8; // Metadata: 0x00698F99
		public InputDeviceCommand baseCommand; // 0x00
	
		// Properties
		public static FourCC Type { get; } // 0x0000000181DCA7C0-0x0000000181DCA800 
		public FourCC typeStatic { get; } // 0x0000000181DCA800-0x0000000181DCA840 
	
		// Nested types
		public enum Result // TypeDefIndex: 6400
		{
			ErrorAlreadyInProgress = -2,
			ErrorNotSupported = -1,
			SuccessfullyInitiated = 1
		}
	
		// Methods
		public static InitiateUserAccountPairingCommand Create(); // 0x0000000181DCA770-0x0000000181DCA7C0
	}
}
