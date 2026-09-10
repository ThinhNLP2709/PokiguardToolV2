/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PokyHome;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class InfoPlayerSettingsLink : MonoBehaviour // TypeDefIndex: 2402
	{
		// Fields
		public const string FLAG_SETTINGS = "infoplayer.settings"; // Metadata: 0x0068EF42
		public const string N_BTN = "btn_Settings"; // Metadata: 0x0068EF56
		private const string N_TOP_RIGHT = "sec_TopRight"; // Metadata: 0x0068EF63
		private const string GEAR_SPRITE = "Image/petK/btnEdit"; // Metadata: 0x0068EF70
		private const float DROP = 96f; // Metadata: 0x0068EF83
		private const string MSG_UNAVAILABLE = "Ch\u01B0a m\u1EDF \u0111\u01B0\u1EE3c C\u00E0i \u0111\u1EB7t, th\u1EED l\u1EA1i sau."; // Metadata: 0x0068EF87
		private GameObject _button; // 0x20
		private bool _built; // 0x28
	
		// Constructors
		public InfoPlayerSettingsLink(); // 0x00000001802EBA70-0x00000001802EBAF0
	
		// Methods
		public void EnsureBuilt(); // 0x00000001807E3E00-0x00000001807E45E0
		public void SetVisible(bool on); // 0x00000001807E4920-0x00000001807E49B0
		public void OpenSettings(); // 0x00000001807E45E0-0x00000001807E4810
		private static PokySettingsPopup ResolveHubSettings(); // 0x00000001807E4810-0x00000001807E4920
	}
}
