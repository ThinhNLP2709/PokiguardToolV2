namespace UnityEngine.Rendering.RenderGraphModule;

[DebuggerDisplay("RayTracingAccelerationStructureResource ({desc.name})")]
internal class RayTracingAccelerationStructureResource : RenderGraphResource<RayTracingAccelerationStructureDesc, RayTracingAccelerationStructure>
{

	public RayTracingAccelerationStructureResource() { }

	public virtual string GetName() { }

}

