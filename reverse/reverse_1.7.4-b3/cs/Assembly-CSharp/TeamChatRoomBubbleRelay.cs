/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class TeamChatRoomBubbleRelay : MonoBehaviour // TypeDefIndex: 582
{
	// Fields
	private static TeamChatRoomBubbleRelay _instance; // 0x00

	// Constructors
	public TeamChatRoomBubbleRelay(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static void Ensure(); // 0x000000018040C660-0x000000018040C830
	private void OnEnable(); // 0x000000018040C830-0x000000018040C9A0
	private void OnDisable(); // 0x000000018040C9A0-0x000000018040CB10
	private void OnDestroy(); // 0x000000018040CB10-0x000000018040CCD0
	private void HandleTeamMessage(ChatMessageDTO m); // 0x000000018040CCD0-0x000000018040CF80
	private static bool SameUser(string a, string b); // 0x000000018040CF80-0x000000018040D060
	private static bool TryResolveCoop(string username, out Transform parent, out Vector3 top, out SpriteRenderer sortAbove); // 0x000000018040D060-0x000000018040D440
	private static bool TryResolvePvp(string username, out Transform parent, out Vector3 top, out SpriteRenderer sortAbove); // 0x000000018040D440-0x000000018040D800
	private static SpriteRenderer HeadOf(SpriteRenderer pet, SpriteRenderer avatar, Transform fallback, out Vector3 top); // 0x000000018040D800-0x000000018040DAD0
	private static bool Visible(SpriteRenderer r); // 0x000000018040DAD0-0x000000018040DD30
}

