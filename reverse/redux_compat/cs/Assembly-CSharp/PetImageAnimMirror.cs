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
public class PetImageAnimMirror : MonoBehaviour // TypeDefIndex: 848
{
	// Fields
	private Animator _anim; // 0x20
	private SpriteRenderer _sr; // 0x28
	private Image _img; // 0x30
	private Sprite _last; // 0x38
	[CompilerGenerated]
	private bool _Mirroring_k__BackingField; // 0x40

	// Properties
	public bool Mirroring { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803B1170-0x00000001803B1180 0x000000018042B340-0x000000018042B350
	public SpriteRenderer Mailbox { get; } // 0x000000018042B320-0x000000018042B340 

	// Constructors
	public PetImageAnimMirror(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Awake(); // 0x000000018042ACC0-0x000000018042ACD0
	public static PetImageAnimMirror Ensure(Animator anim, Image img); // 0x000000018042AF70-0x000000018042B090
	public static void Stop(Animator anim, Sprite staticIcon); // 0x000000018042B0C0-0x000000018042B230
	private void EnsureParts(); // 0x000000018042ADB0-0x000000018042AF70
	public void Activate(); // 0x000000018042AC80-0x000000018042ACC0
	public void Deactivate(Sprite staticIcon); // 0x000000018042ACD0-0x000000018042ADB0
	public void Sync(); // 0x000000018042B230-0x000000018042B320
	private void LateUpdate(); // 0x000000018042B090-0x000000018042B0A0
	private void OnDisable(); // 0x000000018042B0A0-0x000000018042B0C0
}

