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
	public struct StyleUIAnimationClip : IStyleValue<UnityEngine.UIElements.UIAnimationClip>, IEquatable<UnityEngine.UIElements.StyleUIAnimationClip> // TypeDefIndex: 4682
	{
		// Fields
		private UIAnimationClip m_Value; // 0x00
		private StyleKeyword m_Keyword; // 0x08
	
		// Properties
		public UIAnimationClip value { get; set; } // 0x0000000182562580-0x0000000182562590 0x000000018171B230-0x000000018171B250
		public StyleKeyword keyword { get; set; } // 0x0000000180732D20-0x0000000180732D30 0x0000000180732D60-0x0000000180732D70
	
		// Constructors
		public StyleUIAnimationClip(UIAnimationClip v); // 0x0000000182564E10-0x0000000182564E20
		public StyleUIAnimationClip(StyleKeyword keyword); // 0x00000001815046B0-0x00000001815046D0
		internal StyleUIAnimationClip(UIAnimationClip v, StyleKeyword keyword); // 0x0000000182564E00-0x0000000182564E10
	
		// Methods
		public static bool operator ==(StyleUIAnimationClip lhs, StyleUIAnimationClip rhs); // 0x000000018256E1D0-0x000000018256E240
		public static implicit operator StyleUIAnimationClip(StyleKeyword keyword); // 0x0000000182564E90-0x0000000182564EC0
		public static implicit operator StyleUIAnimationClip(UIAnimationClip v); // 0x0000000182564EC0-0x0000000182564EE0
		public bool Equals(StyleUIAnimationClip other); // 0x000000018256E060-0x000000018256E0E0
		public override bool Equals(object obj); // 0x000000018256DF60-0x000000018256E060
		public override int GetHashCode(); // 0x000000018256E0E0-0x000000018256E170
		public override string ToString(); // 0x000000018256E170-0x000000018256E1D0
	}
}
