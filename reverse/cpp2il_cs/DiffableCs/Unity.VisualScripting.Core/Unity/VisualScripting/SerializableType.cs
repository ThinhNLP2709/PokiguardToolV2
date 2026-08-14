namespace Unity.VisualScripting;

[SerializationVersion("A", new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {})]
public struct SerializableType : IEquatable<SerializableType>, IComparable<SerializableType>
{
	[Serialize]
	public string Identification; //Field offset: 0x0

	public SerializableType(string identification) { }

	public override int CompareTo(SerializableType other) { }

	public override bool Equals(SerializableType other) { }

	public virtual bool Equals(object obj) { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(SerializableType left, SerializableType right) { }

	public static bool op_Inequality(SerializableType left, SerializableType right) { }

}

