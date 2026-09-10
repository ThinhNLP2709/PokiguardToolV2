/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class FriendProfileBox : MonoBehaviour // TypeDefIndex: 608
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
	public bool IsOpen { get; } // 0x00000001803F21A0-0x00000001803F2220 
	public long CurrentFriendId { get; } // 0x00000001803F2170-0x00000001803F21A0 

	// Events
	public event Action OnClosed {
		add; // 0x00000001803F20C0-0x00000001803F2170
		remove; // 0x00000001803F22D0-0x00000001803F2380
	}
	public event Action OnClaimed {
		add; // 0x00000001803F2010-0x00000001803F20C0
		remove; // 0x00000001803F2220-0x00000001803F22D0
	}

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass38_0 // TypeDefIndex: 609
	{
		// Fields
		public Button btnClaim; // 0x10
		public int level; // 0x18
		public FriendProfileBox __4__this; // 0x20

		// Constructors
		public __c__DisplayClass38_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _BuildMilestones_b__0(); // 0x00000001803F5D30-0x00000001803F5D60
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass40_0 // TypeDefIndex: 610
	{
		// Fields
		public FriendProfileBox __4__this; // 0x10
		public Button btn; // 0x18

		// Constructors
		public __c__DisplayClass40_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Claim_b__0(IntimacyLevelData claimed); // 0x00000001803F5D60-0x00000001803F5F20
		internal void _Claim_b__1(string err); // 0x00000001803F5F20-0x00000001803F6010
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass43_0 // TypeDefIndex: 611
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass43_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SpawnHearts_b__0(); // 0x00000001803F6060-0x00000001803F60D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass44_0 // TypeDefIndex: 612
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass44_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayLevelUpFx_b__0(); // 0x00000001803F60D0-0x00000001803F6140
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass44_1 // TypeDefIndex: 613
	{
		// Fields
		public GameObject t; // 0x10

		// Constructors
		public __c__DisplayClass44_1(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayLevelUpFx_b__1(); // 0x00000001803F6140-0x00000001803F61F0
	}

	// Constructors
	public FriendProfileBox(); // 0x00000001803F1F90-0x00000001803F2010
	static FriendProfileBox(); // 0x00000001803F1EB0-0x00000001803F1F90

	// Methods
	private void Awake(); // 0x00000001803EEF00-0x00000001803EEFB0
	private void AutoFindRefs(); // 0x00000001803EE880-0x00000001803EEF00
	public void Open(int userId, long friendUserId); // 0x00000001803F01A0-0x00000001803F0400
	public void Close(); // 0x00000001803F0030-0x00000001803F0130
	private void CloseImmediate(); // 0x00000001803EFF50-0x00000001803F0030
	private void Render(FriendProfileData profile); // 0x00000001803F0C40-0x00000001803F1230
	private void BuildMilestones(FriendProfileData profile); // 0x00000001803EEFB0-0x00000001803EFAD0
	private static string RewardText(IntimacyLevelData lv); // 0x00000001803F1230-0x00000001803F1510
	private void Claim(int level, Button btn); // 0x00000001803EFAD0-0x00000001803EFCF0
	public void NotifyLevelUp(); // 0x00000001803F0130-0x00000001803F0180
	private void PlayHeartFxIfGained(FriendItemData f); // 0x00000001803F0400-0x00000001803F0500
	private void SpawnHearts(int count); // 0x00000001803F1510-0x00000001803F1C60
	private void PlayLevelUpFx(); // 0x00000001803F0500-0x00000001803F0C40
	private void ClearFx(); // 0x00000001803EFCF0-0x00000001803EFF50
	private void OnDisable(); // 0x00000001803F0180-0x00000001803F01A0
	[CompilerGenerated]
	private void _Open_b__34_0(FriendProfileData profile); // 0x00000001803F1C80-0x00000001803F1E20
	[CompilerGenerated]
	private void _Open_b__34_1(string err); // 0x00000001803F1E20-0x00000001803F1EB0
	[CompilerGenerated]
	private void _Close_b__35_0(); // 0x00000001803F1C60-0x00000001803F1C80
}

