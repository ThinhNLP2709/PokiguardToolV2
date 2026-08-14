namespace Unity.VisualScripting;

[AddComponentMenu("Visual Scripting/Script Machine")]
[DisableAnnotation]
[RenamedFrom("Bolt.FlowMachine")]
[RenamedFrom("Unity.VisualScripting.FlowMachine")]
[RequireComponent(typeof(Variables))]
public sealed class ScriptMachine : EventMachine<FlowGraph, ScriptGraphAsset>
{

	public ScriptMachine() { }

	public virtual FlowGraph DefaultGraph() { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	protected virtual void OnInstantiateWhileEnabled() { }

	protected virtual void OnUninstantiateWhileEnabled() { }

	[ContextMenu("Show Data...")]
	protected virtual void ShowData() { }

}

