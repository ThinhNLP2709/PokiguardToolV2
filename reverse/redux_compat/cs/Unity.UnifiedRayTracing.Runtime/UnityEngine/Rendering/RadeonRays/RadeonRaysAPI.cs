/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.RadeonRays
{
	internal class RadeonRaysAPI : IDisposable // TypeDefIndex: 14259
	{
		// Fields
		private readonly HlbvhBuilder buildBvh; // 0x10
		private readonly HlbvhTopLevelBuilder buildTopLevelBvh; // 0x18
		private readonly RestructureBvh restructureBvh; // 0x20
		public const GraphicsBuffer.Target BufferTarget = GraphicsBuffer.Target.Structured; // Metadata: 0x006A95FC
	
		// Constructors
		public RadeonRaysAPI(RadeonRaysShaders shaders); // 0x0000000182120D20-0x0000000182121140
	
		// Methods
		public void Dispose(); // 0x0000000182120650-0x0000000182120680
		public static int BvhInternalNodeSizeInDwords(); // 0x0000000182120170-0x00000001821201C0
		public static int BvhInternalNodeSizeInBytes(); // 0x0000000182120120-0x0000000182120170
		public static int BvhLeafNodeSizeInBytes(); // 0x00000001821201C0-0x0000000182120210
		public static int BvhLeafNodeSizeInDwords(); // 0x0000000182120210-0x0000000182120260
		public void BuildMeshAccelStruct(CommandBuffer cmd, MeshBuildInfo buildInfo, BuildFlags buildFlags, GraphicsBuffer scratchBuffer, [IsReadOnly] in BottomLevelAccelStruct result); // 0x000000018211FAE0-0x000000018211FC60
		public void BuildProceduralAccelStruct(CommandBuffer cmd, ProceduralBuildInfo buildInfo, BuildFlags buildFlags, GraphicsBuffer scratchBuffer, [IsReadOnly] in BottomLevelAccelStruct result); // 0x000000018211FC60-0x000000018211FD40
		public MeshBuildMemoryRequirements GetBlasBuildMemoryRequirements(uint primCount, BuildFlags buildFlags); // 0x0000000182120680-0x0000000182120780
		public MeshBuildMemoryRequirements GetMeshBuildMemoryRequirements(MeshBuildInfo buildInfo, BuildFlags buildFlags); // 0x0000000182120780-0x00000001821207C0
		public MeshBuildMemoryRequirements GetProceduralBuildMemoryRequirements(ProceduralBuildInfo buildInfo, BuildFlags buildFlags); // 0x00000001821207C0-0x0000000182120800
		public TopLevelAccelStruct BuildSceneAccelStruct(CommandBuffer cmd, GraphicsBuffer meshAccelStructsBuffer, Instance[] instances, GraphicsBuffer scratchBuffer); // 0x000000018211FD40-0x0000000182120120
		public TopLevelAccelStruct CreateSceneAccelStructBuffers(GraphicsBuffer meshAccelStructsBuffer, uint tlasSizeInDwords, Instance[] instances); // 0x0000000182120260-0x0000000182120650
		public SceneBuildMemoryRequirements GetSceneBuildMemoryRequirements(uint instanceCount); // 0x0000000182120800-0x0000000182120870
		public SceneMemoryRequirements GetSceneMemoryRequirements(MeshBuildInfo[] buildInfos, BuildFlags buildFlags); // 0x0000000182120870-0x0000000182120D10
		public static ulong GetTraceMemoryRequirements(uint rayCount); // 0x0000000182120D10-0x0000000182120D20
	}
}
