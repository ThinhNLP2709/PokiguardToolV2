namespace UnityEngine.Rendering;

[AttributeUsage(20, AllowMultiple = False)]
[Conditional("UNITY_EDITOR")]
public class CoreRPHelpURLAttribute : HelpURLAttribute
{

	public CoreRPHelpURLAttribute(string pageName, string packageName = "com.unity.render-pipelines.core") { }

	public CoreRPHelpURLAttribute(string pageName, string pageHash, string packageName = "com.unity.render-pipelines.core") { }

}

