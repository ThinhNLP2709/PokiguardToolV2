/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	[DefaultMember("Item")]
	internal struct RawSlice // TypeDefIndex: 5050
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		private readonly unsafe byte* m_Buffer; // 0x00
		private readonly int m_Length; // 0x08
		private readonly int m_Stride; // 0x0C
	
		// Properties
		public int Length { get; } // 0x0000000180732D20-0x0000000180732D30 
		public int Stride { get; } // 0x0000000180732D30-0x0000000180732D40 
		public int ByteLength { get; } // 0x000000018241CB10-0x000000018241CB20 
	
		// Constructors
		internal unsafe RawSlice(byte* buffer, int length, int stride); // 0x0000000180F467E0-0x0000000180F467F0
	
		// Methods
		public IntPtr GetUnsafePtr(); // 0x0000000180E85FD0-0x0000000180E85FE0
		public IntPtr GetUnsafeReadOnlyPtr(); // 0x0000000180E85FD0-0x0000000180E85FE0
		public RawSlice Slice(int start, int count); // 0x000000018241CA20-0x000000018241CA40
	}
}
