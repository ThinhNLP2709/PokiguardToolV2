/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Text
{
	[Serializable]
	[ComVisible(true)]
	public abstract class Encoding : ICloneable // TypeDefIndex: 2734
	{
		// Fields
		private static Encoding defaultEncoding; // 0x00
		private static Encoding unicodeEncoding; // 0x08
		private static Encoding bigEndianUnicode; // 0x10
		private static Encoding utf7Encoding; // 0x18
		private static Encoding utf8Encoding; // 0x20
		private static Encoding utf32Encoding; // 0x28
		private static Encoding asciiEncoding; // 0x30
		private static Encoding latin1Encoding; // 0x38
		private static Dictionary<int, Encoding> encodings; // 0x40
		internal int m_codePage; // 0x10
		internal CodePageDataItem dataItem; // 0x18
		[NonSerialized]
		internal bool m_deserializedFromEverett; // 0x20
		[OptionalField(VersionAdded = 2)]
		private bool m_isReadOnly; // 0x21
		[OptionalField(VersionAdded = 2)]
		internal EncoderFallback encoderFallback; // 0x28
		[OptionalField(VersionAdded = 2)]
		internal DecoderFallback decoderFallback; // 0x30
		private static object s_InternalSyncObject; // 0x48
	
		// Properties
		private static object InternalSyncObject { get; } // 0x000000018147B630-0x000000018147B6C0 
		public virtual ReadOnlySpan<byte> Preamble { get; } // 0x000000018147B790-0x000000018147B7E0 
		public virtual string EncodingName { get; } // 0x000000018147B620-0x000000018147B630 
		public virtual string WebName { get; } // 0x000000018147BAF0-0x000000018147BC30 
		[ComVisible(false)]
		public EncoderFallback EncoderFallback { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018147BD10-0x000000018147BDE0
		[ComVisible(false)]
		public DecoderFallback DecoderFallback { get; set; } // 0x000000018031E110-0x000000018031E120 0x000000018147BC40-0x000000018147BD10
		[ComVisible(false)]
		public bool IsReadOnly { get; } // 0x000000018147B6C0-0x000000018147B6D0 
		public static Encoding ASCII { get; } // 0x000000018147B3B0-0x000000018147B470 
		private static Encoding Latin1 { get; } // 0x000000018147B6D0-0x000000018147B790 
		public virtual int CodePage { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public static Encoding Default { get; } // 0x000000018147B540-0x000000018147B620 
		public static Encoding Unicode { get; } // 0x000000018147BA20-0x000000018147BAF0 
		public static Encoding BigEndianUnicode { get; } // 0x000000018147B470-0x000000018147B540 
		public static Encoding UTF7 { get; } // 0x000000018147B8A0-0x000000018147B960 
		public static Encoding UTF8 { get; } // 0x000000018147B960-0x000000018147BA20 
		public static Encoding UTF32 { get; } // 0x000000018147B7E0-0x000000018147B8A0 
	
		// Nested types
		[Serializable]
		internal class DefaultEncoder : Encoder, ISerializable, IObjectReference // TypeDefIndex: 2735
		{
			// Fields
			private Encoding m_encoding; // 0x20
			[NonSerialized]
			private bool m_hasInitializedEncoding; // 0x28
			[NonSerialized]
			internal char charLeftOver; // 0x2A
	
			// Constructors
			public DefaultEncoder(Encoding encoding); // 0x0000000181476C60-0x0000000181476CA0
			internal DefaultEncoder(SerializationInfo info, StreamingContext context); // 0x0000000181476EE0-0x00000001814771A0
	
			// Methods
			public object GetRealObject(StreamingContext context); // 0x0000000181476D70-0x0000000181476E40
			void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181476E40-0x0000000181476EE0
			public override int GetByteCount(char[] chars, int index, int count, bool flush); // 0x0000000181476CD0-0x0000000181476D00
			public override unsafe int GetByteCount(char* chars, int count, bool flush); // 0x0000000181476CA0-0x0000000181476CD0
			public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex, bool flush); // 0x0000000181476D00-0x0000000181476D40
			public override unsafe int GetBytes(char* chars, int charCount, byte* bytes, int byteCount, bool flush); // 0x0000000181476D40-0x0000000181476D70
		}
	
		[Serializable]
		internal class DefaultDecoder : Decoder, ISerializable, IObjectReference // TypeDefIndex: 2736
		{
			// Fields
			private Encoding m_encoding; // 0x20
			[NonSerialized]
			private bool m_hasInitializedEncoding; // 0x28
	
			// Constructors
			public DefaultDecoder(Encoding encoding); // 0x0000000181476C60-0x0000000181476CA0
			internal DefaultDecoder(SerializationInfo info, StreamingContext context); // 0x00000001814769E0-0x0000000181476C60
	
			// Methods
			public object GetRealObject(StreamingContext context); // 0x00000001814768D0-0x0000000181476940
			void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181476940-0x00000001814769E0
			public override int GetCharCount(byte[] bytes, int index, int count); // 0x00000001814767C0-0x00000001814767F0
			public override int GetCharCount(byte[] bytes, int index, int count, bool flush); // 0x0000000181476790-0x00000001814767C0
			public override unsafe int GetCharCount(byte* bytes, int count, bool flush); // 0x00000001814767F0-0x0000000181476820
			public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex); // 0x0000000181476820-0x0000000181476860
			public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex, bool flush); // 0x0000000181476890-0x00000001814768D0
			public override unsafe int GetChars(byte* bytes, int byteCount, char* chars, int charCount, bool flush); // 0x0000000181476860-0x0000000181476890
		}
	
		internal class EncodingCharBuffer // TypeDefIndex: 2737
		{
			// Fields
			private unsafe char* chars; // 0x10
			private unsafe char* charStart; // 0x18
			private unsafe char* charEnd; // 0x20
			private int charCountResult; // 0x28
			private Encoding enc; // 0x30
			private DecoderNLS decoder; // 0x38
			private unsafe byte* byteStart; // 0x40
			private unsafe byte* byteEnd; // 0x48
			private unsafe byte* bytes; // 0x50
			private DecoderFallbackBuffer fallbackBuffer; // 0x58
	
			// Properties
			internal bool MoreData { get; } // 0x0000000181477CA0-0x0000000181477CB0 
			internal int BytesUsed { get; } // 0x0000000181477C90-0x0000000181477CA0 
			internal int Count { get; } // 0x0000000180377930-0x0000000180377940 
	
			// Constructors
			internal unsafe EncodingCharBuffer(Encoding enc, DecoderNLS decoder, char* charStart, int charCount, byte* byteStart, int byteCount); // 0x0000000181477BA0-0x0000000181477C90
	
			// Methods
			internal bool AddChar(char ch, int numBytes); // 0x00000001814777C0-0x00000001814778B0
			internal bool AddChar(char ch); // 0x00000001814778B0-0x0000000181477990
			internal void AdjustBytes(int count); // 0x0000000181477990-0x00000001814779A0
			internal byte GetNextByte(); // 0x0000000181477B80-0x0000000181477BA0
			internal bool Fallback(byte fallbackByte); // 0x00000001814779A0-0x0000000181477A10
			internal bool Fallback(byte[] byteBuffer); // 0x0000000181477A10-0x0000000181477B80
		}
	
		internal class EncodingByteBuffer // TypeDefIndex: 2738
		{
			// Fields
			private unsafe byte* bytes; // 0x10
			private unsafe byte* byteStart; // 0x18
			private unsafe byte* byteEnd; // 0x20
			private unsafe char* chars; // 0x28
			private unsafe char* charStart; // 0x30
			private unsafe char* charEnd; // 0x38
			private int byteCountResult; // 0x40
			private Encoding enc; // 0x48
			private EncoderNLS encoder; // 0x50
			internal EncoderFallbackBuffer fallbackBuffer; // 0x58
	
			// Properties
			internal bool MoreData { get; } // 0x0000000181477770-0x00000001814777C0 
			internal int CharsUsed { get; } // 0x0000000181477750-0x0000000181477770 
			internal int Count { get; } // 0x000000018033D790-0x000000018033D7A0 
	
			// Constructors
			internal unsafe EncodingByteBuffer(Encoding inEncoding, EncoderNLS inEncoder, byte* inByteStart, int inByteCount, char* inCharStart, int inCharCount); // 0x00000001814774D0-0x0000000181477750
	
			// Methods
			internal bool AddByte(byte b, int moreBytesExpected); // 0x0000000181477260-0x0000000181477380
			internal bool AddByte(byte b1); // 0x0000000181477250-0x0000000181477260
			internal bool AddByte(byte b1, byte b2); // 0x0000000181477200-0x0000000181477250
			internal bool AddByte(byte b1, byte b2, int moreBytesExpected); // 0x00000001814771A0-0x0000000181477200
			internal void MovePrevious(bool bThrow); // 0x00000001814773D0-0x00000001814774D0
			internal char GetNextChar(); // 0x0000000181477380-0x00000001814773D0
		}
	
		// Constructors
		protected Encoding(); // 0x000000018147B2E0-0x000000018147B320
		protected Encoding(int codePage); // 0x000000018147B320-0x000000018147B3B0
	
		// Methods
		internal virtual void SetDefaultFallbacks(); // 0x000000018147AEE0-0x000000018147AF80
		internal void OnDeserializing(); // 0x000000018147AD30-0x000000018147AD70
		internal void OnDeserialized(); // 0x000000018147ACE0-0x000000018147AD30
		[OnDeserializing]
		private void OnDeserializing(StreamingContext ctx); // 0x000000018147AD30-0x000000018147AD70
		[OnDeserialized]
		private void OnDeserialized(StreamingContext ctx); // 0x000000018147ACE0-0x000000018147AD30
		[OnSerializing]
		private void OnSerializing(StreamingContext ctx); // 0x000000018133DB00-0x000000018133DB20
		internal void DeserializeEncoding(SerializationInfo info, StreamingContext context); // 0x00000001814785A0-0x00000001814788F0
		internal void SerializeEncoding(SerializationInfo info, StreamingContext context); // 0x000000018147AD70-0x000000018147AEE0
		public static Encoding GetEncoding(int codepage); // 0x0000000181479D70-0x000000018147A920
		public static Encoding GetEncoding(int codepage, EncoderFallback encoderFallback, DecoderFallback decoderFallback); // 0x0000000181479A70-0x0000000181479CE0
		public static Encoding GetEncoding(string name); // 0x0000000181479CE0-0x0000000181479D70
		public virtual byte[] GetPreamble(); // 0x000000018147A990-0x000000018147A9E0
		private void GetDataItem(); // 0x0000000181479860-0x0000000181479990
		[ComVisible(false)]
		public virtual object Clone(); // 0x00000001814784D0-0x0000000181478550
		public virtual int GetByteCount(string s); // 0x0000000181478A60-0x0000000181478B00
		public abstract int GetByteCount(char[] chars, int index, int count);
		[CLSCompliant(false)]
		[ComVisible(false)]
		public virtual unsafe int GetByteCount(char* chars, int count); // 0x0000000181478B00-0x0000000181478CA0
		internal virtual unsafe int GetByteCount(char* chars, int count, EncoderNLS encoder); // 0x0000000181478CA0-0x0000000181478CC0
		public virtual byte[] GetBytes(char[] chars); // 0x00000001814790D0-0x0000000181479180
		public virtual byte[] GetBytes(char[] chars, int index, int count); // 0x0000000181478F70-0x0000000181479040
		public abstract int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex);
		public virtual byte[] GetBytes(string s); // 0x0000000181479180-0x0000000181479290
		public virtual int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex); // 0x0000000181479290-0x0000000181479340
		internal virtual unsafe int GetBytes(char* chars, int charCount, byte* bytes, int byteCount, EncoderNLS encoder); // 0x00000001814790B0-0x00000001814790D0
		[CLSCompliant(false)]
		[ComVisible(false)]
		public virtual unsafe int GetBytes(char* chars, int charCount, byte* bytes, int byteCount); // 0x0000000181478D00-0x0000000181478F70
		public abstract int GetCharCount(byte[] bytes, int index, int count);
		[CLSCompliant(false)]
		[ComVisible(false)]
		public virtual unsafe int GetCharCount(byte* bytes, int count); // 0x0000000181479340-0x00000001814794E0
		internal virtual unsafe int GetCharCount(byte* bytes, int count, DecoderNLS decoder); // 0x00000001814794E0-0x0000000181479500
		public virtual char[] GetChars(byte[] bytes, int index, int count); // 0x0000000181479500-0x00000001814795D0
		public abstract int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex);
		[CLSCompliant(false)]
		[ComVisible(false)]
		public virtual unsafe int GetChars(byte* bytes, int byteCount, char* chars, int charCount); // 0x00000001814795F0-0x0000000181479860
		internal virtual unsafe int GetChars(byte* bytes, int byteCount, char* chars, int charCount, DecoderNLS decoder); // 0x00000001814795D0-0x00000001814795F0
		[CLSCompliant(false)]
		[ComVisible(false)]
		public unsafe string GetString(byte* bytes, int byteCount); // 0x000000018147AA90-0x000000018147AB90
		public string GetString(ReadOnlySpan<byte> bytes); // 0x000000018147AB90-0x000000018147ACB0
		public virtual Decoder GetDecoder(); // 0x0000000181479990-0x0000000181479A00
		private static Encoding CreateDefaultEncoding(); // 0x0000000181478550-0x00000001814785A0
		internal void setReadOnly(bool value = true /* Metadata: 0x0064EA9A */); // 0x000000018147BC30-0x000000018147BC40
		public virtual Encoder GetEncoder(); // 0x0000000181479A00-0x0000000181479A70
		public abstract int GetMaxByteCount(int charCount);
		public abstract int GetMaxCharCount(int byteCount);
		public virtual string GetString(byte[] bytes); // 0x000000018147A9E0-0x000000018147AA90
		public virtual string GetString(byte[] bytes, int index, int count); // 0x000000018147ACB0-0x000000018147ACE0
		public override bool Equals(object value); // 0x00000001814788F0-0x00000001814789C0
		public override int GetHashCode(); // 0x000000018147A920-0x000000018147A990
		internal virtual char[] GetBestFitUnicodeToBytesData(); // 0x0000000181478A10-0x0000000181478A60
		internal virtual char[] GetBestFitBytesToUnicodeData(); // 0x00000001814789C0-0x0000000181478A10
		internal void ThrowBytesOverflow(); // 0x000000018147AF80-0x000000018147B090
		internal void ThrowBytesOverflow(EncoderNLS encoder, bool nothingEncoded); // 0x000000018147B090-0x000000018147B130
		internal void ThrowCharsOverflow(); // 0x000000018147B130-0x000000018147B240
		internal void ThrowCharsOverflow(DecoderNLS decoder, bool nothingDecoded); // 0x000000018147B240-0x000000018147B2E0
		public virtual int GetByteCount(ReadOnlySpan<char> chars); // 0x0000000181478CC0-0x0000000181478D00
		public virtual int GetBytes(ReadOnlySpan<char> chars, Span<byte> bytes); // 0x0000000181479040-0x00000001814790B0
	}
}
