namespace UnityEngine.VFX;

[NativeHeader("VFXScriptingClasses.h")]
[NativeHeader("Modules/VFX/Public/VisualEffectAsset.h")]
[UsedByNativeCode]
public class VisualEffectAsset : VisualEffectObject
{
	public static readonly int PlayEventID; //Field offset: 0x0
	public static readonly int StopEventID; //Field offset: 0x4

	private static VisualEffectAsset() { }

}

