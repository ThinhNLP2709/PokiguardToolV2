/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class RenderData // TypeDefIndex: 5123
	{
		// Fields
		public VisualElement owner; // 0x10
		public RenderTree renderTree; // 0x18
		public RenderData parent; // 0x20
		public RenderData prevSibling; // 0x28
		public RenderData nextSibling; // 0x30
		public RenderData firstChild; // 0x38
		public RenderData lastChild; // 0x40
		public RenderData groupTransformAncestor; // 0x48
		public RenderData boneTransformAncestor; // 0x50
		public RenderData prevDirty; // 0x58
		public RenderData nextDirty; // 0x60
		public RenderDataFlags flags; // 0x68
		public int depthInRenderTree; // 0x6C
		public RenderDataDirtyTypes dirtiedValues; // 0x70
		public uint dirtyID; // 0x74
		public RenderChainCommand firstHeadCommand; // 0x78
		public RenderChainCommand lastHeadCommand; // 0x80
		public RenderChainCommand firstTailCommand; // 0x88
		public RenderChainCommand lastTailCommand; // 0x90
		public bool localFlipsWinding; // 0x98
		public bool worldFlipsWinding; // 0x99
		public bool worldTransformScaleZero; // 0x9A
		public ClipMethod clipMethod; // 0x9C
		public int childrenStencilRef; // 0xA0
		public int childrenMaskDepth; // 0xA4
		public MeshHandle headMesh; // 0xA8
		public MeshHandle tailMesh; // 0xB0
		public ushort elementId; // 0xB8
		public BMPAlloc transformID; // 0xBC
		public BMPAlloc clipRectID; // 0xC4
		public BMPAlloc opacityID; // 0xCC
		public BMPAlloc textCoreSettingsID; // 0xD4
		public BMPAlloc colorID; // 0xDC
		public BMPAlloc backgroundColorID; // 0xE4
		public BMPAlloc borderLeftColorID; // 0xEC
		public BMPAlloc borderTopColorID; // 0xF4
		public BMPAlloc borderRightColorID; // 0xFC
		public BMPAlloc borderBottomColorID; // 0x104
		public BMPAlloc tintColorID; // 0x10C
		public float compositeOpacity; // 0x114
		public float backgroundAlpha; // 0x118
		public BasicNode<GraphicEntry> graphicEntries; // 0x120
		public TextureId backdropFilterTextureId; // 0x128
		public RenderTexture backdropFilterTemporaryTexture; // 0x130
		public Vector2 backdropFilterUVBottomLeft; // 0x138
		public Vector2 backdropFilterUVTopLeft; // 0x140
		public Vector2 backdropFilterUVTopRight; // 0x148
		public Vector2 backdropFilterUVBottomRight; // 0x150
		public bool pendingRepaint; // 0x158
		public bool pendingHierarchicalRepaint; // 0x159
		public List<MeshModifierRegistration> m_EffectiveModifiers; // 0x160
		private Rect m_ClippingRect; // 0x168
		private Rect m_ClippingRectMinusGroup; // 0x178
		private bool m_ClippingRectIsInfinite; // 0x188
	
		// Properties
		public bool hasBackdropFilterAllocated { get; } // 0x0000000182428E60-0x0000000182428EB0 
		public bool isGroupTransform { get; } // 0x0000000180C55C50-0x0000000180C55C60 
		public bool isIgnoringDynamicColorHint { get; } // 0x0000000182428EF0-0x0000000182428F00 
		public bool hasExtraData { get; } // 0x0000000182428EB0-0x0000000182428EC0 
		public bool hasExtraMeshes { get; } // 0x0000000182428EC0-0x0000000182428ED0 
		public bool isSubTreeQuad { get; } // 0x0000000182428F20-0x0000000182428F30 
		public bool isNestedRenderTreeRoot { get; } // 0x0000000182428F00-0x0000000182428F10 
		public bool isClippingRectDirty { get; } // 0x0000000182428ED0-0x0000000182428EE0 
		public bool isStickyBone { get; } // 0x0000000182428F10-0x0000000182428F20 
		public bool isElementInfoDirty { get; } // 0x0000000182428EE0-0x0000000182428EF0 
		public Rect clippingRect { get; set; } // 0x0000000182428E20-0x0000000182428E60 0x0000000182428F50-0x0000000182428F60
		public Rect clippingRectMinusGroup { get; set; } // 0x0000000182428DE0-0x0000000182428E20 0x0000000182428F40-0x0000000182428F50
		internal bool clippingRectIsInfinite { get; set; } // 0x0000000182428DA0-0x0000000182428DE0 0x0000000182428F30-0x0000000182428F40
	
		// Constructors
		public RenderData(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public static bool AllocatesID(BMPAlloc alloc); // 0x0000000182427A00-0x0000000182427A60
		public static bool InheritsID(BMPAlloc alloc); // 0x0000000182427D20-0x0000000182427D80
		public void Init(); // 0x0000000182427D80-0x0000000182428230
		public void Reset(); // 0x0000000182428300-0x0000000182428460
		internal void UpdateClippingRect(); // 0x0000000182428460-0x0000000182428DA0
		private static Rect IntersectClipRects(Rect rect, Rect parentRect); // 0x0000000182428230-0x0000000182428300
		private static void GetLocalClippingRect(VisualElement owner, out Rect localRect); // 0x0000000182427A60-0x0000000182427D20
	}
}
