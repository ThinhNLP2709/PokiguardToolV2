/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class FindMatches : MonoBehaviour // TypeDefIndex: 1661
{
	// Fields
	[CompilerGenerated]
	private static FindMatches _Instance_k__BackingField; // 0x00
	private Board _board; // 0x20
	private BoardPVP _boardPVP; // 0x28
	public List<GameObject> currentMatches; // 0x30

	// Properties
	public static FindMatches Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805C9DF0-0x00000001805C9E30 0x00000001805C9EF0-0x00000001805C9F50
	private bool IsPVP { get; } // 0x00000001805C9E30-0x00000001805C9EF0 
	private int BoardWidth { get; } // 0x00000001805C9DA0-0x00000001805C9DF0 
	private int BoardHeight { get; } // 0x00000001805C9D50-0x00000001805C9DA0 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1662
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<int, int, GameObject> __9__19_1; // 0x08

		// Constructors
		static __c(); // 0x00000001805D4410-0x00000001805D4480
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal GameObject _VirtualFindAllMatches_b__19_1(int x, int y); // 0x00000001805D3FD0-0x00000001805D40B0
	}

	// Constructors
	public FindMatches(); // 0x00000001805C9CD0-0x00000001805C9D50

	// Methods
	private void Awake(); // 0x00000001805C8C70-0x00000001805C8D60
	private void OnDestroy(); // 0x00000001805C9450-0x00000001805C9520
	private GameObject GetDot(int x, int y); // 0x00000001805C93B0-0x00000001805C9450
	private void Start(); // 0x00000001805C9520-0x00000001805C9670
	public void FindAllMatches(); // 0x00000001805C8D60-0x00000001805C93B0
	private void AddToCurrentMatches(GameObject dot); // 0x00000001805C8BA0-0x00000001805C8C70
	public void VirtualFindAllMatches(HashSet<GameObject> matches); // 0x00000001805C96C0-0x00000001805C9CD0
	[CompilerGenerated]
	private GameObject _VirtualFindAllMatches_b__19_0(int x, int y); // 0x00000001805C9670-0x00000001805C96C0
}

