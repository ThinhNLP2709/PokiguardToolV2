/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.Scripting.APIUpdating;

// Image 51: UnityEngine.TerrainModule.dll - Assembly: UnityEngine.TerrainModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15533-15553

namespace UnityEngine.TerrainUtils
{
	[MovedFrom("UnityEngine.Experimental.TerrainAPI")]
	public static class TerrainUtility // TypeDefIndex: 15548
	{
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass2_0 // TypeDefIndex: 15549
		{
			// Fields
			public bool onlyAutoConnectedTerrains; // 0x10
	
			// Constructors
			public __c__DisplayClass2_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass2_1 // TypeDefIndex: 15550
		{
			// Fields
			public Terrain t; // 0x10
			public __c__DisplayClass2_0 CS___8__locals1; // 0x18
	
			// Constructors
			public __c__DisplayClass2_1(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _CollectTerrains_b__0(Terrain x); // 0x00000001822EE110-0x00000001822EE220
		}
	
		// Methods
		internal static bool ValidTerrainsExist(); // 0x00000001822ED9D0-0x00000001822EDA40
		internal static void ClearConnectivity(); // 0x00000001822ED590-0x00000001822ED6A0
		internal static Dictionary<int, TerrainMap> CollectTerrains(bool onlyAutoConnectedTerrains = true /* Metadata: 0x006AA0E7 */); // 0x00000001822ED6A0-0x00000001822ED9D0
		[RequiredByNativeCode]
		public static void AutoConnect(); // 0x00000001822ED1B0-0x00000001822ED590
	}
}
