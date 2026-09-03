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
	public struct IMECompositionEvent : IInputEventTypeInfo // TypeDefIndex: 6457
	{
		// Fields
		internal const int kIMECharBufferSize = 64; // Metadata: 0x00699049
		public const int Type = 1229800787; // Metadata: 0x0069904B
		public InputEvent baseEvent; // 0x00
		public IMECompositionString compositionString; // 0x14
	
		// Properties
		public FourCC typeStatic { get; } // 0x0000000181DCA550-0x0000000181DCA560 
	
		// Methods
		public static IMECompositionEvent Create(int deviceId, string compositionString, double time); // 0x0000000181DCA2E0-0x0000000181DCA550
	}
}
