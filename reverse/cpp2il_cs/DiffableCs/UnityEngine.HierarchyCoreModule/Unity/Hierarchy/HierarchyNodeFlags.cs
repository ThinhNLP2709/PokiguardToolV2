namespace Unity.Hierarchy;

[Flags]
[NativeHeader("Modules/HierarchyCore/Public/HierarchyNodeFlags.h")]
public enum HierarchyNodeFlags
{
	None = 0,
	Expanded = 1,
	Selected = 2,
	Cut = 4,
	Hidden = 8,
}

