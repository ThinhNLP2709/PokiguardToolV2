namespace System.Text.RegularExpressions;

[DebuggerDisplay("Count = {Count}")]
[DebuggerTypeProxy(typeof(System.Text.RegularExpressions.CollectionDebuggerProxy`1<System.Text.RegularExpressions.Capture>))]
[DefaultMember("Item")]
public class CaptureCollection
{
	private readonly Group _group; //Field offset: 0x10
	private readonly int _capcount; //Field offset: 0x18
	private Capture[] _captures; //Field offset: 0x20

}

