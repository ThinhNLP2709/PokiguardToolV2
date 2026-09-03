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
	public struct StyleBackgroundPosition : IStyleValue<BackgroundPosition>, IEquatable<StyleBackgroundPosition> // TypeDefIndex: 4657
	{
		// Fields
		[SerializeField]
		private BackgroundPosition m_Value; // 0x00
		[SerializeField]
		private StyleKeyword m_Keyword; // 0x0C
	
		// Properties
		public BackgroundPosition value { get; set; } // 0x00000001825622C0-0x0000000182562300 0x00000001825622A0-0x00000001825622C0
		public StyleKeyword keyword { get; set; } // 0x0000000180732D30-0x0000000180732D40 0x0000000180732D70-0x0000000180732D80
	
		// Constructors
		public StyleBackgroundPosition(BackgroundPosition v); // 0x00000001825622A0-0x00000001825622C0
		public StyleBackgroundPosition(StyleKeyword keyword); // 0x0000000182562280-0x00000001825622A0
		internal StyleBackgroundPosition(BackgroundPosition v, StyleKeyword keyword); // 0x0000000181E52DE0-0x0000000181E52E00
	
		// Methods
		public static bool operator ==(StyleBackgroundPosition lhs, StyleBackgroundPosition rhs); // 0x0000000182562300-0x0000000182562350
		public static implicit operator StyleBackgroundPosition(StyleKeyword keyword); // 0x0000000182562370-0x00000001825623A0
		public static implicit operator StyleBackgroundPosition(BackgroundPosition v); // 0x0000000182562350-0x0000000182562370
		public bool Equals(StyleBackgroundPosition other); // 0x00000001825621A0-0x0000000182562200
		public override bool Equals(object obj); // 0x00000001825620D0-0x00000001825621A0
		public override int GetHashCode(); // 0x0000000182562200-0x0000000182562220
		public override string ToString(); // 0x0000000182562220-0x0000000182562280
	}
}
