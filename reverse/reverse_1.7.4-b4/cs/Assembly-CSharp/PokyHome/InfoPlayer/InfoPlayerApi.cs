/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.InfoPlayer
{
	public static class InfoPlayerApi // TypeDefIndex: 2808
	{
		// Fields
		private static readonly Regex CodeTagPattern; // 0x00
		private static readonly Regex HttpStatusPattern; // 0x08
	
		// Nested types
		public delegate void ErrorHandler(string message, long httpCode); // TypeDefIndex: 2809; 0x0000000180CA6170-0x0000000180CA6180
	
		[Serializable]
		private class EquipReq // TypeDefIndex: 2810
		{
			// Fields
			public long rowId; // 0x10
	
			// Constructors
			public EquipReq(); // 0x000000018028A320-0x000000018028A330
		}
	
		[Serializable]
		private class UnequipReq // TypeDefIndex: 2811
		{
			// Fields
			public int slot; // 0x10
	
			// Constructors
			public UnequipReq(); // 0x000000018028A320-0x000000018028A330
		}
	
		[Serializable]
		private class AvatarHiddenReq // TypeDefIndex: 2812
		{
			// Fields
			public bool hidden; // 0x10
	
			// Constructors
			public AvatarHiddenReq(); // 0x000000018028A320-0x000000018028A330
		}
	
		[Serializable]
		private class EmptyReq // TypeDefIndex: 2813
		{
			// Constructors
			public EmptyReq(); // 0x000000018028A320-0x000000018028A330
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass16_0 // TypeDefIndex: 2814
		{
			// Fields
			public Action onOk; // 0x10
	
			// Constructors
			public __c__DisplayClass16_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _SendFriendRequest_b__0(object _); // 0x0000000180335C50-0x0000000180335C70
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass17_0<T> // TypeDefIndex: 2815
		{
			// Fields
			public Action<T> onOk;
			public ErrorHandler onError;
	
			// Constructors
			public __c__DisplayClass17_0();
	
			// Methods
			internal void _Send_b__0(T d);
			internal void _Send_b__1(string e);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass18_0<T> // TypeDefIndex: 2816
		{
			// Fields
			public Action<T> onOk;
			public ErrorHandler onError;
	
			// Constructors
			public __c__DisplayClass18_0();
	
			// Methods
			internal void _Post_b__0(T d);
			internal void _Post_b__1(string e);
		}
	
		// Constructors
		static InfoPlayerApi(); // 0x0000000180CF71D0-0x0000000180CF7370
	
		// Methods
		public static Coroutine GetProfile(long userId, Action<ProfileDTO> onOk, ErrorHandler onError); // 0x0000000180CF5E50-0x0000000180CF5FE0
		public static Coroutine ViewProfile(long userId, long targetId, Action<ProfileDTO> onOk, ErrorHandler onError); // 0x0000000180CF5FE0-0x0000000180CF61A0
		public static Coroutine GetBag(long userId, EquipCategory category, EquipSlot slot, bool sortByPower, int page, Action<EquipBagDTO> onOk, ErrorHandler onError); // 0x0000000180CF61A0-0x0000000180CF62A0
		public static Coroutine GetItem(long userId, long itemId, Action<EquipItemDTO> onOk, ErrorHandler onError); // 0x0000000180CF62A0-0x0000000180CF6460
		public static Coroutine Equip(long userId, long rowId, Action<EquipBookDTO> onOk, ErrorHandler onError); // 0x0000000180CF6460-0x0000000180CF6630
		public static Coroutine Unequip(long userId, EquipSlot slot, Action<EquipBookDTO> onOk, ErrorHandler onError); // 0x0000000180CF6630-0x0000000180CF6800
		public static Coroutine SetAvatarSetHidden(long userId, bool hidden, Action<EquipBookDTO> onOk, ErrorHandler onError); // 0x0000000180CF6800-0x0000000180CF69D0
		public static Coroutine UpgradeStar(long userId, long rowId, Action<EquipBookDTO> onOk, ErrorHandler onError); // 0x0000000180CF69D0-0x0000000180CF6BA0
		public static Coroutine Salvage(long userId, long rowId, Action<EquipBookDTO> onOk, ErrorHandler onError); // 0x0000000180CF6BA0-0x0000000180CF6D70
		public static Coroutine SendFriendRequest(long userId, long targetId, Action onOk, ErrorHandler onError); // 0x0000000180CF6D70-0x0000000180CF6F40
		private static Coroutine Send<T>(string url, Action<T> onOk, ErrorHandler onError);
		private static Coroutine Post<T>(string url, object body, Action<T> onOk, ErrorHandler onError);
		private static void Ok<T>(Action<T> onOk, T data);
		private static void Fail(ErrorHandler onError, string message, long code); // 0x0000000180CF6F40-0x0000000180CF6FB0
		public static long ParseHttpCode(string error); // 0x0000000180CF6FB0-0x0000000180CF71D0
		public static bool IsFeatureMissing(long httpCode); // 0x0000000180CA5EA0-0x0000000180CA5EB0
	}
}
