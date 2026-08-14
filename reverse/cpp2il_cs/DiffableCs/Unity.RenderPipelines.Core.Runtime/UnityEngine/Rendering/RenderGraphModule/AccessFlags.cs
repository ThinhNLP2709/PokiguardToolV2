namespace UnityEngine.Rendering.RenderGraphModule;

[Flags]
[MovedFrom(True, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
public enum AccessFlags
{
	None = 0,
	Read = 1,
	Write = 2,
	Discard = 4,
	WriteAll = 6,
	ReadWrite = 3,
}

