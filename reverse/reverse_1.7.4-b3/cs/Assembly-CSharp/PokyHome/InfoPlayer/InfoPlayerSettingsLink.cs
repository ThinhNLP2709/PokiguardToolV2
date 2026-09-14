/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class InfoPlayerSettingsLink : MonoBehaviour // TypeDefIndex: 2847
	{
		// Fields
		public const string FLAG_SETTINGS = "infoplayer.settings"; // Metadata: 0x005F1DC6
		public const string N_BTN = "btn_Settings"; // Metadata: 0x005F1DDA
		private const string N_TOP_RIGHT = "sec_TopRight"; // Metadata: 0x005F1DE7
		private const string GEAR_SPRITE = "Image/petK/btnEdit"; // Metadata: 0x005F1DF4
		private const float DROP = 96f; // Metadata: 0x005F1E07
		private GameObject _button; // 0x20
		private bool _built; // 0x28
	
		// Constructors
		public InfoPlayerSettingsLink(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		public void EnsureBuilt(); // 0x0000000180D027A0-0x0000000180D03640
		public void SetVisible(bool on); // 0x0000000180D03640-0x0000000180D037A0
		public void OpenSettings(); // 0x0000000180D037A0-0x0000000180D038B0
	}
}
