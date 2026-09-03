/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using Unity.Profiling;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	[BurstCompile]
	internal static class MeshUtilities // TypeDefIndex: 14362
	{
		// Fields
		private static readonly ProfilerMarker k_OldOutline; // 0x00
		private static readonly ProfilerMarker k_newOutline; // 0x08
	
		// Nested types
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate int GenerateUTessOutline_0000008E_PostfixBurstDelegate([IsReadOnly] in NativeArray<ushort> indices, ref NativeArray<int2> outline); // TypeDefIndex: 14363; 0x0000000180A70FB0-0x0000000180A70FC0
	
		internal static class GenerateUTessOutline_0000008E_BurstDirectCall // TypeDefIndex: 14364
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181C1C760-0x0000000181C1C7A0
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_0001b5c1); // 0x0000000181C1C7A0-0x0000000181C1C910
			private static IntPtr GetFunctionPointer(); // 0x0000000181C1C910-0x0000000181C1CA70
			public static int Invoke([IsReadOnly] in NativeArray<ushort> indices, ref NativeArray<int2> outline); // 0x0000000181C1CA70-0x0000000181C1CCA0
		}
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void GetOutlineEdgesFallback_0000008F_PostfixBurstDelegate([IsReadOnly] in NativeArray<ushort> indices, out NativeArray<int2> output); // TypeDefIndex: 14365; 0x0000000180A70FB0-0x0000000180A70FC0
	
		internal static class GetOutlineEdgesFallback_0000008F_BurstDirectCall // TypeDefIndex: 14366
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181C1CD50-0x0000000181C1CD90
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_0001b5cd); // 0x0000000181C1CD90-0x0000000181C1CF00
			private static IntPtr GetFunctionPointer(); // 0x0000000181C1CF00-0x0000000181C1D060
			public static void Invoke([IsReadOnly] in NativeArray<ushort> indices, out NativeArray<int2> output); // 0x0000000181C1D060-0x0000000181C1D260
		}
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void AddToEdgeMap_00000090_PostfixBurstDelegate(int x, int y, ref UnsafeHashMap<ulong, int2> edgeMap); // TypeDefIndex: 14367; 0x0000000180A72B30-0x0000000180A72B50
	
		internal static class AddToEdgeMap_00000090_BurstDirectCall // TypeDefIndex: 14368
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181C15F00-0x0000000181C15F40
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_0001b5db); // 0x0000000181C15F40-0x0000000181C160A0
			private static IntPtr GetFunctionPointer(); // 0x0000000181C160A0-0x0000000181C161F0
			public static void Invoke(int x, int y, ref UnsafeHashMap<ulong, int2> edgeMap); // 0x0000000181C161F0-0x0000000181C163E0
		}
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void SortEdges_00000091_PostfixBurstDelegate([IsReadOnly] in NativeArray<int2> unsortedEdges, out NativeArray<int2> sortedEdges); // TypeDefIndex: 14369; 0x0000000180A70FB0-0x0000000180A70FC0
	
		internal static class SortEdges_00000091_BurstDirectCall // TypeDefIndex: 14370
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181C1F940-0x0000000181C1F980
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_0001b5e8); // 0x0000000181C1F980-0x0000000181C1FAF0
			private static IntPtr GetFunctionPointer(); // 0x0000000181C1FAF0-0x0000000181C1FC50
			public static void Invoke([IsReadOnly] in NativeArray<int2> unsortedEdges, out NativeArray<int2> sortedEdges); // 0x0000000181C1F3E0-0x0000000181C1F5E0
		}
	
		// Constructors
		static MeshUtilities(); // 0x0000000181C1F5E0-0x0000000181C1F680
	
		// Methods
		public static NativeArray<int2> GetOutlineEdges([IsReadOnly] in NativeArray<ushort> indices); // 0x0000000181C1F030-0x0000000181C1F0A0
		public static NativeArray<int2> GetOutlineEdgesUTess([IsReadOnly] in NativeArray<ushort> indices); // 0x0000000181C1EF60-0x0000000181C1F030
		[BurstCompile]
		private static int GenerateUTessOutline([IsReadOnly] in NativeArray<ushort> indices, ref NativeArray<int2> outline); // 0x0000000181C1ED50-0x0000000181C1ED60
		[BurstCompile]
		public static void GetOutlineEdgesFallback([IsReadOnly] in NativeArray<ushort> indices, out NativeArray<int2> output); // 0x0000000181C1D060-0x0000000181C1D260
		[BurstCompile]
		private static void AddToEdgeMap(int x, int y, ref UnsafeHashMap<ulong, int2> edgeMap); // 0x0000000181C1ECE0-0x0000000181C1ECF0
		[BurstCompile]
		private static void SortEdges([IsReadOnly] in NativeArray<int2> unsortedEdges, out NativeArray<int2> sortedEdges); // 0x0000000181C1F3E0-0x0000000181C1F5E0
		[BurstCompile]
		[MonoPInvokeCallback(typeof(GenerateUTessOutline_0000008E_PostfixBurstDelegate))]
		internal static int GenerateUTessOutline_BurstManaged([IsReadOnly] in NativeArray<ushort> indices, ref NativeArray<int2> outline); // 0x0000000181C1ECF0-0x0000000181C1ED50
		[BurstCompile]
		[MonoPInvokeCallback(typeof(GetOutlineEdgesFallback_0000008F_PostfixBurstDelegate))]
		internal static void GetOutlineEdgesFallback_BurstManaged([IsReadOnly] in NativeArray<ushort> indices, out NativeArray<int2> output); // 0x0000000181C1ED60-0x0000000181C1EF60
		[BurstCompile]
		[MonoPInvokeCallback(typeof(AddToEdgeMap_00000090_PostfixBurstDelegate))]
		internal static void AddToEdgeMap_BurstManaged(int x, int y, ref UnsafeHashMap<ulong, int2> edgeMap); // 0x0000000181C1EC40-0x0000000181C1ECE0
		[BurstCompile]
		[MonoPInvokeCallback(typeof(SortEdges_00000091_PostfixBurstDelegate))]
		internal static void SortEdges_BurstManaged([IsReadOnly] in NativeArray<int2> unsortedEdges, out NativeArray<int2> sortedEdges); // 0x0000000181C1F0A0-0x0000000181C1F3E0
	}
}
