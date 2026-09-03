/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Serialization.Formatters.Binary
{
	internal sealed class __BinaryParser // TypeDefIndex: 3104
	{
		// Fields
		internal ObjectReader objectReader; // 0x10
		internal Stream input; // 0x18
		internal long topId; // 0x20
		internal long headerId; // 0x28
		internal SizedArray objectMapIdTable; // 0x30
		internal SizedArray assemIdToAssemblyTable; // 0x38
		internal SerStack stack; // 0x40
		internal BinaryTypeEnum expectedType; // 0x48
		internal object expectedTypeInformation; // 0x50
		internal ParseRecord PRS; // 0x58
		private BinaryAssemblyInfo systemAssemblyInfo; // 0x60
		private BinaryReader dataReader; // 0x68
		private static Encoding encoding; // 0x00
		private SerStack opPool; // 0x70
		private BinaryObject binaryObject; // 0x78
		private BinaryObjectWithMap bowm; // 0x80
		private BinaryObjectWithMapTyped bowmt; // 0x88
		internal BinaryObjectString objectString; // 0x90
		internal BinaryCrossAppDomainString crossAppDomainString; // 0x98
		internal MemberPrimitiveTyped memberPrimitiveTyped; // 0xA0
		private byte[] byteBuffer; // 0xA8
		internal MemberPrimitiveUnTyped memberPrimitiveUnTyped; // 0xB0
		internal MemberReference memberReference; // 0xB8
		internal ObjectNull objectNull; // 0xC0
		internal static MessageEnd messageEnd; // 0x08
	
		// Properties
		internal BinaryAssemblyInfo SystemAssemblyInfo { get; } // 0x00000001815226A0-0x0000000181522770 
		internal SizedArray ObjectMapIdTable { get; } // 0x00000001815225D0-0x00000001815226A0 
		internal SizedArray AssemIdToAssemblyTable { get; } // 0x0000000181522500-0x00000001815225D0 
		internal ParseRecord prs { get; } // 0x0000000181522770-0x00000001815228A0 
	
		// Constructors
		internal __BinaryParser(Stream stream, ObjectReader objectReader); // 0x00000001815223D0-0x0000000181522500
		static __BinaryParser(); // 0x0000000181522350-0x00000001815223D0
	
		// Methods
		internal void Run(); // 0x0000000181521D60-0x0000000181522350
		internal void ReadBegin(); // 0x00000001802E76C0-0x00000001802E76D0
		internal void ReadEnd(); // 0x00000001802E76C0-0x00000001802E76D0
		internal bool ReadBoolean(); // 0x000000018151DF90-0x000000018151DFC0
		internal byte ReadByte(); // 0x000000018151DFC0-0x000000018151DFF0
		internal byte[] ReadBytes(int length); // 0x000000018151DFF0-0x000000018151E020
		internal void ReadBytes(byte[] byteA, int offset, int size); // 0x000000018151E020-0x000000018151E0C0
		internal char ReadChar(); // 0x000000018151E0C0-0x000000018151E0F0
		internal char[] ReadChars(int length); // 0x000000018151E0F0-0x000000018151E120
		internal decimal ReadDecimal(); // 0x000000018151E370-0x000000018151E430
		internal float ReadSingle(); // 0x0000000181521700-0x0000000181521730
		internal double ReadDouble(); // 0x000000018151E430-0x000000018151E460
		internal short ReadInt16(); // 0x000000018151E460-0x000000018151E490
		internal int ReadInt32(); // 0x000000018151E490-0x000000018151E4C0
		internal long ReadInt64(); // 0x000000018151E4C0-0x000000018151E4F0
		internal sbyte ReadSByte(); // 0x000000018151DFC0-0x000000018151DFF0
		internal string ReadString(); // 0x0000000181521730-0x0000000181521760
		internal TimeSpan ReadTimeSpan(); // 0x000000018151E4C0-0x000000018151E4F0
		internal DateTime ReadDateTime(); // 0x000000018151E300-0x000000018151E370
		internal ushort ReadUInt16(); // 0x0000000181521760-0x0000000181521790
		internal uint ReadUInt32(); // 0x0000000181521790-0x00000001815217C0
		internal ulong ReadUInt64(); // 0x00000001815217C0-0x00000001815217F0
		internal void ReadSerializationHeaderRecord(); // 0x0000000181521640-0x0000000181521700
		internal void ReadAssembly(BinaryHeaderEnum binaryHeaderEnum); // 0x000000018151DD00-0x000000018151DF90
		private void ReadObject(); // 0x0000000181521100-0x0000000181521640
		internal void ReadCrossAppDomainMap(); // 0x000000018151E120-0x000000018151E300
		internal void ReadObjectWithMap(BinaryHeaderEnum binaryHeaderEnum); // 0x0000000181520A70-0x0000000181520B40
		private void ReadObjectWithMap(BinaryObjectWithMap record); // 0x0000000181520B40-0x0000000181521100
		internal void ReadObjectWithMapTyped(BinaryHeaderEnum binaryHeaderEnum); // 0x0000000181520360-0x0000000181520420
		private void ReadObjectWithMapTyped(BinaryObjectWithMapTyped record); // 0x0000000181520420-0x0000000181520A70
		private void ReadObjectString(BinaryHeaderEnum binaryHeaderEnum); // 0x000000018151F950-0x0000000181520360
		private void ReadMemberPrimitiveTyped(); // 0x000000018151E4F0-0x000000018151EB20
		private void ReadArray(BinaryHeaderEnum binaryHeaderEnum); // 0x000000018151D5D0-0x000000018151DD00
		private void ReadArrayAsBytes(ParseRecord pr); // 0x000000018151D2C0-0x000000018151D5D0
		private void ReadMemberPrimitiveUnTyped(); // 0x000000018151EB20-0x000000018151F090
		private void ReadMemberReference(); // 0x000000018151F090-0x000000018151F450
		private void ReadObjectNull(BinaryHeaderEnum binaryHeaderEnum); // 0x000000018151F5D0-0x000000018151F950
		private void ReadMessageEnd(); // 0x000000018151F450-0x000000018151F5D0
		internal object ReadValue(InternalPrimitiveTypeE code); // 0x00000001815217F0-0x0000000181521D60
		private ObjectProgress GetOp(); // 0x000000018151D170-0x000000018151D220
		private void PutOp(ObjectProgress op); // 0x000000018151D220-0x000000018151D2C0
	}
}
