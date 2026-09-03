/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class PetAnimatorBinder // TypeDefIndex: 847
{
	// Fields
	private const string ICON_PATH = "Image/IconsPet/"; // Metadata: 0x0064CB8E
	private static readonly string[] IDLE_CLIP_NAMES; // 0x00

	// Constructors
	static PetAnimatorBinder(); // 0x000000018042ABB0-0x000000018042AC80

	// Methods
	public static RuntimeAnimatorController ResolveBase(Animator animator); // 0x000000018042A8F0-0x000000018042AAB0
	public static bool Bind(Animator animator, AnimationClip[] clips, string debugLabel = null); // 0x000000018042A760-0x000000018042A7E0
	public static bool Bind(Animator animator, AnimationClip[] clips, out bool complete, string debugLabel = null); // 0x0000000180429FD0-0x000000018042A760
	public static bool BindSingle(Animator animator, string clipName, AnimationClip clip); // 0x0000000180429DF0-0x0000000180429FD0
	public static bool BindOrFallback(Animator animator, AnimationClip[] clips, string petId, Image fallbackImage = null, SpriteRenderer fallbackRenderer = null); // 0x0000000180429C20-0x0000000180429DF0
	public static void ApplyStaticFallback(Animator animator, string petId, Image image = null, SpriteRenderer renderer = null); // 0x0000000180429A00-0x0000000180429C20
	private static void UseAnimatedRenderer(Animator animator); // 0x000000018042AAB0-0x000000018042ABB0
	private static void ApplyController(Animator animator, AnimatorOverrideController controller); // 0x00000001804298D0-0x0000000180429A00
	private static bool HasIntParam(Animator animator, string name); // 0x000000018042A7E0-0x000000018042A8F0
}

