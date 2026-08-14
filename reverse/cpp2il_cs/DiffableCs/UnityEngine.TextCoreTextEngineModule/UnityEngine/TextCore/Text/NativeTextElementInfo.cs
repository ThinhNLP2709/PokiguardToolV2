namespace UnityEngine.TextCore.Text;

[NativeHeader("Modules/TextCoreTextEngine/Native/TextElementInfo.h")]
[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule", "UnityEngine.IMGUIModule"})]
internal struct NativeTextElementInfo
{
	public int glyphID; //Field offset: 0x0
	public TextCoreVertex bottomLeft; //Field offset: 0x4
	public TextCoreVertex topLeft; //Field offset: 0x24
	public TextCoreVertex topRight; //Field offset: 0x44
	public TextCoreVertex bottomRight; //Field offset: 0x64

}

