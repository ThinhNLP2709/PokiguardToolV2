namespace UnityEngine.UIElements;

public class MeshWriteData
{
	internal NativeSlice<Vertex> m_Vertices; //Field offset: 0x10
	internal NativeSlice<UInt16> m_Indices; //Field offset: 0x20
	internal int currentIndex; //Field offset: 0x30
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal int currentVertex; //Field offset: 0x34

	internal MeshWriteData() { }

}

