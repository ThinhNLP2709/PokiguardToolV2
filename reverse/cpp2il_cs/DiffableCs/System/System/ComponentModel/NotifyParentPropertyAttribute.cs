namespace System.ComponentModel;

[AttributeUsage(AttributeTargets::Property (128))]
public sealed class NotifyParentPropertyAttribute : Attribute
{
	public static readonly NotifyParentPropertyAttribute Yes; //Field offset: 0x0
	public static readonly NotifyParentPropertyAttribute No; //Field offset: 0x8
	public static readonly NotifyParentPropertyAttribute Default; //Field offset: 0x10
	private bool notifyParent; //Field offset: 0x10

	public bool NotifyParent
	{
		 get { } //Length: 5
	}

	private static NotifyParentPropertyAttribute() { }

	public NotifyParentPropertyAttribute(bool notifyParent) { }

	public virtual bool Equals(object obj) { }

	public bool get_NotifyParent() { }

	public virtual int GetHashCode() { }

	public virtual bool IsDefaultAttribute() { }

}

