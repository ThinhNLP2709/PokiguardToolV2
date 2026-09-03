/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data.SqlTypes
{
	[Serializable]
	[XmlSchemaProvider("GetXsdType")]
	public struct SqlDecimal : INullable, IComparable, IXmlSerializable // TypeDefIndex: 11354
	{
		// Fields
		internal byte _bStatus; // 0x00
		internal byte _bLen; // 0x01
		internal byte _bPrec; // 0x02
		internal byte _bScale; // 0x03
		internal uint _data1; // 0x04
		internal uint _data2; // 0x08
		internal uint _data3; // 0x0C
		internal uint _data4; // 0x10
		private static readonly byte s_NUMERIC_MAX_PRECISION; // 0x00
		public static readonly byte MaxPrecision; // 0x01
		public static readonly byte MaxScale; // 0x02
		private static readonly byte s_bNullMask; // 0x03
		private static readonly byte s_bIsNull; // 0x04
		private static readonly byte s_bNotNull; // 0x05
		private static readonly byte s_bReverseNullMask; // 0x06
		private static readonly byte s_bSignMask; // 0x07
		private static readonly byte s_bPositive; // 0x08
		private static readonly byte s_bNegative; // 0x09
		private static readonly byte s_bReverseSignMask; // 0x0A
		private static readonly uint s_uiZero; // 0x0C
		private static readonly int s_cNumeMax; // 0x10
		private static readonly long s_lInt32Base; // 0x18
		private static readonly ulong s_ulInt32Base; // 0x20
		private static readonly ulong s_ulInt32BaseForMod; // 0x28
		internal static readonly ulong s_llMax; // 0x30
		private static readonly uint s_ulBase10; // 0x38
		private static readonly double s_DUINT_BASE; // 0x40
		private static readonly double s_DUINT_BASE2; // 0x48
		private static readonly double s_DUINT_BASE3; // 0x50
		private static readonly double s_DMAX_NUME; // 0x58
		private static readonly uint s_DBL_DIG; // 0x60
		private static readonly byte s_cNumeDivScaleMin; // 0x64
		private static readonly uint[] s_rgulShiftBase; // 0x68
		private static readonly uint[] s_decimalHelpersLo; // 0x70
		private static readonly uint[] s_decimalHelpersMid; // 0x78
		private static readonly uint[] s_decimalHelpersHi; // 0x80
		private static readonly uint[] s_decimalHelpersHiHi; // 0x88
		private static readonly byte[] s_rgCLenFromPrec; // 0x90
		private static readonly uint s_ulT1; // 0x98
		private static readonly uint s_ulT2; // 0x9C
		private static readonly uint s_ulT3; // 0xA0
		private static readonly uint s_ulT4; // 0xA4
		private static readonly uint s_ulT5; // 0xA8
		private static readonly uint s_ulT6; // 0xAC
		private static readonly uint s_ulT7; // 0xB0
		private static readonly uint s_ulT8; // 0xB4
		private static readonly uint s_ulT9; // 0xB8
		private static readonly ulong s_dwlT10; // 0xC0
		private static readonly ulong s_dwlT11; // 0xC8
		private static readonly ulong s_dwlT12; // 0xD0
		private static readonly ulong s_dwlT13; // 0xD8
		private static readonly ulong s_dwlT14; // 0xE0
		private static readonly ulong s_dwlT15; // 0xE8
		private static readonly ulong s_dwlT16; // 0xF0
		private static readonly ulong s_dwlT17; // 0xF8
		private static readonly ulong s_dwlT18; // 0x100
		private static readonly ulong s_dwlT19; // 0x108
		public static readonly SqlDecimal Null; // 0x110
		public static readonly SqlDecimal MinValue; // 0x124
		public static readonly SqlDecimal MaxValue; // 0x138
	
		// Properties
		public bool IsNull { get; } // 0x00000001818E4960-0x00000001818E49C0 
		public decimal Value { get; } // 0x00000001818E4BA0-0x00000001818E4DA0 
		public bool IsPositive { get; } // 0x00000001818E49C0-0x00000001818E4AB0 
		public byte Scale { get; } // 0x00000001818E4AB0-0x00000001818E4BA0 
		public int[] Data { get; } // 0x00000001818E4820-0x00000001818E4960 
	
		// Constructors
		private SqlDecimal(bool fNull); // 0x00000001818E4200-0x00000001818E4270
		public SqlDecimal(decimal value); // 0x00000001818E46E0-0x00000001818E4820
		public SqlDecimal(int value); // 0x00000001818E4070-0x00000001818E4200
		public SqlDecimal(long value); // 0x00000001818E4270-0x00000001818E44D0
		private SqlDecimal(uint[] rglData, byte bLen, byte bPrec, byte bScale, bool fPositive); // 0x00000001818E44D0-0x00000001818E46E0
		static SqlDecimal(); // 0x00000001818E3770-0x00000001818E4070
	
		// Methods
		private byte CalculatePrecision(); // 0x00000001818DF720-0x00000001818DFAC0
		private bool VerifyPrecision(byte precision); // 0x00000001818E3590-0x00000001818E36F0
		private void SetPositive(); // 0x00000001818E26A0-0x00000001818E2710
		private void SetSignBit(bool fPositive); // 0x00000001818E2710-0x00000001818E27C0
		public override string ToString(); // 0x00000001818E31C0-0x00000001818E3590
		public static SqlDecimal Parse(string s); // 0x00000001818E2000-0x00000001818E26A0
		public double ToDouble(); // 0x00000001818E2D40-0x00000001818E2F00
		private decimal ToDecimal(); // 0x00000001818E2B90-0x00000001818E2D40
		public static implicit operator SqlDecimal(decimal x); // 0x00000001818E5D70-0x00000001818E5DB0
		public static implicit operator SqlDecimal(long x); // 0x00000001818E5DB0-0x00000001818E5E00
		public static SqlDecimal operator -(SqlDecimal x); // 0x00000001818E70D0-0x00000001818E7260
		public static SqlDecimal operator +(SqlDecimal x, SqlDecimal y); // 0x00000001818E4DA0-0x00000001818E5490
		public static SqlDecimal operator -(SqlDecimal x, SqlDecimal y); // 0x00000001818E6ED0-0x00000001818E70D0
		public static SqlDecimal operator *(SqlDecimal x, SqlDecimal y); // 0x00000001818E6410-0x00000001818E6ED0
		public static SqlDecimal operator /(SqlDecimal x, SqlDecimal y); // 0x00000001818E5490-0x00000001818E5A70
		public static implicit operator SqlDecimal(SqlByte x); // 0x00000001818E5FA0-0x00000001818E6070
		public static implicit operator SqlDecimal(SqlInt16 x); // 0x00000001818E5E00-0x00000001818E5ED0
		public static implicit operator SqlDecimal(SqlInt32 x); // 0x00000001818E6150-0x00000001818E6290
		public static implicit operator SqlDecimal(SqlInt64 x); // 0x00000001818E5ED0-0x00000001818E5FA0
		public static implicit operator SqlDecimal(SqlMoney x); // 0x00000001818E6070-0x00000001818E6150
		private static void ZeroToMaxLen(uint[] rgulData, int cUI4sCur); // 0x00000001818E36F0-0x00000001818E3770
		private bool FZero(); // 0x00000001818E08A0-0x00000001818E08C0
		private bool FGt10_38(); // 0x00000001818E0810-0x00000001818E0850
		private bool FGt10_38(uint[] rglData); // 0x00000001818E0850-0x00000001818E08A0
		private static byte BGetPrecUI4(uint value); // 0x00000001818DF500-0x00000001818DF5C0
		private static byte BGetPrecUI8(ulong dwlVal); // 0x00000001818DF5C0-0x00000001818DF720
		private void AddULong(uint ulAdd); // 0x00000001818DEF90-0x00000001818DF1F0
		private void MultByULong(uint uiMultiplier); // 0x00000001818E1D10-0x00000001818E2000
		private uint DivByULong(uint iDivisor); // 0x00000001818E02A0-0x00000001818E0490
		internal void AdjustScale(int digits, bool fRound); // 0x00000001818DF1F0-0x00000001818DF500
		private int LAbsCmp(SqlDecimal snumOp); // 0x00000001818E0C30-0x00000001818E0DF0
		private static void MpMove(uint[] rgulS, int ciulS, uint[] rgulD, out int ciulD); // 0x00000001818E1B50-0x00000001818E1BC0
		private static void MpSet(uint[] rgulD, out int ciulD, uint iulN); // 0x00000001818E1CE0-0x00000001818E1D10
		private static void MpNormalize(uint[] rgulU, ref int ciulU); // 0x00000001818E1CA0-0x00000001818E1CE0
		private static void MpMul1(uint[] piulD, ref int ciulD, uint iulX); // 0x00000001818E1BC0-0x00000001818E1CA0
		private static void MpDiv1(uint[] rgulU, ref int ciulU, uint iulD, out uint iulR); // 0x00000001818E0E70-0x00000001818E0F70
		internal static ulong DWL(uint lo, uint hi); // 0x00000001818E0290-0x00000001818E02A0
		private static uint HI(ulong x); // 0x0000000181603EE0-0x0000000181603EF0
		private static uint LO(ulong x); // 0x0000000180815D70-0x0000000180815D80
		private static void MpDiv(uint[] rgulU, int ciulU, uint[] rgulD, int ciulD, uint[] rgulQ, out int ciulQ, uint[] rgulR, out int ciulR); // 0x00000001818E0F70-0x00000001818E1B50
		private EComparison CompareNm(SqlDecimal snumOp); // 0x00000001818DFB90-0x00000001818DFD20
		private static void CheckValidPrecScale(byte bPrec, byte bScale); // 0x00000001818DFAD0-0x00000001818DFB90
		public static SqlBoolean operator ==(SqlDecimal x, SqlDecimal y); // 0x00000001818E5A70-0x00000001818E5BF0
		public static SqlBoolean operator <(SqlDecimal x, SqlDecimal y); // 0x00000001818E6290-0x00000001818E6410
		public static SqlBoolean operator >(SqlDecimal x, SqlDecimal y); // 0x00000001818E5BF0-0x00000001818E5D70
		public static SqlBoolean LessThan(SqlDecimal x, SqlDecimal y); // 0x00000001818E0DF0-0x00000001818E0E70
		public static SqlBoolean GreaterThan(SqlDecimal x, SqlDecimal y); // 0x00000001818E0BB0-0x00000001818E0C30
		public SqlDouble ToSqlDouble(); // 0x00000001818E2F00-0x00000001818E30C0
		public SqlInt64 ToSqlInt64(); // 0x00000001818E30C0-0x00000001818E3140
		public SqlMoney ToSqlMoney(); // 0x00000001818E3140-0x00000001818E31C0
		private static char ChFromDigit(uint uiDigit); // 0x00000001818DFAC0-0x00000001818DFAD0
		private void StoreFromWorkingArray(uint[] rguiData); // 0x00000001818E2830-0x00000001818E2880
		private void SetToZero(); // 0x00000001818E27C0-0x00000001818E2830
		public int CompareTo(object value); // 0x00000001818DFF60-0x00000001818E0290
		public int CompareTo(SqlDecimal value); // 0x00000001818DFD20-0x00000001818DFF60
		public override bool Equals(object value); // 0x00000001818E0490-0x00000001818E0810
		public override int GetHashCode(); // 0x00000001818E08C0-0x00000001818E0B40
		XmlSchema IXmlSerializable.GetSchema(); // 0x00000001802E7860-0x00000001802E7870
		void IXmlSerializable.ReadXml(XmlReader reader); // 0x00000001818E2880-0x00000001818E2A30
		void IXmlSerializable.WriteXml(XmlWriter writer); // 0x00000001818E2A30-0x00000001818E2B90
		public static XmlQualifiedName GetXsdType(XmlSchemaSet schemaSet); // 0x00000001818E0B40-0x00000001818E0BB0
	}
}
