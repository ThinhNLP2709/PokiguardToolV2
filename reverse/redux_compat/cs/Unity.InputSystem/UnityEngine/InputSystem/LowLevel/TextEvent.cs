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
	public struct TextEvent : IInputEventTypeInfo // TypeDefIndex: 6479
	{
		// Fields
		public const int Type = 1413830740; // Metadata: 0x006990D0
		public InputEvent baseEvent; // 0x00
		public int character; // 0x14
	
		// Properties
		public FourCC typeStatic { get; } // 0x0000000181DEA0A0-0x0000000181DEA0B0 
	
		// Methods
		public static unsafe TextEvent* From(InputEventPtr eventPtr); // 0x0000000181DE9F90-0x0000000181DEA0A0
		public static TextEvent Create(int deviceId, char character, double time = -1 /* Metadata: 0x006990C0 */); // 0x0000000181DE9EB0-0x0000000181DE9F20
		public static TextEvent Create(int deviceId, int character, double time = -1 /* Metadata: 0x006990C8 */); // 0x0000000181DE9F20-0x0000000181DE9F90
	}
}
