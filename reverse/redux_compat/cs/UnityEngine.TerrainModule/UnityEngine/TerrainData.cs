/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 51: UnityEngine.TerrainModule.dll - Assembly: UnityEngine.TerrainModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15533-15553

namespace UnityEngine
{
	[NativeClass("TerrainData", PersistentTypeId = 156)]
	[NativeHeader("TerrainScriptingClasses.h")]
	[NativeHeader("Modules/Terrain/Public/TerrainDataScriptingInterface.h")]
	[UsedByNativeCode]
	public sealed class TerrainData : Object // TypeDefIndex: 15542
	{
		// Fields
		internal static readonly int k_MaximumResolution; // 0x00
		internal static readonly int k_MinimumDetailResolutionPerPatch; // 0x04
		internal static readonly int k_MaximumDetailResolutionPerPatch; // 0x08
		internal static readonly int k_MaximumDetailPatchCount; // 0x0C
		internal static readonly int k_MinimumAlphamapResolution; // 0x10
		internal static readonly int k_MaximumAlphamapResolution; // 0x14
		internal static readonly int k_MinimumBaseMapResolution; // 0x18
		internal static readonly int k_MaximumBaseMapResolution; // 0x1C
	
		// Properties
		public RenderTexture heightmapTexture { [NativeName("GetHeightmap().GetHeightmapTexture")] get; } // 0x00000001822EB740-0x00000001822EB7F0 
		public int heightmapResolution { get; } // 0x00000001822EB570-0x00000001822EB600 
		private int internalHeightmapResolution { [NativeName("GetHeightmap().GetResolution")] get; } // 0x00000001822EB570-0x00000001822EB600 
		public Vector3 heightmapScale { [NativeName("GetHeightmap().GetScale")] get; } // 0x00000001822EB650-0x00000001822EB700 
		public int holesResolution { get; } // 0x00000001822EB7F0-0x00000001822EB880 
		public Vector3 size { [NativeName("GetHeightmap().GetSize")] get; } // 0x00000001822EB910-0x00000001822EB9C0 
		public TreeInstance[] treeInstances { get; } // 0x00000001822EB9C0-0x00000001822EB9D0 
		public TreePrototype[] treePrototypes { [FreeFunction("TerrainDataScriptingInterface::GetTreePrototypes", HasExplicitThis = true)] get; } // 0x00000001822EBA10-0x00000001822EBAA0 
		internal Terrain[] users { get; } // 0x00000001822EBAE0-0x00000001822EBB70 
	
		// Nested types
		private enum BoundaryValueType // TypeDefIndex: 15543
		{
			MaxHeightmapRes = 0,
			MinDetailResPerPatch = 1,
			MaxDetailResPerPatch = 2,
			MaxDetailPatchCount = 3,
			MaxCoveragePerRes = 4,
			MinAlphamapRes = 5,
			MaxAlphamapRes = 6,
			MinBaseMapRes = 7,
			MaxBaseMapRes = 8
		}
	
		// Constructors
		static TerrainData(); // 0x00000001822EB390-0x00000001822EB570
	
		// Methods
		[NativeMethod(IsThreadSafe = true)]
		[StaticAccessor("TerrainDataScriptingInterface", StaticAccessorType.DoubleColon)]
		private static int GetBoundaryValue(BoundaryValueType type); // 0x00000001822EAA70-0x00000001822EAAB0
		public float[,] GetHeights(int xBase, int yBase, int width, int height); // 0x00000001822EAAB0-0x00000001822EACD0
		[FreeFunction("TerrainDataScriptingInterface::GetHeights", HasExplicitThis = true)]
		private void Internal_GetHeights(int xBase, int yBase, int width, int height, float[,] heights); // 0x00000001822EAF50-0x00000001822EB080
		public bool[,] GetHoles(int xBase, int yBase, int width, int height); // 0x00000001822EACD0-0x00000001822EAEF0
		[FreeFunction("TerrainDataScriptingInterface::GetHoles", HasExplicitThis = true)]
		private void Internal_GetHoles(int xBase, int yBase, int width, int height, bool[,] holes); // 0x00000001822EB0E0-0x00000001822EB210
		[NativeName("GetTreeDatabase().GetInstances")]
		private TreeInstance[] Internal_GetTreeInstances(); // 0x00000001822EB260-0x00000001822EB390
		[NativeName("GetSplatDatabase().GetAlphamapResolution")]
		[RequiredByNativeCode]
		internal float GetAlphamapResolutionInternal(); // 0x00000001822EA9E0-0x00000001822EAA70
		private static IntPtr get_heightmapTexture_Injected(IntPtr _unity_self); // 0x00000001822EB700-0x00000001822EB740
		private static int get_internalHeightmapResolution_Injected(IntPtr _unity_self); // 0x00000001822EB880-0x00000001822EB8C0
		private static void get_heightmapScale_Injected(IntPtr _unity_self, ); // 0x00000001822EB600-0x00000001822EB650
		private static void get_size_Injected(IntPtr _unity_self, ); // 0x00000001822EB8C0-0x00000001822EB910
		private static void Internal_GetHeights_Injected(IntPtr _unity_self, int xBase, int yBase, int width, int height, ref ManagedSpanWrapper heights); // 0x00000001822EAEF0-0x00000001822EAF50
		private static void Internal_GetHoles_Injected(IntPtr _unity_self, int xBase, int yBase, int width, int height, ref ManagedSpanWrapper holes); // 0x00000001822EB080-0x00000001822EB0E0
		private static void Internal_GetTreeInstances_Injected(IntPtr _unity_self, ); // 0x00000001822EB210-0x00000001822EB260
		private static TreePrototype[] get_treePrototypes_Injected(IntPtr _unity_self); // 0x00000001822EB9D0-0x00000001822EBA10
		private static float GetAlphamapResolutionInternal_Injected(IntPtr _unity_self); // 0x00000001822EA9A0-0x00000001822EA9E0
		private static Terrain[] get_users_Injected(IntPtr _unity_self); // 0x00000001822EBAA0-0x00000001822EBAE0
	}
}
