/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[UsedByNativeCode]
	internal struct EmbeddedLODBuffer // TypeDefIndex: 8369
	{
		// Fields
		private unsafe fixed /* 0x00000000-0x00000000 */ ushort m_ScreenRelativeTransitionHeights[0]; // 0x00
		private unsafe fixed /* 0x00000000-0x00000000 */ ushort m_FadeTransitionWidths[0]; // 0x10
		private unsafe fixed /* 0x00000000-0x00000000 */ byte m_RendererCounts[0]; // 0x20
		private byte m_Length; // 0x28
	
		// Properties
		public int Length { get; } // 0x0000000180327270-0x0000000180327280 
	
		// Nested types
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _m_FadeTransitionWidths_e__FixedBuffer // TypeDefIndex: 8370
		{
			// Fields
			public ushort FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _m_RendererCounts_e__FixedBuffer // TypeDefIndex: 8371
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _m_ScreenRelativeTransitionHeights_e__FixedBuffer // TypeDefIndex: 8372
		{
			// Fields
			public ushort FixedElementField; // 0x00
		}
	
		// Methods
		public float GetScreenRelativeTransitionHeight(int index); // 0x000000018225A9F0-0x000000018225AAA0
		public float GetFadeTransitionWidth(int index); // 0x000000018225A8D0-0x000000018225A980
		public int GetRendererCount(int index); // 0x000000018225A980-0x000000018225A9F0
		private static float MapUShortToFloat01(ushort x); // 0x000000018225AAA0-0x000000018225AAD0
	}
}
