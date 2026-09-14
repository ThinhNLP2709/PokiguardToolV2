/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.ShopAvatar
{
	public static class ShopAvatarApi // TypeDefIndex: 2733
	{
		// Fields
		private static readonly Regex CodeTagPattern; // 0x00
		private static readonly Regex HttpStatusPattern; // 0x08
	
		// Nested types
		public delegate void ErrorHandler(string message, long httpCode); // TypeDefIndex: 2734; 0x0000000180C72AC0-0x0000000180C72AD0
	
		[Serializable]
		private class PurchaseReq // TypeDefIndex: 2735
		{
			// Fields
			public long userId; // 0x10
			public long shopId; // 0x18
			public bool equipNow; // 0x20
	
			// Constructors
			public PurchaseReq(); // 0x000000018028A320-0x000000018028A330
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass7_0<T> // TypeDefIndex: 2736
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
		private sealed class __c__DisplayClass8_0<T> // TypeDefIndex: 2737
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
		static ShopAvatarApi(); // 0x0000000180C72810-0x0000000180C729B0
	
		// Methods
		public static Coroutine GetPage(long userId, int category, int rarity, bool hideOwned, string sort, int page, Action<ShopAvatarDataDTO> onOk, ErrorHandler onError); // 0x0000000180C72120-0x0000000180C72250
		public static Coroutine GetPortraits(long userId, Action<ShopAvatarPortraitDTO[]> onOk, ErrorHandler onError); // 0x0000000180C72250-0x0000000180C723E0
		public static Coroutine Purchase(long userId, long shopId, bool equipNow, Action<ShopAvatarPurchaseDTO> onOk, ErrorHandler onError); // 0x0000000180C723E0-0x0000000180C72560
		private static Coroutine Send<T>(string url, Action<T> onOk, ErrorHandler onError);
		private static Coroutine Post<T>(string url, object body, Action<T> onOk, ErrorHandler onError);
		private static void Ok<T>(Action<T> onOk, T data);
		private static void Fail(ErrorHandler onError, string message, long code); // 0x0000000180C72560-0x0000000180C725D0
		public static long ParseHttpCode(string error); // 0x0000000180C725D0-0x0000000180C727F0
		public static bool IsFeatureMissing(long httpCode); // 0x0000000180C727F0-0x0000000180C72800
		public static bool IsRateLimited(long httpCode); // 0x0000000180C72800-0x0000000180C72810
	}
}
