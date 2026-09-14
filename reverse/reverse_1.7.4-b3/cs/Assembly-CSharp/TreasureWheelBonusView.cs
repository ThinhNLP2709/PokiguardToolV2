/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class TreasureWheelBonusView : MonoBehaviour // TypeDefIndex: 1370
{
	// Fields
	public int index; // 0x20
	public Image bar; // 0x28
	public Image icon; // 0x30
	public Image piece; // 0x38
	public UnityEngine.UI.Text txtAmount; // 0x40
	public UnityEngine.UI.Text txtLevel; // 0x48
	public UnityEngine.UI.Text txtClaimed; // 0x50
	public GameObject canReceive; // 0x58
	public Button button; // 0x60
	[CompilerGenerated]
	private long _BonusId_k__BackingField; // 0x68
	[CompilerGenerated]
	private string _Status_k__BackingField; // 0x70
	private Action<TreasureWheelBonusView> _onClick; // 0x78
	private bool _wired; // 0x80
	private static readonly Color BAR_NORMAL; // 0x00
	private static readonly Color BAR_CLAIMED; // 0x10
	private static readonly Color BAR_LOCKED; // 0x20

	// Properties
	public long BonusId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803456F0-0x0000000180345700 0x00000001803C6070-0x00000001803C6080
	public string Status { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6080-0x00000001803C6090 0x000000018077D060-0x000000018077D0C0

	// Constructors
	public TreasureWheelBonusView(); // 0x000000018028A560-0x000000018028A5B0
	static TreasureWheelBonusView(); // 0x000000018077E180-0x000000018077E200

	// Methods
	private void Awake(); // 0x000000018077D0C0-0x000000018077D0D0
	public void EnsureWired(); // 0x000000018077D0D0-0x000000018077D350
	public void SetClickHandler(Action<TreasureWheelBonusView> handler); // 0x000000018077D350-0x000000018077D3C0
	public void Hide(); // 0x000000018077D3C0-0x000000018077D4C0
	public void Render(TreasureWheelBonusDTO dto); // 0x000000018077D4C0-0x000000018077E010
	public void SetInteractable(bool on); // 0x000000018077E010-0x000000018077E180
	[CompilerGenerated]
	private void _EnsureWired_b__23_0(); // 0x000000018077E200-0x000000018077E220
}

