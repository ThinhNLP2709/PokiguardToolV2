namespace Unity.Properties;

public class DelegateProperty : Property<TContainer, TValue>
{
	private readonly PropertyGetter<TContainer, TValue> m_Getter; //Field offset: 0x0
	private readonly PropertySetter<TContainer, TValue> m_Setter; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly string <Name>k__BackingField; //Field offset: 0x0

	public virtual bool IsReadOnly
	{
		 get { } //Length: 9
	}

	public virtual string Name
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public DelegateProperty`2(string name, PropertyGetter<TContainer, TValue> getter, PropertySetter<TContainer, TValue> setter = null) { }

	public virtual bool get_IsReadOnly() { }

	[CompilerGenerated]
	public virtual string get_Name() { }

	public virtual TValue GetValue(ref TContainer container) { }

	public virtual void SetValue(ref TContainer container, TValue value) { }

}

