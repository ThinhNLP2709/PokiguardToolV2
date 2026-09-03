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
	public struct StyleTextAutoSize : IStyleValue<UnityEngine.UIElements.TextAutoSize>, IEquatable<UnityEngine.UIElements.StyleTextAutoSize> // TypeDefIndex: 4820
	{
		// Fields
		private StyleKeyword m_Keyword; // 0x00
		private TextAutoSize m_Value; // 0x04
	
		// Properties
		public TextAutoSize value { get; set; } // 0x00000001823BA030-0x00000001823BA060 0x00000001823B9FE0-0x00000001823BA000
		public StyleKeyword keyword { get; set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
	
		// Constructors
		public StyleTextAutoSize(TextAutoSize v); // 0x00000001823B9FE0-0x00000001823BA000
		public StyleTextAutoSize(StyleKeyword keyword); // 0x00000001823BA020-0x00000001823BA030
		internal StyleTextAutoSize(TextAutoSize v, StyleKeyword keyword); // 0x00000001823BA000-0x00000001823BA020
	
		// Methods
		public static bool operator ==(StyleTextAutoSize lhs, StyleTextAutoSize rhs); // 0x00000001823BA060-0x00000001823BA0B0
		public static implicit operator StyleTextAutoSize(StyleKeyword keyword); // 0x00000001823BA0D0-0x00000001823BA0F0
		public static implicit operator StyleTextAutoSize(TextAutoSize v); // 0x00000001823BA0B0-0x00000001823BA0D0
		public bool Equals(StyleTextAutoSize other); // 0x00000001823B9DC0-0x00000001823B9E40
		public override bool Equals(object obj); // 0x00000001823B9E40-0x00000001823B9F30
		public override int GetHashCode(); // 0x00000001823B9F30-0x00000001823B9F70
		public override string ToString(); // 0x00000001823B9F70-0x00000001823B9FE0
	}
}
