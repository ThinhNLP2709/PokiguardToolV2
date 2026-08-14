namespace UnityEngine.Rendering.Universal;

[AttributeUsage(AttributeTargets::Class (4), AllowMultiple = False)]
public sealed class VolumeRequiresRendererFeatures : Attribute
{
	internal HashSet<Type> TargetFeatureTypes; //Field offset: 0x10

	public VolumeRequiresRendererFeatures(Type[] featureTypes) { }

}

