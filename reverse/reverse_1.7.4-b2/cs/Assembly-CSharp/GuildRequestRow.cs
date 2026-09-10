/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class GuildRequestRow : MonoBehaviour // TypeDefIndex: 775
{
	// Fields
	[SerializeField]
	private UnityEngine.UI.Text txtName; // 0x20
	[SerializeField]
	private UnityEngine.UI.Text txtOnline; // 0x28
	[SerializeField]
	private Button btnView; // 0x30
	[SerializeField]
	private Button btnAgree; // 0x38
	[SerializeField]
	private Button btnDecline; // 0x40
	private static readonly Color DOT_ONLINE; // 0x00
	private static readonly Color DOT_OFFLINE; // 0x10
	private bool _wired; // 0x48
	private GuildRequestItem _data; // 0x50

	// Properties
	public GuildRequestItem Data { get; } // 0x00000001803199C0-0x00000001803199D0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass13_0 // TypeDefIndex: 776
	{
		// Fields
		public Action<GuildRequestItem> onAgree; // 0x10
		public GuildRequestRow __4__this; // 0x18
		public Action<GuildRequestItem> onDecline; // 0x20
		public Action<GuildRequestItem> onView; // 0x28

		// Constructors
		public __c__DisplayClass13_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Bind_b__0(); // 0x0000000180496970-0x00000001804969B0
		internal void _Bind_b__1(); // 0x00000001804969B0-0x00000001804969F0
		internal void _Bind_b__2(); // 0x00000001804969F0-0x0000000180496A30
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass15_0 // TypeDefIndex: 777
	{
		// Fields
		public RectTransform rt; // 0x10
		public Vector2 from; // 0x18
		public CanvasGroup cg; // 0x20
		public GuildRequestRow __4__this; // 0x28
		public Action onDone; // 0x30

		// Constructors
		public __c__DisplayClass15_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayResolvedFx_b__0(float k); // 0x0000000180496B40-0x0000000180496C20
		internal void _PlayResolvedFx_b__1(); // 0x0000000180496C20-0x0000000180496D20
	}

	// Constructors
	public GuildRequestRow(); // 0x00000001802EBA70-0x00000001802EBAF0
	static GuildRequestRow(); // 0x0000000180480520-0x0000000180480580

	// Methods
	private void Awake(); // 0x000000018047F7B0-0x000000018047F7C0
	private void EnsureWired(); // 0x000000018047FDC0-0x0000000180480100
	public void Bind(GuildRequestItem data, bool canManage, Action<GuildRequestItem> onAgree, Action<GuildRequestItem> onDecline, Action<GuildRequestItem> onView); // 0x000000018047F7C0-0x000000018047FDC0
	public void SetInteractable(bool on); // 0x0000000180480470-0x0000000180480520
	public void PlayResolvedFx(Action onDone); // 0x0000000180480100-0x0000000180480470
}

