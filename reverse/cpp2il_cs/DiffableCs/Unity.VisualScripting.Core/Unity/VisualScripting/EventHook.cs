namespace Unity.VisualScripting;

public struct EventHook
{
	public readonly string name; //Field offset: 0x0
	public readonly object target; //Field offset: 0x8
	public readonly object tag; //Field offset: 0x10

	public EventHook(string name, object target = null, object tag = null) { }

	public virtual bool Equals(object obj) { }

	public bool Equals(EventHook other) { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(EventHook a, EventHook b) { }

	public static EventHook op_Implicit(string name) { }

	public static bool op_Inequality(EventHook a, EventHook b) { }

}

