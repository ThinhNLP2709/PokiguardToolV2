namespace UnityEngine.Audio;

[NativeHeader("Runtime/Director/Core/HPlayable.h")]
[NativeHeader("Modules/Audio/Public/Director/AudioClipPlayable.h")]
[NativeHeader("Modules/Audio/Public/ScriptBindings/AudioClipPlayable.bindings.h")]
[RequiredByNativeCode]
[StaticAccessor("AudioClipPlayableBindings", StaticAccessorType::DoubleColon (2))]
public struct AudioClipPlayable : IEquatable<AudioClipPlayable>
{
	private PlayableHandle m_Handle; //Field offset: 0x0

	public override bool Equals(AudioClipPlayable other) { }

	public override PlayableHandle GetHandle() { }

}

