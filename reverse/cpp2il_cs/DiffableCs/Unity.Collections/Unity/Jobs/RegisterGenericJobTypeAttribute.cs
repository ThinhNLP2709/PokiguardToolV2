namespace Unity.Jobs;

[AttributeUsage(AttributeTargets::Assembly (1), AllowMultiple = True)]
[MovedFrom(True, "Unity.Entities", "Unity.Entities", null)]
public class RegisterGenericJobTypeAttribute : Attribute
{
	public Type ConcreteType; //Field offset: 0x10

	public RegisterGenericJobTypeAttribute(Type type) { }

}

