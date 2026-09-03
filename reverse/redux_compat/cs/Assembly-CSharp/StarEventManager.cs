/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class StarEventManager : MonoBehaviour // TypeDefIndex: 1507
{
	// Fields
	public static StarEventManager Instance; // 0x00
	[CompilerGenerated]
	private Action<int, int, int> OnStarCountChanged; // 0x20

	// Events
	public event Action<int, int, int> OnStarCountChanged {
		add; // 0x0000000180573BC0-0x0000000180573C80
		remove; // 0x0000000180573C80-0x0000000180573D40
	}

	// Constructors
	public StarEventManager(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Awake(); // 0x0000000180573A20-0x0000000180573AF0
	public void UpdateStarCount(int white, int blue, int red); // 0x0000000180573AF0-0x0000000180573BC0
}

