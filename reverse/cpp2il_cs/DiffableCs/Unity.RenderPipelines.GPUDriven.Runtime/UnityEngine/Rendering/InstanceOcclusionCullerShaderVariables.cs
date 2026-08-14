namespace UnityEngine.Rendering;

[GenerateHLSL(PackingRules::Exact (0), True, False, False, 1, False, False, False, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core\\Runtime\\GPUDriven\\InstanceOcclusionCullerShaderVariables.cs", needAccessors = False, generateCBuffer = True)]
internal struct InstanceOcclusionCullerShaderVariables
{
	public uint _DrawInfoAllocIndex; //Field offset: 0x0
	public uint _DrawInfoCount; //Field offset: 0x4
	public uint _InstanceInfoAllocIndex; //Field offset: 0x8
	public uint _InstanceInfoCount; //Field offset: 0xC
	public int _BoundingSphereInstanceDataAddress; //Field offset: 0x10
	public int _DebugCounterIndex; //Field offset: 0x14
	public int _InstanceMultiplierShift; //Field offset: 0x18
	public int _InstanceOcclusionCullerPad0; //Field offset: 0x1C

}

