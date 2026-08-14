namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(AttributeTargets::Method (64), Inherited = False)]
public sealed class DoesNotReturnAttribute : Attribute
{

	public DoesNotReturnAttribute() { }

}

