namespace UnityEngine.TextCore.Text;

[NativeHeader("Modules/TextCoreTextEngine/Native/ATGMeshInfo.h")]
[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
internal struct ATGMeshInfo
{
	public NativeTextElementInfo[] textElementInfos; //Field offset: 0x0
	public int fontAssetId; //Field offset: 0x8
	public int textElementCount; //Field offset: 0xC
	[Ignore]
	public FontAsset fontAsset; //Field offset: 0x10

}

