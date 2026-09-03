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
	internal abstract class AtlasBase // TypeDefIndex: 3794
	{
		// Fields
		internal TextureRegistry textureRegistry; // 0x10
	
		// Constructors
		protected AtlasBase(); // 0x000000018237CC80-0x000000018237CD30
	
		// Methods
		public virtual bool TryGetAtlas(VisualElement ctx, Texture2D src, out TextureId atlas, out RectInt atlasRect); // 0x000000018237CC10-0x000000018237CC80
		public virtual void ReturnAtlas(VisualElement ctx, Texture2D src, TextureId atlas); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void Reset(); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void OnAssignedToPanel(IPanel panel); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void OnRemovedFromPanel(IPanel panel); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void OnUpdateDynamicTextures(IPanel panel); // 0x00000001802E76C0-0x00000001802E76D0
		internal void InvokeAssignedToPanel(IPanel panel); // 0x000000018237CB00-0x000000018237CB20
		internal void InvokeRemovedFromPanel(IPanel panel); // 0x000000018195C640-0x000000018195C660
		internal void InvokeUpdateDynamicTextures(IPanel panel); // 0x0000000181B591A0-0x0000000181B591C0
		protected static void RepaintTexturedElements(IPanel panel); // 0x000000018237CB20-0x000000018237CBF0
		protected void SetDynamicTexture(TextureId id, Texture texture); // 0x000000018237CBF0-0x000000018237CC10
	}
}
