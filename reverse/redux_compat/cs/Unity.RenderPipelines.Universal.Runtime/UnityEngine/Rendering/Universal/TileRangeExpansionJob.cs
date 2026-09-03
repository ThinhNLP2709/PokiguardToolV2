/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[BurstCompile(FloatMode = FloatMode.Fast, DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
	internal struct TileRangeExpansionJob : IJobFor // TypeDefIndex: 9800
	{
		// Fields
		[ReadOnly]
		public NativeArray<InclusiveRange> tileRanges; // 0x00
		[NativeDisableParallelForRestriction]
		public NativeArray<uint> tileMasks; // 0x10
		public int rangesPerItem; // 0x20
		public int itemsPerTile; // 0x24
		public int wordsPerTile; // 0x28
		public int2 tileResolution; // 0x2C
	
		// Methods
		public void Execute(int jobIndex); // 0x0000000181FEC8C0-0x0000000181FECAA0
	}
}
