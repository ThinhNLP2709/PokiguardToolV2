namespace UnityEngine.UIElements;

public abstract class UxmlSerializedData
{
	[Flags]
	internal enum UxmlAttributeFlags
	{
		Ignore = 0,
		OverriddenInUxml = 1,
		DefaultValue = 2,
	}

	internal const string AttributeFlagSuffix = "_UxmlAttributeFlags"; //Field offset: 0x0
	private const UxmlAttributeFlags k_DefaultFlags = 1; //Field offset: 0x0
	private static UxmlAttributeFlags s_CurrentDeserializeFlags; //Field offset: 0x0
	[HideInInspector]
	[SerializeField]
	[UxmlIgnore]
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal int uxmlAssetId; //Field offset: 0x10

	private static UxmlSerializedData() { }

	protected UxmlSerializedData() { }

	public abstract object CreateInstance() { }

	public abstract void Deserialize(object obj) { }

}

