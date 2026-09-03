/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class TreasureWheelBonusView : MonoBehaviour // TypeDefIndex: 805
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
	public long BonusId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180316960-0x0000000180316970 0x000000018033EA60-0x000000018033EA70
	public string Status { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D4D0-0x000000018033D4E0 0x0000000180434A10-0x0000000180434A20

	// Constructors
	public TreasureWheelBonusView(); // 0x00000001802E7A70-0x00000001802E7BC0
	static TreasureWheelBonusView(); // 0x0000000180434990-0x0000000180434A10

	// Methods
	private void Awake(); // 0x0000000180433F50-0x0000000180433F60
	public void EnsureWired(); // 0x0000000180433F60-0x00000001804340A0
	public void SetClickHandler(Action<TreasureWheelBonusView> handler); // 0x0000000180434880-0x00000001804348C0
	public void Hide(); // 0x00000001804340A0-0x0000000180434110
	public void Render(TreasureWheelBonusDTO dto); // 0x0000000180434110-0x0000000180434880
	public void SetInteractable(bool on); // 0x00000001804348C0-0x0000000180434970
	[CompilerGenerated]
	private void _EnsureWired_b__23_0(); // 0x0000000180434970-0x0000000180434990
}

