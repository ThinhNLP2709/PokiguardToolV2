namespace UnityEngine.UIElements;

[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
internal class VisualElementFactoryRegistry
{
	private static Dictionary<String, List`1<IUxmlFactory>> s_Factories; //Field offset: 0x0
	private static Dictionary<String, List`1<IUxmlFactory>> s_MovedTypesFactories; //Field offset: 0x8

	internal static Dictionary<String, List`1<IUxmlFactory>> factories
	{
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
		internal get { } //Length: 286
	}

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal static Dictionary<String, List`1<IUxmlFactory>> get_factories() { }

	internal static string GetMovedUIControlTypeName(Type type, MovedFromAttribute attr) { }

	private static void RegisterEngineFactories() { }

	protected static void RegisterFactory(IUxmlFactory factory) { }

	internal static void RegisterUserFactories() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal static bool TryGetValue(string fullTypeName, out List<IUxmlFactory>& factoryList) { }

}

