/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyGiftBoxSkin : MonoBehaviour // TypeDefIndex: 2680
	{
		// Fields
		public const string SKIN_KEY = "PanelGiftBox"; // Metadata: 0x005F27A7
		public const string RESOURCE_PATH = "UIPanels/PanelGiftBox_Poky"; // Metadata: 0x005F27B4
		private const string NODE_RESULT = "PanelResult"; // Metadata: 0x005F27CF
		private const string NODE_LIST = "ListReward"; // Metadata: 0x005F27DB
		private const string NODE_BUTTON = "btnGet"; // Metadata: 0x005F27E6
		private const string NODE_TITLE = "txtTitle"; // Metadata: 0x005F27ED
		private Transform _result; // 0x20
		private PokySkinCanvasFit _fit; // 0x28
	
		// Constructors
		public PokyGiftBoxSkin(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		private void OnEnable(); // 0x0000000180C43010-0x0000000180C43020
		private void OnDisable(); // 0x0000000180C43010-0x0000000180C43020
		private void RestoreResultScale(); // 0x0000000180C43020-0x0000000180C43650
		public static bool TryApply(ManagerQuangTruong qt); // 0x0000000180C43650-0x0000000180C43F80
		private static string Validate(GameObject skin); // 0x0000000180C43F80-0x0000000180C44570
	}
}
