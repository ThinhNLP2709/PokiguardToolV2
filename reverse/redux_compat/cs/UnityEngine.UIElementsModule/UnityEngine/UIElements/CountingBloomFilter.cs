/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal struct CountingBloomFilter // TypeDefIndex: 3927
	{
		// Fields
		private unsafe fixed /* 0x00000000-0x00000000 */ byte m_Counters[0]; // 0x00
	
		// Nested types
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _m_Counters_e__FixedBuffer // TypeDefIndex: 3928
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	
		// Methods
		private void AdjustSlot(uint index, bool increment); // 0x000000018239AFF0-0x000000018239B020
		private uint Hash1(uint hash); // 0x000000018239B050-0x000000018239B060
		private uint Hash2(uint hash); // 0x000000018239B060-0x000000018239B070
		private bool IsSlotEmpty(uint index); // 0x000000018239B0A0-0x000000018239B0B0
		public void InsertHash(uint hash); // 0x000000018239B070-0x000000018239B0A0
		public void RemoveHash(uint hash); // 0x000000018239B0B0-0x000000018239B0E0
		public bool ContainsHash(uint hash); // 0x000000018239B020-0x000000018239B050
	}
}
