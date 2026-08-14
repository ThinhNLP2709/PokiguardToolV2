namespace UnityEngine.U2D;

[NativeHeader("Runtime/Graphics/SpriteFrame.h")]
[NativeType(Header = "Runtime/2D/SpriteAtlas/SpriteAtlas.h")]
public class SpriteAtlas : object
{

	public bool CanBindTo(Sprite sprite) { }

	private static bool CanBindTo_Injected(IntPtr _unity_self, IntPtr sprite) { }

	public Sprite GetSprite(string name) { }

	private static IntPtr GetSprite_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name) { }

}

