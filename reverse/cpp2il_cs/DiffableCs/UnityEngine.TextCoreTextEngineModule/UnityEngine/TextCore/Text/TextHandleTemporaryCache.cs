namespace UnityEngine.TextCore.Text;

[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
internal class TextHandleTemporaryCache
{
	internal const int s_MinFramesInCache = 2; //Field offset: 0x0
	internal LinkedList<TextInfo> s_TextInfoPool; //Field offset: 0x10
	internal int currentFrame; //Field offset: 0x18
	private object syncRoot; //Field offset: 0x20

	public TextHandleTemporaryCache() { }

	public void AddTextInfoToCache(TextHandle textHandle, int hashCode) { }

	public void ClearTemporaryCache() { }

	private void RecycleTextInfoFromCache(TextHandle textHandle) { }

	private void RefreshCaching(TextHandle textHandle) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	public override void RemoveTextInfoFromCache(TextHandle textHandle) { }

	public void UpdateCurrentFrame() { }

}

