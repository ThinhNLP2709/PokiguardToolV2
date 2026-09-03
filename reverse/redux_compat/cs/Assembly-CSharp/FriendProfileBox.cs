/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class FriendProfileBox : MonoBehaviour // TypeDefIndex: 531
{
	// Fields
	[SerializeField]
	private GameObject boxRoot; // 0x20
	[SerializeField]
	private CanvasGroup canvasGroup; // 0x28
	[SerializeField]
	private Image imgAvatarBig; // 0x30
	[SerializeField]
	private UnityEngine.UI.Text txtName; // 0x38
	[SerializeField]
	private UnityEngine.UI.Text txtLevel; // 0x40
	[SerializeField]
	private UnityEngine.UI.Text txtPower; // 0x48
	[SerializeField]
	private UnityEngine.UI.Text txtPet; // 0x50
	[SerializeField]
	private Image barFill; // 0x58
	[SerializeField]
	private UnityEngine.UI.Text txtPoint; // 0x60
	[SerializeField]
	private UnityEngine.UI.Text txtLevelName; // 0x68
	[SerializeField]
	private Transform contentMilestone; // 0x70
	[SerializeField]
	private GameObject rowTemplate; // 0x78
	[SerializeField]
	private Transform fxRoot; // 0x80
	[SerializeField]
	private Button btnClose; // 0x88
	private static readonly Color CLAIMABLE; // 0x00
	private static readonly Color LOCKED; // 0x10
	private static readonly Color CLAIMED; // 0x20
	private int _userId; // 0x90
	private long _friendUserId; // 0x98
	private bool _claiming; // 0xA0
	private static readonly Dictionary<long, int> _lastSeenPoint; // 0x30
	private readonly List<int> _fxTweenIds; // 0xA8
	[CompilerGenerated]
	private Action OnClosed; // 0xB0
	[CompilerGenerated]
	private Action OnClaimed; // 0xB8

	// Properties
	public bool IsOpen { get; } // 0x0000000180388F30-0x0000000180388FB0 
	public long CurrentFriendId { get; } // 0x0000000180388F00-0x0000000180388F30 

	// Events
	public event Action OnClosed {
		add; // 0x0000000180388E50-0x0000000180388F00
		remove; // 0x0000000180389060-0x0000000180389110
	}
	public event Action OnClaimed {
		add; // 0x0000000180388DA0-0x0000000180388E50
		remove; // 0x0000000180388FB0-0x0000000180389060
	}

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass38_0 // TypeDefIndex: 532
	{
		// Fields
		public Button btnClaim; // 0x10
		public int level; // 0x18
		public FriendProfileBox __4__this; // 0x20

		// Constructors
		public __c__DisplayClass38_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _BuildMilestones_b__0(); // 0x000000018038D4F0-0x000000018038D520
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass40_0 // TypeDefIndex: 533
	{
		// Fields
		public FriendProfileBox __4__this; // 0x10
		public Button btn; // 0x18

		// Constructors
		public __c__DisplayClass40_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _Claim_b__0(IntimacyLevelData claimed); // 0x000000018038D520-0x000000018038D6E0
		internal void _Claim_b__1(string err); // 0x000000018038D6E0-0x000000018038D7D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass43_0 // TypeDefIndex: 534
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass43_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SpawnHearts_b__0(); // 0x000000018038D820-0x000000018038D890
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass44_0 // TypeDefIndex: 535
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass44_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PlayLevelUpFx_b__0(); // 0x000000018038D890-0x000000018038D900
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass44_1 // TypeDefIndex: 536
	{
		// Fields
		public GameObject t; // 0x10

		// Constructors
		public __c__DisplayClass44_1(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PlayLevelUpFx_b__1(); // 0x000000018038D900-0x000000018038D9B0
	}

	// Constructors
	public FriendProfileBox(); // 0x0000000180388D20-0x0000000180388DA0
	static FriendProfileBox(); // 0x0000000180388C40-0x0000000180388D20

	// Methods
	private void Awake(); // 0x0000000180385CE0-0x0000000180385D90
	private void AutoFindRefs(); // 0x0000000180385660-0x0000000180385CE0
	public void Open(int userId, long friendUserId); // 0x0000000180386F80-0x00000001803871E0
	public void Close(); // 0x0000000180386E10-0x0000000180386F10
	private void CloseImmediate(); // 0x0000000180386D30-0x0000000180386E10
	private void Render(FriendProfileData profile); // 0x0000000180387A20-0x0000000180387FC0
	private void BuildMilestones(FriendProfileData profile); // 0x0000000180385D90-0x00000001803868B0
	private static string RewardText(IntimacyLevelData lv); // 0x0000000180387FC0-0x00000001803882A0
	private void Claim(int level, Button btn); // 0x00000001803868B0-0x0000000180386AD0
	public void NotifyLevelUp(); // 0x0000000180386F10-0x0000000180386F60
	private void PlayHeartFxIfGained(FriendItemData f); // 0x00000001803871E0-0x00000001803872E0
	private void SpawnHearts(int count); // 0x00000001803882A0-0x00000001803889F0
	private void PlayLevelUpFx(); // 0x00000001803872E0-0x0000000180387A20
	private void ClearFx(); // 0x0000000180386AD0-0x0000000180386D30
	private void OnDisable(); // 0x0000000180386F60-0x0000000180386F80
	[CompilerGenerated]
	private void _Open_b__34_0(FriendProfileData profile); // 0x0000000180388A10-0x0000000180388BB0
	[CompilerGenerated]
	private void _Open_b__34_1(string err); // 0x0000000180388BB0-0x0000000180388C40
	[CompilerGenerated]
	private void _Close_b__35_0(); // 0x00000001803889F0-0x0000000180388A10
}

