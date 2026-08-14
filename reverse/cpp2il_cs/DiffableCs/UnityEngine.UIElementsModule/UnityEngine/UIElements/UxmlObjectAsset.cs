namespace UnityEngine.UIElements;

[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
internal class UxmlObjectAsset : UxmlAsset
{
	[SerializeField]
	private bool m_IsField; //Field offset: 0x48

	public bool isField
	{
		 get { } //Length: 5
	}

	public UxmlObjectAsset(string fullTypeNameOrFieldName, bool isField, UxmlNamespaceDefinition xmlNamespace = null) { }

	public bool get_isField() { }

	public virtual string ToString() { }

}

