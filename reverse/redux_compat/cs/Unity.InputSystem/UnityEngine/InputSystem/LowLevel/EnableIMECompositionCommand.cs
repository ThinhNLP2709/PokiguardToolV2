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
	public struct EnableIMECompositionCommand : IInputDeviceCommandInfo // TypeDefIndex: 6397
	{
		// Fields
		internal const int kSize = 12; // Metadata: 0x00698F98
		public InputDeviceCommand baseCommand; // 0x00
		private byte m_ImeEnabled; // 0x08
	
		// Properties
		public static FourCC Type { get; } // 0x0000000181DC2D30-0x0000000181DC2D70 
		public bool imeEnabled { get; } // 0x0000000181DC2D70-0x0000000181DC2D80 
		public FourCC typeStatic { get; } // 0x0000000181DC2D80-0x0000000181DC2DC0 
	
		// Methods
		public static EnableIMECompositionCommand Create(bool enabled); // 0x0000000181DC2CB0-0x0000000181DC2D30
	}
}
