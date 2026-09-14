/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyGiftBoxSkin : MonoBehaviour // TypeDefIndex: 2673
	{
		// Fields
		public const string SKIN_KEY = "PanelGiftBox"; // Metadata: 0x005F1390
		public const string RESOURCE_PATH = "UIPanels/PanelGiftBox_Poky"; // Metadata: 0x005F139D
		private const string NODE_RESULT = "PanelResult"; // Metadata: 0x005F13B8
		private const string NODE_LIST = "ListReward"; // Metadata: 0x005F13C4
		private const string NODE_BUTTON = "btnGet"; // Metadata: 0x005F13CF
		private const string NODE_TITLE = "txtTitle"; // Metadata: 0x005F13D6
		private Transform _result; // 0x20
		private PokySkinCanvasFit _fit; // 0x28
	
		// Constructors
		public PokyGiftBoxSkin(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		private void OnEnable(); // 0x0000000180C35BB0-0x0000000180C35BC0
		private void OnDisable(); // 0x0000000180C35BB0-0x0000000180C35BC0
		private void RestoreResultScale(); // 0x0000000180C35BC0-0x0000000180C361F0
		public static bool TryApply(ManagerQuangTruong qt); // 0x0000000180C361F0-0x0000000180C36B20
		private static string Validate(GameObject skin); // 0x0000000180C36B20-0x0000000180C37110
	}
}
