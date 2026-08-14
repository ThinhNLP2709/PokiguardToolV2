namespace UnityEngine.TextCore.Text;

[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
internal class TextHandlePermanentCache
{
	internal LinkedList<TextInfo> s_TextInfoPool; //Field offset: 0x10
	private object syncRoot; //Field offset: 0x18

	public TextHandlePermanentCache() { }

	public override void AddTextInfoToCache(TextHandle textHandle) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	public void RemoveTextInfoFromCache(TextHandle textHandle) { }

}

