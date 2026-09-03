/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal static class RenderEvents // TypeDefIndex: 5125
	{
		// Fields
		private static readonly float VisibilityTreshold; // 0x00
	
		// Constructors
		static RenderEvents(); // 0x000000018242DBB0-0x000000018242DBF0
	
		// Methods
		internal static void ProcessOnClippingChanged(RenderTreeManager renderTreeManager, RenderData renderData, uint dirtyID, ref ChainBuilderStats stats); // 0x000000018242BA60-0x000000018242BB50
		internal static void ProcessOnOpacityChanged(RenderTreeManager renderTreeManager, RenderData renderData, uint dirtyID, ref ChainBuilderStats stats); // 0x000000018242BBE0-0x000000018242BD30
		internal static void ProcessOnColorChanged(RenderTreeManager renderTreeManager, RenderData renderData, uint dirtyID, ref ChainBuilderStats stats); // 0x000000018242BB50-0x000000018242BBE0
		internal static void ProcessOnTransformOrSizeChanged(RenderTreeManager renderTreeManager, RenderData renderData, uint dirtyID, ref ChainBuilderStats stats); // 0x000000018242BD30-0x000000018242BDD0
		private static Matrix4x4 GetTransformIDTransformInfo(RenderData renderData); // 0x000000018242B260-0x000000018242B3E0
		private static Vector4 GetClipRectIDClipInfo(RenderData renderData); // 0x000000018242B050-0x000000018242B260
		internal static uint DepthFirstOnChildAdded(RenderTreeManager renderTreeManager, VisualElement parent, VisualElement ve, int index); // 0x0000000182428F60-0x0000000182429740
		internal static uint DepthFirstOnElementRemoving(RenderTreeManager renderTreeManager, VisualElement ve); // 0x0000000182429DA0-0x0000000182429F70
		private static void DepthFirstRemoveRenderData(RenderTreeManager renderTreeManager, RenderData renderData); // 0x000000018242ABC0-0x000000018242AD10
		private static void DoDepthFirstRemoveRenderData(RenderTreeManager renderTreeManager, RenderData renderData); // 0x000000018242AF60-0x000000018242B050
		private static void DisconnectSubTree(RenderData renderData); // 0x000000018242AEC0-0x000000018242AF60
		private static void DisconnectRenderTreeFromParent(RenderTree parentTree, RenderTree nestedTree); // 0x000000018242AE30-0x000000018242AEC0
		private static void ResetRenderData(RenderTreeManager renderTreeManager, RenderData renderData); // 0x000000018242BEB0-0x000000018242C9E0
		private static void DepthFirstOnClippingChanged(RenderTreeManager renderTreeManager, RenderData parentRenderData, RenderData renderData, uint dirtyID, bool hierarchical, bool isRootOfChange, bool isPendingHierarchicalRepaint, bool inheritedClipRectIDChanged, bool inheritedMaskingChanged, ref ChainBuilderStats stats); // 0x0000000182429740-0x0000000182429DA0
		private static void DepthFirstOnOpacityChanged(RenderTreeManager renderTreeManager, float parentCompositeOpacity, RenderData renderData, uint dirtyID, bool hierarchical, ref ChainBuilderStats stats); // 0x0000000182429F70-0x000000018242A440
		private static void OnColorChanged(RenderTreeManager renderTreeManager, RenderData renderData, uint dirtyID, ref ChainBuilderStats stats); // 0x000000018242B890-0x000000018242BA60
		private static void DepthFirstOnTransformOrSizeChanged(RenderTreeManager renderTreeManager, RenderData renderData, uint dirtyID, bool isAncestorOfChangeSkinned, bool transformChanged, bool parentBoneChanged, ref ChainBuilderStats stats); // 0x000000018242A440-0x000000018242ABC0
		private static bool PromoteToBone(RenderTreeManager renderTreeManager, RenderData renderData); // 0x000000018242BDD0-0x000000018242BEB0
		public static bool UpdateTextCoreSettings(RenderTreeManager renderTreeManager, TextElement te); // 0x000000018242D460-0x000000018242D970
		private static ClipMethod DetermineSelfClipMethod(RenderTreeManager renderTreeManager, RenderData renderData); // 0x000000018242AD10-0x000000018242AE30
		private static bool UpdateLocalFlipsWinding(RenderData renderData); // 0x000000018242D340-0x000000018242D460
		private static void UpdateZeroScaling(RenderData renderData); // 0x000000018242D970-0x000000018242DBB0
		private static bool NeedsTransformID(VisualElement ve); // 0x000000018242B850-0x000000018242B890
		internal static bool NeedsColorID(VisualElement ve); // 0x000000018242B790-0x000000018242B7B0
		internal static bool NeedsTextCoreSettings(TextElement te); // 0x000000018242B7B0-0x000000018242B850
		private static bool InitColorIDs(RenderTreeManager renderTreeManager, VisualElement ve); // 0x000000018242B3E0-0x000000018242B790
		public static void SyncBackdropFilterState(RenderTreeManager renderTreeManager, RenderData renderData); // 0x000000018242D110-0x000000018242D340
		public static void SetColorValues(RenderTreeManager renderTreeManager, VisualElement ve); // 0x000000018242C9E0-0x000000018242D110
	}
}
