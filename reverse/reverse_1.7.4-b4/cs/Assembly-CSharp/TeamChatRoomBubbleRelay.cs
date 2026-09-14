/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class TeamChatRoomBubbleRelay : MonoBehaviour // TypeDefIndex: 583
{
	// Fields
	private static TeamChatRoomBubbleRelay _instance; // 0x00

	// Constructors
	public TeamChatRoomBubbleRelay(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static void Ensure(); // 0x000000018040D3C0-0x000000018040D590
	private void OnEnable(); // 0x000000018040D590-0x000000018040D700
	private void OnDisable(); // 0x000000018040D700-0x000000018040D870
	private void OnDestroy(); // 0x000000018040D870-0x000000018040DA30
	private void HandleTeamMessage(ChatMessageDTO m); // 0x000000018040DA30-0x000000018040DCE0
	private static bool SameUser(string a, string b); // 0x000000018040DCE0-0x000000018040DDC0
	private static bool TryResolveCoop(string username, out Transform parent, out Vector3 top, out SpriteRenderer sortAbove); // 0x000000018040DDC0-0x000000018040E1A0
	private static bool TryResolvePvp(string username, out Transform parent, out Vector3 top, out SpriteRenderer sortAbove); // 0x000000018040E1A0-0x000000018040E560
	private static SpriteRenderer HeadOf(SpriteRenderer pet, SpriteRenderer avatar, Transform fallback, out Vector3 top); // 0x000000018040E560-0x000000018040E830
	private static bool Visible(SpriteRenderer r); // 0x000000018040E830-0x000000018040EA90
}

