/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class InfoPlayerSettingsLink : MonoBehaviour // TypeDefIndex: 2854
	{
		// Fields
		public const string FLAG_SETTINGS = "infoplayer.settings"; // Metadata: 0x005F31DD
		public const string N_BTN = "btn_Settings"; // Metadata: 0x005F31F1
		private const string N_TOP_RIGHT = "sec_TopRight"; // Metadata: 0x005F31FE
		private const string GEAR_SPRITE = "Image/petK/btnEdit"; // Metadata: 0x005F320B
		private const float DROP = 96f; // Metadata: 0x005F321E
		private GameObject _button; // 0x20
		private bool _built; // 0x28
	
		// Constructors
		public InfoPlayerSettingsLink(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		public void EnsureBuilt(); // 0x0000000180D10100-0x0000000180D10FA0
		public void SetVisible(bool on); // 0x0000000180D10FA0-0x0000000180D11100
		public void OpenSettings(); // 0x0000000180D11100-0x0000000180D11210
	}
}
