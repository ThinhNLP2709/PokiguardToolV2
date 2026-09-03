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
	public class PokyQuestProgressBar : MonoBehaviour // TypeDefIndex: 1925
	{
		// Fields
		[Tooltip("\u00D4 ch\u1EEF m\u00E0 ManagerQuest ghi \'m\u00F4 t\u1EA3 (a/b)\' v\u00E0o.")]
		public UnityEngine.UI.Text source; // 0x20
		[Tooltip("\u1EA2nh Filled c\u1EE7a thanh (item-bar).")]
		public Image fill; // 0x28
		[Tooltip("\u1EA8n c\u1EA3 thanh khi kh\u00F4ng \u0111\u1ECDc \u0111\u01B0\u1EE3c c\u1EB7p s\u1ED1 (th\u00E0 tr\u1ED1ng c\u00F2n h\u01A1n v\u1EBD sai).")]
		public GameObject barRoot; // 0x30
	
		// Constructors
		public PokyQuestProgressBar(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		private void OnEnable(); // 0x000000018064BB40-0x000000018064BB50
		private void LateUpdate(); // 0x000000018064B9C0-0x000000018064BB40
		private void Apply(string text); // 0x000000018064B8B0-0x000000018064B9C0
		public static bool TryParseRatio(string s, out float ratio); // 0x000000018064BB50-0x000000018064BCD0
	}
}
