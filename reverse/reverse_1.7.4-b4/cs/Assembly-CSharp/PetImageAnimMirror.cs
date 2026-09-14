/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class PetImageAnimMirror : MonoBehaviour // TypeDefIndex: 1429
{
	// Fields
	private Animator _anim; // 0x20
	private SpriteRenderer _sr; // 0x28
	private Image _img; // 0x30
	private Sprite _last; // 0x38
	[CompilerGenerated]
	private bool _Mirroring_k__BackingField; // 0x40

	// Properties
	public bool Mirroring { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805E46D0-0x00000001805E46E0 0x00000001807C8F70-0x00000001807C8F80
	public SpriteRenderer Mailbox { get; } // 0x00000001807C8F80-0x00000001807C8FA0 

	// Constructors
	public PetImageAnimMirror(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x00000001807C8FA0-0x00000001807C8FB0
	public static PetImageAnimMirror Ensure(Animator anim, Image img); // 0x00000001807C8FB0-0x00000001807C9290
	public static void Stop(Animator anim, Sprite staticIcon); // 0x00000001807C9290-0x00000001807C9480
	private void EnsureParts(); // 0x00000001807C9480-0x00000001807C9AC0
	public void Activate(); // 0x00000001807C9AC0-0x00000001807C9B40
	public void Deactivate(Sprite staticIcon); // 0x00000001807C9B40-0x00000001807C9E30
	public void Sync(); // 0x00000001807C9E30-0x00000001807CA130
	private void LateUpdate(); // 0x00000001807CA130-0x00000001807CA140
	private void OnDisable(); // 0x00000001807CA140-0x00000001807CA1A0
}

