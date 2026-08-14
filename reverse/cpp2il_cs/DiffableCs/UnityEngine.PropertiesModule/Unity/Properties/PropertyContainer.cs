namespace Unity.Properties;

public static class PropertyContainer
{
	private class GetPropertyVisitor : PathVisitor
	{
		[CompilerGenerated]
		private sealed class <>c
		{
			public static readonly <>c <>9; //Field offset: 0x0

			private static <>c() { }

			public <>c() { }

			internal GetPropertyVisitor <.cctor>b__5_0() { }

			internal void <.cctor>b__5_1(GetPropertyVisitor v) { }

		}

		public static readonly ObjectPool<GetPropertyVisitor> Pool; //Field offset: 0x0
		public IProperty Property; //Field offset: 0xB8

		private static GetPropertyVisitor() { }

		public GetPropertyVisitor() { }

		public virtual void Reset() { }

		protected virtual void VisitPath(Property<TContainer, TValue> property, ref TContainer container, ref TValue value) { }

	}

	private class GetValueVisitor : PathVisitor
	{
		[CompilerGenerated]
		private sealed class <>c
		{
			public static readonly <>c<TSrcValue> <>9; //Field offset: 0x0

			private static <>c() { }

			public <>c() { }

			internal GetValueVisitor<TSrcValue> <.cctor>b__5_0() { }

			internal void <.cctor>b__5_1(GetValueVisitor<TSrcValue> v) { }

		}

		public static readonly ObjectPool<GetValueVisitor`1<TSrcValue>> Pool; //Field offset: 0x0
		public TSrcValue Value; //Field offset: 0x0

		private static GetValueVisitor`1() { }

		public GetValueVisitor`1() { }

		public virtual void Reset() { }

		protected virtual void VisitPath(Property<TContainer, TValue> property, ref TContainer container, ref TValue value) { }

	}


	public static void Accept(IPropertyBagVisitor visitor, ref TContainer container, VisitParameters parameters = null) { }

	public static bool TryAccept(IPropertyBagVisitor visitor, ref TContainer container, VisitParameters parameters = null) { }

	public static bool TryAccept(IPropertyBagVisitor visitor, ref TContainer container, out VisitReturnCode returnCode, VisitParameters parameters = null) { }

	public static bool TryGetProperty(ref TContainer container, in PropertyPath path, out IProperty property) { }

	public static bool TryGetProperty(ref TContainer container, in PropertyPath path, out IProperty property, out VisitReturnCode returnCode) { }

	public static bool TryGetValue(ref TContainer container, string name, out TValue value) { }

	public static bool TryGetValue(ref TContainer container, in PropertyPath path, out TValue value, out VisitReturnCode returnCode) { }

}

