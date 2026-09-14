/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class FindMatches : MonoBehaviour // TypeDefIndex: 2307
{
	// Fields
	[CompilerGenerated]
	private static FindMatches _Instance_k__BackingField; // 0x00
	private Board _board; // 0x20
	private BoardPVP _boardPVP; // 0x28
	public List<GameObject> currentMatches; // 0x30

	// Properties
	public static FindMatches Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180B14AA0-0x0000000180B14AE0 0x0000000180B14AE0-0x0000000180B14B80
	private bool IsPVP { get; } // 0x0000000180B14E60-0x0000000180B14FC0 
	private int BoardWidth { get; } // 0x0000000180B14FC0-0x0000000180B15010 
	private int BoardHeight { get; } // 0x0000000180B15010-0x0000000180B15060 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 2308
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<int, int, GameObject> __9__19_1; // 0x08

		// Constructors
		static __c(); // 0x0000000180B16AA0-0x0000000180B16B40
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal GameObject _VirtualFindAllMatches_b__19_1(int x, int y); // 0x0000000180B16B40-0x0000000180B16BE0
	}

	// Constructors
	public FindMatches(); // 0x0000000180B16950-0x0000000180B16A50

	// Methods
	private void Awake(); // 0x0000000180B14B80-0x0000000180B14D00
	private void OnDestroy(); // 0x0000000180B14D00-0x0000000180B14E60
	private GameObject GetDot(int x, int y); // 0x0000000180B15060-0x0000000180B15100
	private void Start(); // 0x0000000180B15100-0x0000000180B15340
	public void FindAllMatches(); // 0x0000000180B15340-0x0000000180B15F00
	private void AddToCurrentMatches(GameObject dot); // 0x0000000180B15F00-0x0000000180B15FC0
	public void VirtualFindAllMatches(HashSet<GameObject> matches); // 0x0000000180B15FC0-0x0000000180B16950
	[CompilerGenerated]
	private GameObject _VirtualFindAllMatches_b__19_0(int x, int y); // 0x0000000180B16A50-0x0000000180B16AA0
}

