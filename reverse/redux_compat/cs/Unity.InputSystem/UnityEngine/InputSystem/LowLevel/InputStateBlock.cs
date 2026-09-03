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
	public struct InputStateBlock // TypeDefIndex: 6498
	{
		// Fields
		public const uint InvalidOffset = 4294967295; // Metadata: 0x00699103
		public const uint AutomaticOffset = 4294967294; // Metadata: 0x00699104
		public static readonly FourCC FormatInvalid; // 0x00
		internal const int kFormatInvalid = 0; // Metadata: 0x00699105
		public static readonly FourCC FormatBit; // 0x04
		internal const int kFormatBit = 1112101920; // Metadata: 0x00699106
		public static readonly FourCC FormatSBit; // 0x08
		internal const int kFormatSBit = 1396853076; // Metadata: 0x0069910B
		public static readonly FourCC FormatInt; // 0x0C
		internal const int kFormatInt = 1229870112; // Metadata: 0x00699110
		public static readonly FourCC FormatUInt; // 0x10
		internal const int kFormatUInt = 1430867540; // Metadata: 0x00699115
		public static readonly FourCC FormatShort; // 0x14
		internal const int kFormatShort = 1397248596; // Metadata: 0x0069911A
		public static readonly FourCC FormatUShort; // 0x18
		internal const int kFormatUShort = 1431521364; // Metadata: 0x0069911F
		public static readonly FourCC FormatByte; // 0x1C
		internal const int kFormatByte = 1113150533; // Metadata: 0x00699124
		public static readonly FourCC FormatSByte; // 0x20
		internal const int kFormatSByte = 1396857172; // Metadata: 0x00699129
		public static readonly FourCC FormatLong; // 0x24
		internal const int kFormatLong = 1280198432; // Metadata: 0x0069912E
		public static readonly FourCC FormatULong; // 0x28
		internal const int kFormatULong = 1431064135; // Metadata: 0x00699133
		public static readonly FourCC FormatFloat; // 0x2C
		internal const int kFormatFloat = 1179407392; // Metadata: 0x00699138
		public static readonly FourCC FormatDouble; // 0x30
		internal const int kFormatDouble = 1145195552; // Metadata: 0x0069913D
		public static readonly FourCC FormatVector2; // 0x34
		internal const int kFormatVector2 = 1447379762; // Metadata: 0x00699142
		public static readonly FourCC FormatVector3; // 0x38
		internal const int kFormatVector3 = 1447379763; // Metadata: 0x00699147
		public static readonly FourCC FormatQuaternion; // 0x3C
		internal const int kFormatQuaternion = 1364541780; // Metadata: 0x0069914C
		public static readonly FourCC FormatVector2Short; // 0x40
		public static readonly FourCC FormatVector3Short; // 0x44
		public static readonly FourCC FormatVector2Byte; // 0x48
		public static readonly FourCC FormatVector3Byte; // 0x4C
		public static readonly FourCC FormatPose; // 0x50
		internal const int kFormatPose = 1349481317; // Metadata: 0x00699151
		[CompilerGenerated]
		private FourCC _format_k__BackingField; // 0x00
		internal uint m_ByteOffset; // 0x04
		[CompilerGenerated]
		private uint _bitOffset_k__BackingField; // 0x08
		[CompilerGenerated]
		private uint _sizeInBits_k__BackingField; // 0x0C
	
		// Properties
		public FourCC format { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
		public uint byteOffset { get; set; } // 0x00000001802E7C60-0x00000001802E7DA0 0x0000000180732D40-0x0000000180732D50
		public uint bitOffset { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180732D20-0x0000000180732D30 0x0000000180732D60-0x0000000180732D70
		public uint sizeInBits { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180732D30-0x0000000180732D40 0x0000000180732D70-0x0000000180732D80
		internal uint alignedSizeInBytes { get; } // 0x0000000181DE11A0-0x0000000181DE11F0 
		internal uint effectiveByteOffset { get; } // 0x0000000181DE1240-0x0000000181DE1290 
		internal uint effectiveBitOffset { get; } // 0x0000000181DE11F0-0x0000000181DE1240 
	
		// Constructors
		static InputStateBlock(); // 0x0000000181DE0C80-0x0000000181DE11A0
	
		// Methods
		public static int GetSizeOfPrimitiveFormatInBits(FourCC type); // 0x0000000181DDF6B0-0x0000000181DDF7E0
		public static FourCC GetPrimitiveFormatFromType(Type type); // 0x0000000181DDF290-0x0000000181DDF6B0
		public unsafe int ReadInt(void* statePtr); // 0x0000000181DDFEF0-0x0000000181DE00E0
		public unsafe void WriteInt(void* statePtr, int value); // 0x0000000181DE0790-0x0000000181DE09A0
		public unsafe float ReadFloat(void* statePtr); // 0x0000000181DDFB80-0x0000000181DDFEF0
		public unsafe void WriteFloat(void* statePtr, float value); // 0x0000000181DE0450-0x0000000181DE0790
		internal PrimitiveValue FloatToPrimitiveValue(float value); // 0x0000000181DDEEC0-0x0000000181DDF290
		public unsafe double ReadDouble(void* statePtr); // 0x0000000181DDF7E0-0x0000000181DDFB80
		public unsafe void WriteDouble(void* statePtr, double value); // 0x0000000181DE00E0-0x0000000181DE0450
		public unsafe void Write(void* statePtr, PrimitiveValue value); // 0x0000000181DE09A0-0x0000000181DE0C80
		public unsafe void CopyToFrom(void* toStatePtr, void* fromStatePtr); // 0x0000000181DDEDA0-0x0000000181DDEEC0
	}
}
