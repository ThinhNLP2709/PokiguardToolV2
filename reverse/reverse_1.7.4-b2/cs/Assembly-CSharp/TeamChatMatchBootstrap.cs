/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class TeamChatMatchBootstrap : MonoBehaviour // TypeDefIndex: 511
{
	// Fields
	private static TeamChatMatchBootstrap _instance; // 0x00

	// Constructors
	public TeamChatMatchBootstrap(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	public static void EnsureForMatch(); // 0x00000001803AA150-0x00000001803AA420
	private void OnEnable(); // 0x00000001803AA890-0x00000001803AA9C0
	private void OnDisable(); // 0x00000001803AA760-0x00000001803AA890
	private void HandleTeamMessage(ChatMessageDTO m); // 0x00000001803AA4C0-0x00000001803AA6B0
	private static RectTransform ResolveBoardRect(); // 0x00000001803AAAC0-0x00000001803AACF0
	private void OnDestroy(); // 0x00000001803AA6B0-0x00000001803AA760
	private void HandleTeamEmote(ChatMessageDTO m); // 0x00000001803AA420-0x00000001803AA4C0
	private static int ResolveActor(string username); // 0x00000001803AA9C0-0x00000001803AAAC0
}

