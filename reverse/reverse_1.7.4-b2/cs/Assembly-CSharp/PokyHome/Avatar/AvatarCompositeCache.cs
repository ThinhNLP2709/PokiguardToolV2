/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.Avatar
{
	public static class AvatarCompositeCache // TypeDefIndex: 2458
	{
		// Fields
		private static readonly Dictionary<string, Entry> _map; // 0x00
		private static readonly Dictionary<object, string> _owners; // 0x08
		private static long _clock; // 0x10
		private static string _pinnedKey; // 0x18
		private const int SWEEP_EVERY = 256; // Metadata: 0x0068F529
		private static int _sinceSweep; // 0x20
		private static readonly Dictionary<string, float> _failed; // 0x28
		public const float FAILED_TTL = 60f; // Metadata: 0x0068F52B
	
		// Properties
		public static int Count { get; } // 0x00000001807FD680-0x00000001807FD6E0 
	
		// Nested types
		private sealed class Entry // TypeDefIndex: 2459
		{
			// Fields
			public string key; // 0x10
			public Sprite sprite; // 0x18
			public Texture2D texture; // 0x20
			public int refs; // 0x28
			public bool pinned; // 0x2C
			public long stamp; // 0x30
	
			// Constructors
			public Entry(); // 0x00000001802E9CB0-0x00000001802E9CC0
		}
	
		// Constructors
		static AvatarCompositeCache(); // 0x00000001807FD430-0x00000001807FD680
	
		// Methods
		public static void MarkFailed(string key); // 0x00000001807FC510-0x00000001807FC5B0
		public static bool IsFailedRecently(string key); // 0x00000001807FC420-0x00000001807FC510
		public static Sprite Peek(string key); // 0x00000001807FC5B0-0x00000001807FC780
		public static Sprite Put(string key, Sprite sprite, Texture2D texture); // 0x00000001807FC910-0x00000001807FCC80
		public static void AddRef(object owner, string key); // 0x00000001807FBD10-0x00000001807FBF40
		public static void ReleaseOwner(object owner); // 0x00000001807FCC80-0x00000001807FCDF0
		public static void Pin(string specKey); // 0x00000001807FC780-0x00000001807FC910
		public static void Invalidate(); // 0x00000001807FC1B0-0x00000001807FC420
		private static void DecRef(string key); // 0x00000001807FBF40-0x00000001807FBFF0
		private static void Trim(); // 0x00000001807FD190-0x00000001807FD430
		private static void SweepDeadOwners(); // 0x00000001807FCDF0-0x00000001807FD190
		private static void Drop(Entry e); // 0x00000001807FC0F0-0x00000001807FC1B0
		private static void DestroyPair(Sprite sprite, Texture2D texture); // 0x00000001807FBFF0-0x00000001807FC0F0
	}
}
