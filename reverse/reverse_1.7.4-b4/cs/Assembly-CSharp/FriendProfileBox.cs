/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class FriendProfileBox : MonoBehaviour // TypeDefIndex: 700
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
	public bool IsOpen { get; } // 0x00000001804A3600-0x00000001804A3750 
	public long CurrentFriendId { get; } // 0x00000001804A3750-0x00000001804A3780 

	// Events
	public event Action OnClosed {
		add; // 0x00000001804A3780-0x00000001804A3880
		remove; // 0x00000001804A3880-0x00000001804A3980
	}
	public event Action OnClaimed {
		add; // 0x00000001804A3980-0x00000001804A3A80
		remove; // 0x00000001804A3A80-0x00000001804A3B80
	}

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass38_0 // TypeDefIndex: 701
	{
		// Fields
		public Button btnClaim; // 0x10
		public int level; // 0x18
		public FriendProfileBox __4__this; // 0x20

		// Constructors
		public __c__DisplayClass38_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildMilestones_b__0(); // 0x00000001804AA190-0x00000001804AA1C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass40_0 // TypeDefIndex: 702
	{
		// Fields
		public FriendProfileBox __4__this; // 0x10
		public Button btn; // 0x18

		// Constructors
		public __c__DisplayClass40_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Claim_b__0(IntimacyLevelData claimed); // 0x00000001804AA1C0-0x00000001804AA3F0
		internal void _Claim_b__1(string err); // 0x00000001804AA3F0-0x00000001804AA570
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass43_0 // TypeDefIndex: 703
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass43_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SpawnHearts_b__0(); // 0x00000001804AA570-0x00000001804AA6A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass44_0 // TypeDefIndex: 704
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass44_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayLevelUpFx_b__0(); // 0x00000001804AA6A0-0x00000001804AA7D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass44_1 // TypeDefIndex: 705
	{
		// Fields
		public GameObject t; // 0x10

		// Constructors
		public __c__DisplayClass44_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayLevelUpFx_b__1(); // 0x00000001804AA7D0-0x00000001804AA950
	}

	// Constructors
	public FriendProfileBox(); // 0x00000001804A9CB0-0x00000001804A9DB0
	static FriendProfileBox(); // 0x00000001804A9DB0-0x00000001804A9EE0

	// Methods
	private void Awake(); // 0x00000001804A3B80-0x00000001804A3C50
	private void AutoFindRefs(); // 0x00000001804A3C50-0x00000001804A4C80
	public void Open(int userId, long friendUserId); // 0x00000001804A4C80-0x00000001804A52D0
	public void Close(); // 0x00000001804A52D0-0x00000001804A5460
	private void CloseImmediate(); // 0x00000001804A5460-0x00000001804A5680
	private void Render(FriendProfileData profile); // 0x00000001804A5680-0x00000001804A61E0
	private void BuildMilestones(FriendProfileData profile); // 0x00000001804A61E0-0x00000001804A74D0
	private static string RewardText(IntimacyLevelData lv); // 0x00000001804A74D0-0x00000001804A7860
	private void Claim(int level, Button btn); // 0x00000001804A7860-0x00000001804A7C50
	public void NotifyLevelUp(); // 0x00000001804A7C50-0x00000001804A7CA0
	private void PlayHeartFxIfGained(FriendItemData f); // 0x00000001804A7CA0-0x00000001804A7E00
	private void SpawnHearts(int count); // 0x00000001804A7E00-0x00000001804A8B70
	private void PlayLevelUpFx(); // 0x00000001804A8B70-0x00000001804A95A0
	private void ClearFx(); // 0x00000001804A95A0-0x00000001804A9C90
	private void OnDisable(); // 0x00000001804A9C90-0x00000001804A9CB0
	[CompilerGenerated]
	private void _Open_b__34_0(FriendProfileData profile); // 0x00000001804A9EE0-0x00000001804AA0D0
	[CompilerGenerated]
	private void _Open_b__34_1(string err); // 0x00000001804AA0D0-0x00000001804AA170
	[CompilerGenerated]
	private void _Close_b__35_0(); // 0x00000001804AA170-0x00000001804AA190
}

