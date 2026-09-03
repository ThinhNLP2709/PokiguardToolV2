/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class LoadDataCard : MonoBehaviour // TypeDefIndex: 1735
{
	// Fields
	public GameObject boardCardPanel; // 0x20
	public GameObject itemPrefab; // 0x28
	public Texture2D fallbackTexture; // 0x30
	public ApiLoadRoom apiLoadRoom; // 0x38

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass5_0 // TypeDefIndex: 1736
	{
		// Fields
		public string iconName; // 0x10
		public LoadDataCard __4__this; // 0x18

		// Constructors
		public __c__DisplayClass5_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadCard_b__0(); // 0x00000001805E8FF0-0x00000001805E9070
	}

	// Constructors
	public LoadDataCard(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Start(); // 0x00000001802E76C0-0x00000001802E76D0
	public void LoadCard(ChooseCard[] listChooseCard); // 0x00000001805DE580-0x00000001805DEDD0
	private void OnImageButtonClick(string name); // 0x00000001805DEDD0-0x00000001805DEE40
}

