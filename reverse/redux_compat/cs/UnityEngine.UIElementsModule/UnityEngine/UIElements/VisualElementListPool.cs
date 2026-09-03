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

namespace UnityEngine.UIElements
{
	internal static class VisualElementListPool // TypeDefIndex: 4938
	{
		// Fields
		private static ObjectPool<List<VisualElement>> pool; // 0x00
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4939
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001823D3BB0-0x00000001823D3C20
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal List<VisualElement> _.cctor_b__4_0(); // 0x00000001823D3780-0x00000001823D37E0
		}
	
		// Constructors
		static VisualElementListPool(); // 0x00000001823E59C0-0x00000001823E5AD0
	
		// Methods
		public static List<VisualElement> Copy(List<VisualElement> elements); // 0x00000001823E57B0-0x00000001823E5860
		public static List<VisualElement> Get(int initialCapacity = 0 /* Metadata: 0x00660956 */); // 0x00000001823E5860-0x00000001823E5920
		public static void Release(List<VisualElement> elements); // 0x00000001823E5920-0x00000001823E59C0
	}
}
