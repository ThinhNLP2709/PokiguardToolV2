/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyQuestProgressBar : MonoBehaviour // TypeDefIndex: 2694
	{
		// Fields
		[Tooltip("\u00D4 ch\u1EEF m\u00E0 ManagerQuest ghi \'m\u00F4 t\u1EA3 (a/b)\' v\u00E0o.")]
		public UnityEngine.UI.Text source; // 0x20
		[Tooltip("\u1EA2nh Filled c\u1EE7a thanh (item-bar).")]
		public Image fill; // 0x28
		[Tooltip("\u1EA8n c\u1EA3 thanh khi kh\u00F4ng \u0111\u1ECDc \u0111\u01B0\u1EE3c c\u1EB7p s\u1ED1 (th\u00E0 tr\u1ED1ng c\u00F2n h\u01A1n v\u1EBD sai).")]
		public GameObject barRoot; // 0x30
	
		// Constructors
		public PokyQuestProgressBar(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		private void OnEnable(); // 0x0000000180C52EF0-0x0000000180C52F70
		private void LateUpdate(); // 0x0000000180C52F70-0x0000000180C530F0
		private void Apply(string text); // 0x0000000180C530F0-0x0000000180C53350
		public static bool TryParseRatio(string s, out float ratio); // 0x0000000180C53350-0x0000000180C53500
	}
}
