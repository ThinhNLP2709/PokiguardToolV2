namespace System.Reflection;

public abstract class PropertyInfo : MemberInfo
{

	public abstract PropertyAttributes Attributes
	{
		 get { } //Length: 0
	}

	public abstract bool CanRead
	{
		 get { } //Length: 0
	}

	public abstract bool CanWrite
	{
		 get { } //Length: 0
	}

	public override MethodInfo GetMethod
	{
		 get { } //Length: 22
	}

	public override bool IsSpecialName
	{
		 get { } //Length: 36
	}

	public virtual MemberTypes MemberType
	{
		 get { } //Length: 6
	}

	public abstract Type PropertyType
	{
		 get { } //Length: 0
	}

	protected PropertyInfo() { }

	public virtual bool Equals(object obj) { }

	public abstract PropertyAttributes get_Attributes() { }

	public abstract bool get_CanRead() { }

	public abstract bool get_CanWrite() { }

	public override MethodInfo get_GetMethod() { }

	public override bool get_IsSpecialName() { }

	public virtual MemberTypes get_MemberType() { }

	public abstract Type get_PropertyType() { }

	public override MethodInfo GetGetMethod() { }

	public abstract MethodInfo GetGetMethod(bool nonPublic) { }

	public virtual int GetHashCode() { }

	public abstract ParameterInfo[] GetIndexParameters() { }

	public override MethodInfo GetSetMethod() { }

	public abstract MethodInfo GetSetMethod(bool nonPublic) { }

	[DebuggerHidden]
	[DebuggerStepThrough]
	public override object GetValue(object obj, Object[] index) { }

	public abstract object GetValue(object obj, BindingFlags invokeAttr, Binder binder, Object[] index, CultureInfo culture) { }

	[DebuggerHidden]
	[DebuggerStepThrough]
	public object GetValue(object obj) { }

	public static bool op_Equality(PropertyInfo left, PropertyInfo right) { }

	public static bool op_Inequality(PropertyInfo left, PropertyInfo right) { }

	[DebuggerHidden]
	[DebuggerStepThrough]
	public void SetValue(object obj, object value) { }

	[DebuggerHidden]
	[DebuggerStepThrough]
	public override void SetValue(object obj, object value, Object[] index) { }

	public abstract void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, Object[] index, CultureInfo culture) { }

}

