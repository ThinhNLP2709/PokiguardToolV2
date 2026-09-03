/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Resources
{
	[ComVisible(true)]
	public sealed class ResourceReader : IResourceReader // TypeDefIndex: 3266
	{
		// Fields
		private BinaryReader _store; // 0x10
		internal Dictionary<string, ResourceLocator> _resCache; // 0x18
		private long _nameSectionOffset; // 0x20
		private long _dataSectionOffset; // 0x28
		private int[] _nameHashes; // 0x30
		private unsafe int* _nameHashesPtr; // 0x38
		private int[] _namePositions; // 0x40
		private unsafe int* _namePositionsPtr; // 0x48
		private RuntimeType[] _typeTable; // 0x50
		private int[] _typeNamePositions; // 0x58
		private BinaryFormatter _objFormatter; // 0x60
		private int _numResources; // 0x68
		private UnmanagedMemoryStream _ums; // 0x70
		private int _version; // 0x78
	
		// Nested types
		internal sealed class ResourceEnumerator : IDictionaryEnumerator // TypeDefIndex: 3267
		{
			// Fields
			private ResourceReader _reader; // 0x10
			private bool _currentIsValid; // 0x18
			private int _currentName; // 0x1C
			private int _dataPosition; // 0x20
	
			// Properties
			public object Key { get; } // 0x00000001815131D0-0x0000000181513330 
			public object Current { get; } // 0x0000000181512D30-0x0000000181512D90 
			internal int DataPosition { get; } // 0x0000000180C4F680-0x0000000180C4F690 
			public DictionaryEntry Entry { get; } // 0x0000000181512D90-0x00000001815131D0 
			public object Value { get; } // 0x0000000181513330-0x0000000181513490 
	
			// Constructors
			internal ResourceEnumerator(ResourceReader reader); // 0x0000000181512CF0-0x0000000181512D30
	
			// Methods
			public bool MoveNext(); // 0x0000000181512C00-0x0000000181512C50
			public void Reset(); // 0x0000000181512C50-0x0000000181512CF0
		}
	
		// Constructors
		internal ResourceReader(Stream stream, Dictionary<string, ResourceLocator> resCache); // 0x0000000181517F70-0x00000001815180C0
	
		// Methods
		public void Close(); // 0x0000000181514580-0x0000000181514640
		public void Dispose(); // 0x0000000181514CB0-0x0000000181514CC0
		private void Dispose(bool disposing); // 0x0000000181514BF0-0x0000000181514CB0
		internal static unsafe int ReadUnalignedI4(int* p); // 0x00000001815161D0-0x00000001815161F0
		private void SkipString(); // 0x00000001815161F0-0x00000001815162C0
		private int GetNameHash(int index); // 0x0000000181515670-0x00000001815156E0
		private int GetNamePosition(int index); // 0x00000001815156E0-0x0000000181515810
		IEnumerator IEnumerable.GetEnumerator(); // 0x00000001815155A0-0x0000000181515670
		public IDictionaryEnumerator GetEnumerator(); // 0x00000001815155A0-0x0000000181515670
		internal ResourceEnumerator GetEnumeratorInternal(); // 0x0000000181515530-0x00000001815155A0
		internal int FindPosForResource(string name); // 0x0000000181514CC0-0x00000001815151A0
		private bool CompareStringEqualsName(string name); // 0x0000000181514640-0x0000000181514A40
		private string AllocateStringForNameIndex(int index, out int dataOffset); // 0x0000000181513E10-0x0000000181514580
		private object GetValueForNameIndex(int index); // 0x0000000181515810-0x0000000181515AD0
		internal string LoadString(int pos); // 0x0000000181515D60-0x0000000181516050
		internal object LoadObject(int pos); // 0x0000000181515CD0-0x0000000181515D00
		internal object LoadObject(int pos, out ResourceTypeCode typeCode); // 0x0000000181515D00-0x0000000181515D60
		internal object LoadObjectV1(int pos); // 0x0000000181515AD0-0x0000000181515BD0
		private object _LoadObjectV1(int pos); // 0x00000001815162C0-0x0000000181516960
		internal object LoadObjectV2(int pos, out ResourceTypeCode typeCode); // 0x0000000181515BD0-0x0000000181515CD0
		private object _LoadObjectV2(int pos, out ResourceTypeCode typeCode); // 0x0000000181516960-0x00000001815174C0
		private object DeserializeObject(int typeIndex); // 0x0000000181514A40-0x0000000181514BF0
		private void ReadResources(); // 0x0000000181516050-0x00000001815161D0
		private void _ReadResources(); // 0x00000001815174C0-0x0000000181517F70
		private RuntimeType FindType(int typeIndex); // 0x00000001815151A0-0x0000000181515530
	}
}
