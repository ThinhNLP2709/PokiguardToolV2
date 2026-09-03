/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Globalization
{
	[Serializable]
	[ComVisible(true)]
	public class RegionInfo // TypeDefIndex: 3456
	{
		// Fields
		private static RegionInfo currentRegion; // 0x00
		private int regionId; // 0x10
		private string iso2Name; // 0x18
		private string iso3Name; // 0x20
		private string win3Name; // 0x28
		private string englishName; // 0x30
		private string nativeName; // 0x38
		private string currencySymbol; // 0x40
		private string isoCurrencySymbol; // 0x48
		private string currencyEnglishName; // 0x50
		private string currencyNativeName; // 0x58
	
		// Properties
		public static RegionInfo CurrentRegion { get; } // 0x000000018159E640-0x000000018159E720 
		[ComVisible(false)]
		public virtual string CurrencyEnglishName { get; } // 0x00000001806CCC00-0x00000001806CCC10 
		public virtual string CurrencySymbol { get; } // 0x0000000180377940-0x0000000180377950 
		[MonoTODO("DisplayName currently only returns the EnglishName")]
		public virtual string DisplayName { get; } // 0x000000018031E110-0x000000018031E120 
		public virtual string EnglishName { get; } // 0x000000018031E110-0x000000018031E120 
		[ComVisible(false)]
		public virtual int GeoId { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public virtual bool IsMetric { get; } // 0x000000018159E720-0x000000018159E790 
		public virtual string ISOCurrencySymbol { get; } // 0x00000001803272B0-0x00000001803272C0 
		[ComVisible(false)]
		public virtual string NativeName { get; } // 0x00000001803272A0-0x00000001803272B0 
		[ComVisible(false)]
		public virtual string CurrencyNativeName { get; } // 0x00000001802F4000-0x00000001802F4010 
		public virtual string Name { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public virtual string ThreeLetterISORegionName { get; } // 0x00000001802F8630-0x00000001802F8640 
		public virtual string ThreeLetterWindowsRegionName { get; } // 0x000000018033D240-0x000000018033D250 
		public virtual string TwoLetterISORegionName { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Constructors
		public RegionInfo(int culture); // 0x000000018159E4D0-0x000000018159E630
		public RegionInfo(string name); // 0x000000018159E120-0x000000018159E2C0
		private RegionInfo(CultureInfo ci); // 0x000000018159E2C0-0x000000018159E4D0
	
		// Methods
		private bool GetByTerritory(CultureInfo ci); // 0x000000018159E010-0x000000018159E0C0
		private bool construct_internal_region_from_name(string name); // 0x000000018159E630-0x000000018159E640
		public override bool Equals(object value); // 0x000000018159DF50-0x000000018159E010
		public override int GetHashCode(); // 0x000000018159E0C0-0x000000018159E100
		public override string ToString(); // 0x000000018159E100-0x000000018159E120
		internal static void ClearCachedData(); // 0x000000018159DF00-0x000000018159DF50
	}
}
