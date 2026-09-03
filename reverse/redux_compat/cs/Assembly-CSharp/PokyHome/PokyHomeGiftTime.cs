/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyHomeGiftTime : MonoBehaviour // TypeDefIndex: 1879
	{
		// Fields
		[Tooltip("Node hi\u1EC7n/\u1EA9n \u2014 ch\u00EDnh node GiftTime d\u1EF1ng t\u1EEB prefab.")]
		public GameObject root; // 0x20
		[Tooltip("Khung gi\u1EDD \u0111\u1EBFm ng\u01B0\u1EE3c (node \'Image\') \u2014 \u1EA9n v\u00EC kh\u00F4ng c\u00F3 ngu\u1ED3n \u0111\u1EBFm ng\u01B0\u1EE3c.")]
		public GameObject timeFrame; // 0x28
		[Tooltip("S\u1ED1 qu\u00E0 (node \'txtQuantity\').")]
		public UnityEngine.UI.Text quantityText; // 0x30
		private int _count; // 0x38
	
		// Constructors
		public PokyHomeGiftTime(); // 0x000000018062A1E0-0x000000018062A1F0
	
		// Methods
		private void Awake(); // 0x000000018062BC40-0x000000018062BD10
		public void SetCount(int count); // 0x000000018062BD10-0x000000018062BE40
	}
}
