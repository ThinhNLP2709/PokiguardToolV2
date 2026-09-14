/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.Avatar
{
	public static class AvatarCompositeCache // TypeDefIndex: 2905
	{
		// Fields
		private static readonly Dictionary<string, Entry> _map; // 0x00
		private static readonly Dictionary<object, string> _owners; // 0x08
		private static long _clock; // 0x10
		private static string _pinnedKey; // 0x18
		private static int _sinceSweep; // 0x20
		private static readonly Dictionary<string, float> _failed; // 0x28
	
		// Nested types
		private sealed class Entry // TypeDefIndex: 2906
		{
			// Fields
			public string key; // 0x10
			public Sprite sprite; // 0x18
			public Texture2D texture; // 0x20
			public int refs; // 0x28
			public bool pinned; // 0x2C
			public long stamp; // 0x30
	
			// Constructors
			public Entry(); // 0x000000018028A320-0x000000018028A330
		}
	
		// Constructors
		static AvatarCompositeCache(); // 0x0000000180D41BB0-0x0000000180D41EF0
	
		// Methods
		public static void MarkFailed(string key); // 0x0000000180D3F2E0-0x0000000180D3F3E0
		public static bool IsFailedRecently(string key); // 0x0000000180D3F3E0-0x0000000180D3F570
		public static Sprite Peek(string key); // 0x0000000180D3F570-0x0000000180D3F870
		public static Sprite Put(string key, Sprite sprite, Texture2D texture); // 0x0000000180D3F870-0x0000000180D3FF00
		public static void AddRef(object owner, string key); // 0x0000000180D3FF00-0x0000000180D40440
		public static void ReleaseOwner(object owner); // 0x0000000180D40440-0x0000000180D40870
		public static void Pin(string specKey); // 0x0000000180D40870-0x0000000180D40B10
		public static void Invalidate(); // 0x0000000180D40B10-0x0000000180D40E60
		private static void DecRef(string key); // 0x0000000180D40E60-0x0000000180D40F20
		private static void Trim(); // 0x0000000180D40F20-0x0000000180D41210
		private static void SweepDeadOwners(); // 0x0000000180D41210-0x0000000180D41700
		private static void Drop(Entry e); // 0x0000000180D41700-0x0000000180D41860
		private static void DestroyPair(Sprite sprite, Texture2D texture); // 0x0000000180D41860-0x0000000180D41BB0
	}
}
