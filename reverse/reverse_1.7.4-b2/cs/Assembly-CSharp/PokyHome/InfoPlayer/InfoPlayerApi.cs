/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.InfoPlayer
{
	public static class InfoPlayerApi // TypeDefIndex: 2358
	{
		// Fields
		public const long HTTP_NOT_FOUND = 404; // Metadata: 0x0068ED9E
		private static readonly Regex CodeTagPattern; // 0x00
		private static readonly Regex HttpStatusPattern; // 0x08
	
		// Nested types
		public delegate void ErrorHandler(string message, long httpCode); // TypeDefIndex: 2359; 0x00000001807B4030-0x00000001807B4040
	
		[Serializable]
		private class EquipReq // TypeDefIndex: 2360
		{
			// Fields
			public long rowId; // 0x10
	
			// Constructors
			public EquipReq(); // 0x00000001802E9CB0-0x00000001802E9CC0
		}
	
		[Serializable]
		private class UnequipReq // TypeDefIndex: 2361
		{
			// Fields
			public int slot; // 0x10
	
			// Constructors
			public UnequipReq(); // 0x00000001802E9CB0-0x00000001802E9CC0
		}
	
		[Serializable]
		private class AvatarHiddenReq // TypeDefIndex: 2362
		{
			// Fields
			public bool hidden; // 0x10
	
			// Constructors
			public AvatarHiddenReq(); // 0x00000001802E9CB0-0x00000001802E9CC0
		}
	
		[Serializable]
		private class EmptyReq // TypeDefIndex: 2363
		{
			// Constructors
			public EmptyReq(); // 0x00000001802E9CB0-0x00000001802E9CC0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass15_0 // TypeDefIndex: 2364
		{
			// Fields
			public Action onOk; // 0x10
	
			// Constructors
			public __c__DisplayClass15_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _SendFriendRequest_b__0(object _); // 0x0000000180410BE0-0x0000000180410C00
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass16_0<T> // TypeDefIndex: 2365
		{
			// Fields
			public Action<T> onOk;
			public ErrorHandler onError;
	
			// Constructors
			public __c__DisplayClass16_0();
	
			// Methods
			internal void _Send_b__0(T d);
			internal void _Send_b__1(string e);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass17_0<T> // TypeDefIndex: 2366
		{
			// Fields
			public Action<T> onOk;
			public ErrorHandler onError;
	
			// Constructors
			public __c__DisplayClass17_0();
	
			// Methods
			internal void _Post_b__0(T d);
			internal void _Post_b__1(string e);
		}
	
		// Constructors
		static InfoPlayerApi(); // 0x00000001807D89C0-0x00000001807D8AB0
	
		// Methods
		public static Coroutine GetProfile(long userId, Action<ProfileDTO> onOk, ErrorHandler onError); // 0x00000001807D8180-0x00000001807D8230
		public static Coroutine ViewProfile(long userId, long targetId, Action<ProfileDTO> onOk, ErrorHandler onError); // 0x00000001807D8900-0x00000001807D89C0
		public static Coroutine GetBook(long userId, Action<EquipBookDTO> onOk, ErrorHandler onError); // 0x00000001807D80D0-0x00000001807D8180
		public static Coroutine GetBag(long userId, EquipCategory category, EquipSlot slot, bool sortByPower, int page, Action<EquipBagDTO> onOk, ErrorHandler onError); // 0x00000001807D7FE0-0x00000001807D80D0
		public static Coroutine Equip(long userId, long rowId, Action<EquipBookDTO> onOk, ErrorHandler onError); // 0x00000001807D7E70-0x00000001807D7F70
		public static Coroutine Unequip(long userId, EquipSlot slot, Action<EquipBookDTO> onOk, ErrorHandler onError); // 0x00000001807D8700-0x00000001807D8800
		public static Coroutine SetAvatarSetHidden(long userId, bool hidden, Action<EquipBookDTO> onOk, ErrorHandler onError); // 0x00000001807D8600-0x00000001807D8700
		public static Coroutine UpgradeStar(long userId, long rowId, Action<EquipBookDTO> onOk, ErrorHandler onError); // 0x00000001807D8800-0x00000001807D8900
		public static Coroutine Salvage(long userId, long rowId, Action<EquipBookDTO> onOk, ErrorHandler onError); // 0x00000001807D8380-0x00000001807D8480
		public static Coroutine SendFriendRequest(long userId, long targetId, Action onOk, ErrorHandler onError); // 0x00000001807D8480-0x00000001807D8600
		private static Coroutine Send<T>(string url, Action<T> onOk, ErrorHandler onError);
		private static Coroutine Post<T>(string url, object body, Action<T> onOk, ErrorHandler onError);
		private static void Ok<T>(Action<T> onOk, T data);
		private static void Fail(ErrorHandler onError, string message, long code); // 0x00000001807D7F70-0x00000001807D7FE0
		public static long ParseHttpCode(string error); // 0x00000001807D8230-0x00000001807D8380
		public static bool IsFeatureMissing(long httpCode); // 0x00000001807B4630-0x00000001807B4640
	}
}
