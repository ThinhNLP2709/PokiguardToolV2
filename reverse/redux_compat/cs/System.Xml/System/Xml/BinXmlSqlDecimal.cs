/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	internal struct BinXmlSqlDecimal // TypeDefIndex: 6685
	{
		// Fields
		internal byte m_bLen; // 0x00
		internal byte m_bPrec; // 0x01
		internal byte m_bScale; // 0x02
		internal byte m_bSign; // 0x03
		internal uint m_data1; // 0x04
		internal uint m_data2; // 0x08
		internal uint m_data3; // 0x0C
		internal uint m_data4; // 0x10
		private static readonly byte NUMERIC_MAX_PRECISION; // 0x00
		private static readonly byte MaxPrecision; // 0x01
		private static readonly byte MaxScale; // 0x02
		private static readonly int x_cNumeMax; // 0x04
		private static readonly long x_lInt32Base; // 0x08
		private static readonly ulong x_ulInt32Base; // 0x10
		private static readonly ulong x_ulInt32BaseForMod; // 0x18
		internal static readonly ulong x_llMax; // 0x20
		private static readonly double DUINT_BASE; // 0x28
		private static readonly double DUINT_BASE2; // 0x30
		private static readonly double DUINT_BASE3; // 0x38
		private static readonly uint[] x_rgulShiftBase; // 0x40
		private static readonly byte[] rgCLenFromPrec; // 0x48
	
		// Properties
		public bool IsPositive { get; } // 0x0000000181942190-0x00000001819421A0 
	
		// Constructors
		public BinXmlSqlDecimal(byte[] data, int offset, bool trim); // 0x0000000181941E60-0x0000000181942190
		static BinXmlSqlDecimal(); // 0x0000000181941C40-0x0000000181941E60
	
		// Methods
		private static uint UIntFromByteArray(byte[] data, int offset); // 0x0000000181501B00-0x0000000181501B70
		private static void MpDiv1(uint[] rgulU, ref int ciulU, uint iulD, out uint iulR); // 0x0000000181941460-0x0000000181941560
		private static void MpNormalize(uint[] rgulU, ref int ciulU); // 0x00000001818E1CA0-0x00000001818E1CE0
		private static char ChFromDigit(uint uiDigit); // 0x00000001818DFAC0-0x00000001818DFAD0
		public decimal ToDecimal(); // 0x0000000181941560-0x0000000181941670
		private void TrimTrailingZeros(); // 0x00000001819419D0-0x0000000181941C40
		public override string ToString(); // 0x0000000181941670-0x00000001819419D0
	}
}
