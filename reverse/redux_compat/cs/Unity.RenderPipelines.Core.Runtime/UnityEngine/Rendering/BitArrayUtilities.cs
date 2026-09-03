/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public static class BitArrayUtilities // TypeDefIndex: 5738
	{
		// Methods
		public static bool Get8(uint index, byte data); // 0x0000000181EA4E80-0x0000000181EA4EA0
		public static bool Get16(uint index, ushort data); // 0x0000000181EA4E00-0x0000000181EA4E20
		public static bool Get32(uint index, uint data); // 0x0000000181EA4E60-0x0000000181EA4E70
		public static bool Get64(uint index, ulong data); // 0x0000000181EA4E70-0x0000000181EA4E80
		public static bool Get128(uint index, ulong data1, ulong data2); // 0x0000000181EA4DE0-0x0000000181EA4E00
		public static bool Get256(uint index, ulong data1, ulong data2, ulong data3, ulong data4); // 0x0000000181EA4E20-0x0000000181EA4E60
		public static void Set8(uint index, ref byte data, bool value); // 0x0000000181EA4FB0-0x0000000181EA4FD0
		public static void Set16(uint index, ref ushort data, bool value); // 0x0000000181EA4EE0-0x0000000181EA4F00
		public static void Set32(uint index, ref uint data, bool value); // 0x0000000181EA4F70-0x0000000181EA4F90
		public static void Set64(uint index, ref ulong data, bool value); // 0x0000000181EA4F90-0x0000000181EA4FB0
		public static void Set128(uint index, ref ulong data1, ref ulong data2, bool value); // 0x0000000181EA4EA0-0x0000000181EA4EE0
		public static void Set256(uint index, ref ulong data1, ref ulong data2, ref ulong data3, ref ulong data4, bool value); // 0x0000000181EA4F00-0x0000000181EA4F70
	}
}
