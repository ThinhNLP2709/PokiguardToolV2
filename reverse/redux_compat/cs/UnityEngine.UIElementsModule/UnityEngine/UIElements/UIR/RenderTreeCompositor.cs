/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class RenderTreeCompositor : IDisposable // TypeDefIndex: 5131
	{
		// Fields
		private readonly RenderTreeManager m_RenderTreeManager; // 0x10
		private DrawOperation m_RootOperation; // 0x18
		private List<RenderTexture> m_AllocatedTextures; // 0x20
		private MaterialPropertyBlock m_Block; // 0x28
		private ObjectPool<DrawOperation> m_DrawOperationPool; // 0x30
		private int m_NextFilterGroupId; // 0x38
		[NoAutoStaticsCleanup]
		private static Vector4[] s_UVRects; // 0x00
		private static readonly int s_UnityUIE_UVRectId; // 0x08
		[NoAutoStaticsCleanup]
		private static readonly Dictionary<string, InputBindingIds> s_InputBindingIds; // 0x10
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0x3C
	
		// Properties
		protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804654D0-0x00000001804654E0 0x0000000180C263E0-0x0000000180C263F0
	
		// Nested types
		private enum DrawOperationType // TypeDefIndex: 5132
		{
			Undefined = 0,
			RenderTree = 1,
			Effect = 2
		}
	
		private class DrawOperation // TypeDefIndex: 5133
		{
			// Fields
			private DrawOperationType m_Type; // 0x10
			private VisualElement m_VisualElement; // 0x18
			private RenderTree m_RenderTree; // 0x20
			private PostProcessingPass m_FilterPass; // 0x28
			private int m_FilterPassIndex; // 0x88
			private FilterFunction m_Filter; // 0x90
			public RectInt bounds; // 0x100
			public RectInt drawSourceBounds; // 0x110
			public Vector4 drawSourceTexOffsets; // 0x120
			public RenderTreeAtlas.AtlasBlock dstAtlasBlock; // 0x130
			public TextureId dstTextureId; // 0x160
			public int filterGroupId; // 0x164
			public DrawOperation parent; // 0x168
			public DrawOperation firstChild; // 0x170
			public DrawOperation lastChild; // 0x178
			public DrawOperation prevSibling; // 0x180
			public DrawOperation nextSibling; // 0x188
	
			// Properties
			public DrawOperationType type { get; } // 0x00000001802E64B0-0x00000001802E64C0 
			public VisualElement visualElement { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			public RenderTree renderTree { get; } // 0x00000001802F8630-0x00000001802F8640 
			public PostProcessingPass FilterPass { get; } // 0x0000000182436380-0x00000001824363C0 
			public int FilterPassIndex { get; } // 0x000000018033D620-0x000000018033D630 
			public FilterFunction filter { get; } // 0x00000001824363C0-0x0000000182436410 
	
			// Constructors
			public DrawOperation(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public void Init(VisualElement ve, [IsReadOnly] in PostProcessingPass filterPass, int filterPassIndex, FilterFunction filter); // 0x0000000182436110-0x0000000182436230
			public void Init(RenderTree renderTree); // 0x0000000182436230-0x0000000182436290
			private void InitPointers(); // 0x0000000182436080-0x0000000182436110
			public void Reset(); // 0x0000000182436290-0x0000000182436380
			public void AddChild(DrawOperation op); // 0x0000000182435F90-0x0000000182436080
		}
	
		private struct InputBindingIds // TypeDefIndex: 5134
		{
			// Fields
			public int texId; // 0x00
			public int scaleOffsetId; // 0x04
			public int uvRectId; // 0x08
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5135
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<DrawOperation> __9__8_0; // 0x08
	
			// Constructors
			static __c(); // 0x000000018244A960-0x000000018244A9D0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal DrawOperation _.ctor_b__8_0(); // 0x000000018244A750-0x000000018244A7A0
		}
	
		// Constructors
		public RenderTreeCompositor(RenderTreeManager owner); // 0x00000001824317D0-0x00000001824319A0
		static RenderTreeCompositor(); // 0x00000001824316D0-0x00000001824317D0
	
		// Methods
		public void Update(RenderTree rootRenderTree); // 0x00000001824315F0-0x00000001824316D0
		private void BuildDrawOperationTree(RenderTree rootRenderTree); // 0x000000018242F030-0x000000018242F0E0
		private void AddChildrenOperations_DepthFirst(DrawOperation parentOperation, RenderTree renderTree); // 0x000000018242DFD0-0x000000018242E430
		private static PostProcessingMargins GetReadMargins(PostProcessingPass effect, FilterFunction func); // 0x00000001824303C0-0x0000000182430470
		private static PostProcessingMargins GetWriteMargins(PostProcessingPass effect, FilterFunction func); // 0x0000000182430470-0x0000000182430520
		private void UpdateDrawBounds_PostOrder(DrawOperation op); // 0x0000000182430650-0x00000001824315F0
		private void AssignTextureIds_DepthFirst(DrawOperation op); // 0x000000018242E710-0x000000018242E900
		public void RenderNestedPasses(); // 0x0000000182430520-0x0000000182430560
		private void ExecuteDrawOperation_PostOrder(DrawOperation op); // 0x000000018242F3C0-0x0000000182430230
		private static InputBindingIds GetInputBindingIds(string name); // 0x0000000182430230-0x00000001824303C0
		private void BindRequiredInput(DrawOperation currentOp, RectInt drawRect, Rect uvRect); // 0x000000018242EC20-0x000000018242F030
		private static DrawOperation ResolveInputOp(DrawOperation currentOp, string name); // 0x0000000182430560-0x0000000182430650
		private void BindMappedTexture(DrawOperation sourceOp, RectInt drawRect, Rect uvRect, InputBindingIds ids); // 0x000000018242E900-0x000000018242EC20
		private void ApplyEffectParameters(PostProcessingPass effect, FilterFunction filter, VisualElement source, bool readsGamma); // 0x000000018242E430-0x000000018242E710
		private void CleanupOperationTree(); // 0x000000018242F0E0-0x000000018242F210
		private void CleanupOperation_PostOrder(DrawOperation op); // 0x000000018242F210-0x000000018242F330
		public void Dispose(); // 0x000000018242F330-0x000000018242F390
		protected void Dispose(bool disposing); // 0x000000018242F390-0x000000018242F3C0
	}
}
