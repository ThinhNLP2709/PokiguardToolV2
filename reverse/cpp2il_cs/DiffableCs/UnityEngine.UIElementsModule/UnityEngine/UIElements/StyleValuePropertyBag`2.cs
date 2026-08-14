namespace UnityEngine.UIElements;

internal class StyleValuePropertyBag : ContainerPropertyBag<TContainer>
{
	private class KeywordProperty : Property<TContainer, StyleKeyword>
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private readonly string <Name>k__BackingField; //Field offset: 0x0
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private readonly bool <IsReadOnly>k__BackingField; //Field offset: 0x0

		public virtual bool IsReadOnly
		{
			[CompilerGenerated]
			 get { } //Length: 5
		}

		public virtual string Name
		{
			[CompilerGenerated]
			 get { } //Length: 5
		}

		public KeywordProperty() { }

		[CompilerGenerated]
		public virtual bool get_IsReadOnly() { }

		[CompilerGenerated]
		public virtual string get_Name() { }

		public virtual StyleKeyword GetValue(ref TContainer container) { }

		public virtual void SetValue(ref TContainer container, StyleKeyword value) { }

	}

	private class ValueProperty : Property<TContainer, TValue>
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private readonly string <Name>k__BackingField; //Field offset: 0x0
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private readonly bool <IsReadOnly>k__BackingField; //Field offset: 0x0

		public virtual bool IsReadOnly
		{
			[CompilerGenerated]
			 get { } //Length: 5
		}

		public virtual string Name
		{
			[CompilerGenerated]
			 get { } //Length: 5
		}

		public ValueProperty() { }

		[CompilerGenerated]
		public virtual bool get_IsReadOnly() { }

		[CompilerGenerated]
		public virtual string get_Name() { }

		public virtual TValue GetValue(ref TContainer container) { }

		public virtual void SetValue(ref TContainer container, TValue value) { }

	}


	public StyleValuePropertyBag`2() { }

}

