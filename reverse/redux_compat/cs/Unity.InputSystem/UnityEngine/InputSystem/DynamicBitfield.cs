/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	internal struct DynamicBitfield // TypeDefIndex: 6245
	{
		// Fields
		public InlinedArray<ulong> array; // 0x00
		public int length; // 0x18
	
		// Methods
		public void SetLength(int newLength); // 0x0000000181D8B880-0x0000000181D8B8E0
		public void SetBit(int bitIndex); // 0x0000000181D8B7E0-0x0000000181D8B880
		public bool TestBit(int bitIndex); // 0x0000000181D8B8E0-0x0000000181D8B960
		public void ClearBit(int bitIndex); // 0x0000000181D8B740-0x0000000181D8B7E0
		public bool AnyBitIsSet(); // 0x0000000181D8B6C0-0x0000000181D8B730
		private static int BitCountToULongCount(int bitCount); // 0x0000000181D8B730-0x0000000181D8B740
	}
}
