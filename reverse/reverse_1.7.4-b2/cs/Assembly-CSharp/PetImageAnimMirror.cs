/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class PetImageAnimMirror : MonoBehaviour // TypeDefIndex: 1048
{
	// Fields
	private Animator _anim; // 0x20
	private SpriteRenderer _sr; // 0x28
	private Image _img; // 0x30
	private Sprite _last; // 0x38
	[CompilerGenerated]
	private bool _Mirroring_k__BackingField; // 0x40

	// Properties
	public bool Mirroring { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180490AB0-0x0000000180490AC0 0x0000000180501600-0x0000000180501610
	public SpriteRenderer Mailbox { get; } // 0x00000001805015E0-0x0000000180501600 

	// Constructors
	public PetImageAnimMirror(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void Awake(); // 0x0000000180500F80-0x0000000180500F90
	public static PetImageAnimMirror Ensure(Animator anim, Image img); // 0x0000000180501230-0x0000000180501350
	public static void Stop(Animator anim, Sprite staticIcon); // 0x0000000180501380-0x00000001805014F0
	private void EnsureParts(); // 0x0000000180501070-0x0000000180501230
	public void Activate(); // 0x0000000180500F40-0x0000000180500F80
	public void Deactivate(Sprite staticIcon); // 0x0000000180500F90-0x0000000180501070
	public void Sync(); // 0x00000001805014F0-0x00000001805015E0
	private void LateUpdate(); // 0x0000000180501350-0x0000000180501360
	private void OnDisable(); // 0x0000000180501360-0x0000000180501380
}

