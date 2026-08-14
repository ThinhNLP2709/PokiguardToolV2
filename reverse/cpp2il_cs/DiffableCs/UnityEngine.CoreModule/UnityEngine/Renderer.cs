namespace UnityEngine;

[NativeHeader("Runtime/Graphics/GraphicsScriptBindings.h")]
[NativeHeader("Runtime/Graphics/Renderer.h")]
[RequireComponent(typeof(Transform))]
[UsedByNativeCode]
public class Renderer : Component
{

	internal bool allowGPUDrivenRendering
	{
		internal set { } //Length: 134
	}

	public Bounds bounds
	{
		[FreeFunction(Name = "RendererScripting::GetWorldBounds", HasExplicitThis = True)]
		 get { } //Length: 148
	}

	public bool enabled
	{
		 get { } //Length: 118
		 set { } //Length: 134
	}

	public bool isVisible
	{
		[NativeName("IsVisibleInScene")]
		 get { } //Length: 118
	}

	public Bounds localBounds
	{
		[NativeName("SetLocalAABB")]
		 set { } //Length: 133
	}

	public Material material
	{
		 get { } //Length: 144
		 set { } //Length: 186
	}

	public Material[] materials
	{
		 get { } //Length: 118
	}

	public bool receiveShadows
	{
		 set { } //Length: 134
	}

	public ShadowCastingMode shadowCastingMode
	{
		 set { } //Length: 131
	}

	public Material sharedMaterial
	{
		 get { } //Length: 144
		 set { } //Length: 186
	}

	internal bool smallMeshCulling
	{
		internal set { } //Length: 134
	}

	internal int sortingGroupID
	{
		internal get { } //Length: 118
	}

	internal int sortingGroupOrder
	{
		internal get { } //Length: 118
	}

	public int sortingLayerID
	{
		 get { } //Length: 118
		 set { } //Length: 131
	}

	public string sortingLayerName
	{
		 set { } //Length: 437
	}

	public int sortingOrder
	{
		 get { } //Length: 118
		 set { } //Length: 131
	}

	[FreeFunction(Name = "RendererScripting::GetWorldBounds", HasExplicitThis = True)]
	public Bounds get_bounds() { }

	private static void get_bounds_Injected(IntPtr _unity_self, out Bounds ret) { }

	public bool get_enabled() { }

	private static bool get_enabled_Injected(IntPtr _unity_self) { }

	[NativeName("IsVisibleInScene")]
	public bool get_isVisible() { }

	private static bool get_isVisible_Injected(IntPtr _unity_self) { }

	public Material get_material() { }

	public Material[] get_materials() { }

	public Material get_sharedMaterial() { }

	internal int get_sortingGroupID() { }

	private static int get_sortingGroupID_Injected(IntPtr _unity_self) { }

	internal int get_sortingGroupOrder() { }

	private static int get_sortingGroupOrder_Injected(IntPtr _unity_self) { }

	public int get_sortingLayerID() { }

	private static int get_sortingLayerID_Injected(IntPtr _unity_self) { }

	public int get_sortingOrder() { }

	private static int get_sortingOrder_Injected(IntPtr _unity_self) { }

	[FreeFunction(Name = "RendererScripting::GetMaterial", HasExplicitThis = True)]
	private Material GetMaterial() { }

	private static IntPtr GetMaterial_Injected(IntPtr _unity_self) { }

	[FreeFunction(Name = "RendererScripting::GetMaterialArray", HasExplicitThis = True)]
	private Material[] GetMaterialArray() { }

	private static Material[] GetMaterialArray_Injected(IntPtr _unity_self) { }

	[FreeFunction(Name = "RendererScripting::GetSharedMaterial", HasExplicitThis = True)]
	private Material GetSharedMaterial() { }

	private static IntPtr GetSharedMaterial_Injected(IntPtr _unity_self) { }

	internal void set_allowGPUDrivenRendering(bool value) { }

	private static void set_allowGPUDrivenRendering_Injected(IntPtr _unity_self, bool value) { }

	public void set_enabled(bool value) { }

	private static void set_enabled_Injected(IntPtr _unity_self, bool value) { }

	[NativeName("SetLocalAABB")]
	public void set_localBounds(Bounds value) { }

	private static void set_localBounds_Injected(IntPtr _unity_self, in Bounds value) { }

	public void set_material(Material value) { }

	public void set_receiveShadows(bool value) { }

	private static void set_receiveShadows_Injected(IntPtr _unity_self, bool value) { }

	public void set_shadowCastingMode(ShadowCastingMode value) { }

	private static void set_shadowCastingMode_Injected(IntPtr _unity_self, ShadowCastingMode value) { }

	public void set_sharedMaterial(Material value) { }

	internal void set_smallMeshCulling(bool value) { }

	private static void set_smallMeshCulling_Injected(IntPtr _unity_self, bool value) { }

	public void set_sortingLayerID(int value) { }

	private static void set_sortingLayerID_Injected(IntPtr _unity_self, int value) { }

	public void set_sortingLayerName(string value) { }

	private static void set_sortingLayerName_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value) { }

	public void set_sortingOrder(int value) { }

	private static void set_sortingOrder_Injected(IntPtr _unity_self, int value) { }

	[FreeFunction(Name = "RendererScripting::SetMaterial", HasExplicitThis = True)]
	private void SetMaterial(Material m) { }

	private static void SetMaterial_Injected(IntPtr _unity_self, IntPtr m) { }

}

