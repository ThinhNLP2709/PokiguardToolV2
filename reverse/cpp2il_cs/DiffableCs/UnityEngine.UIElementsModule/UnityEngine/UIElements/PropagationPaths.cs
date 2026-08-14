namespace UnityEngine.UIElements;

internal class PropagationPaths : IDisposable
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal PropagationPaths <.cctor>b__8_0() { }

	}

	private static readonly ObjectPool<PropagationPaths> s_Pool; //Field offset: 0x0
	public readonly List<VisualElement> trickleDownPath; //Field offset: 0x10
	public readonly List<VisualElement> bubbleUpPath; //Field offset: 0x18

	private static PropagationPaths() { }

	public PropagationPaths() { }

	[NotNull]
	public static PropagationPaths Build(VisualElement elem, EventBase evt, int eventCategories) { }

	public override void Dispose() { }

}

