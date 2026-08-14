namespace UnityEngine.Playables;

[NativeHeader("Runtime/Director/Core/HPlayableGraph.h")]
[NativeHeader("Runtime/Export/Director/PlayableHandle.bindings.h")]
[NativeHeader("Runtime/Director/Core/HPlayable.h")]
[UsedByNativeCode]
public struct PlayableHandle : IEquatable<PlayableHandle>
{
	private static readonly PlayableHandle m_Null; //Field offset: 0x0
	internal IntPtr m_Handle; //Field offset: 0x0
	internal uint m_Version; //Field offset: 0x8

	public static PlayableHandle Null
	{
		 get { } //Length: 96
	}

	private static PlayableHandle() { }

	internal static bool CompareVersion(PlayableHandle lhs, PlayableHandle rhs) { }

	public virtual bool Equals(object p) { }

	public override bool Equals(PlayableHandle other) { }

	public static PlayableHandle get_Null() { }

	public virtual int GetHashCode() { }

	[FreeFunction("PlayableHandleBindings::GetPlayableType", HasExplicitThis = True, ThrowsException = True)]
	[VisibleToOtherModules]
	internal Type GetPlayableType() { }

	[VisibleToOtherModules]
	internal bool IsPlayableOfType() { }

	[VisibleToOtherModules]
	internal bool IsValid() { }

	public static bool op_Equality(PlayableHandle x, PlayableHandle y) { }

}

