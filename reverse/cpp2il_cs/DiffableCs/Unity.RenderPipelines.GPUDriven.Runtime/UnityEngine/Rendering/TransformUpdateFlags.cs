namespace UnityEngine.Rendering;

[Flags]
internal enum TransformUpdateFlags
{
	None = 0,
	HasLightProbeCombined = 1,
	IsPartOfStaticBatch = 2,
}

