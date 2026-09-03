/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[BurstCompile]
	internal struct AutoFreeAllocator : AllocatorManager.IAllocator // TypeDefIndex: 11470
	{
		// Fields
		private ArrayOfArrays<IntPtr> m_allocated; // 0x00
		private ArrayOfArrays<IntPtr> m_tofree; // 0x20
		private AllocatorManager.AllocatorHandle m_handle; // 0x40
		private AllocatorManager.AllocatorHandle m_backingAllocatorHandle; // 0x44
	
		// Properties
		public AllocatorManager.TryFunction Function { get; } // 0x0000000181C8A3F0-0x0000000181C8A4D0 
		public AllocatorManager.AllocatorHandle Handle { get; set; } // 0x000000018033D790-0x000000018033D7A0 0x000000018033ED10-0x000000018033ED20
		public Allocator ToAllocator { get; } // 0x0000000181C8A4E0-0x0000000181C8A4F0 
		public bool IsCustomAllocator { get; } // 0x0000000181C8A4D0-0x0000000181C8A4E0 
		public bool IsAutoDispose { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
		// Nested types
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate int Try_000000E9_PostfixBurstDelegate(IntPtr state, ref AllocatorManager.Block block); // TypeDefIndex: 11471; 0x0000000180A70FB0-0x0000000180A70FC0
	
		internal static class Try_000000E9_BurstDirectCall // TypeDefIndex: 11472
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181CA0460-0x0000000181CA04A0
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_00015524); // 0x0000000181CA04A0-0x0000000181CA0600
			private static IntPtr GetFunctionPointer(); // 0x0000000181CA0600-0x0000000181CA0750
			public static int Invoke(IntPtr state, ref AllocatorManager.Block block); // 0x0000000181C8A0B0-0x0000000181C8A280
		}
	
		// Methods
		public void Update(); // 0x0000000181C8A330-0x0000000181C8A3F0
		public void Initialize(AllocatorManager.AllocatorHandle backingAllocatorHandle); // 0x0000000181C89FE0-0x0000000181C8A080
		public void FreeAll(); // 0x0000000181C89EF0-0x0000000181C89FE0
		public void Dispose(); // 0x0000000181C89DE0-0x0000000181C89EF0
		public int Try(ref AllocatorManager.Block block); // 0x0000000181C8A280-0x0000000181C8A330
		[BurstCompile]
		[MonoPInvokeCallback(typeof(AllocatorManager.TryFunction))]
		internal static int Try(IntPtr state, ref AllocatorManager.Block block); // 0x0000000181C8A0B0-0x0000000181C8A280
		[BurstCompile]
		[MonoPInvokeCallback(typeof(AllocatorManager.TryFunction))]
		internal static int Try_BurstManaged(IntPtr state, ref AllocatorManager.Block block); // 0x0000000181C8A080-0x0000000181C8A0B0
	}
}
