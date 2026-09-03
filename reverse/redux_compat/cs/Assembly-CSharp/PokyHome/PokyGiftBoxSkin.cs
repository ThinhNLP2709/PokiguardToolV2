/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyGiftBoxSkin : MonoBehaviour // TypeDefIndex: 1911
	{
		// Fields
		public const string SKIN_KEY = "PanelGiftBox"; // Metadata: 0x0064DE5C
		public const string RESOURCE_PATH = "UIPanels/PanelGiftBox_Poky"; // Metadata: 0x0064DE69
		private const string NODE_RESULT = "PanelResult"; // Metadata: 0x0064DE84
		private const string NODE_LIST = "ListReward"; // Metadata: 0x0064DE90
		private const string NODE_BUTTON = "btnGet"; // Metadata: 0x0064DE9B
		private const string NODE_TITLE = "txtTitle"; // Metadata: 0x0064DEA2
		private Transform _result; // 0x20
		private PokySkinCanvasFit _fit; // 0x28
	
		// Constructors
		public PokyGiftBoxSkin(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		private void OnEnable(); // 0x0000000180642A90-0x0000000180642AA0
		private void OnDisable(); // 0x0000000180642A90-0x0000000180642AA0
		private void RestoreResultScale(); // 0x0000000180642AA0-0x0000000180642CB0
		public static bool TryApply(ManagerQuangTruong qt); // 0x0000000180642CB0-0x00000001806431C0
		private static string Validate(GameObject skin); // 0x00000001806431C0-0x0000000180643440
	}
}
