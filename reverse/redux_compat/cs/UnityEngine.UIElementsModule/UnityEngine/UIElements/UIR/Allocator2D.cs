/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class Allocator2D // TypeDefIndex: 5011
	{
		// Fields
		private readonly Vector2Int m_MinSize; // 0x10
		private readonly Vector2Int m_MaxSize; // 0x18
		private readonly Vector2Int m_MaxAllocSize; // 0x20
		private readonly int m_RowHeightBias; // 0x28
		private readonly Row[] m_Rows; // 0x30
		private readonly List<Area> m_Areas; // 0x38
	
		// Nested types
		public class Area // TypeDefIndex: 5012
		{
			// Fields
			public RectInt rect; // 0x10
			public BestFitAllocator allocator; // 0x20
	
			// Constructors
			public Area(RectInt rect); // 0x00000001823ECEF0-0x00000001823ECF90
		}
	
		public class Row : LinkedPoolItem<Row> // TypeDefIndex: 5013
		{
			// Fields
			public RectInt rect; // 0x18
			public Area area; // 0x28
			public BestFitAllocator allocator; // 0x30
			public Alloc alloc; // 0x38
			public Row next; // 0x50
			[NoAutoStaticsCleanup]
			public static readonly LinkedPool<Row> pool; // 0x00
	
			// Constructors
			public Row(); // 0x00000001802F4070-0x00000001802F4080
			static Row(); // 0x00000001823F9310-0x00000001823F9420
	
			// Methods
			private static Row Create(); // 0x00000001823F9250-0x00000001823F92A0
			private static void Reset(Row row); // 0x00000001823F92A0-0x00000001823F9310
		}
	
		public struct Alloc2D // TypeDefIndex: 5014
		{
			// Fields
			public RectInt rect; // 0x00
			public Row row; // 0x10
			public Alloc alloc; // 0x18
	
			// Constructors
			public Alloc2D(Row row, Alloc alloc, int width, int height); // 0x00000001823EBE90-0x00000001823EBF80
		}
	
		// Constructors
		public Allocator2D(Vector2Int minSize, Vector2Int maxSize, int rowHeightBias); // 0x00000001823ECC20-0x00000001823ECEF0
	
		// Methods
		public bool TryAllocate(int width, int height, out Alloc2D alloc2D); // 0x00000001823EC5D0-0x00000001823ECC20
		public void Free(Alloc2D alloc2D); // 0x00000001823EC350-0x00000001823EC5D0
		private static void BuildAreas(List<Area> areas, Vector2Int minSize, Vector2Int maxSize); // 0x00000001823EBF80-0x00000001823EC1D0
		private static Vector2Int ComputeMaxAllocSize(List<Area> areas, int rowHeightBias); // 0x00000001823EC240-0x00000001823EC350
		private static Row[] BuildRowArray(int maxRowHeight, int rowHeightBias); // 0x00000001823EC1D0-0x00000001823EC240
	}
}
