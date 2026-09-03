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
	[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
	internal struct Specificity : IEquatable<Specificity>, IComparable<Specificity> // TypeDefIndex: 4789
	{
		// Fields
		[SerializeField]
		private int m_Score; // 0x00
	
		// Properties
		public byte idScore { get; set; } // 0x000000018166C8F0-0x000000018166C900 0x00000001825620B0-0x00000001825620C0
		public byte classScore { get; set; } // 0x0000000182562090-0x00000001825620A0 0x00000001825620A0-0x00000001825620B0
		public byte typeScore { get; set; } // 0x0000000180333490-0x00000001803334A0 0x00000001825620C0-0x00000001825620D0
	
		// Constructors
		public Specificity(int score); // 0x0000000180732D50-0x0000000180732D60
	
		// Methods
		private static byte GetValueFromMask(int value, int offset); // 0x0000000182561FA0-0x0000000182561FC0
		private static void SetValueWithMask(ref int score, byte value, int offset); // 0x0000000182561FC0-0x0000000182561FF0
		public static implicit operator int(Specificity specificity); // 0x0000000180815D70-0x0000000180815D80
		public static implicit operator Specificity(int specificityScore); // 0x0000000180815D70-0x0000000180815D80
		public override string ToString(); // 0x0000000182561FF0-0x0000000182562090
		public bool Equals(Specificity other); // 0x00000001815FCAB0-0x00000001815FCAC0
		public override bool Equals(object obj); // 0x0000000182561F20-0x0000000182561FA0
		public override int GetHashCode(); // 0x0000000180732D10-0x0000000180732D20
		public int CompareTo(Specificity other); // 0x0000000181F17C20-0x0000000181F17C30
	}
}
