/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
	internal interface IPanelSettings // TypeDefIndex: 4187
	{
		// Properties
		BindingLogLevel bindingLogLevel { get; }
		Color colorClearValue { get; }
		bool clearColor { get; }
		bool clearDepthStencil { get; }
		DynamicAtlasSettings dynamicAtlasSettings { get; }
		float fallbackDpi { get; }
		bool forceGammaRendering { get; }
		float match { get; }
		float pixelsPerUnit { get; }
		float referenceDpi { get; }
		Vector2Int referenceResolution { get; }
		float referenceSpritePixelsPerUnit { get; }
		PanelRenderMode renderMode { get; }
		float resolvedScale { get; }
		float scale { get; }
		PanelScaleMode scaleMode { get; }
		float screenDpi { get; }
		PanelScreenMatchMode screenMatchMode { get; }
		int targetDisplay { get; }
		Rect targetRect { get; }
		TextureSlotCount textureSlotCount { get; }
		uint vertexBudget { get; }
		ExtraVertexChannels extraVertexChannels { get; }
	}
}
