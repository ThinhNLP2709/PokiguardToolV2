namespace UnityEngine.Rendering;

internal class ProbeVolumeDebugColorPreferences
{
	internal static Func<Color> GetDetailSubdivisionColor; //Field offset: 0x0
	internal static Func<Color> GetMediumSubdivisionColor; //Field offset: 0x8
	internal static Func<Color> GetLowSubdivisionColor; //Field offset: 0x10
	internal static Func<Color> GetVeryLowSubdivisionColor; //Field offset: 0x18
	internal static Func<Color> GetSparseSubdivisionColor; //Field offset: 0x20
	internal static Func<Color> GetSparsestSubdivisionColor; //Field offset: 0x28
	internal static Color s_DetailSubdivision; //Field offset: 0x30
	internal static Color s_MediumSubdivision; //Field offset: 0x40
	internal static Color s_LowSubdivision; //Field offset: 0x50
	internal static Color s_VeryLowSubdivision; //Field offset: 0x60
	internal static Color s_SparseSubdivision; //Field offset: 0x70
	internal static Color s_SparsestSubdivision; //Field offset: 0x80

	private static ProbeVolumeDebugColorPreferences() { }

	public ProbeVolumeDebugColorPreferences() { }

}

