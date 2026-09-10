/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class GuildLogoView : MonoBehaviour // TypeDefIndex: 714
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
	public GuildLogoView(); // 0x000000018046CB90-0x000000018046CBA0

	// Methods
	private void Awake(); // 0x000000018046C770-0x000000018046C780
	private void EnsureWired(); // 0x000000018046C910-0x000000018046CB80
	public void Bind(int bgId, int patternId, int petId); // 0x000000018046C7B0-0x000000018046C900
	public void Bind(GuildInfo g); // 0x000000018046C780-0x000000018046C7B0
	public void Bind(GuildListItem g); // 0x000000018046C780-0x000000018046C7B0
	public void Bind(GuildTopGuildRow g); // 0x000000018046C780-0x000000018046C7B0
	public void Invalidate(); // 0x000000018046CB80-0x000000018046CB90
	private static int Clamp(int id, int max); // 0x000000018046C900-0x000000018046C910
}

