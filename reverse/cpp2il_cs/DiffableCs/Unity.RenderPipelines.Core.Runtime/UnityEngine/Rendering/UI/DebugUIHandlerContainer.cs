namespace UnityEngine.Rendering.UI;

public class DebugUIHandlerContainer : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public DebugUIHandlerWidget widget; //Field offset: 0x10

		public <>c__DisplayClass3_0() { }

		internal bool <IsDirectChild>b__0(DebugUIHandlerWidget x) { }

	}

	[SerializeField]
	public RectTransform contentHolder; //Field offset: 0x20

	public DebugUIHandlerContainer() { }

	private List<DebugUIHandlerWidget> GetActiveChildren() { }

	internal DebugUIHandlerWidget GetFirstItem() { }

	internal DebugUIHandlerWidget GetLastItem() { }

	internal bool IsDirectChild(DebugUIHandlerWidget widget) { }

}

