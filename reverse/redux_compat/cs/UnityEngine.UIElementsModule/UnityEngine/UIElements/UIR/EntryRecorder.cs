/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class EntryRecorder // TypeDefIndex: 5061
	{
		// Fields
		private EntryPool m_EntryPool; // 0x10
		private readonly ExtraVertexChannels m_PanelExtras; // 0x18
	
		// Constructors
		public EntryRecorder(EntryPool entryPool, ExtraVertexChannels panelExtras = ExtraVertexChannels.None /* Metadata: 0x00660A6D */); // 0x000000018240F840-0x000000018240F8D0
	
		// Methods
		public void DrawMesh(Entry parentEntry, NativeSlice<Vertex> vertices, NativeSlice<ushort> indices, Texture texture, TextureOptions textureOptions = TextureOptions.None /* Metadata: 0x00660A6E */, DrawPhase phase = DrawPhase.Content /* Metadata: 0x00660A6F */, int userData = 0 /* Metadata: 0x00660A70 */); // 0x000000018240F0F0-0x000000018240F220
		public void DrawMesh(Entry parentEntry, ref UIMesh mesh, Texture texture, TextureOptions textureOptions = TextureOptions.None /* Metadata: 0x00660A71 */, bool ignoreExtras = false /* Metadata: 0x00660A72 */, DrawPhase phase = DrawPhase.Content /* Metadata: 0x00660A73 */, int userData = 0 /* Metadata: 0x00660A74 */); // 0x000000018240EB90-0x000000018240EFA0
		private static bool CheckExtras<T>(NativeSlice<T> slice, string name, int expectedLength)
			where T : struct;
		private NativeSlice<T> DropDisabledChannel<T>(NativeSlice<T> slice, string name, ExtraVertexChannels channel)
			where T : struct;
		public void DrawMesh(Entry parentEntry, NativeSlice<Vertex> vertices, NativeSlice<ushort> indices, TextureId textureId, bool isPremultiplied = false /* Metadata: 0x00660A75 */, bool samplesGammaSource = false /* Metadata: 0x00660A76 */, DrawPhase phase = DrawPhase.Content /* Metadata: 0x00660A77 */, int userData = 0 /* Metadata: 0x00660A78 */); // 0x000000018240EFA0-0x000000018240F0F0
		public void DrawRasterText(Entry parentEntry, NativeSlice<Vertex> vertices, NativeSlice<ushort> indices, Texture texture, bool multiChannel, bool usesPerGlyphTextCoreSettings = false /* Metadata: 0x00660A79 */, DrawPhase phase = DrawPhase.Content /* Metadata: 0x00660A7A */); // 0x000000018240F220-0x000000018240F310
		public void DrawSdfText(Entry parentEntry, NativeSlice<Vertex> vertices, NativeSlice<ushort> indices, Texture texture, float scale, float sharpness, bool usesPerGlyphTextCoreSettings = false /* Metadata: 0x00660A7B */, DrawPhase phase = DrawPhase.Content /* Metadata: 0x00660A7C */); // 0x000000018240F310-0x000000018240F3F0
		public void DrawGradients(Entry parentEntry, NativeSlice<Vertex> vertices, NativeSlice<ushort> indices, VectorImage gradientsOwner, DrawPhase phase = DrawPhase.Content /* Metadata: 0x00660A7D */, int userData = 0 /* Metadata: 0x00660A7E */); // 0x000000018240EAD0-0x000000018240EB90
		public void DrawChildren(Entry parentEntry); // 0x000000018240EA90-0x000000018240EAD0
		public void BeginStencilMask(Entry parentEntry); // 0x000000018240EA10-0x000000018240EA50
		public void EndStencilMask(Entry parentEntry); // 0x000000018240F430-0x000000018240F470
		public void PopStencilMask(Entry parentEntry); // 0x000000018240F600-0x000000018240F640
		public void PushClippingRect(Entry parentEntry); // 0x000000018240F640-0x000000018240F680
		public void PopClippingRect(Entry parentEntry); // 0x000000018240F500-0x000000018240F540
		public void PushScissors(Entry parentEntry); // 0x000000018240F800-0x000000018240F840
		public void PopScissors(Entry parentEntry); // 0x000000018240F5C0-0x000000018240F600
		public void PushGroupMatrix(Entry parentEntry); // 0x000000018240F7C0-0x000000018240F800
		public void PopGroupMatrix(Entry parentEntry); // 0x000000018240F580-0x000000018240F5C0
		public void PushDefaultMaterial(Entry parentEntry, UnmanagedMaterialDefinition matDef); // 0x000000018240F680-0x000000018240F7C0
		public void PopDefaultMaterial(Entry parentEntry); // 0x000000018240F540-0x000000018240F580
		public void CutRenderChain(Entry parentEntry); // 0x000000018240EA50-0x000000018240EA90
		public void BeginPanelComponent(Entry parentEntry, EntityId panelComponentId); // 0x000000018240E9C0-0x000000018240EA10
		public void EndPanelComponent(Entry parentEntry); // 0x000000018240F3F0-0x000000018240F430
		public void GenerateBackdropFilterTexture(Entry parentEntry); // 0x000000018240F470-0x000000018240F4B0
		public Entry InsertPlaceholder(Entry parentEntry); // 0x000000018240F4B0-0x000000018240F500
		private static void AppendMeshEntry(Entry parentEntry, Entry entry); // 0x000000018240E740-0x000000018240E8D0
		private static void Append(Entry parentEntry, Entry entry); // 0x000000018240E8D0-0x000000018240E9C0
	}
}
