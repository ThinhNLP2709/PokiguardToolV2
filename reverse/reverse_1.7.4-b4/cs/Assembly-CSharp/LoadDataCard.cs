/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class LoadDataCard : MonoBehaviour // TypeDefIndex: 2415
{
	// Fields
	public GameObject boardCardPanel; // 0x20
	public GameObject itemPrefab; // 0x28
	public Texture2D fallbackTexture; // 0x30
	public ApiLoadRoom apiLoadRoom; // 0x38

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass5_0 // TypeDefIndex: 2416
	{
		// Fields
		public string iconName; // 0x10
		public LoadDataCard __4__this; // 0x18

		// Constructors
		public __c__DisplayClass5_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadCard_b__0(); // 0x0000000180B6BA70-0x0000000180B6BBA0
	}

	// Constructors
	public LoadDataCard(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public void LoadCard(ChooseCard[] listChooseCard); // 0x0000000180B6ACC0-0x0000000180B6B950
	private void OnImageButtonClick(string name); // 0x0000000180B6B950-0x0000000180B6BA70
}

