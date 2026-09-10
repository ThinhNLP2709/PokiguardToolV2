/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class TeamChatRoomBubbleRelay : MonoBehaviour // TypeDefIndex: 529
{
	// Fields
	private static TeamChatRoomBubbleRelay _instance; // 0x00

	// Constructors
	public TeamChatRoomBubbleRelay(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	public static void Ensure(); // 0x00000001803CBE30-0x00000001803CBF30
	private void OnEnable(); // 0x00000001803CC400-0x00000001803CC4F0
	private void OnDisable(); // 0x00000001803CC310-0x00000001803CC400
	private void OnDestroy(); // 0x00000001803CC260-0x00000001803CC310
	private void HandleTeamMessage(ChatMessageDTO m); // 0x00000001803CBF30-0x00000001803CC110
	private static bool SameUser(string a, string b); // 0x00000001803CC4F0-0x00000001803CC550
	private static bool TryResolveCoop(string username, out Transform parent, out Vector3 top, out SpriteRenderer sortAbove); // 0x00000001803CC550-0x00000001803CC790
	private static bool TryResolvePvp(string username, out Transform parent, out Vector3 top, out SpriteRenderer sortAbove); // 0x00000001803CC790-0x00000001803CC9B0
	private static SpriteRenderer HeadOf(SpriteRenderer pet, SpriteRenderer avatar, Transform fallback, out Vector3 top); // 0x00000001803CC110-0x00000001803CC260
	private static bool Visible(SpriteRenderer r); // 0x00000001803CC9B0-0x00000001803CCA60
}

