namespace UnityEngine.UIElements;

[Obsolete("UxmlObjectFactoryRegistry is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
internal class UxmlObjectFactoryRegistry
{
	private static Dictionary<String, List`1<IBaseUxmlObjectFactory>> s_Factories; //Field offset: 0x0

	internal static Dictionary<String, List`1<IBaseUxmlObjectFactory>> factories
	{
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
		internal get { } //Length: 191
	}

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal static Dictionary<String, List`1<IBaseUxmlObjectFactory>> get_factories() { }

	private static void RegisterEngineFactories() { }

	protected static void RegisterFactory(IBaseUxmlObjectFactory factory) { }

	private static void RegisterUserFactories() { }

}

