/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	internal sealed class NetEventSource : EventSource // TypeDefIndex: 8997
	{
		// Fields
		public static readonly NetEventSource Log; // 0x00
	
		// Properties
		public static bool IsEnabled { get; } // 0x0000000181BD1440-0x0000000181BD14A0 
	
		// Nested types
		public class Keywords // TypeDefIndex: 8998
		{
			// Fields
			public const EventKeywords Default = EventKeywords.None; // Metadata: 0x0069E17D
			public const EventKeywords Debug = EventKeywords.None; // Metadata: 0x0069E185
			public const EventKeywords EnterExit = EventKeywords.None; // Metadata: 0x0069E18D
		}
	
		// Constructors
		public NetEventSource(); // 0x00000001815A75F0-0x00000001815A7600
		static NetEventSource(); // 0x0000000181BD13D0-0x0000000181BD1440
	
		// Methods
		[NonEvent]
		public static void Enter(object thisOrContextObject, FormattableString formattableString = null, [CallerMemberName] string memberName = null); // 0x0000000181BCFB60-0x0000000181BCFCD0
		[NonEvent]
		public static void Enter(object thisOrContextObject, object arg0, [CallerMemberName] string memberName = null); // 0x0000000181BCF9F0-0x0000000181BCFB60
		[NonEvent]
		public static void Enter(object thisOrContextObject, object arg0, object arg1, object arg2, [CallerMemberName] string memberName = null); // 0x0000000181BCFCD0-0x0000000181BCFE70
		[Event(1, Level = EventLevel.Informational, Keywords = EventKeywords.None)]
		private void Enter(string thisOrContextObject, string memberName, string parameters); // 0x0000000181BCFE70-0x0000000181BCFF00
		[NonEvent]
		public static void Exit(object thisOrContextObject, FormattableString formattableString = null, [CallerMemberName] string memberName = null); // 0x0000000181BD0190-0x0000000181BD0300
		[NonEvent]
		public static void Exit(object thisOrContextObject, object arg0, [CallerMemberName] string memberName = null); // 0x0000000181BD0300-0x0000000181BD0470
		[Event(2, Level = EventLevel.Informational, Keywords = EventKeywords.None)]
		private void Exit(string thisOrContextObject, string memberName, string result); // 0x0000000181BD0100-0x0000000181BD0190
		[NonEvent]
		public static void Info(object thisOrContextObject, FormattableString formattableString = null, [CallerMemberName] string memberName = null); // 0x0000000181BD0E50-0x0000000181BD0FC0
		[NonEvent]
		public static void Info(object thisOrContextObject, object message, [CallerMemberName] string memberName = null); // 0x0000000181BD1050-0x0000000181BD11C0
		[Event(4, Level = EventLevel.Informational, Keywords = EventKeywords.None)]
		private void Info(string thisOrContextObject, string memberName, string message); // 0x0000000181BD0FC0-0x0000000181BD1050
		[NonEvent]
		public static void Error(object thisOrContextObject, object message, [CallerMemberName] string memberName = null); // 0x0000000181BCFF90-0x0000000181BD0100
		[Event(5, Level = EventLevel.Warning, Keywords = EventKeywords.None)]
		private void ErrorMessage(string thisOrContextObject, string memberName, string message); // 0x0000000181BCFF00-0x0000000181BCFF90
		[NonEvent]
		public static void Fail(object thisOrContextObject, object message, [CallerMemberName] string memberName = null); // 0x0000000181BD0470-0x0000000181BD05E0
		[Event(6, Level = EventLevel.Critical, Keywords = EventKeywords.None)]
		private void CriticalFailure(string thisOrContextObject, string memberName, string message); // 0x0000000181BCF960-0x0000000181BCF9F0
		[NonEvent]
		public static void Associate(object first, object second, [CallerMemberName] string memberName = null); // 0x0000000181BCF750-0x0000000181BCF8C0
		[Event(3, Level = EventLevel.Informational, Keywords = EventKeywords.None, Message = "[{2}]<-->[{3}]")]
		private void Associate(string thisOrContextObject, string memberName, string first, string second); // 0x0000000181BCF8C0-0x0000000181BCF960
		[NonEvent]
		public static string IdOf(object value); // 0x0000000181BD0D60-0x0000000181BD0E50
		[NonEvent]
		public static int GetHashCode(object value); // 0x0000000181BD0D40-0x0000000181BD0D60
		[NonEvent]
		public static object Format(object value); // 0x0000000181BD0980-0x0000000181BD0D40
		[NonEvent]
		private static string Format(FormattableString s); // 0x0000000181BD05E0-0x0000000181BD0980
		[NonEvent]
		private void WriteEvent(int eventId, string arg1, string arg2, string arg3, string arg4); // 0x0000000181BD11C0-0x0000000181BD13D0
	}
}
