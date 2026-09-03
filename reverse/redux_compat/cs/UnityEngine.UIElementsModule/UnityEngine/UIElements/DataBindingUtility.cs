/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text.RegularExpressions;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Pool;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Internal;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
	internal static class DataBindingUtility // TypeDefIndex: 3849
	{
		// Fields
		private static readonly ObjectPool<TypePathVisitor> k_TypeVisitors; // 0x00
		private static readonly ObjectPool<AutoCompletePathVisitor> k_AutoCompleteVisitors; // 0x08
		private static readonly Regex s_ReplaceIndices; // 0x10
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 3850
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x0000000182393610-0x0000000182393680
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal TypePathVisitor _.cctor_b__25_0(); // 0x0000000182392DF0-0x0000000182392E40
			internal void _.cctor_b__25_1(TypePathVisitor v); // 0x0000000182392E40-0x0000000182392E60
			internal AutoCompletePathVisitor _.cctor_b__25_2(); // 0x0000000182392E60-0x0000000182392EB0
			internal void _.cctor_b__25_3(AutoCompletePathVisitor v); // 0x0000000182392EB0-0x0000000182392ED0
		}
	
		// Constructors
		static DataBindingUtility(); // 0x0000000182389180-0x00000001823894A0
	
		// Methods
		public static bool TryGetBinding(VisualElement element, [IsReadOnly] in BindingId bindingId, out BindingInfo bindingInfo); // 0x0000000182388B80-0x0000000182389180
	}
}
