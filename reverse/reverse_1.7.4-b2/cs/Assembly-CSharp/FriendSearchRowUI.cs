/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class FriendSearchRowUI : MonoBehaviour // TypeDefIndex: 618
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
	public FriendSearchItemData Data { get; } // 0x00000001803F79E0-0x00000001803F79F0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass15_0 // TypeDefIndex: 619
	{
		// Fields
		public FriendSearchRowUI __4__this; // 0x10
		public Action<FriendSearchItemData> onAdd; // 0x18

		// Constructors
		public __c__DisplayClass15_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Bind_b__0(); // 0x000000018040FC20-0x000000018040FC80
	}

	// Constructors
	public FriendSearchRowUI(); // 0x00000001802EBA70-0x00000001802EBAF0
	static FriendSearchRowUI(); // 0x00000001803F7960-0x00000001803F79E0

	// Methods
	private void Awake(); // 0x00000001803F7070-0x00000001803F7080
	private void AutoFindRefs(); // 0x00000001803F6D00-0x00000001803F7070
	public void Bind(FriendSearchItemData data, Action<FriendSearchItemData> onAdd); // 0x00000001803F7080-0x00000001803F77E0
	private static string RelationLabel(string relation, int playCount); // 0x00000001803F77E0-0x00000001803F7960
}

