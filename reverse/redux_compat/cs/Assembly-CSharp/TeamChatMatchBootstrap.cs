/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class TeamChatMatchBootstrap : MonoBehaviour // TypeDefIndex: 442
{
	// Fields
	private static TeamChatMatchBootstrap _instance; // 0x00

	// Constructors
	public TeamChatMatchBootstrap(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	public static void EnsureForMatch(); // 0x000000018034B500-0x000000018034B7D0
	private void OnEnable(); // 0x000000018034BAE0-0x000000018034BBD0
	private void OnDisable(); // 0x000000018034B9F0-0x000000018034BAE0
	private void OnDestroy(); // 0x000000018034B940-0x000000018034B9F0
	private void HandleTeamEmote(ChatMessageDTO m); // 0x000000018034B7D0-0x000000018034B940
	private static int ResolveActor(string username); // 0x000000018034BBD0-0x000000018034BCC0
}

