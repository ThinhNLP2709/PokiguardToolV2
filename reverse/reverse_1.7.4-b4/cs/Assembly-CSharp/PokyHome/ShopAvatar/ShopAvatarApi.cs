/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.ShopAvatar
{
	public static class ShopAvatarApi // TypeDefIndex: 2740
	{
		// Fields
		private static readonly Regex CodeTagPattern; // 0x00
		private static readonly Regex HttpStatusPattern; // 0x08
	
		// Nested types
		public delegate void ErrorHandler(string message, long httpCode); // TypeDefIndex: 2741; 0x0000000180CA6170-0x0000000180CA6180
	
		[Serializable]
		private class PurchaseReq // TypeDefIndex: 2742
		{
			// Fields
			public long userId; // 0x10
			public long shopId; // 0x18
			public bool equipNow; // 0x20
	
			// Constructors
			public PurchaseReq(); // 0x000000018028A320-0x000000018028A330
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass7_0<T> // TypeDefIndex: 2743
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
		private sealed class __c__DisplayClass8_0<T> // TypeDefIndex: 2744
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
		static ShopAvatarApi(); // 0x0000000180CA5EC0-0x0000000180CA6060
	
		// Methods
		public static Coroutine GetPage(long userId, int category, int rarity, bool hideOwned, string sort, int page, Action<ShopAvatarDataDTO> onOk, ErrorHandler onError); // 0x0000000180CA57D0-0x0000000180CA5900
		public static Coroutine GetPortraits(long userId, Action<ShopAvatarPortraitDTO[]> onOk, ErrorHandler onError); // 0x0000000180CA5900-0x0000000180CA5A90
		public static Coroutine Purchase(long userId, long shopId, bool equipNow, Action<ShopAvatarPurchaseDTO> onOk, ErrorHandler onError); // 0x0000000180CA5A90-0x0000000180CA5C10
		private static Coroutine Send<T>(string url, Action<T> onOk, ErrorHandler onError);
		private static Coroutine Post<T>(string url, object body, Action<T> onOk, ErrorHandler onError);
		private static void Ok<T>(Action<T> onOk, T data);
		private static void Fail(ErrorHandler onError, string message, long code); // 0x0000000180CA5C10-0x0000000180CA5C80
		public static long ParseHttpCode(string error); // 0x0000000180CA5C80-0x0000000180CA5EA0
		public static bool IsFeatureMissing(long httpCode); // 0x0000000180CA5EA0-0x0000000180CA5EB0
		public static bool IsRateLimited(long httpCode); // 0x0000000180CA5EB0-0x0000000180CA5EC0
	}
}
