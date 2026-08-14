namespace UnityEngine;

internal class ParticleSystemExtensionsImpl
{

	[FreeFunction(Name = "ParticleSystemScriptBindings::GetCollisionEvents")]
	internal static int GetCollisionEvents(ParticleSystem ps, GameObject go, List<ParticleCollisionEvent> collisionEvents) { }

	private static int GetCollisionEvents_Injected(IntPtr ps, IntPtr go, ref BlittableListWrapper collisionEvents) { }

}

