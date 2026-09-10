/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.ShopAvatar
{
	public static class ShopAvatarApi // TypeDefIndex: 2297
	{
		// Fields
		public const long HTTP_NOT_FOUND = 404; // Metadata: 0x0068E68A
		public const long HTTP_TOO_MANY = 429; // Metadata: 0x0068E692
		private static readonly Regex CodeTagPattern; // 0x00
		private static readonly Regex HttpStatusPattern; // 0x08
	
		// Nested types
		public delegate void ErrorHandler(string message, long httpCode); // TypeDefIndex: 2298; 0x00000001807B4030-0x00000001807B4040
	
		[Serializable]
		private class PurchaseReq // TypeDefIndex: 2299
		{
			// Fields
			public long userId; // 0x10
			public long shopId; // 0x18
			public bool equipNow; // 0x20
	
			// Constructors
			public PurchaseReq(); // 0x00000001802E9CB0-0x00000001802E9CC0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass7_0<T> // TypeDefIndex: 2300
		{
			// Fields
			public Action<T> onOk;
			public ErrorHandler onError;
	
			// Constructors
			public __c__DisplayClass7_0();
	
			// Methods
			internal void _Send_b__0(T d);
			internal void _Send_b__1(string e);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass8_0<T> // TypeDefIndex: 2301
		{
			// Fields
			public Action<T> onOk;
			public ErrorHandler onError;
	
			// Constructors
			public __c__DisplayClass8_0();
	
			// Methods
			internal void _Post_b__0(T d);
			internal void _Post_b__1(string e);
		}
	
		// Constructors
		static ShopAvatarApi(); // 0x00000001807B48A0-0x00000001807B4990
	
		// Methods
		public static Coroutine GetPage(long userId, int category, int rarity, bool hideOwned, string sort, int page, Action<ShopAvatarDataDTO> onOk, ErrorHandler onError); // 0x00000001807B43F0-0x00000001807B4580
		public static Coroutine GetPortraits(long userId, Action<ShopAvatarPortraitDTO[]> onOk, ErrorHandler onError); // 0x00000001807B4580-0x00000001807B4630
		public static Coroutine Purchase(long userId, long shopId, bool equipNow, Action<ShopAvatarPurchaseDTO> onOk, ErrorHandler onError); // 0x00000001807B47A0-0x00000001807B48A0
		private static Coroutine Send<T>(string url, Action<T> onOk, ErrorHandler onError);
		private static Coroutine Post<T>(string url, object body, Action<T> onOk, ErrorHandler onError);
		private static void Ok<T>(Action<T> onOk, T data);
		private static void Fail(ErrorHandler onError, string message, long code); // 0x00000001807B4380-0x00000001807B43F0
		public static long ParseHttpCode(string error); // 0x00000001807B4650-0x00000001807B47A0
		public static bool IsFeatureMissing(long httpCode); // 0x00000001807B4630-0x00000001807B4640
		public static bool IsRateLimited(long httpCode); // 0x00000001807B4640-0x00000001807B4650
	}
}
