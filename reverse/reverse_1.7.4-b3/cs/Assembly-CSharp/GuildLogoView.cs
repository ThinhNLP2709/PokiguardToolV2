/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class GuildLogoView : MonoBehaviour // TypeDefIndex: 807
{
	// Fields
	[SerializeField]
	private Transform imgBg; // 0x20
	[SerializeField]
	private Transform imgPattern; // 0x28
	[SerializeField]
	private Transform imgLogo; // 0x30
	private bool _wired; // 0x38
	private int _bg; // 0x3C
	private int _pet; // 0x40

	// Constructors
	public GuildLogoView(); // 0x00000001805366D0-0x0000000180536720

	// Methods
	private void Awake(); // 0x0000000180535EE0-0x0000000180535EF0
	private void EnsureWired(); // 0x0000000180535EF0-0x0000000180536490
	public void Bind(int bgId, int patternId, int petId); // 0x0000000180536490-0x0000000180536680
	public void Bind(GuildInfo g); // 0x0000000180536680-0x00000001805366B0
	public void Bind(GuildListItem g); // 0x0000000180536680-0x00000001805366B0
	public void Bind(GuildTopGuildRow g); // 0x0000000180536680-0x00000001805366B0
	public void Invalidate(); // 0x00000001805366B0-0x00000001805366C0
	private static int Clamp(int id, int max); // 0x00000001805366C0-0x00000001805366D0
}

