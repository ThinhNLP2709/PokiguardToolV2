/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class GuildRow : MonoBehaviour // TypeDefIndex: 782
{
	// Fields
	[SerializeField]
	private GuildLogoView logo; // 0x20
	[SerializeField]
	private UnityEngine.UI.Text txtName; // 0x28
	[SerializeField]
	private UnityEngine.UI.Text txtNumMember; // 0x30
	[SerializeField]
	private UnityEngine.UI.Text txtPoint; // 0x38
	[SerializeField]
	private Button btnJoin; // 0x40
	[SerializeField]
	private Button btnCancel; // 0x48
	private bool _wired; // 0x50
	private GuildListItem _data; // 0x58

	// Properties
	public GuildListItem Data { get; } // 0x00000001803F79E0-0x00000001803F79F0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass12_0 // TypeDefIndex: 783
	{
		// Fields
		public Action<GuildListItem> onJoin; // 0x10
		public GuildRow __4__this; // 0x18
		public Action<GuildListItem> onCancel; // 0x20
		public Action<GuildListItem> onDetail; // 0x28

		// Constructors
		public __c__DisplayClass12_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Bind_b__0(); // 0x00000001804968B0-0x00000001804968F0
		internal void _Bind_b__1(); // 0x00000001804968F0-0x0000000180496930
		internal void _Bind_b__2(); // 0x0000000180496930-0x0000000180496970
	}

	// Constructors
	public GuildRow(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void Awake(); // 0x0000000180482940-0x0000000180482950
	private void EnsureWired(); // 0x0000000180482EE0-0x0000000180483370
	public void Bind(GuildListItem data, Action<GuildListItem> onJoin, Action<GuildListItem> onCancel, Action<GuildListItem> onDetail); // 0x0000000180482950-0x0000000180482EE0
	public void SetRequested(bool requested); // 0x0000000180483370-0x0000000180483400
}

