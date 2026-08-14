namespace UnityEngine;

[NativeHeader("TerrainScriptingClasses.h")]
[NativeHeader("Runtime/Interfaces/ITerrainManager.h")]
[NativeHeader("Modules/Terrain/Public/Terrain.h")]
[StaticAccessor("GetITerrainManager()", StaticAccessorType::Arrow (1))]
[UsedByNativeCode]
public sealed class Terrain : Behaviour
{

	[NativeProperty("ActiveTerrainsScriptingArray")]
	public static Terrain[] activeTerrains
	{
		 get { } //Length: 42
	}

	public bool allowAutoConnect
	{
		 get { } //Length: 118
	}

	public int groupingID
	{
		 get { } //Length: 118
	}

	public TerrainData terrainData
	{
		 get { } //Length: 309
	}

	public Terrain() { }

	public static Terrain[] get_activeTerrains() { }

	public bool get_allowAutoConnect() { }

	private static bool get_allowAutoConnect_Injected(IntPtr _unity_self) { }

	public int get_groupingID() { }

	private static int get_groupingID_Injected(IntPtr _unity_self) { }

	public TerrainData get_terrainData() { }

	private static IntPtr get_terrainData_Injected(IntPtr _unity_self) { }

	public void SetNeighbors(Terrain left, Terrain top, Terrain right, Terrain bottom) { }

	private static void SetNeighbors_Injected(IntPtr _unity_self, IntPtr left, IntPtr top, IntPtr right, IntPtr bottom) { }

}

