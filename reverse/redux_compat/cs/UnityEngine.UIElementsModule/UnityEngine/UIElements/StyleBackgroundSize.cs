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
	public struct StyleBackgroundSize : IStyleValue<BackgroundSize>, IEquatable<StyleBackgroundSize> // TypeDefIndex: 4659
	{
		// Fields
		[SerializeField]
		private BackgroundSize m_Value; // 0x00
		[SerializeField]
		private StyleKeyword m_Keyword; // 0x14
	
		// Properties
		public BackgroundSize value { get; set; } // 0x0000000182562870-0x00000001825628A0 0x0000000182562850-0x0000000182562870
		public StyleKeyword keyword { get; set; } // 0x0000000180A5E110-0x0000000180A5E120 0x0000000180E02550-0x0000000180E02560
	
		// Constructors
		public StyleBackgroundSize(BackgroundSize v); // 0x0000000182562850-0x0000000182562870
		public StyleBackgroundSize(StyleKeyword keyword); // 0x0000000182562840-0x0000000182562850
		internal StyleBackgroundSize(BackgroundSize v, StyleKeyword keyword); // 0x0000000182562820-0x0000000182562840
	
		// Methods
		public static bool operator ==(StyleBackgroundSize lhs, StyleBackgroundSize rhs); // 0x00000001825628A0-0x0000000182562910
		public static implicit operator StyleBackgroundSize(StyleKeyword keyword); // 0x0000000182562930-0x0000000182562950
		public static implicit operator StyleBackgroundSize(BackgroundSize v); // 0x0000000182562910-0x0000000182562930
		public bool Equals(StyleBackgroundSize other); // 0x00000001825626F0-0x0000000182562790
		public override bool Equals(object obj); // 0x00000001825625D0-0x00000001825626F0
		public override int GetHashCode(); // 0x0000000182562790-0x00000001825627B0
		public override string ToString(); // 0x00000001825627B0-0x0000000182562820
	}
}
