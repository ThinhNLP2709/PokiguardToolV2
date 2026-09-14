/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class FriendSearchRowUI : MonoBehaviour // TypeDefIndex: 709
{
	// Fields
	[SerializeField]
	private Image imgAvatar; // 0x20
	[SerializeField]
	private UnityEngine.UI.Text txtName; // 0x28
	[SerializeField]
	private UnityEngine.UI.Text txtLevel; // 0x30
	[SerializeField]
	private UnityEngine.UI.Text txtPower; // 0x38
	[SerializeField]
	private UnityEngine.UI.Text txtRelation; // 0x40
	[SerializeField]
	private Button btnAdd; // 0x48
	[SerializeField]
	private Image statusDot; // 0x50
	private static readonly Color DOT_ONLINE; // 0x00
	private static readonly Color DOT_OFFLINE; // 0x10
	private static readonly Color RELATION_GRAY; // 0x20
	private FriendSearchItemData _data; // 0x58

	// Properties
	public FriendSearchItemData Data { get; } // 0x00000001803456E0-0x00000001803456F0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass15_0 // TypeDefIndex: 710
	{
		// Fields
		public FriendSearchRowUI __4__this; // 0x10
		public Action<FriendSearchItemData> onAdd; // 0x18

		// Constructors
		public __c__DisplayClass15_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Bind_b__0(); // 0x00000001804B03D0-0x00000001804B0430
	}

	// Constructors
	public FriendSearchRowUI(); // 0x000000018028A560-0x000000018028A5B0
	static FriendSearchRowUI(); // 0x00000001804B0350-0x00000001804B03D0

	// Methods
	private void Awake(); // 0x00000001804AE900-0x00000001804AE910
	private void AutoFindRefs(); // 0x00000001804AE910-0x00000001804AF430
	public void Bind(FriendSearchItemData data, Action<FriendSearchItemData> onAdd); // 0x00000001804AF430-0x00000001804B00E0
	private static string RelationLabel(string relation, int playCount); // 0x00000001804B00E0-0x00000001804B0350
}

