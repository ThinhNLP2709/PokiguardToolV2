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
	[Serializable]
	[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
	internal struct StyleSelectorPart // TypeDefIndex: 4800
	{
		// Fields
		[SerializeField]
		private string m_Value; // 0x00
		[SerializeField]
		private StyleSelectorType m_Type; // 0x08
		internal object tempData; // 0x10
		[NonSerialized]
		internal int cachedUniqueStyleStringId; // 0x18
	
		// Properties
		public string value { get; [VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })] internal set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180E02C90-0x0000000180E02CA0
		public StyleSelectorType type { get; [VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })] internal set; } // 0x0000000180732D20-0x0000000180732D30 0x0000000180732D60-0x0000000180732D70
	
		// Methods
		public override string ToString(); // 0x0000000182569B50-0x0000000182569BC0
		public override bool Equals(object obj); // 0x0000000182569A60-0x0000000182569AF0
		public override int GetHashCode(); // 0x0000000182569AF0-0x0000000182569B50
		public static StyleSelectorPart CreateClass(string className); // 0x00000001825699D0-0x0000000182569A00
		public static StyleSelectorPart CreateId(string Id); // 0x0000000182569A00-0x0000000182569A30
		public static StyleSelectorPart CreatePredicate(object predicate); // 0x0000000182569A30-0x0000000182569A60
	}
}
