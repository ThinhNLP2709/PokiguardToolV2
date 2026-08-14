namespace UnityEngine.Tilemaps;

[NativeHeader("Modules/Tilemap/TilemapRendererJobs.h")]
[NativeHeader("Modules/Grid/Public/GridMarshalling.h")]
[NativeHeader("Modules/Tilemap/Public/TilemapMarshalling.h")]
[NativeType(Header = "Modules/Tilemap/Public/TilemapRenderer.h")]
[RequireComponent(typeof(Tilemap))]
public sealed class TilemapRenderer : Renderer
{

	internal void OnSpriteAtlasRegistered(SpriteAtlas atlas) { }

	private static void OnSpriteAtlasRegistered_Injected(IntPtr _unity_self, IntPtr atlas) { }

	[RequiredByNativeCode]
	internal void RegisterSpriteAtlasRegistered() { }

	[RequiredByNativeCode]
	internal void UnregisterSpriteAtlasRegistered() { }

}

