/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal struct SelectorAccelerationCacheEntry // TypeDefIndex: 4784
	{
		// Fields
		internal unsafe byte* m_BackingBuffer; // 0x00
		internal unsafe FlattenedSelectorPart* m_AllPartsPtr; // 0x08
		internal int m_AllPartsCount; // 0x10
		internal unsafe FlattenedSelector* m_AllSelectorsPtr; // 0x18
		internal int m_AllSelectorsCount; // 0x20
		internal unsafe SelectorRangeDescriptor* m_AllDescriptorsPtr; // 0x28
		internal int m_AllDescriptorsCount; // 0x30
		public Dictionary<int, DescriptorRange> nameTable; // 0x38
		public Dictionary<int, DescriptorRange> typeTable; // 0x40
		public Dictionary<int, DescriptorRange> classTable; // 0x48
		public DescriptorRange rootSelectorRange; // 0x50
		public DescriptorRange wildCardSelectorRange; // 0x58
		internal StyleSheet ownerStyleSheet; // 0x60
		internal int nonEmptyTablesMask; // 0x68
	
		// Properties
		public ReadOnlySpan<FlattenedSelector> allSelectors { [IsReadOnly] get; } // 0x0000000182560E70-0x0000000182560EC0 
		internal Span<FlattenedSelectorPart> allPartsWritable { [IsReadOnly] get; } // 0x0000000182560E20-0x0000000182560E70 
		internal Span<FlattenedSelector> allSelectorsWritable { [IsReadOnly] get; } // 0x0000000182560E70-0x0000000182560EC0 
		internal Span<SelectorRangeDescriptor> allDescriptorsWritable { [IsReadOnly] get; } // 0x0000000182560DD0-0x0000000182560E20 
	
		// Methods
		[IsReadOnly]
		public ReadOnlySpan<FlattenedSelector> SelectorsFor([IsReadOnly] in SelectorRangeDescriptor descriptor); // 0x0000000182560D80-0x0000000182560DB0
		[IsReadOnly]
		public ReadOnlySpan<SelectorRangeDescriptor> DescriptorsFor([IsReadOnly] in DescriptorRange range); // 0x0000000182560C90-0x0000000182560CE0
		public void Free(); // 0x0000000182560CE0-0x0000000182560D80
		public static SelectorAccelerationCacheEntry Allocate(int totalParts, int totalSelectors, int totalDescriptors); // 0x0000000182560B40-0x0000000182560C90
		[CompilerGenerated]
		internal static long _Allocate_g__AlignUp_31_0(long value, int alignment); // 0x0000000182560DB0-0x0000000182560DD0
	}
}
