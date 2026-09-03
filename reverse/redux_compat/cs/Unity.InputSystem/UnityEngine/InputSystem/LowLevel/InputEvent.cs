/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Utilities;
using UnityEngineInternal.Input;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	public struct InputEvent // TypeDefIndex: 6461
	{
		// Fields
		private const uint kHandledMask = 2147483648; // Metadata: 0x00699058
		private const uint kIdMask = 2147483647; // Metadata: 0x0069905D
		internal const int kBaseEventSize = 20; // Metadata: 0x00699062
		public const int InvalidEventId = 0; // Metadata: 0x00699063
		internal const int kAlignment = 4; // Metadata: 0x00699064
		private NativeInputEvent m_Event; // 0x00
	
		// Properties
		public FourCC type { get; set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
		public uint sizeInBytes { get; set; } // 0x0000000181328330-0x0000000181328340 0x0000000181DCF340-0x0000000181DCF3F0
		public int eventId { get; set; } // 0x0000000181DCF2A0-0x0000000181DCF2B0 0x0000000181DCF310-0x0000000181DCF320
		public int deviceId { get; set; } // 0x0000000181DCF290-0x0000000181DCF2A0 0x0000000181DCF300-0x0000000181DCF310
		public double time { get; set; } // 0x0000000181DCF2B0-0x0000000181DCF300 0x0000000181DCF3F0-0x0000000181DCF440
		internal double internalTime { get; set; } // 0x0000000180C5D1A0-0x0000000180C5D1B0 0x0000000181CE28B0-0x0000000181CE28C0
		public bool handled { get; set; } // 0x0000000181DC8940-0x0000000181DC8950 0x0000000181DCF320-0x0000000181DCF340
	
		// Constructors
		public InputEvent(FourCC type, int sizeInBytes, int deviceId, double time = -1 /* Metadata: 0x00699050 */); // 0x0000000181DCF1D0-0x0000000181DCF290
	
		// Methods
		public override string ToString(); // 0x0000000181DCEF30-0x0000000181DCF1D0
		internal static unsafe InputEvent* GetNextInMemory(InputEvent* currentPtr); // 0x0000000181DCEF10-0x0000000181DCEF30
		internal static unsafe InputEvent* GetNextInMemoryChecked(InputEvent* currentPtr, ref InputEventBuffer buffer); // 0x0000000181DCEE00-0x0000000181DCEF10
		public static unsafe bool Equals(InputEvent* first, InputEvent* second); // 0x0000000181DCEDB0-0x0000000181DCEE00
	}
}
