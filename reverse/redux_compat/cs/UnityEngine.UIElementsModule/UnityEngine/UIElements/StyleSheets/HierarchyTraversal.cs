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

namespace UnityEngine.UIElements.StyleSheets
{
	internal abstract class HierarchyTraversal // TypeDefIndex: 5218
	{
		// Constructors
		protected HierarchyTraversal(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public virtual void Traverse(VisualElement element); // 0x00000001824366D0-0x00000001824366F0
		public abstract void TraverseRecursive(VisualElement element, int depth);
		protected void Recurse(VisualElement element, int depth); // 0x0000000182436600-0x00000001824366D0
	}
}
