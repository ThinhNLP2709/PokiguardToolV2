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
	public struct StyleRatio : IStyleValue<UnityEngine.UIElements.Ratio>, IEquatable<UnityEngine.UIElements.StyleRatio> // TypeDefIndex: 4673
	{
		// Fields
		private Ratio m_Value; // 0x00
		private StyleKeyword m_Keyword; // 0x04
	
		// Properties
		public Ratio value { get; set; } // 0x00000001825689E0-0x00000001825689F0 0x0000000180DF9550-0x0000000180DF9560
		public StyleKeyword keyword { get; set; } // 0x00000001802E7C60-0x00000001802E7DA0 0x0000000182568A80-0x0000000182568A90
	
		// Constructors
		public StyleRatio(Ratio value); // 0x0000000180DF8E10-0x0000000180DF8E20
		public StyleRatio(StyleKeyword keyword); // 0x00000001825689D0-0x00000001825689E0
		internal StyleRatio(Ratio value, StyleKeyword keyword); // 0x0000000180DF8E20-0x0000000180DF8E30
	
		// Methods
		public static StyleRatio Auto(); // 0x00000001825687F0-0x0000000182568810
		internal bool IsAuto(); // 0x0000000182544680-0x0000000182544690
		public static implicit operator StyleRatio(float value); // 0x00000001825647D0-0x00000001825647F0
		public static implicit operator StyleRatio(Ratio value); // 0x0000000180DF93D0-0x0000000180DF93F0
		public static implicit operator Ratio(StyleRatio value); // 0x0000000182568A40-0x0000000182568A60
		public static implicit operator StyleRatio(StyleKeyword value); // 0x0000000182568A60-0x0000000182568A80
		public static bool operator ==(StyleRatio lhs, StyleRatio rhs); // 0x00000001825689F0-0x0000000182568A40
		public bool Equals(StyleRatio other); // 0x0000000182568810-0x0000000182568860
		public override bool Equals(object obj); // 0x0000000182568860-0x0000000182568930
		public override int GetHashCode(); // 0x0000000182568930-0x0000000182568950
		public override string ToString(); // 0x0000000182568950-0x00000001825689D0
	}
}
