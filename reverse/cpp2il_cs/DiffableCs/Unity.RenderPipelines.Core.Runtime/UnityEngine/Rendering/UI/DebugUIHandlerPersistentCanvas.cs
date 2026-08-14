namespace UnityEngine.Rendering.UI;

internal class DebugUIHandlerPersistentCanvas : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public Value widget; //Field offset: 0x10

		public <>c__DisplayClass3_0() { }

		internal bool <Toggle>b__0(DebugUIHandlerValue x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public ValueTuple widget; //Field offset: 0x10

		public <>c__DisplayClass5_0() { }

		internal bool <Toggle>b__0(ValueTuple x) { }

	}

	public RectTransform panel; //Field offset: 0x20
	public RectTransform valuePrefab; //Field offset: 0x28
	private List<DebugUIHandlerValue> m_Items; //Field offset: 0x30
	private List<ValueTuple> m_ValueTupleWidgets; //Field offset: 0x38

	public DebugUIHandlerPersistentCanvas() { }

	internal void Clear() { }

	internal bool IsEmpty() { }

	internal void Toggle(Value widget, string displayName = null) { }

	internal void Toggle(ValueTuple widget, Nullable<Int32> forceTupleIndex = null) { }

}

