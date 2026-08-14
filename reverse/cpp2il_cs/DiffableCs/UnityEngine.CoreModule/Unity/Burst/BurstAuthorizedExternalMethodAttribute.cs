namespace Unity.Burst;

[AttributeUsage(AttributeTargets::Method (64))]
public class BurstAuthorizedExternalMethodAttribute : Attribute
{

	public BurstAuthorizedExternalMethodAttribute() { }

}

