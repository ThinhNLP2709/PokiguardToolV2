/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public static class SweepLineRectUtils // TypeDefIndex: 5788
	{
		// Fields
		private static Vector4[] s_EventsBuffer; // 0x00
		private static Vector2[] s_ActiveBuffer; // 0x08
	
		// Nested types
		private struct EventComparer : IComparer<Vector4> // TypeDefIndex: 5789
		{
			// Methods
			public int Compare(Vector4 a, Vector4 b); // 0x0000000181EBF370-0x0000000181EBF3B0
		}
	
		private struct ActiveComparer : IComparer<Vector2> // TypeDefIndex: 5790
		{
			// Methods
			public int Compare(Vector2 a, Vector2 b); // 0x0000000181EBC860-0x0000000181EBC890
		}
	
		// Constructors
		static SweepLineRectUtils(); // 0x0000000181ECC6B0-0x0000000181ECC770
	
		// Methods
		public static float CalculateRectUnionArea(List<Rect> rects); // 0x0000000181ECC090-0x0000000181ECC480
		private static float MergeLengthY(Vector2[] activeBuffer, int count); // 0x0000000181ECC5F0-0x0000000181ECC6B0
		private static float CalculateRectUnionArea(Vector4[] eventsBuffer, Vector2[] activeBuffer, int eventCount); // 0x0000000181ECBC70-0x0000000181ECC090
		private static void InsertEvents([IsReadOnly] in Rect rect, Vector4[] eventsBuffer, ref int eventCount); // 0x0000000181ECC480-0x0000000181ECC5F0
	}
}
