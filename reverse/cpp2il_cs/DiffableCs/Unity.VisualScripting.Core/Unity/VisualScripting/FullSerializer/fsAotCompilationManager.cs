namespace Unity.VisualScripting.FullSerializer;

public class fsAotCompilationManager
{
	private struct AotCompilation
	{
		public Type Type; //Field offset: 0x0
		public fsMetaProperty[] Members; //Field offset: 0x8
		public bool IsConstructorPublic; //Field offset: 0x10

	}

	private static Dictionary<Type, String> _computedAotCompilations; //Field offset: 0x0
	private static List<AotCompilation> _uncomputedAotCompilations; //Field offset: 0x8

	public static Dictionary<Type, String> AvailableAotCompilations
	{
		 get { } //Length: 412
	}

	private static fsAotCompilationManager() { }

	public fsAotCompilationManager() { }

	public static void AddAotCompilation(Type type, fsMetaProperty[] members, bool isConstructorPublic) { }

	private static string GenerateDirectConverterForTypeInCSharp(Type type, fsMetaProperty[] members, bool isConstructorPublic) { }

	public static Dictionary<Type, String> get_AvailableAotCompilations() { }

	private static string GetConverterString(fsMetaProperty member) { }

	public static bool TryToPerformAotCompilation(fsConfig config, Type type, out string aotCompiledClassInCSharp) { }

}

