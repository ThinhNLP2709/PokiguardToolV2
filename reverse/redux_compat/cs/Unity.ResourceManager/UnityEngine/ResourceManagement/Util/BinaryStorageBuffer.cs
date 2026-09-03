/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.Util
{
	internal class BinaryStorageBuffer // TypeDefIndex: 13685
	{
		// Fields
		private const uint kUnicodeStringFlag = 2147483648; // Metadata: 0x006A7E18
		private const uint kDynamicStringFlag = 1073741824; // Metadata: 0x006A7E1D
		private const uint kClearFlagsMask = 1073741823; // Metadata: 0x006A7E22
	
		// Nested types
		private class BuiltinTypesSerializer : ISerializationAdapter<int>, ISerializationAdapter<bool>, ISerializationAdapter<long>, ISerializationAdapter<string>, ISerializationAdapter<Hash128> // TypeDefIndex: 13686
		{
			// Properties
			public IEnumerable<ISerializationAdapter> Dependencies { get; } // 0x00000001802E7860-0x00000001802E7870 
	
			// Nested types
			private struct ObjectToStringRemap // TypeDefIndex: 13687
			{
				// Fields
				public uint stringId; // 0x00
				public char separator; // 0x04
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass4_0 // TypeDefIndex: 13688
			{
				// Fields
				public char s; // 0x10
	
				// Constructors
				public __c__DisplayClass4_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal bool _FindBestSeparator_b__0(char c); // 0x000000018205AB60-0x000000018205AB70
			}
	
			// Constructors
			public BuiltinTypesSerializer(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public object Deserialize(Reader reader, Type t, uint offset, out uint size); // 0x0000000182048B30-0x0000000182048E40
			private char FindBestSeparator(string str, params char[] seps); // 0x0000000182048E40-0x0000000182048FF0
			public uint Serialize(Writer writer, object val); // 0x0000000182048FF0-0x0000000182049300
		}
	
		private class TypeSerializer : ISerializationAdapter<Type> // TypeDefIndex: 13689
		{
			// Properties
			public IEnumerable<ISerializationAdapter> Dependencies { get; } // 0x00000001802E7860-0x00000001802E7870 
	
			// Nested types
			private struct Data // TypeDefIndex: 13690
			{
				// Fields
				public uint assemblyId; // 0x00
				public uint classId; // 0x04
			}
	
			// Constructors
			public TypeSerializer(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public object Deserialize(Reader reader, Type type, uint offset, out uint size); // 0x000000018205A690-0x000000018205A8B0
			public uint Serialize(Writer writer, object val); // 0x000000018205A8B0-0x000000018205A9E0
		}
	
		private struct DynamicString // TypeDefIndex: 13691
		{
			// Fields
			public uint stringId; // 0x00
			public uint nextId; // 0x04
		}
	
		private struct ObjectTypeData // TypeDefIndex: 13692
		{
			// Fields
			public uint typeId; // 0x00
			public uint objectId; // 0x04
		}
	
		public interface ISerializationAdapter // TypeDefIndex: 13693
		{
			// Properties
			IEnumerable<ISerializationAdapter> Dependencies { get; }
	
			// Methods
			uint Serialize(Writer writer, object val);
			object Deserialize(Reader reader, Type t, uint offset, out uint size);
		}
	
		public interface ISerializationAdapter<T> : ISerializationAdapter // TypeDefIndex: 13694
		{
		}
	
		public class Reader // TypeDefIndex: 13695
		{
			// Fields
			private byte[] m_Buffer; // 0x10
			private Dictionary<Type, ISerializationAdapter> m_Adapters; // 0x18
			private LRUCache<uint, object> m_Cache; // 0x20
			private uint m_MinCachedObjectSize; // 0x40
			private StringBuilder stringBuilder; // 0x48
			private static StringCreationState s_StringCreationState; // 0x00
	
			// Nested types
			private class StringCreationState // TypeDefIndex: 13696
			{
				// Fields
				public uint id; // 0x10
				public char sep; // 0x14
				public int length; // 0x18
				public uint size; // 0x1C
	
				// Constructors
				public StringCreationState(); // 0x00000001802E5CB0-0x00000001802E5CC0
			}
	
			// Constructors
			public Reader(byte[] data, int maxCachedObjects = 1024 /* Metadata: 0x006A7E27 */, uint minCachedObjSize = 64 /* Metadata: 0x006A7E29 */, params ISerializationAdapter[] adapters); // 0x00000001820526C0-0x0000000182052720
			public Reader(Stream inputStream, uint bufferSize, int maxCachedObjects, uint minCachedObjSize, params ISerializationAdapter[] adapters); // 0x0000000182052720-0x0000000182052820
			static Reader(); // 0x0000000182052640-0x00000001820526C0
	
			// Methods
			public void GetCacheStats(out int reqCount, out int reqHits); // 0x0000000182051040-0x0000000182051050
			public void ResetCache(int maxCachedObjects, uint minCachedObjSize); // 0x0000000182052300-0x0000000182052390
			private void Init(byte[] data, int maxCachedObjects, uint minCachedObjSize, params ISerializationAdapter[] adapters); // 0x0000000182051350-0x0000000182051530
			public void AddSerializationAdapter(ISerializationAdapter a); // 0x0000000182050F70-0x0000000182050F80
			internal byte[] GetBuffer(); // 0x0000000180377550-0x0000000180377560
			private bool TryGetCachedValue(Type t, uint offset, out object val); // 0x0000000182052390-0x0000000182052440
			private bool TryGetCachedValue<T>(uint offset, out ref T val);
			public T[] ReadValueArray<T>(uint id, out uint readSize, bool cacheValue = true /* Metadata: 0x006A7E2A */)
				where T : struct;
			public uint ProcessObjectArray<T, C>(uint id, out uint size, C context, Action<T, C, int, int> procFunc, bool cacheValues = true /* Metadata: 0x006A7E2B */);
			public uint ReadObjectArray<T>(ref List<T> results, uint id, out uint size, bool cacheValues = true /* Metadata: 0x006A7E2C */);
			public object[] ReadObjectArray(uint id, out uint size, bool cacheValues = true /* Metadata: 0x006A7E2D */, bool cacheFullArray = false /* Metadata: 0x006A7E2E */); // 0x0000000182051A00-0x0000000182051CA0
			public object[] ReadObjectArray(Type t, uint id, out uint size, bool cacheValues = true /* Metadata: 0x006A7E2F */, bool cacheFullArray = false /* Metadata: 0x006A7E30 */); // 0x00000001820517E0-0x0000000182051A00
			public T[] ReadObjectArray<T>(uint id, out uint size, bool cacheValues = true /* Metadata: 0x006A7E31 */, bool cacheFullArray = false /* Metadata: 0x006A7E32 */);
			public object ReadObject(uint id, out uint size, bool cacheValue = true /* Metadata: 0x006A7E33 */); // 0x0000000182051EB0-0x0000000182051FA0
			public T ReadObject<T>(uint id, out uint size, bool cacheValue = true /* Metadata: 0x006A7E34 */);
			public object ReadObject(Type t, uint id, out uint size, bool cacheValue = true /* Metadata: 0x006A7E35 */); // 0x0000000182051CA0-0x0000000182051EB0
			public T ReadValue<T>(uint id, out uint size)
				where T : struct;
			public string ReadString(uint id, out uint size, char sep = '\x0000' /* Metadata: 0x006A7E36 */, bool cacheValue = true /* Metadata: 0x006A7E38 */); // 0x0000000182052230-0x0000000182052300
			private string ReadStringInternal(uint offset, out uint size, Encoding enc, bool cacheValue = true /* Metadata: 0x006A7E39 */); // 0x0000000182051FA0-0x0000000182052230
			private string ReadAutoEncodedString(uint id, out uint size, bool cacheValue); // 0x0000000182051530-0x00000001820515A0
			public int ComputeStringLength(uint id, char sep = '\x0000' /* Metadata: 0x006A7E3A */); // 0x0000000182050F80-0x0000000182050FF0
			private int GetDynamicStringLength(uint id, char sep); // 0x0000000182051050-0x0000000182051150
			private int GetAutoEncodedStringLength(uint id); // 0x0000000182050FF0-0x0000000182051040
			private int GetStringLengthInternal(uint offset, Encoding enc); // 0x0000000182051150-0x0000000182051350
			private string ReadDynamicString(uint id, out uint size, char sep, bool cacheValue); // 0x00000001820515A0-0x00000001820517E0
			[CompilerGenerated]
			private void _ReadDynamicString_b__33_0(Span<char> chars, StringCreationState state); // 0x0000000182052440-0x0000000182052640
		}
	
		public class Writer // TypeDefIndex: 13697
		{
			// Fields
			private uint totalBytes; // 0x10
			private uint defaulChunkSize; // 0x14
			private List<Chunk> chunks; // 0x18
			private Dictionary<Hash128, uint> existingValues; // 0x20
			private Dictionary<Type, ISerializationAdapter> serializationAdapters; // 0x28
	
			// Properties
			public uint Length { get; } // 0x00000001802E64B0-0x00000001802E64C0 
	
			// Nested types
			private class Chunk // TypeDefIndex: 13698
			{
				// Fields
				public uint position; // 0x10
				public byte[] data; // 0x18
	
				// Constructors
				public Chunk(); // 0x00000001802E5CB0-0x00000001802E5CC0
			}
	
			private struct StringParts // TypeDefIndex: 13699
			{
				// Fields
				public string str; // 0x00
				public uint dataSize; // 0x08
				public bool isUnicode; // 0x0C
			}
	
			// Constructors
			public Writer(int chunkSize = 1048576 /* Metadata: 0x006A7E3C */, params ISerializationAdapter[] adapters); // 0x000000018205D840-0x000000018205DAE0
	
			// Methods
			private Chunk FindChunkWithSpace(uint length); // 0x000000018205C5E0-0x000000018205C780
			private unsafe uint WriteInternal(void* pData, uint dataSize, bool prefixSize); // 0x000000018205D140-0x000000018205D320
			private uint ReserveInternal(uint dataSize, bool prefixSize); // 0x000000018205CA70-0x000000018205CAC0
			private unsafe void WriteInternal(uint id, void* pData, uint dataSize, bool prefixSize); // 0x000000018205D320-0x000000018205D5A0
			public uint Reserve<T>()
				where T : struct;
			public uint Write<T>([IsReadOnly] in ref T val)
				where T : struct;
			public uint Write<T>(T val)
				where T : struct;
			public uint Write<T>(uint offset, [IsReadOnly] in ref T val)
				where T : struct;
			public uint Write<T>(uint offset, T val)
				where T : struct;
			public uint Reserve<T>(uint count)
				where T : struct;
			public uint Write<T>(T[] values, bool hashElements = true /* Metadata: 0x006A7E40 */)
				where T : struct;
			public uint Write<T>(uint offset, T[] values, bool hashElements = true /* Metadata: 0x006A7E41 */)
				where T : struct;
			public uint WriteObjects<T>(IEnumerable<T> objs, bool serizalizeTypeData);
			public uint WriteObject(object obj, bool serializeTypeData); // 0x000000018205D5A0-0x000000018205D6F0
			public uint WriteString(string str, char sep = '\x0000' /* Metadata: 0x006A7E42 */); // 0x000000018205D770-0x000000018205D7A0
			private uint WriteStringInternal(string val, Encoding enc); // 0x000000018205D6F0-0x000000018205D770
			public byte[] SerializeToByteArray(); // 0x000000018205CAC0-0x000000018205CCF0
			public uint SerializeToStream(Stream str); // 0x000000018205CCF0-0x000000018205CE20
			private static bool IsUnicode(string str); // 0x000000018205C780-0x000000018205C7E0
			private uint WriteAutoEncodedString(string str); // 0x000000018205CE20-0x000000018205CF10
			private uint WriteUnicodeString(string str); // 0x000000018205D7A0-0x000000018205D840
			private static uint ComputeStringSize(string str, out bool isUnicode); // 0x000000018205C550-0x000000018205C5E0
			private uint WriteDynamicString(string str, char sep); // 0x000000018205CF10-0x000000018205D140
			private uint RecurseDynamicStringParts(StringParts[] parts, int index, char sep, uint minSize); // 0x000000018205C7E0-0x000000018205CA70
		}
	
		// Constructors
		public BinaryStorageBuffer(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		private static unsafe void ComputeHash(void* pData, ulong size, Hash128* hash); // 0x0000000182048900-0x0000000182048920
		private static void AddSerializationAdapter(Dictionary<Type, ISerializationAdapter> serializationAdapters, ISerializationAdapter adapter, bool forceOverride = false /* Metadata: 0x006A7E17 */); // 0x00000001820483F0-0x0000000182048900
		private static bool GetSerializationAdapter(Dictionary<Type, ISerializationAdapter> serializationAdapters, Type t, out ISerializationAdapter adapter); // 0x0000000182048920-0x0000000182048B30
	}
}
