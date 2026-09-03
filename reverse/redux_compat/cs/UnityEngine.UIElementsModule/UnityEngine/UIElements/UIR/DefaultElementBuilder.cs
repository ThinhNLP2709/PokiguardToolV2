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
	internal class DefaultElementBuilder : BaseElementBuilder // TypeDefIndex: 5022
	{
		// Fields
		private RenderTreeManager m_RenderTreeManager; // 0x10
	
		// Constructors
		public DefaultElementBuilder(RenderTreeManager renderTreeManager); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public override bool RequiresStencilMask(VisualElement ve); // 0x00000001823F8440-0x00000001823F8560
		protected override void DrawVisualElementBackdrop(MeshGenerationContext mgc); // 0x00000001823F56A0-0x00000001823F5D10
		protected override void DrawVisualElementBackground(MeshGenerationContext mgc); // 0x00000001823F5D10-0x00000001823F5D20
		private void DrawVisualElementBackground(MeshGenerationContext mgc, DrawPhase phase); // 0x00000001823F5D20-0x00000001823F7720
		protected override void DrawVisualElementBorder(MeshGenerationContext mgc); // 0x00000001823F7720-0x00000001823F7CC0
		protected override void DrawVisualElementStencilMask(MeshGenerationContext mgc); // 0x00000001823F7CC0-0x00000001823F7D60
		private static void GenerateStencilClipEntryForRoundedRectBackground(MeshGenerationContext mgc); // 0x00000001823F7D60-0x00000001823F8440
		public override void ScheduleMeshGenerationJobs(MeshGenerationContext mgc); // 0x00000001823F8560-0x00000001823F8650
	}
}
