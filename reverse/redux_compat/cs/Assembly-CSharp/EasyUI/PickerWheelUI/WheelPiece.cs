/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace EasyUI.PickerWheelUI
{
	[Serializable]
	public class WheelPiece // TypeDefIndex: 1969
	{
		// Fields
		public Sprite Icon; // 0x10
		public string Label; // 0x18
		[Tooltip("Reward amount")]
		public int Amount; // 0x20
		[Tooltip("M\u1EA3nh pet / m\u1EA3nh v\u0169 kh\u00ED \u2014 v\u1EBD khung m\u1EA3nh \u0111\u00E8 l\u00EAn icon")]
		public bool IsShard; // 0x24
		[Range(0f, 100f)]
		[Tooltip("Probability in %")]
		public float Chance; // 0x28
		[HideInInspector]
		public int Index; // 0x2C
		[HideInInspector]
		public double _weight; // 0x30
	
		// Constructors
		public WheelPiece(); // 0x0000000180670C20-0x0000000180670F30
	}
}
