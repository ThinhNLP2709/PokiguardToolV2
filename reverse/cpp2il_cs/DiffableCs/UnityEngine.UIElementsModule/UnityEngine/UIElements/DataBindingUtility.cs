namespace UnityEngine.UIElements;

[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
internal static class DataBindingUtility
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal TypePathVisitor <.cctor>b__23_0() { }

		internal void <.cctor>b__23_1(TypePathVisitor v) { }

		internal AutoCompletePathVisitor <.cctor>b__23_2() { }

		internal void <.cctor>b__23_3(AutoCompletePathVisitor v) { }

	}

	private static readonly ObjectPool<TypePathVisitor> k_TypeVisitors; //Field offset: 0x0
	private static readonly ObjectPool<AutoCompletePathVisitor> k_AutoCompleteVisitors; //Field offset: 0x8
	private static readonly Regex s_ReplaceIndices; //Field offset: 0x10

	private static DataBindingUtility() { }

	public static bool TryGetBinding(VisualElement element, in BindingId bindingId, out BindingInfo bindingInfo) { }

}

