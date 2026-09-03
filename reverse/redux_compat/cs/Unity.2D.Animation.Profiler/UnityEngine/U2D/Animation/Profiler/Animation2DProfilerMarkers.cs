/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Profiling;

// Image 82: Unity.2D.Animation.Profiler.dll - Assembly: Unity.2D.Animation.Profiler, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15953-15956

namespace UnityEngine.U2D.Animation.Profiler
{
	internal static class Animation2DProfilerMarkers // TypeDefIndex: 15954
	{
		// Fields
		public static readonly Guid k_Animation2DProfilerProjectId; // 0x00
		public const string k_SpriteSkinCPUProcessedProfilerCounterName = "SpriteSkin Processed (CPU)"; // Metadata: 0x006AA399
		public const string k_SpriteSkinCPUVertexProcessedProfilerCounterName = "Vertices Processed (CPU)"; // Metadata: 0x006AA3B4
		public const string k_SpriteSkinGPUProcessedProfilerCounterName = "SpriteSkin Processed (GPU)"; // Metadata: 0x006AA3CD
		public const string k_SpriteSkinGPUVertexProcessedProfilerCounterName = "Vertices Processed (GPU)"; // Metadata: 0x006AA3E8
		public const string k_SpriteSkinBoneTransformedProfilerCounterName = "Bones Transformed"; // Metadata: 0x006AA401
		public static readonly ProfilerCounterValue<int> s_SpriteSkinCPUProcessed; // 0x10
		public static readonly ProfilerCounterValue<int> s_SpriteSkinCPUVertexProcessed; // 0x11
		public static readonly ProfilerCounterValue<int> s_SpriteSkinGPUProcessed; // 0x12
		public static readonly ProfilerCounterValue<int> s_SpriteSkinGPUVertexProcessed; // 0x13
		public static readonly ProfilerCounterValue<int> s_SpriteSkinBoneTransformed; // 0x14
		public const int k_SpriteSkinProfilerFrameMetaDataTag = 0; // Metadata: 0x006AA413
		public const string k_CacheCurrentSpriteProfilerMarkerName = "SpriteSkin.CacheCurrentSprite"; // Metadata: 0x006AA414
		public const string k_CacheHierarchyProfilerMarkerName = "SpriteSkin.CacheHierarchy"; // Metadata: 0x006AA432
		public const string k_GetSpriteBonesTransformFromGuidProfilerMarkerName = "SpriteSkin.GetSpriteBoneTransformsFromGuid"; // Metadata: 0x006AA44C
		public const string k_GetSpriteBonesTransformFromPathProfilerMarkerName = "SpriteSkin.GetSpriteBoneTransformsFromPath"; // Metadata: 0x006AA477
		public const string k_DeformationManagerLateUpdateProfilerMarkerName = "DeformationManager.LateUpdate"; // Metadata: 0x006AA4A2
		public static readonly ProfilerMarker cacheCurrentSpriteProfilerMarker; // 0x18
		public static readonly ProfilerMarker cacheHierarchyProfilerMarker; // 0x20
		public static readonly ProfilerMarker getSpriteBonesTransformFromGuidProfilerMarker; // 0x28
		public static readonly ProfilerMarker getSpriteBonesTransformFromPathProfilerMarker; // 0x30
		public static readonly ProfilerMarker deformationManagerLateUpdateProfilerMarker; // 0x38
	
		// Constructors
		static Animation2DProfilerMarkers(); // 0x0000000181C15360-0x0000000181C155B0
	}
}
