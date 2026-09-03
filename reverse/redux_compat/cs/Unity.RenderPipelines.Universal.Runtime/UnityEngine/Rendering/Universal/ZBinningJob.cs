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
	internal struct ZBinningJob : IJobFor // TypeDefIndex: 9806
	{
		// Fields
		public const int batchSize = 128; // Metadata: 0x0069F0E2
		public const int headerLength = 2; // Metadata: 0x0069F0E4
		[NativeDisableParallelForRestriction]
		public NativeArray<uint> bins; // 0x00
		[ReadOnly]
		public NativeArray<float2> minMaxZs; // 0x10
		public float zBinScale; // 0x20
		public float zBinOffset; // 0x24
		public int binCount; // 0x28
		public int wordsPerTile; // 0x2C
		public int lightCount; // 0x30
		public int reflectionProbeCount; // 0x34
		public int batchCount; // 0x38
		public int viewCount; // 0x3C
		public bool isOrthographic; // 0x40
	
		// Methods
		private static uint EncodeHeader(uint min, uint max); // 0x0000000182019B40-0x0000000182019B50
		private static ValueTuple<uint, uint> DecodeHeader(uint zBin); // 0x0000000182019B10-0x0000000182019B40
		public void Execute(int jobIndex); // 0x0000000182019B50-0x0000000182019C80
		private void FillZBins(int binStart, int binEnd, int itemStart, int itemEnd, int headerIndex, int itemOffset, int binOffset); // 0x0000000182019C80-0x0000000182019E30
	}
}
