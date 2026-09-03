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
	public struct StyleBackgroundRepeat : IStyleValue<BackgroundRepeat>, IEquatable<StyleBackgroundRepeat> // TypeDefIndex: 4658
	{
		// Fields
		[SerializeField]
		private BackgroundRepeat m_Value; // 0x00
		[SerializeField]
		private StyleKeyword m_Keyword; // 0x08
	
		// Properties
		public BackgroundRepeat value { get; set; } // 0x0000000182562580-0x0000000182562590 0x000000018222AF70-0x000000018222AF80
		public StyleKeyword keyword { get; set; } // 0x0000000180732D20-0x0000000180732D30 0x0000000180732D60-0x0000000180732D70
	
		// Constructors
		public StyleBackgroundRepeat(BackgroundRepeat v); // 0x0000000182562550-0x0000000182562560
		public StyleBackgroundRepeat(StyleKeyword keyword); // 0x0000000182562570-0x0000000182562580
		internal StyleBackgroundRepeat(BackgroundRepeat v, StyleKeyword keyword); // 0x0000000182562560-0x0000000182562570
	
		// Methods
		public static bool operator ==(StyleBackgroundRepeat lhs, StyleBackgroundRepeat rhs); // 0x0000000182562590-0x00000001825625B0
		public static implicit operator StyleBackgroundRepeat(StyleKeyword keyword); // 0x00000001825625C0-0x00000001825625D0
		public static implicit operator StyleBackgroundRepeat(BackgroundRepeat v); // 0x00000001825625B0-0x00000001825625C0
		public bool Equals(StyleBackgroundRepeat other); // 0x00000001825623A0-0x0000000182562400
		public override bool Equals(object obj); // 0x0000000182562400-0x00000001825624C0
		public override int GetHashCode(); // 0x00000001825624C0-0x00000001825624E0
		public override string ToString(); // 0x00000001825624E0-0x0000000182562550
	}
}
