namespace Unity.VisualScripting;

[CreateAssetMenu(menuName = "Visual Scripting/Script Graph", fileName = "New Script Graph", order = 81)]
[HelpURL("https://docs.unity3d.com/Packages/com.unity.visualscripting@latest/index.html?subfolder=/manual/vs-script-graphs-intro.html")]
[TypeIcon(typeof(FlowGraph))]
public sealed class ScriptGraphAsset : Macro<FlowGraph>
{

	public ScriptGraphAsset() { }

	public virtual FlowGraph DefaultGraph() { }

	[ContextMenu("Show Data...")]
	protected virtual void ShowData() { }

}

