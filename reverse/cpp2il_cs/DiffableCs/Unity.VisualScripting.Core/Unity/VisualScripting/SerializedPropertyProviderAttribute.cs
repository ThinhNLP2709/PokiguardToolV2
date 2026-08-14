namespace Unity.VisualScripting;

[AttributeUsage(AttributeTargets::Class (4), AllowMultiple = False, Inherited = False)]
public sealed class SerializedPropertyProviderAttribute : Attribute, IDecoratorAttribute
{
	[CompilerGenerated]
	private Type <type>k__BackingField; //Field offset: 0x10

	public private override Type type
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public SerializedPropertyProviderAttribute(Type type) { }

	[CompilerGenerated]
	public override Type get_type() { }

	[CompilerGenerated]
	private void set_type(Type value) { }

}

