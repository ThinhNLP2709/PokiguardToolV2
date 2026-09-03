/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 51: UnityEngine.TerrainModule.dll - Assembly: UnityEngine.TerrainModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15533-15553

namespace UnityEngine.TerrainUtils
{
	public class TerrainMap // TypeDefIndex: 15546
	{
		// Fields
		private Vector3 m_patchSize; // 0x10
		private TerrainMapStatusCode m_errorCode; // 0x1C
		private Dictionary<TerrainTileCoord, Terrain> m_terrainTiles; // 0x20
	
		// Properties
		public Dictionary<TerrainTileCoord, Terrain> terrainTiles { get; } // 0x00000001802F8630-0x00000001802F8640 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass3_0 // TypeDefIndex: 15547
		{
			// Fields
			public int groupID; // 0x10
	
			// Constructors
			public __c__DisplayClass3_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _CreateFromPlacement_b__0(Terrain x); // 0x00000001822EE220-0x00000001822EE590
		}
	
		// Constructors
		public TerrainMap(); // 0x00000001822ED130-0x00000001822ED1B0
	
		// Methods
		public Terrain GetTerrain(int tileX, int tileZ); // 0x00000001822EC5B0-0x00000001822EC630
		public static TerrainMap CreateFromPlacement(Terrain originTerrain, Predicate<Terrain> filter = null, bool fullValidation = true /* Metadata: 0x006AA0E5 */); // 0x00000001822EC230-0x00000001822EC5B0
		public static TerrainMap CreateFromPlacement(Vector2 gridOrigin, Vector2 gridSize, Predicate<Terrain> filter = null, bool fullValidation = true /* Metadata: 0x006AA0E6 */); // 0x00000001822EBE70-0x00000001822EC230
		private void AddTerrainInternal(int x, int z, Terrain terrain); // 0x00000001822EBB70-0x00000001822EBE70
		private bool TryToAddTerrain(int tileX, int tileZ, Terrain terrain); // 0x00000001822EC630-0x00000001822EC710
		private void ValidateTerrain(int tileX, int tileZ); // 0x00000001822EC710-0x00000001822ED010
		private TerrainMapStatusCode Validate(); // 0x00000001822ED010-0x00000001822ED130
	}
}
