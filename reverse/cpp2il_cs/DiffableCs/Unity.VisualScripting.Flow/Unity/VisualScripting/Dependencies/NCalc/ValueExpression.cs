namespace Unity.VisualScripting.Dependencies.NCalc;

public class ValueExpression : LogicalExpression
{
	[CompilerGenerated]
	private object <Value>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private ValueType <Type>k__BackingField; //Field offset: 0x18

	public ValueType Type
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public object Value
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public ValueExpression(object value, ValueType type) { }

	public ValueExpression(object value) { }

	public ValueExpression(string value) { }

	public ValueExpression(int value) { }

	public ValueExpression(float value) { }

	public ValueExpression(DateTime value) { }

	public ValueExpression(bool value) { }

	public virtual void Accept(LogicalExpressionVisitor visitor) { }

	[CompilerGenerated]
	public ValueType get_Type() { }

	[CompilerGenerated]
	public object get_Value() { }

	[CompilerGenerated]
	public void set_Type(ValueType value) { }

	[CompilerGenerated]
	public void set_Value(object value) { }

}

