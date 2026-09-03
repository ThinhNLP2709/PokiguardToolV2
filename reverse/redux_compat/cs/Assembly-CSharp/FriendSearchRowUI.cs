/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class FriendSearchRowUI : MonoBehaviour // TypeDefIndex: 541
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
	public FriendSearchItemData Data { get; } // 0x00000001802F4000-0x00000001802F4010 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass15_0 // TypeDefIndex: 542
	{
		// Fields
		public FriendSearchRowUI __4__this; // 0x10
		public Action<FriendSearchItemData> onAdd; // 0x18

		// Constructors
		public __c__DisplayClass15_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _Bind_b__0(); // 0x00000001803A6440-0x00000001803A64A0
	}

	// Constructors
	public FriendSearchRowUI(); // 0x00000001802E7A70-0x00000001802E7BC0
	static FriendSearchRowUI(); // 0x000000018038C540-0x000000018038C5C0

	// Methods
	private void Awake(); // 0x000000018038BC20-0x000000018038BC30
	private void AutoFindRefs(); // 0x000000018038B8B0-0x000000018038BC20
	public void Bind(FriendSearchItemData data, Action<FriendSearchItemData> onAdd); // 0x000000018038BC30-0x000000018038C3C0
	private static string RelationLabel(string relation, int playCount); // 0x000000018038C3C0-0x000000018038C540
}

