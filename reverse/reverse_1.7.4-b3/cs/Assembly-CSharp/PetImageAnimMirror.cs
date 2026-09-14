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
public class PetImageAnimMirror : MonoBehaviour // TypeDefIndex: 1427
{
	// Fields
	private Animator _anim; // 0x20
	private SpriteRenderer _sr; // 0x28
	private Image _img; // 0x30
	private Sprite _last; // 0x38
	[CompilerGenerated]
	private bool _Mirroring_k__BackingField; // 0x40

	// Properties
	public bool Mirroring { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805E2D50-0x00000001805E2D60 0x00000001807C6F00-0x00000001807C6F10
	public SpriteRenderer Mailbox { get; } // 0x00000001807C6F10-0x00000001807C6F30 

	// Constructors
	public PetImageAnimMirror(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x00000001807C6F30-0x00000001807C6F40
	public static PetImageAnimMirror Ensure(Animator anim, Image img); // 0x00000001807C6F40-0x00000001807C7220
	public static void Stop(Animator anim, Sprite staticIcon); // 0x00000001807C7220-0x00000001807C7410
	private void EnsureParts(); // 0x00000001807C7410-0x00000001807C7A50
	public void Activate(); // 0x00000001807C7A50-0x00000001807C7AD0
	public void Deactivate(Sprite staticIcon); // 0x00000001807C7AD0-0x00000001807C7DC0
	public void Sync(); // 0x00000001807C7DC0-0x00000001807C80C0
	private void LateUpdate(); // 0x00000001807C80C0-0x00000001807C80D0
	private void OnDisable(); // 0x00000001807C80D0-0x00000001807C8130
}

