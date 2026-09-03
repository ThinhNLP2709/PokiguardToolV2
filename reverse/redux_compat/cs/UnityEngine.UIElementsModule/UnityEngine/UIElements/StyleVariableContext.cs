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
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
	internal class StyleVariableContext // TypeDefIndex: 4814
	{
		// Fields
		public static readonly StyleVariableContext none; // 0x00
		private int m_VariableHash; // 0x10
		private List<StyleVariable> m_Variables; // 0x18
		private List<int> m_SortedHash; // 0x20
	
		// Nested types
		[CompilerGenerated]
		private struct __c__DisplayClass6_0 // TypeDefIndex: 4815
		{
			// Fields
			public int hash; // 0x00
		}
	
		// Constructors
		public StyleVariableContext(); // 0x00000001823BADB0-0x00000001823BAE80
		public StyleVariableContext(StyleVariableContext other); // 0x00000001823BACB0-0x00000001823BADB0
		static StyleVariableContext(); // 0x00000001823BAB90-0x00000001823BACB0
	
		// Methods
		public void Add(StyleVariable sv); // 0x00000001823BA770-0x00000001823BAA10
		public void AddInitialRange(StyleVariableContext other); // 0x00000001823BA690-0x00000001823BA770
		public void Clear(); // 0x00000001823BAA10-0x00000001823BAA70
		public bool TryFindVariable(int nameId, out StyleVariable v); // 0x00000001823BAA70-0x00000001823BAB80
		public int GetVariableHash(); // 0x00000001802E64B0-0x00000001802E64C0
		[CompilerGenerated]
		internal static int _Add_g__ComputeOrderSensitiveHash_6_0(int index, ref __c__DisplayClass6_0 param_000078dc); // 0x00000001823BAB80-0x00000001823BAB90
	}
}
