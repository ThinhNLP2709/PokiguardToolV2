/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Microsoft.Win32;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	[TypeForwardedFrom("System.Core, Version=2.0.5.0, Culture=Neutral, PublicKeyToken=7cec85d7bea7798e")]
	public sealed class TimeZoneInfo : IEquatable<System.TimeZoneInfo>, ISerializable, IDeserializationCallback // TypeDefIndex: 2174
	{
		// Fields
		private static Lazy<bool> lazyHaveRegistry; // 0x00
		private readonly string _id; // 0x10
		private readonly string _displayName; // 0x18
		private readonly string _standardDisplayName; // 0x20
		private readonly string _daylightDisplayName; // 0x28
		private readonly TimeSpan _baseUtcOffset; // 0x30
		private readonly bool _supportsDaylightSavingTime; // 0x38
		private readonly AdjustmentRule[] _adjustmentRules; // 0x40
		private static readonly TimeZoneInfo s_utcTimeZone; // 0x08
		private static CachedData s_cachedData; // 0x10
		private static readonly DateTime s_maxDateOnly; // 0x18
		private static readonly DateTime s_minDateOnly; // 0x20
		private static readonly TimeSpan MaxOffset; // 0x28
		private static readonly TimeSpan MinOffset; // 0x30
	
		// Properties
		private static bool HaveRegistry { get; } // 0x00000001815763E0-0x0000000181576450 
		public string Id { get; } // 0x0000000180377550-0x0000000180377560 
		public string DisplayName { get; } // 0x0000000181571840-0x0000000181571860 
		public TimeSpan BaseUtcOffset { get; } // 0x000000018031E110-0x000000018031E120 
		public static TimeZoneInfo Local { get; } // 0x0000000181576450-0x00000001815764E0 
		public static TimeZoneInfo Utc { get; } // 0x00000001815764E0-0x0000000181576530 
	
		// Nested types
		private sealed class CachedData // TypeDefIndex: 2175
		{
			// Fields
			private OffsetAndRule _oneYearLocalFromUtc; // 0x10
			private TimeZoneInfo _localTimeZone; // 0x18
			public Dictionary<string, TimeZoneInfo> _systemTimeZones; // 0x20
			public ReadOnlyCollection<TimeZoneInfo> _readOnlySystemTimeZones; // 0x28
			public bool _allSystemTimeZonesRead; // 0x30
	
			// Properties
			public TimeZoneInfo Local { get; } // 0x00000001815603D0-0x0000000181560410 
	
			// Constructors
			public CachedData(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			private static TimeZoneInfo GetCurrentOneYearLocal(); // 0x0000000181560100-0x0000000181560200
			public OffsetAndRule GetOneYearLocalFromUtc(int year); // 0x0000000181560200-0x00000001815603D0
			private TimeZoneInfo CreateLocal(); // 0x000000018155FEC0-0x0000000181560070
			public DateTimeKind GetCorrespondingKind(TimeZoneInfo timeZone); // 0x0000000181560070-0x0000000181560100
		}
	
		private sealed class OffsetAndRule // TypeDefIndex: 2176
		{
			// Fields
			public readonly int Year; // 0x10
			public readonly TimeSpan Offset; // 0x18
			public readonly AdjustmentRule Rule; // 0x20
	
			// Constructors
			public OffsetAndRule(int year, TimeSpan offset, AdjustmentRule rule); // 0x000000018156ACD0-0x000000018156AD30
		}
	
		internal struct DYNAMIC_TIME_ZONE_INFORMATION // TypeDefIndex: 2177
		{
			// Fields
			internal Interop.Kernel32.TIME_ZONE_INFORMATION TZI; // 0x00
			internal string TimeZoneKeyName; // 0xB0
			internal byte DynamicDaylightTimeDisabled; // 0xB8
		}
	
		private enum TimeZoneInfoResult // TypeDefIndex: 2178
		{
			Success = 0,
			TimeZoneNotFoundException = 1,
			InvalidTimeZoneException = 2,
			SecurityException = 3
		}
	
		[Serializable]
		public sealed class AdjustmentRule : IEquatable<AdjustmentRule>, ISerializable, IDeserializationCallback // TypeDefIndex: 2179
		{
			// Fields
			private readonly DateTime _dateStart; // 0x10
			private readonly DateTime _dateEnd; // 0x18
			private readonly TimeSpan _daylightDelta; // 0x20
			private readonly TransitionTime _daylightTransitionStart; // 0x28
			private readonly TransitionTime _daylightTransitionEnd; // 0x40
			private readonly TimeSpan _baseUtcOffsetDelta; // 0x58
			private readonly bool _noDaylightTransitions; // 0x60
	
			// Properties
			public DateTime DateStart { get; } // 0x0000000180377550-0x0000000180377560 
			public DateTime DateEnd { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			public TimeSpan DaylightDelta { get; } // 0x00000001802F8630-0x00000001802F8640 
			public TransitionTime DaylightTransitionStart { get; } // 0x0000000181333180-0x00000001813331A0 
			public TransitionTime DaylightTransitionEnd { get; } // 0x000000018155B160-0x000000018155B180 
			internal TimeSpan BaseUtcOffsetDelta { get; } // 0x00000001802F4000-0x00000001802F4010 
			internal bool NoDaylightTransitions { get; } // 0x000000018033D4F0-0x000000018033D500 
			internal bool HasDaylightSaving { get; } // 0x000000018155B180-0x000000018155B350 
	
			// Constructors
			private AdjustmentRule(DateTime dateStart, DateTime dateEnd, TimeSpan daylightDelta, TransitionTime daylightTransitionStart, TransitionTime daylightTransitionEnd, TimeSpan baseUtcOffsetDelta, bool noDaylightTransitions); // 0x000000018155B020-0x000000018155B130
			private AdjustmentRule(SerializationInfo info, StreamingContext context); // 0x000000018155AC80-0x000000018155B020
			internal AdjustmentRule(); // 0x000000018155B130-0x000000018155B160
	
			// Methods
			public bool Equals(AdjustmentRule other); // 0x000000018155A0C0-0x000000018155A200
			public override int GetHashCode(); // 0x000000018155A200-0x000000018155A250
			internal static AdjustmentRule CreateAdjustmentRule(DateTime dateStart, DateTime dateEnd, TimeSpan daylightDelta, TransitionTime daylightTransitionStart, TransitionTime daylightTransitionEnd, TimeSpan baseUtcOffsetDelta, bool noDaylightTransitions); // 0x0000000181559F80-0x000000018155A0C0
			internal bool IsStartDateMarkerForBeginningOfYear(); // 0x000000018155A350-0x000000018155A450
			internal bool IsEndDateMarkerForEndOfYear(); // 0x000000018155A250-0x000000018155A350
			private static void ValidateAdjustmentRule(DateTime dateStart, DateTime dateEnd, TimeSpan daylightDelta, TransitionTime daylightTransitionStart, TransitionTime daylightTransitionEnd, bool noDaylightTransitions); // 0x000000018155A730-0x000000018155AC80
			void IDeserializationCallback.OnDeserialization(object sender); // 0x000000018155A450-0x000000018155A530
			void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context); // 0x000000018155A530-0x000000018155A730
		}
	
		[Serializable]
		[IsReadOnly]
		public struct TransitionTime : IEquatable<TransitionTime>, ISerializable, IDeserializationCallback // TypeDefIndex: 2180
		{
			// Fields
			private readonly DateTime _timeOfDay; // 0x00
			private readonly byte _month; // 0x08
			private readonly byte _week; // 0x09
			private readonly byte _day; // 0x0A
			private readonly DayOfWeek _dayOfWeek; // 0x0C
			private readonly bool _isFixedDateRule; // 0x10
	
			// Properties
			public DateTime TimeOfDay { get; } // 0x00000001808BADD0-0x00000001808BADE0 
			public int Month { get; } // 0x0000000181325D60-0x0000000181325D70 
			public int Week { get; } // 0x0000000181577100-0x0000000181577110 
			public int Day { get; } // 0x00000001815770F0-0x0000000181577100 
			public DayOfWeek DayOfWeek { get; } // 0x0000000180732D30-0x0000000180732D40 
			public bool IsFixedDateRule { get; } // 0x00000001805625D0-0x00000001805625E0 
	
			// Constructors
			private TransitionTime(DateTime timeOfDay, int month, int week, int day, DayOfWeek dayOfWeek, bool isFixedDateRule); // 0x0000000181576D50-0x0000000181576DE0
			private TransitionTime(SerializationInfo info, StreamingContext context); // 0x0000000181576DE0-0x00000001815770F0
	
			// Methods
			public override bool Equals(object obj); // 0x0000000181576640-0x00000001815766E0
			public static bool operator !=(TransitionTime t1, TransitionTime t2); // 0x0000000181577110-0x0000000181577140
			public bool Equals(TransitionTime other); // 0x00000001815766E0-0x00000001815767E0
			public override int GetHashCode(); // 0x00000001815767E0-0x00000001815767F0
			public static TransitionTime CreateFixedDateRule(DateTime timeOfDay, int month, int day); // 0x0000000181576530-0x00000001815765B0
			public static TransitionTime CreateFloatingDateRule(DateTime timeOfDay, int month, int week, DayOfWeek dayOfWeek); // 0x00000001815765B0-0x0000000181576640
			private static void ValidateTransitionTime(DateTime timeOfDay, int month, int week, int day, DayOfWeek dayOfWeek); // 0x0000000181576A00-0x0000000181576D50
			void IDeserializationCallback.OnDeserialization(object sender); // 0x00000001815767F0-0x0000000181576890
			void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181576890-0x0000000181576A00
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2181
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Comparison<TimeZoneInfo> __9__49_0; // 0x08
			public static Comparison<TimeZoneInfo> __9__110_0; // 0x10
	
			// Constructors
			static __c(); // 0x00000001815775B0-0x0000000181577620
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal int _GetSystemTimeZonesWinRTFallback_b__49_0(TimeZoneInfo x, TimeZoneInfo y); // 0x0000000181577200-0x00000001815772C0
			internal int _GetSystemTimeZones_b__110_0(TimeZoneInfo x, TimeZoneInfo y); // 0x0000000181577140-0x0000000181577200
			internal bool _.cctor_b__157_0(); // 0x00000001815774C0-0x00000001815775B0
		}
	
		// Constructors
		private TimeZoneInfo([IsReadOnly] in Interop.Kernel32.TIME_ZONE_INFORMATION zone, bool dstDisabled); // 0x0000000181575FD0-0x00000001815763E0
		private TimeZoneInfo(string id, TimeSpan baseUtcOffset, string displayName, string standardDisplayName, string daylightDisplayName, AdjustmentRule[] adjustmentRules, bool disableDaylightSavingTime); // 0x0000000181575EB0-0x0000000181575FD0
		private TimeZoneInfo(SerializationInfo info, StreamingContext context); // 0x00000001815759F0-0x0000000181575E80
		static TimeZoneInfo(); // 0x0000000181575750-0x00000001815759F0
		internal TimeZoneInfo(); // 0x0000000181575E80-0x0000000181575EB0
	
		// Methods
		private static void PopulateAllSystemTimeZones(CachedData cachedData); // 0x0000000181571480-0x00000001815714E0
		private static void PopulateAllSystemTimeZonesFromRegistry(CachedData cachedData); // 0x00000001815712A0-0x0000000181571480
		private static bool CheckDaylightSavingTimeNotSupported([IsReadOnly] in Interop.Kernel32.TIME_ZONE_INFORMATION timeZone); // 0x000000018156AD30-0x000000018156AD60
		private static AdjustmentRule CreateAdjustmentRuleFromTimeZoneInformation([IsReadOnly] in Interop.Kernel32.REG_TZI_FORMAT timeZoneInformation, DateTime startDate, DateTime endDate, int defaultBaseUtcOffset); // 0x000000018156C240-0x000000018156C590
		private static string FindIdFromTimeZoneInformation([IsReadOnly] in Interop.Kernel32.TIME_ZONE_INFORMATION timeZone, out bool dstDisabled); // 0x000000018156C8A0-0x000000018156CA80
		private static TimeZoneInfo GetLocalTimeZone(CachedData cachedData); // 0x000000018156EFC0-0x000000018156F270
		private static TimeZoneInfo GetLocalTimeZoneFromWin32Data([IsReadOnly] in Interop.Kernel32.TIME_ZONE_INFORMATION timeZoneInformation, bool dstDisabled); // 0x000000018156EBA0-0x000000018156ECC0
		internal static TimeSpan GetDateTimeNowUtcOffsetFromUtc(DateTime time, out bool isAmbiguousLocalDst); // 0x000000018156CF60-0x000000018156D2C0
		private static bool TransitionTimeFromTimeZoneInformation([IsReadOnly] in Interop.Kernel32.REG_TZI_FORMAT timeZoneInformation, out TransitionTime transitionTime, bool readStartDate); // 0x0000000181572700-0x00000001815728F0
		private static bool TryCreateAdjustmentRules(string id, [IsReadOnly] in Interop.Kernel32.REG_TZI_FORMAT defaultTimeZoneInformation, out AdjustmentRule[] rules, out Exception e, int defaultBaseUtcOffset); // 0x0000000181573050-0x0000000181573A90
		private static bool TryGetTimeZoneEntryFromRegistry(RegistryKey key, string name, out Interop.Kernel32.REG_TZI_FORMAT dtzi); // 0x0000000181574740-0x0000000181574820
		private static bool TryCompareStandardDate([IsReadOnly] in Interop.Kernel32.TIME_ZONE_INFORMATION timeZone, [IsReadOnly] in Interop.Kernel32.REG_TZI_FORMAT registryTimeZoneInfo); // 0x0000000181572B80-0x0000000181572BC0
		private static bool TryCompareTimeZoneInformationToRegistry([IsReadOnly] in Interop.Kernel32.TIME_ZONE_INFORMATION timeZone, string id, out bool dstDisabled); // 0x0000000181572BC0-0x0000000181573050
		private static string TryGetLocalizedNameByMuiNativeResource(string resource); // 0x0000000181574370-0x00000001815745E0
		private static string TryGetLocalizedNameByNativeResource(string filePath, int resource); // 0x00000001815745E0-0x0000000181574740
		private static void GetLocalizedNamesByRegistryKey(RegistryKey key, out string displayName, out string standardName, out string daylightName); // 0x000000018156F330-0x000000018156F700
		private static TimeZoneInfoResult TryGetTimeZoneFromLocalMachine(string id, out TimeZoneInfo value, out Exception e); // 0x0000000181574B60-0x0000000181574C10
		private static TimeZoneInfoResult TryGetTimeZoneFromLocalRegistry(string id, out TimeZoneInfo value, out Exception e); // 0x0000000181574C10-0x00000001815750A0
		internal static extern uint EnumDynamicTimeZoneInformation(uint dwIndex, out DYNAMIC_TIME_ZONE_INFORMATION lpTimeZoneInformation); // 0x000000018156C630-0x000000018156C7A0
		internal static extern uint GetDynamicTimeZoneInformation(out DYNAMIC_TIME_ZONE_INFORMATION pTimeZoneInformation); // 0x000000018156D730-0x000000018156D890
		internal static extern uint GetDynamicTimeZoneInformationEffectiveYears(ref DYNAMIC_TIME_ZONE_INFORMATION lpTimeZoneInformation, out uint FirstYear, out uint LastYear); // 0x000000018156D5B0-0x000000018156D730
		internal static extern bool GetTimeZoneInformationForYear(ushort wYear, ref DYNAMIC_TIME_ZONE_INFORMATION pdtzi, out Interop.Kernel32.TIME_ZONE_INFORMATION ptzi); // 0x0000000181570260-0x00000001815703F0
		internal static AdjustmentRule CreateAdjustmentRuleFromTimeZoneInformation(ref DYNAMIC_TIME_ZONE_INFORMATION timeZoneInformation, DateTime startDate, DateTime endDate, int defaultBaseUtcOffset); // 0x000000018156BD20-0x000000018156C240
		private static bool TransitionTimeFromTimeZoneInformation(DYNAMIC_TIME_ZONE_INFORMATION timeZoneInformation, out TransitionTime transitionTime, bool readStartDate); // 0x0000000181571860-0x0000000181572700
		internal static TimeZoneInfo TryCreateTimeZone(DYNAMIC_TIME_ZONE_INFORMATION timeZoneInformation); // 0x0000000181573A90-0x0000000181574370
		internal static TimeZoneInfo GetLocalTimeZoneInfoWinRTFallback(); // 0x000000018156ECC0-0x000000018156EFC0
		internal static TimeZoneInfo FindSystemTimeZoneByIdWinRTFallback(string id); // 0x000000018156CA80-0x000000018156CD20
		private static void GetSystemTimeZonesWinRTFallback(CachedData cachedData); // 0x000000018156F7D0-0x000000018156FF30
		private AdjustmentRule GetPreviousAdjustmentRule(AdjustmentRule rule, int? ruleIndex); // 0x000000018156F700-0x000000018156F7D0
		public TimeSpan GetUtcOffset(DateTime dateTime); // 0x0000000181570E40-0x0000000181570EC0
		internal static TimeSpan GetLocalUtcOffset(DateTime dateTime, TimeZoneInfoOptions flags); // 0x000000018156F270-0x000000018156F330
		internal TimeSpan GetUtcOffset(DateTime dateTime, TimeZoneInfoOptions flags); // 0x0000000181570780-0x0000000181570810
		private TimeSpan GetUtcOffset(DateTime dateTime, TimeZoneInfoOptions flags, CachedData cachedData); // 0x00000001815708C0-0x0000000181570C60
		internal static DateTime ConvertTime(DateTime dateTime, TimeZoneInfo sourceTimeZone, TimeZoneInfo destinationTimeZone, TimeZoneInfoOptions flags); // 0x000000018156B280-0x000000018156B320
		private static DateTime ConvertTime(DateTime dateTime, TimeZoneInfo sourceTimeZone, TimeZoneInfo destinationTimeZone, TimeZoneInfoOptions flags, CachedData cachedData); // 0x000000018156B320-0x000000018156B9F0
		internal static DateTime ConvertTimeToUtc(DateTime dateTime, TimeZoneInfoOptions flags); // 0x000000018156B170-0x000000018156B280
		public bool Equals(TimeZoneInfo other); // 0x000000018156C7A0-0x000000018156C800
		public override bool Equals(object obj); // 0x000000018156C800-0x000000018156C8A0
		public override int GetHashCode(); // 0x000000018156D890-0x000000018156D950
		public static ReadOnlyCollection<TimeZoneInfo> GetSystemTimeZones(); // 0x000000018156FF30-0x0000000181570260
		public bool HasSameRules(TimeZoneInfo other); // 0x0000000181570EC0-0x00000001815711B0
		public override string ToString(); // 0x0000000181571840-0x0000000181571860
		public static TimeZoneInfo CreateCustomTimeZone(string id, TimeSpan baseUtcOffset, string displayName, string standardDisplayName); // 0x000000018156C590-0x000000018156C630
		void IDeserializationCallback.OnDeserialization(object sender); // 0x00000001815714E0-0x00000001815716A0
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001815716A0-0x0000000181571840
		private AdjustmentRule GetAdjustmentRuleForTime(DateTime dateTime, out int? ruleIndex); // 0x000000018156CF40-0x000000018156CF60
		private AdjustmentRule GetAdjustmentRuleForTime(DateTime dateTime, bool dateTimeisUtc, out int? ruleIndex); // 0x000000018156CD20-0x000000018156CF40
		private int CompareAdjustmentRuleToDateTime(AdjustmentRule rule, AdjustmentRule previousRule, DateTime dateTime, DateTime dateOnly, bool dateTimeisUtc); // 0x000000018156B000-0x000000018156B150
		private DateTime ConvertToUtc(DateTime dateTime, TimeSpan daylightDelta, TimeSpan baseUtcOffsetDelta); // 0x000000018156BB40-0x000000018156BB60
		private DateTime ConvertFromUtc(DateTime dateTime, TimeSpan daylightDelta, TimeSpan baseUtcOffsetDelta); // 0x000000018156B150-0x000000018156B170
		private DateTime ConvertToFromUtc(DateTime dateTime, TimeSpan daylightDelta, TimeSpan baseUtcOffsetDelta, bool convertToUtc); // 0x000000018156B9F0-0x000000018156BB40
		private static DateTime ConvertUtcToTimeZone(long ticks, TimeZoneInfo destinationTimeZone, out bool isAmbiguousLocalDst); // 0x000000018156BB60-0x000000018156BD20
		private DaylightTimeStruct GetDaylightTime(int year, AdjustmentRule rule, int? ruleIndex); // 0x000000018156D430-0x000000018156D5B0
		private static bool GetIsDaylightSavings(DateTime time, AdjustmentRule rule, DaylightTimeStruct daylightTime, TimeZoneInfoOptions flags); // 0x000000018156E560-0x000000018156E8D0
		private TimeSpan GetDaylightSavingsStartOffsetFromUtc(TimeSpan baseUtcOffset, AdjustmentRule rule, int? ruleIndex); // 0x000000018156D350-0x000000018156D430
		private TimeSpan GetDaylightSavingsEndOffsetFromUtc(TimeSpan baseUtcOffset, AdjustmentRule rule); // 0x000000018156D2C0-0x000000018156D350
		private static bool GetIsDaylightSavingsFromUtc(DateTime time, int year, TimeSpan utc, AdjustmentRule rule, int? ruleIndex, out bool isAmbiguousLocalDst, TimeZoneInfo zone); // 0x000000018156DC10-0x000000018156E560
		private static bool CheckIsDst(DateTime startTime, DateTime time, DateTime endTime, bool ignoreYearAdjustment, AdjustmentRule rule); // 0x000000018156AD60-0x000000018156B000
		private static bool GetIsAmbiguousTime(DateTime time, AdjustmentRule rule, DaylightTimeStruct daylightTime); // 0x000000018156D950-0x000000018156DC10
		private static bool GetIsInvalidTime(DateTime time, AdjustmentRule rule, DaylightTimeStruct daylightTime); // 0x000000018156E8D0-0x000000018156EBA0
		private static TimeSpan GetUtcOffset(DateTime time, TimeZoneInfo zone, TimeZoneInfoOptions flags); // 0x0000000181570C60-0x0000000181570E40
		private static TimeSpan GetUtcOffsetFromUtc(DateTime time, TimeZoneInfo zone); // 0x0000000181570470-0x0000000181570520
		private static TimeSpan GetUtcOffsetFromUtc(DateTime time, TimeZoneInfo zone, out bool isDaylightSavings); // 0x00000001815703F0-0x0000000181570470
		internal static TimeSpan GetUtcOffsetFromUtc(DateTime time, TimeZoneInfo zone, out bool isDaylightSavings, out bool isAmbiguousLocalDst); // 0x0000000181570520-0x0000000181570780
		internal static DateTime TransitionTimeToDateTime(int year, TransitionTime transitionTime); // 0x00000001815728F0-0x0000000181572B80
		private static TimeZoneInfoResult TryGetTimeZone(string id, bool dstDisabled, out TimeZoneInfo value, out Exception e, CachedData cachedData, bool alwaysFallbackToLocalMachine = false /* Metadata: 0x0064E2B5 */); // 0x00000001815750A0-0x00000001815752B0
		private static TimeZoneInfoResult TryGetTimeZoneFromLocalMachine(string id, bool dstDisabled, out TimeZoneInfo value, out Exception e, CachedData cachedData); // 0x0000000181574820-0x0000000181574B60
		private static void ValidateTimeZoneInfo(string id, TimeSpan baseUtcOffset, AdjustmentRule[] adjustmentRules, out bool adjustmentRulesSupportDst); // 0x0000000181575370-0x0000000181575750
		internal static bool UtcOffsetOutOfRange(TimeSpan offset); // 0x00000001815752B0-0x0000000181575370
		private static TimeSpan GetUtcOffset(TimeSpan baseUtcOffset, AdjustmentRule adjustmentRule); // 0x0000000181570810-0x00000001815708C0
		private static bool IsValidAdjustmentRuleOffest(TimeSpan baseUtcOffset, AdjustmentRule adjustmentRule); // 0x00000001815711B0-0x00000001815712A0
	}
}
