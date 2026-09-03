/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Security.Cryptography
{
	internal class DerSequenceReader // TypeDefIndex: 8752
	{
		// Fields
		internal static DateTimeFormatInfo s_validityDateTimeFormatInfo; // 0x00
		private static Encoding s_utf8EncodingWithExceptionFallback; // 0x08
		private static Encoding s_latin1Encoding; // 0x10
		private readonly byte[] _data; // 0x10
		private readonly int _end; // 0x18
		private int _position; // 0x1C
		[CompilerGenerated]
		private int _ContentLength_k__BackingField; // 0x20
	
		// Properties
		private int ContentLength { [CompilerGenerated] set; } // 0x0000000180E332D0-0x0000000180E332E0
		internal bool HasData { get; } // 0x0000000181B76F90-0x0000000181B76FA0 
	
		// Nested types
		internal enum DerTag : byte // TypeDefIndex: 8753
		{
			Boolean = 1,
			Integer = 2,
			BitString = 3,
			OctetString = 4,
			Null = 5,
			ObjectIdentifier = 6,
			UTF8String = 12,
			Sequence = 16,
			Set = 17,
			PrintableString = 19,
			T61String = 20,
			IA5String = 22,
			UTCTime = 23,
			GeneralizedTime = 24,
			BMPString = 30
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 8754
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<Encoding> __9__45_0; // 0x08
			public static Func<Encoding> __9__45_1; // 0x10
			public static Func<DateTimeFormatInfo> __9__51_0; // 0x18
	
			// Constructors
			static __c(); // 0x0000000181B88570-0x0000000181B885E0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Encoding _ReadT61String_b__45_0(); // 0x0000000181B88410-0x0000000181B88460
			internal Encoding _ReadT61String_b__45_1(); // 0x0000000181B88460-0x0000000181B884A0
			internal DateTimeFormatInfo _ReadTime_b__51_0(); // 0x0000000181B884A0-0x0000000181B88570
		}
	
		// Constructors
		internal DerSequenceReader(byte[] data); // 0x0000000181B76F20-0x0000000181B76F60
		internal DerSequenceReader(byte[] data, int offset, int length); // 0x0000000181B76F60-0x0000000181B76F90
		private DerSequenceReader(DerTag tagToEat, byte[] data, int offset, int length); // 0x0000000181B76DB0-0x0000000181B76F20
	
		// Methods
		internal byte PeekTag(); // 0x0000000181B75610-0x0000000181B756F0
		internal void SkipValue(); // 0x0000000181B76CF0-0x0000000181B76D40
		internal byte[] ReadNextEncodedValue(); // 0x0000000181B75DC0-0x0000000181B75E70
		internal bool ReadBoolean(); // 0x0000000181B75960-0x0000000181B75A30
		internal int ReadInteger(); // 0x0000000181B75D10-0x0000000181B75DC0
		internal byte[] ReadIntegerBytes(); // 0x0000000181B75CE0-0x0000000181B75D10
		internal byte[] ReadBitString(); // 0x0000000181B757D0-0x0000000181B75960
		internal byte[] ReadOctetString(); // 0x0000000181B75E70-0x0000000181B75EA0
		internal string ReadOidAsString(); // 0x0000000181B75EA0-0x0000000181B761D0
		internal string ReadUtf8String(); // 0x0000000181B76830-0x0000000181B76910
		private DerSequenceReader ReadCollectionWithTag(DerTag expected); // 0x0000000181B75A30-0x0000000181B75B10
		internal DerSequenceReader ReadSequence(); // 0x0000000181B762B0-0x0000000181B762C0
		internal DerSequenceReader ReadSet(); // 0x0000000181B762C0-0x0000000181B762D0
		internal string ReadPrintableString(); // 0x0000000181B761D0-0x0000000181B762B0
		internal string ReadIA5String(); // 0x0000000181B75C00-0x0000000181B75CE0
		internal string ReadT61String(); // 0x0000000181B762D0-0x0000000181B765B0
		internal DateTime ReadX509Date(); // 0x0000000181B76910-0x0000000181B769E0
		internal DateTime ReadUtcTime(); // 0x0000000181B767F0-0x0000000181B76830
		internal DateTime ReadGeneralizedTime(); // 0x0000000181B75BC0-0x0000000181B75C00
		internal string ReadBMPString(); // 0x0000000181B756F0-0x0000000181B757D0
		private static string TrimTrailingNulls(string value); // 0x0000000181B76D40-0x0000000181B76DB0
		private DateTime ReadTime(DerTag timeTag, string formatString); // 0x0000000181B765B0-0x0000000181B767F0
		private byte[] ReadContentAsBytes(); // 0x0000000181B75B10-0x0000000181B75BC0
		private void EatTag(DerTag expected); // 0x0000000181B75590-0x0000000181B75610
		private static void CheckTag(DerTag expected, byte[] data, int position); // 0x0000000181B75420-0x0000000181B75550
		private int EatLength(); // 0x0000000181B75550-0x0000000181B75590
		private static int ScanContentLength(byte[] data, int offset, int end, out int bytesConsumed); // 0x0000000181B769E0-0x0000000181B76CF0
	}
}
