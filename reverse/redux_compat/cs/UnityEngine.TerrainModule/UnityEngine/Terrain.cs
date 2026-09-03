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
	[NativeClass("Terrain", PersistentTypeId = 218)]
	[NativeHeader("TerrainScriptingClasses.h")]
	[NativeHeader("Runtime/Interfaces/ITerrainManager.h")]
	[NativeHeader("Modules/Terrain/Public/Terrain.h")]
	[StaticAccessor("GetITerrainManager()", StaticAccessorType.Arrow)]
	[UsedByNativeCode]
	public sealed class Terrain : Behaviour // TypeDefIndex: 15536
	{
		// Properties
		public TerrainData terrainData { get; } // 0x00000001822EDD30-0x00000001822EDDC0 
		public bool allowAutoConnect { get; } // 0x00000001822EDBF0-0x00000001822EDC50 
		public int groupingID { get; } // 0x00000001822EDC90-0x00000001822EDCF0 
		[NativeProperty("ActiveTerrainsScriptingArray")]
		public static Terrain[] activeTerrains { get; } // 0x00000001822EDB80-0x00000001822EDBB0 
	
		// Constructors
		public Terrain(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		public void SetNeighbors(Terrain left, Terrain top, Terrain right, Terrain bottom); // 0x00000001822EDAB0-0x00000001822EDB80
		private static IntPtr get_terrainData_Injected(IntPtr _unity_self); // 0x00000001822EDCF0-0x00000001822EDD30
		private static bool get_allowAutoConnect_Injected(IntPtr _unity_self); // 0x00000001822EDBB0-0x00000001822EDBF0
		private static int get_groupingID_Injected(IntPtr _unity_self); // 0x00000001822EDC50-0x00000001822EDC90
		private static void SetNeighbors_Injected(IntPtr _unity_self, IntPtr left, IntPtr top, IntPtr right, IntPtr bottom); // 0x00000001822EDA40-0x00000001822EDAB0
	}
}
