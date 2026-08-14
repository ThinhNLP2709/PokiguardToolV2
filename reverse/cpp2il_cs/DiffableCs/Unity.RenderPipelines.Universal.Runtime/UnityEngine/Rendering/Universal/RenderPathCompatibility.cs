namespace UnityEngine.Rendering.Universal;

[Flags]
public enum RenderPathCompatibility
{
	Forward = 1,
	Deferred = 2,
	ForwardPlus = 4,
	All = 7,
}

