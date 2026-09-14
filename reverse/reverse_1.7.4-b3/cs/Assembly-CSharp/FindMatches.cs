/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class FindMatches : MonoBehaviour // TypeDefIndex: 2300
{
	// Fields
	[CompilerGenerated]
	private static FindMatches _Instance_k__BackingField; // 0x00
	private Board _board; // 0x20
	private BoardPVP _boardPVP; // 0x28
	public List<GameObject> currentMatches; // 0x30

	// Properties
	public static FindMatches Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180AEA980-0x0000000180AEA9C0 0x0000000180AEA9C0-0x0000000180AEAA60
	private bool IsPVP { get; } // 0x0000000180AEAD40-0x0000000180AEAEA0 
	private int BoardWidth { get; } // 0x0000000180AEAEA0-0x0000000180AEAEF0 
	private int BoardHeight { get; } // 0x0000000180AEAEF0-0x0000000180AEAF40 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 2301
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<int, int, GameObject> __9__19_1; // 0x08

		// Constructors
		static __c(); // 0x0000000180AEC980-0x0000000180AECA20
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal GameObject _VirtualFindAllMatches_b__19_1(int x, int y); // 0x0000000180AECA20-0x0000000180AECAC0
	}

	// Constructors
	public FindMatches(); // 0x0000000180AEC830-0x0000000180AEC930

	// Methods
	private void Awake(); // 0x0000000180AEAA60-0x0000000180AEABE0
	private void OnDestroy(); // 0x0000000180AEABE0-0x0000000180AEAD40
	private GameObject GetDot(int x, int y); // 0x0000000180AEAF40-0x0000000180AEAFE0
	private void Start(); // 0x0000000180AEAFE0-0x0000000180AEB220
	public void FindAllMatches(); // 0x0000000180AEB220-0x0000000180AEBDE0
	private void AddToCurrentMatches(GameObject dot); // 0x0000000180AEBDE0-0x0000000180AEBEA0
	public void VirtualFindAllMatches(HashSet<GameObject> matches); // 0x0000000180AEBEA0-0x0000000180AEC830
	[CompilerGenerated]
	private GameObject _VirtualFindAllMatches_b__19_0(int x, int y); // 0x0000000180AEC930-0x0000000180AEC980
}

