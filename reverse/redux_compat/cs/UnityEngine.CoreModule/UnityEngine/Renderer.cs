/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeClass("Renderer", PersistentTypeId = 25)]
	[NativeHeader("Runtime/Graphics/GraphicsScriptBindings.h")]
	[NativeHeader("Runtime/Graphics/Renderer.h")]
	[RequireComponent(typeof(Transform))]
	[UsedByNativeCode]
	public class Renderer : Component // TypeDefIndex: 7570
	{
		// Properties
		public Bounds bounds { [FreeFunction(Name = "RendererScripting::GetWorldBounds", HasExplicitThis = true)] get; [NativeName("SetWorldAABB")] set; } // 0x00000001821BE850-0x00000001821BE8C0 0x00000001821BEEF0-0x00000001821BEF50
		public Bounds localBounds { [FreeFunction(Name = "RendererScripting::GetLocalBounds", HasExplicitThis = true)] get; [NativeName("SetLocalAABB")] set; } // 0x00000001821BEA50-0x00000001821BEAC0 0x00000001821BF050-0x00000001821BF0B0
		public bool enabled { get; set; } // 0x00000001821BE900-0x00000001821BE960 0x00000001821BEFA0-0x00000001821BF000
		public bool isVisible { [NativeName("IsVisibleInScene")] get; } // 0x00000001821BE9A0-0x00000001821BEA00 
		public ShadowCastingMode shadowCastingMode { set; } // 0x00000001821BF1A0-0x00000001821BF200
		public bool receiveShadows { set; } // 0x00000001821BF100-0x00000001821BF160
		internal bool allowGPUDrivenRendering { set; } // 0x00000001821BED90-0x00000001821BEDF0
		internal bool smallMeshCulling { set; } // 0x00000001821BF250-0x00000001821BF2B0
		public string sortingLayerName { set; } // 0x00000001821BF3A0-0x00000001821BF510
		public int sortingLayerID { get; set; } // 0x00000001821BEC40-0x00000001821BECA0 0x00000001821BF2F0-0x00000001821BF350
		public int sortingOrder { get; set; } // 0x00000001821BECE0-0x00000001821BED40 0x00000001821BF550-0x00000001821BF5B0
		internal int sortingGroupID { get; } // 0x00000001821BEB00-0x00000001821BEB60 
		internal int sortingGroupOrder { get; } // 0x00000001821BEBA0-0x00000001821BEC00 
		[NativeProperty("IsDynamicOccludee")]
		public bool allowOcclusionWhenDynamic { get; set; } // 0x00000001821BE7A0-0x00000001821BE800 0x00000001821BEE40-0x00000001821BEEA0
		public Material[] materials { get; } // 0x00000001821BE3F0-0x00000001821BE450 
		public Material material { get; set; } // 0x00000001821BE490-0x00000001821BE520 0x00000001821BE6E0-0x00000001821BE760
		public Material sharedMaterial { get; set; } // 0x00000001821BE600-0x00000001821BE690 0x00000001821BE6E0-0x00000001821BE760
		public Material[] sharedMaterials { get; } // 0x00000001821BE560-0x00000001821BE5C0 
	
		// Constructors
		public Renderer(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		[FreeFunction(Name = "RendererScripting::GetMaterial", HasExplicitThis = true)]
		private Material GetMaterial(); // 0x00000001821BE490-0x00000001821BE520
		[FreeFunction(Name = "RendererScripting::GetSharedMaterial", HasExplicitThis = true)]
		private Material GetSharedMaterial(); // 0x00000001821BE600-0x00000001821BE690
		[FreeFunction(Name = "RendererScripting::SetMaterial", HasExplicitThis = true)]
		private void SetMaterial(Material m); // 0x00000001821BE6E0-0x00000001821BE760
		[FreeFunction(Name = "RendererScripting::GetMaterialArray", HasExplicitThis = true)]
		private Material[] GetMaterialArray(); // 0x00000001821BE3F0-0x00000001821BE450
		[NativeName("GetMaterialArray")]
		private Material[] GetSharedMaterialArray(); // 0x00000001821BE560-0x00000001821BE5C0
		private static void get_bounds_Injected(IntPtr _unity_self, ); // 0x00000001821BE800-0x00000001821BE850
		private static void set_bounds_Injected(IntPtr _unity_self, in Bounds value); // 0x00000001821BEEA0-0x00000001821BEEF0
		private static void get_localBounds_Injected(IntPtr _unity_self, ); // 0x00000001821BEA00-0x00000001821BEA50
		private static void set_localBounds_Injected(IntPtr _unity_self, in Bounds value); // 0x00000001821BF000-0x00000001821BF050
		private static IntPtr GetMaterial_Injected(IntPtr _unity_self); // 0x00000001821BE450-0x00000001821BE490
		private static IntPtr GetSharedMaterial_Injected(IntPtr _unity_self); // 0x00000001821BE5C0-0x00000001821BE600
		private static void SetMaterial_Injected(IntPtr _unity_self, IntPtr m); // 0x00000001821BE690-0x00000001821BE6E0
		private static Material[] GetMaterialArray_Injected(IntPtr _unity_self); // 0x00000001821BE3B0-0x00000001821BE3F0
		private static bool get_enabled_Injected(IntPtr _unity_self); // 0x00000001821BE8C0-0x00000001821BE900
		private static void set_enabled_Injected(IntPtr _unity_self, bool value); // 0x00000001821BEF50-0x00000001821BEFA0
		private static bool get_isVisible_Injected(IntPtr _unity_self); // 0x00000001821BE960-0x00000001821BE9A0
		private static void set_shadowCastingMode_Injected(IntPtr _unity_self, ShadowCastingMode value); // 0x00000001821BF160-0x00000001821BF1A0
		private static void set_receiveShadows_Injected(IntPtr _unity_self, bool value); // 0x00000001821BF0B0-0x00000001821BF100
		private static void set_allowGPUDrivenRendering_Injected(IntPtr _unity_self, bool value); // 0x00000001821BED40-0x00000001821BED90
		private static void set_smallMeshCulling_Injected(IntPtr _unity_self, bool value); // 0x00000001821BF200-0x00000001821BF250
		private static void set_sortingLayerName_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value); // 0x00000001821BF350-0x00000001821BF3A0
		private static int get_sortingLayerID_Injected(IntPtr _unity_self); // 0x00000001821BEC00-0x00000001821BEC40
		private static void set_sortingLayerID_Injected(IntPtr _unity_self, int value); // 0x00000001821BF2B0-0x00000001821BF2F0
		private static int get_sortingOrder_Injected(IntPtr _unity_self); // 0x00000001821BECA0-0x00000001821BECE0
		private static void set_sortingOrder_Injected(IntPtr _unity_self, int value); // 0x00000001821BF510-0x00000001821BF550
		private static int get_sortingGroupID_Injected(IntPtr _unity_self); // 0x00000001821BEAC0-0x00000001821BEB00
		private static int get_sortingGroupOrder_Injected(IntPtr _unity_self); // 0x00000001821BEB60-0x00000001821BEBA0
		private static bool get_allowOcclusionWhenDynamic_Injected(IntPtr _unity_self); // 0x00000001821BE760-0x00000001821BE7A0
		private static void set_allowOcclusionWhenDynamic_Injected(IntPtr _unity_self, bool value); // 0x00000001821BEDF0-0x00000001821BEE40
		private static Material[] GetSharedMaterialArray_Injected(IntPtr _unity_self); // 0x00000001821BE520-0x00000001821BE560
	}
}
