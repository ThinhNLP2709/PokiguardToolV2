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
	internal abstract class BaseElementBuilder // TypeDefIndex: 5021
	{
		// Constructors
		protected BaseElementBuilder(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public abstract bool RequiresStencilMask(VisualElement ve);
		public void Build(MeshGenerationContext mgc); // 0x00000001823F07E0-0x00000001823F0820
		private void BuildRenderTreeQuadElement(MeshGenerationContext mgc); // 0x00000001823EF960-0x00000001823EFFB0
		private void BuildStandardElement(MeshGenerationContext mgc); // 0x00000001823EFFB0-0x00000001823F07E0
		protected abstract void DrawVisualElementBackdrop(MeshGenerationContext mgc);
		protected abstract void DrawVisualElementBackground(MeshGenerationContext mgc);
		protected abstract void DrawVisualElementBorder(MeshGenerationContext mgc);
		protected abstract void DrawVisualElementStencilMask(MeshGenerationContext mgc);
		public abstract void ScheduleMeshGenerationJobs(MeshGenerationContext mgc);
		private void PushVisualElementClipping(MeshGenerationContext mgc); // 0x00000001823F0A30-0x00000001823F0B90
		private static void PopVisualElementClipping(MeshGenerationContext mgc); // 0x00000001823F0930-0x00000001823F0A30
		private static void InvokeGenerateVisualContent(MeshGenerationContext mgc); // 0x00000001823F0820-0x00000001823F0930
	}
}
