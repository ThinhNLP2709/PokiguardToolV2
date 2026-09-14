/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class TeamChatMatchBootstrap : MonoBehaviour // TypeDefIndex: 565
{
	// Fields
	private static TeamChatMatchBootstrap _instance; // 0x00

	// Constructors
	public TeamChatMatchBootstrap(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static void EnsureForMatch(); // 0x00000001803ED8D0-0x00000001803EDDF0
	private void OnEnable(); // 0x00000001803EDDF0-0x00000001803EDFB0
	private void OnDisable(); // 0x00000001803EDFB0-0x00000001803EE170
	private void HandleTeamMessage(ChatMessageDTO m); // 0x00000001803EE170-0x00000001803EE490
	private static RectTransform ResolveBoardRect(); // 0x00000001803EE490-0x00000001803EE900
	private void OnDestroy(); // 0x00000001803EE900-0x00000001803EEAC0
	private void HandleTeamEmote(ChatMessageDTO m); // 0x00000001803EEAC0-0x00000001803EEB60
	private static int ResolveActor(string username); // 0x00000001803EEB60-0x00000001803EEC20
}

