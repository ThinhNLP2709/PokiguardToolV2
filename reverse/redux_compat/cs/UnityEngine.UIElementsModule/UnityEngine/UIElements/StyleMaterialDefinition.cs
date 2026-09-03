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

namespace UnityEngine.UIElements
{
	[Serializable]
	public struct StyleMaterialDefinition : IStyleValue<MaterialDefinition>, IEquatable<StyleMaterialDefinition> // TypeDefIndex: 4672
	{
		// Fields
		[SerializeField]
		private MaterialDefinition m_Value; // 0x00
		[SerializeField]
		private StyleKeyword m_Keyword; // 0x10
	
		// Properties
		public MaterialDefinition value { get; set; } // 0x00000001825630C0-0x00000001825630E0 0x00000001825659F0-0x0000000182565A20
		public StyleKeyword keyword { get; set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
	
		// Constructors
		public StyleMaterialDefinition(MaterialDefinition m); // 0x00000001825658C0-0x00000001825658E0
		public StyleMaterialDefinition(StyleKeyword keyword); // 0x00000001825658E0-0x0000000182565920
		internal StyleMaterialDefinition(MaterialDefinition m, StyleKeyword keyword); // 0x00000001825658A0-0x00000001825658C0
	
		// Methods
		public static bool operator ==(StyleMaterialDefinition lhs, StyleMaterialDefinition rhs); // 0x0000000182565920-0x0000000182565970
		public static implicit operator StyleMaterialDefinition(StyleKeyword keyword); // 0x0000000182565970-0x00000001825659C0
		public static implicit operator StyleMaterialDefinition(MaterialDefinition m); // 0x00000001825659C0-0x00000001825659F0
		public bool Equals(StyleMaterialDefinition other); // 0x0000000182565650-0x00000001825656D0
		public override bool Equals(object obj); // 0x00000001825656D0-0x00000001825657C0
		public override int GetHashCode(); // 0x00000001825657C0-0x0000000182565830
		public override string ToString(); // 0x0000000182565830-0x00000001825658A0
	}
}
