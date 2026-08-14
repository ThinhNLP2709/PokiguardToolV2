namespace UnityEngine.Rendering;

[Flags]
internal enum InstanceComponentGroup
{
	Default = 1,
	Wind = 2,
	LightProbe = 4,
	Lightmap = 8,
	DefaultWind = 3,
	DefaultLightProbe = 5,
	DefaultLightmap = 9,
	DefaultWindLightProbe = 7,
	DefaultWindLightmap = 11,
}

