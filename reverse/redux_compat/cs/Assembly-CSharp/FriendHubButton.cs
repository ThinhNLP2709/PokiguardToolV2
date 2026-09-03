/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class FriendHubButton : MonoBehaviour // TypeDefIndex: 518
{
	// Fields
	private const float REFETCH_COOLDOWN = 5f; // Metadata: 0x0064C519
	public GameObject badge; // 0x20
	public UnityEngine.UI.Text txtCount; // 0x28
	private long _count; // 0x30
	private float _lastFetchAt; // 0x38
	private bool _pendingFetch; // 0x3C
	private Vector3 _badgeBaseScale; // 0x40
	private int _pulseTweenId; // 0x4C

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 519
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__13_0; // 0x08

		// Constructors
		static __c(); // 0x000000018038E2C0-0x000000018038E330
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _Fetch_b__13_0(string err); // 0x00000001802E76C0-0x00000001802E76D0
	}

	// Constructors
	public FriendHubButton(); // 0x0000000180385580-0x00000001803855C0

	// Methods
	private void Awake(); // 0x0000000180384700-0x0000000180384980
	private void OnEnable(); // 0x0000000180385140-0x00000001803852B0
	private void OnDisable(); // 0x0000000180384FD0-0x0000000180385140
	private void OpenPanel(); // 0x00000001803852C0-0x0000000180385310
	private void OnFriendSignal(ChatMessageDTO _); // 0x00000001803852B0-0x00000001803852C0
	private void Fetch(); // 0x0000000180384A80-0x0000000180384CF0
	private void FetchDelayed(); // 0x0000000180384A70-0x0000000180384A80
	private void OnBadge(FriendBadgeData data); // 0x0000000180384CF0-0x0000000180384FD0
	private void Pulse(); // 0x0000000180385310-0x00000001803854D0
	private void CancelPulse(); // 0x0000000180384980-0x0000000180384A70
	[CompilerGenerated]
	private void _Pulse_b__16_0(); // 0x00000001803854D0-0x0000000180385580
}

