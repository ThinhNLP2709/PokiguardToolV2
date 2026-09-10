/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class FindMatches : MonoBehaviour // TypeDefIndex: 1934
{
	// Fields
	[CompilerGenerated]
	private static FindMatches _Instance_k__BackingField; // 0x00
	private Board _board; // 0x20
	private BoardPVP _boardPVP; // 0x28
	public List<GameObject> currentMatches; // 0x30

	// Properties
	public static FindMatches Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806FBAD0-0x00000001806FBB10 0x00000001806FBBD0-0x00000001806FBC30
	private bool IsPVP { get; } // 0x00000001806FBB10-0x00000001806FBBD0 
	private int BoardWidth { get; } // 0x00000001806FBA80-0x00000001806FBAD0 
	private int BoardHeight { get; } // 0x00000001806FBA30-0x00000001806FBA80 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1935
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<int, int, GameObject> __9__19_1; // 0x08

		// Constructors
		static __c(); // 0x00000001807106B0-0x0000000180710720
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal GameObject _VirtualFindAllMatches_b__19_1(int x, int y); // 0x000000018070FEA0-0x000000018070FF80
	}

	// Constructors
	public FindMatches(); // 0x00000001806FB9B0-0x00000001806FBA30

	// Methods
	private void Awake(); // 0x00000001806FA950-0x00000001806FAA40
	private void OnDestroy(); // 0x00000001806FB130-0x00000001806FB200
	private GameObject GetDot(int x, int y); // 0x00000001806FB090-0x00000001806FB130
	private void Start(); // 0x00000001806FB200-0x00000001806FB350
	public void FindAllMatches(); // 0x00000001806FAA40-0x00000001806FB090
	private void AddToCurrentMatches(GameObject dot); // 0x00000001806FA880-0x00000001806FA950
	public void VirtualFindAllMatches(HashSet<GameObject> matches); // 0x00000001806FB3A0-0x00000001806FB9B0
	[CompilerGenerated]
	private GameObject _VirtualFindAllMatches_b__19_0(int x, int y); // 0x00000001806FB350-0x00000001806FB3A0
}

