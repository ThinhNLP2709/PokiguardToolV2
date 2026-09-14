/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class TeamChatMatchBootstrap : MonoBehaviour // TypeDefIndex: 564
{
	// Fields
	private static TeamChatMatchBootstrap _instance; // 0x00

	// Constructors
	public TeamChatMatchBootstrap(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static void EnsureForMatch(); // 0x00000001803ECB90-0x00000001803ED0B0
	private void OnEnable(); // 0x00000001803ED0B0-0x00000001803ED270
	private void OnDisable(); // 0x00000001803ED270-0x00000001803ED430
	private void HandleTeamMessage(ChatMessageDTO m); // 0x00000001803ED430-0x00000001803ED750
	private static RectTransform ResolveBoardRect(); // 0x00000001803ED750-0x00000001803EDBC0
	private void OnDestroy(); // 0x00000001803EDBC0-0x00000001803EDD80
	private void HandleTeamEmote(ChatMessageDTO m); // 0x00000001803EDD80-0x00000001803EDE20
	private static int ResolveActor(string username); // 0x00000001803EDE20-0x00000001803EDEE0
}

