namespace UnityEngine.Playables;

[NativeHeader("Runtime/Director/Core/HPlayableOutput.h")]
[NativeHeader("Modules/Director/ScriptBindings/DataPlayableOutput.bindings.h")]
[NativeHeader("Modules/Director/ScriptBindings/DataPlayableOutputExtensions.bindings.h")]
[NativeHeader("Modules/Director/DataPlayableOutput.h")]
[NativeHeader("Runtime/Director/Core/HPlayableGraph.h")]
[RequiredByNativeCode]
[StaticAccessor("DataPlayableOutputBindings", StaticAccessorType::DoubleColon (2))]
internal struct DataPlayableOutput
{
	private PlayableOutputHandle m_Handle; //Field offset: 0x0

	internal DataPlayableOutput(PlayableOutputHandle handle) { }

	[RequiredByNativeCode]
	private static void Internal_CallOnPlayerChanged(PlayableOutputHandle handle, object previousPlayer, object currentPlayer) { }

}

