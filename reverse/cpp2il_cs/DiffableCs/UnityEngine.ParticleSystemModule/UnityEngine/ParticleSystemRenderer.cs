namespace UnityEngine;

[NativeHeader("Modules/ParticleSystem/ScriptBindings/ParticleSystemRendererScriptBindings.h")]
[NativeHeader("Modules/ParticleSystem/ParticleSystemRenderer.h")]
[NativeHeader("ParticleSystemScriptingClasses.h")]
[RequireComponent(typeof(Transform))]
public sealed class ParticleSystemRenderer : Renderer
{

	[FreeFunction(Name = "ParticleSystemRendererScriptBindings::GetMeshes", HasExplicitThis = True)]
	[RequiredByNativeCode]
	public int GetMeshes(out Mesh[] meshes) { }

	private static int GetMeshes_Injected(IntPtr _unity_self, out Mesh[] meshes) { }

}

