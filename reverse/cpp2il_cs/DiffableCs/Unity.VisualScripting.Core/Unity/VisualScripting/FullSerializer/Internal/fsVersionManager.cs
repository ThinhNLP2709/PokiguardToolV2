namespace Unity.VisualScripting.FullSerializer.Internal;

public static class fsVersionManager
{
	private static readonly Dictionary<Type, fsOption`1<fsVersionedType>> _cache; //Field offset: 0x0

	private static fsVersionManager() { }

	public static fsOption<fsVersionedType> GetVersionedType(Type type) { }

	public static fsResult GetVersionImportPath(string currentVersion, fsVersionedType targetVersion, out List<fsVersionedType>& path) { }

	private static bool GetVersionImportPathRecursive(List<fsVersionedType> path, string currentVersion, fsVersionedType current) { }

	private static void VerifyConstructors(fsVersionedType type) { }

	private static void VerifyUniqueVersionStrings(fsVersionedType type) { }

}

