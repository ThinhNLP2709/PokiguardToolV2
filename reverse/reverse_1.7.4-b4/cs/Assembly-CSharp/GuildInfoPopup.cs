/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public abstract class GuildInfoPopup : MonoBehaviour // TypeDefIndex: 800
{
	// Fields
	public const float FRAME_W = 1774f; // Metadata: 0x005EFD98
	public const float FRAME_H = 887f; // Metadata: 0x005EFD9C
	protected const float DIM_OVERSCAN = 600f; // Metadata: 0x005EFDA0
	protected const string TAP_GUARD = "tap_Guard"; // Metadata: 0x005EFDA4
	protected const float HELP_X = 1578f; // Metadata: 0x005EFDAE
	protected const float HELP_Y = 15f; // Metadata: 0x005EFDB2
	protected const float HELP_D = 78f; // Metadata: 0x005EFDB6
	protected RectTransform InfoRoot; // 0x20
	protected RectTransform Content; // 0x28
	protected RectTransform Box; // 0x30
	protected Image BgFrame; // 0x38
	protected UnityEngine.UI.Text Title; // 0x40
	protected Button CloseButton; // 0x48
	protected CanvasGroup Group; // 0x50
	private Image _dim; // 0x58
	private Button _dimButton; // 0x60
	private bool _shellBuilt; // 0x68
	[CompilerGenerated]
	private bool _Locked_k__BackingField; // 0x69

	// Properties
	protected bool Locked { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018052DB00-0x000000018052DB10 0x000000018052DB10-0x000000018052DB20
	public bool IsOpen { get; } // 0x000000018052DB20-0x000000018052DC80 

	// Nested types
	public struct Flag // TypeDefIndex: 801
	{
		// Fields
		public RectTransform root; // 0x00
		public Image bg; // 0x08
		public Image icon; // 0x10

		// Methods
		public void Set(int bgId, int petId); // 0x00000001805312B0-0x0000000180531610
	}

	public struct Badge // TypeDefIndex: 802
	{
		// Fields
		public Image bg; // 0x00
		public UnityEngine.UI.Text txt; // 0x08
		public Image icon; // 0x10

		// Methods
		public void Set(int rank, Sprite poky); // 0x0000000180531610-0x0000000180531C30
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass26_0 // TypeDefIndex: 803
	{
		// Fields
		public bool tapOutsideCloses; // 0x10
		public GuildInfoPopup __4__this; // 0x18

		// Constructors
		public __c__DisplayClass26_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildBase_b__0(); // 0x0000000180531C30-0x0000000180531C70
	}

	// Constructors
	protected GuildInfoPopup(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static T Mount<T>(Transform host, string name)
		where T : GuildInfoPopup;
	protected RectTransform BuildFull(string title, bool tapOutsideCloses = true /* Metadata: 0x005EFD96 */); // 0x000000018052DC80-0x000000018052E440
	protected RectTransform BuildBox(string title, float w, float h, bool tapOutsideCloses = true /* Metadata: 0x005EFD97 */); // 0x000000018052E440-0x000000018052E940
	private void BuildBase(bool tapOutsideCloses); // 0x000000018052E940-0x000000018052EF90
	public virtual void Show(); // 0x000000018052EF90-0x000000018052F4B0
	public virtual void Hide(); // 0x000000018052F4B0-0x000000018052F720
	public void HideImmediate(); // 0x000000018052F720-0x000000018052FA10
	public void RaiseIfOpen(); // 0x000000018052FA10-0x000000018052FAA0
	protected void RequestClose(); // 0x000000018052FAA0-0x000000018052FAC0
	protected void SetLocked(bool on); // 0x000000018052FAC0-0x000000018052FCB0
	protected virtual void OnDisable(); // 0x000000018052FCB0-0x000000018052FEC0
	protected Button HelpButton(Transform parent, float x, float y, float d, UnityAction onTap); // 0x000000018052FEC0-0x0000000180530300
	protected Button HelpButton(Transform parent, UnityAction onTap); // 0x0000000180530300-0x0000000180530340
	public static Flag MakeFlag(Transform parent, string name, float x, float y, float side); // 0x0000000180530340-0x0000000180530710
	public static string LevelLabel(int level); // 0x0000000180530710-0x0000000180530800
	public static UnityEngine.UI.Text LevelChip(MonoBehaviour host, Transform parent, string name, float x, float y, float w, float h, int level); // 0x0000000180530800-0x0000000180530990
	public static UnityEngine.UI.Text StatRow(Transform parent, string name, float x, float y, float w, float h, string label, string value, Color valueColor); // 0x0000000180530990-0x0000000180530B90
	public static Badge RankBadge(MonoBehaviour host, Transform parent, string name, float x, float y, float d); // 0x0000000180530B90-0x0000000180531040
	public static Color RankColor(int rank); // 0x0000000180531040-0x00000001805310D0
	[CompilerGenerated]
	private void _Hide_b__28_0(); // 0x00000001805310D0-0x00000001805312B0
}

