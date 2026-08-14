namespace UnityEngine.Rendering;

public interface IPostProcessComponent
{

	public bool IsActive() { }

	[Obsolete("Unused #from(2023.1)", False)]
	public bool IsTileCompatible() { }

}

