/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Mono.Interop;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Globalization
{
	[Serializable]
	[ComVisible(true)]
	public class CultureInfo : ICloneable, IFormatProvider // TypeDefIndex: 3450
	{
		// Fields
		private static CultureInfo invariant_culture_info; // 0x00
		private static object shared_table_lock; // 0x08
		private static CultureInfo default_current_culture; // 0x10
		private bool m_isReadOnly; // 0x10
		private int cultureID; // 0x14
		[NonSerialized]
		private int parent_lcid; // 0x18
		[NonSerialized]
		private int datetime_index; // 0x1C
		[NonSerialized]
		private int number_index; // 0x20
		[NonSerialized]
		private int default_calendar_type; // 0x24
		private bool m_useUserOverride; // 0x28
		internal NumberFormatInfo numInfo; // 0x30
		internal DateTimeFormatInfo dateTimeInfo; // 0x38
		private TextInfo textInfo; // 0x40
		internal string m_name; // 0x48
		[NonSerialized]
		private string englishname; // 0x50
		[NonSerialized]
		private string nativename; // 0x58
		[NonSerialized]
		private string iso3lang; // 0x60
		[NonSerialized]
		private string iso2lang; // 0x68
		[NonSerialized]
		private string win3lang; // 0x70
		[NonSerialized]
		private string territory; // 0x78
		[NonSerialized]
		private string[] native_calendar_names; // 0x80
		private CompareInfo compareInfo; // 0x88
		[NonSerialized]
		private readonly unsafe void* textinfo_data; // 0x90
		private int m_dataItem; // 0x98
		private Calendar calendar; // 0xA0
		[NonSerialized]
		private CultureInfo parent_culture; // 0xA8
		[NonSerialized]
		private bool constructed; // 0xB0
		[NonSerialized]
		internal byte[] cached_serialized_form; // 0xB8
		[NonSerialized]
		internal CultureData m_cultureData; // 0xC0
		[NonSerialized]
		internal bool m_isInherited; // 0xC8
		internal const int InvariantCultureId = 127; // Metadata: 0x0064EFF1
		private const int CalendarTypeBits = 8; // Metadata: 0x0064EFF3
		internal const int LOCALE_INVARIANT = 127; // Metadata: 0x0064EFF4
		private const string MSG_READONLY = "This instance is read only"; // Metadata: 0x0064EFF6
		private static CultureInfo s_DefaultThreadCurrentUICulture; // 0x18
		private static CultureInfo s_DefaultThreadCurrentCulture; // 0x20
		private static Dictionary<int, CultureInfo> shared_by_number; // 0x28
		private static Dictionary<string, CultureInfo> shared_by_name; // 0x30
		private static CultureInfo s_UserPreferredCultureInfoInAppX; // 0x38
		internal static readonly bool IsTaiwanSku; // 0x40
	
		// Properties
		internal CultureData _cultureData { get; } // 0x00000001806CCB70-0x00000001806CCB80 
		internal bool _isInherited { get; } // 0x00000001815989B0-0x00000001815989C0 
		public static CultureInfo InvariantCulture { get; } // 0x00000001815983C0-0x0000000181598400 
		public static CultureInfo CurrentCulture { get; } // 0x0000000181598100-0x0000000181598130 
		public static CultureInfo CurrentUICulture { get; } // 0x0000000181598130-0x0000000181598160 
		internal string Territory { get; } // 0x000000018033D4E0-0x000000018033D4F0 
		internal string _name { get; } // 0x00000001803272B0-0x00000001803272C0 
		public virtual int LCID { get; } // 0x0000000180A5E110-0x0000000180A5E120 
		public virtual string Name { get; } // 0x00000001803272B0-0x00000001803272C0 
		public virtual Calendar Calendar { get; } // 0x0000000181597F10-0x0000000181597FA0 
		public virtual CultureInfo Parent { get; } // 0x00000001815984F0-0x00000001815987E0 
		public virtual TextInfo TextInfo { get; } // 0x00000001815987E0-0x0000000181598970 
		public virtual CompareInfo CompareInfo { get; } // 0x0000000181597FA0-0x0000000181598100 
		public virtual bool IsNeutralCulture { get; } // 0x0000000181598400-0x0000000181598440 
		public virtual NumberFormatInfo NumberFormat { get; set; } // 0x0000000181598440-0x00000001815984F0 0x0000000181598C60-0x0000000181598D50
		public virtual DateTimeFormatInfo DateTimeFormat { get; set; } // 0x0000000181598160-0x0000000181598300 0x0000000181598B70-0x0000000181598C60
		public virtual string EnglishName { get; } // 0x0000000181598380-0x00000001815983C0 
		internal int CalendarType { get; } // 0x0000000181597E70-0x0000000181597F10 
		public static CultureInfo DefaultThreadCurrentCulture { get; } // 0x0000000181598300-0x0000000181598340 
		public static CultureInfo DefaultThreadCurrentUICulture { get; } // 0x0000000181598340-0x0000000181598380 
		internal string SortName { get; } // 0x00000001803272B0-0x00000001803272C0 
		internal static CultureInfo UserDefaultUICulture { get; } // 0x0000000181598970-0x00000001815989B0 
		internal static CultureInfo UserDefaultCulture { get; } // 0x0000000181593D70-0x0000000181593DA0 
	
		// Nested types
		private struct Data // TypeDefIndex: 3451
		{
			// Fields
			public int ansi; // 0x00
			public int ebcdic; // 0x04
			public int mac; // 0x08
			public int oem; // 0x0C
			public bool right_to_left; // 0x10
			public byte list_sep; // 0x11
		}
	
		private delegate void OnCultureInfoChangedDelegate(string language); // TypeDefIndex: 3452; 0x00000001804A78A0-0x00000001804A78B0
	
		// Constructors
		public CultureInfo(int culture); // 0x0000000181597E30-0x0000000181597E50
		public CultureInfo(int culture, bool useUserOverride); // 0x0000000181597AD0-0x0000000181597AF0
		private CultureInfo(int culture, bool useUserOverride, bool read_only); // 0x0000000181597AF0-0x0000000181597E10
		public CultureInfo(string name); // 0x0000000181597A90-0x0000000181597AB0
		public CultureInfo(string name, bool useUserOverride); // 0x0000000181597E10-0x0000000181597E30
		private CultureInfo(string name, bool useUserOverride, bool read_only); // 0x00000001815977E0-0x0000000181597A90
		private CultureInfo(); // 0x0000000181597AB0-0x0000000181597AD0
		static CultureInfo(); // 0x0000000181597430-0x00000001815977E0
	
		// Methods
		internal static CultureInfo ConstructCurrentCulture(); // 0x0000000181593BC0-0x0000000181593D70
		internal static CultureInfo ConstructCurrentUICulture(); // 0x0000000181593D70-0x0000000181593DA0
		public virtual object Clone(); // 0x00000001815939F0-0x0000000181593BC0
		public override bool Equals(object value); // 0x00000001815968B0-0x0000000181596900
		public static CultureInfo[] GetCultures(CultureTypes types); // 0x0000000181596E80-0x0000000181597260
		private Data GetTextInfoData(); // 0x0000000181597330-0x0000000181597350
		public override int GetHashCode(); // 0x0000000181597320-0x0000000181597330
		public override string ToString(); // 0x00000001803272B0-0x00000001803272C0
		private void CheckNeutral(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual object GetFormat(Type formatType); // 0x0000000181597260-0x0000000181597320
		private void Construct(); // 0x0000000181594020-0x0000000181594040
		private bool construct_internal_locale_from_lcid(int lcid); // 0x0000000181597E50-0x0000000181597E60
		private bool construct_internal_locale_from_name(string name); // 0x0000000181597E60-0x0000000181597E70
		private static string get_current_locale_name(); // 0x00000001815989C0-0x00000001815989D0
		private static CultureInfo[] internal_get_cultures(bool neutral, bool specific, bool installed); // 0x0000000181598B60-0x0000000181598B70
		private void ConstructInvariant(bool read_only); // 0x0000000181593DA0-0x0000000181593F80
		private TextInfo CreateTextInfo(bool readOnly); // 0x0000000181596830-0x00000001815968B0
		private static void insert_into_shared_tables(CultureInfo c); // 0x00000001815989D0-0x0000000181598B60
		public static CultureInfo GetCultureInfo(int culture); // 0x0000000181596A40-0x0000000181596C60
		public static CultureInfo GetCultureInfo(string name); // 0x0000000181596C60-0x0000000181596E80
		internal static CultureInfo CreateCulture(string name, bool reference); // 0x0000000181594230-0x00000001815942A0
		public static CultureInfo CreateSpecificCulture(string name); // 0x0000000181596510-0x0000000181596830
		private bool ConstructLocaleFromName(string name); // 0x0000000181593F80-0x0000000181594020
		private static CultureInfo CreateSpecificCultureFromNeutral(string name); // 0x0000000181594340-0x0000000181596510
		private static Calendar CreateCalendar(int calendarType); // 0x0000000181594040-0x0000000181594230
		private static Exception CreateNotFoundException(string name); // 0x00000001815942A0-0x0000000181594340
		private static extern void InitializeUserPreferredCultureInfoInAppX(OnCultureInfoChangedDelegate onCultureInfoChangedInAppX); // 0x0000000181597350-0x0000000181597370
		[MonoPInvokeCallback(typeof(OnCultureInfoChangedDelegate))]
		private static void OnCultureInfoChangedInAppX(string language); // 0x0000000181597370-0x0000000181597430
		internal static CultureInfo GetCultureInfoForUserPreferredLanguageInAppX(); // 0x0000000181596900-0x0000000181596A40
	}
}
