/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	public sealed class DBNull : ISerializable, IConvertible // TypeDefIndex: 2229
	{
		// Fields
		public static readonly DBNull Value; // 0x00
	
		// Constructors
		private DBNull(); // 0x00000001802E5CB0-0x00000001802E5CC0
		private DBNull(SerializationInfo info, StreamingContext context); // 0x00000001815DCCD0-0x00000001815DCD30
		static DBNull(); // 0x00000001815DCC80-0x00000001815DCCD0
	
		// Methods
		public void GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001815DC7A0-0x00000001815DC7B0
		public override string ToString(); // 0x00000001815B1550-0x00000001815B1570
		public string ToString(IFormatProvider provider); // 0x00000001815B1550-0x00000001815B1570
		public TypeCode GetTypeCode(); // 0x0000000180476390-0x00000001804763A0
		bool IConvertible.ToBoolean(IFormatProvider provider); // 0x00000001815DC7B0-0x00000001815DC800
		char IConvertible.ToChar(IFormatProvider provider); // 0x00000001815DC850-0x00000001815DC8A0
		sbyte IConvertible.ToSByte(IFormatProvider provider); // 0x00000001815DCA80-0x00000001815DCAD0
		byte IConvertible.ToByte(IFormatProvider provider); // 0x00000001815DC800-0x00000001815DC850
		short IConvertible.ToInt16(IFormatProvider provider); // 0x00000001815DC990-0x00000001815DC9E0
		ushort IConvertible.ToUInt16(IFormatProvider provider); // 0x00000001815DCB90-0x00000001815DCBE0
		int IConvertible.ToInt32(IFormatProvider provider); // 0x00000001815DC9E0-0x00000001815DCA30
		uint IConvertible.ToUInt32(IFormatProvider provider); // 0x00000001815DCBE0-0x00000001815DCC30
		long IConvertible.ToInt64(IFormatProvider provider); // 0x00000001815DCA30-0x00000001815DCA80
		ulong IConvertible.ToUInt64(IFormatProvider provider); // 0x00000001815DCC30-0x00000001815DCC80
		float IConvertible.ToSingle(IFormatProvider provider); // 0x00000001815DCAD0-0x00000001815DCB20
		double IConvertible.ToDouble(IFormatProvider provider); // 0x00000001815DC940-0x00000001815DC990
		decimal IConvertible.ToDecimal(IFormatProvider provider); // 0x00000001815DC8F0-0x00000001815DC940
		DateTime IConvertible.ToDateTime(IFormatProvider provider); // 0x00000001815DC8A0-0x00000001815DC8F0
		object IConvertible.ToType(Type type, IFormatProvider provider); // 0x00000001815DCB20-0x00000001815DCB90
	}
}
