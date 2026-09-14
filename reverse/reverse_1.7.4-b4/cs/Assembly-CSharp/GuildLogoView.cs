/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class GuildLogoView : MonoBehaviour // TypeDefIndex: 808
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
	public GuildLogoView(); // 0x0000000180537EB0-0x0000000180537F00

	// Methods
	private void Awake(); // 0x00000001805376C0-0x00000001805376D0
	private void EnsureWired(); // 0x00000001805376D0-0x0000000180537C70
	public void Bind(int bgId, int patternId, int petId); // 0x0000000180537C70-0x0000000180537E60
	public void Bind(GuildInfo g); // 0x0000000180537E60-0x0000000180537E90
	public void Bind(GuildListItem g); // 0x0000000180537E60-0x0000000180537E90
	public void Bind(GuildTopGuildRow g); // 0x0000000180537E60-0x0000000180537E90
	public void Invalidate(); // 0x0000000180537E90-0x0000000180537EA0
	private static int Clamp(int id, int max); // 0x0000000180537EA0-0x0000000180537EB0
}

