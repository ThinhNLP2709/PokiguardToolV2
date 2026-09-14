/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class StarEventManager : MonoBehaviour // TypeDefIndex: 2118
{
	// Fields
	public static StarEventManager Instance; // 0x00
	[CompilerGenerated]
	private Action<int, int, int> OnStarCountChanged; // 0x20

	// Events
	public event Action<int, int, int> OnStarCountChanged {
		add; // 0x0000000180A04620-0x0000000180A04740
		remove; // 0x0000000180A04740-0x0000000180A04860
	}

	// Constructors
	public StarEventManager(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x0000000180A04860-0x0000000180A04A40
	public void UpdateStarCount(int white, int blue, int red); // 0x0000000180A04A40-0x0000000180A04B60
}

