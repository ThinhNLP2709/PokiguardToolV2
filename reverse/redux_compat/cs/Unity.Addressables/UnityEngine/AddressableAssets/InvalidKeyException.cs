/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

// Image 25: Unity.Addressables.dll - Assembly: Unity.Addressables, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14023-14125

namespace UnityEngine.AddressableAssets
{
	public class InvalidKeyException : Exception // TypeDefIndex: 14030
	{
		// Fields
		[CompilerGenerated]
		private object _Key_k__BackingField; // 0x90
		[CompilerGenerated]
		private Type _Type_k__BackingField; // 0x98
		[CompilerGenerated]
		private readonly Addressables.MergeMode? _MergeMode_k__BackingField; // 0xA0
		private AddressablesImpl m_Addressables; // 0xA8
		internal const string BaseInvalidKeyMessageFormat = "{0}, Key={1}, Type={2}"; // Metadata: 0x006A9178
		internal const string NoLocationMessageFormat = "{0} No Location found for Key={1}"; // Metadata: 0x006A918F
		internal const string MultipleTypeMismatchMessageFormat = "{0} No Asset found for Key={1} with Type={2}. Key exists as multiple Types={3}, which is not assignable from the requested Type={2}"; // Metadata: 0x006A91B1
		internal const string TypeMismatchMessageFormat = "{0} No Asset found for Key={1} with Type={2}. Key exists as Type={3}, which is not assignable from the requested Type={2}"; // Metadata: 0x006A9236
		internal const string MultipleTypesMessageFormat = "{0} Enumerable key contains multiple Types. {1}, all Keys are expected to be strings"; // Metadata: 0x006A92B1
		internal const string MergeModeNoLocationMessageFormat = "\nNo Location found for Key={0}"; // Metadata: 0x006A9307
		internal const string NoMergeModeMessageFormat = "{0} No MergeMode is set to merge the multiple keys requested. {1}, Type={2}"; // Metadata: 0x006A9326
		internal const string MergeModeBaseMessageFormat = "{0} No {1} of Assets between {2} with Type={3}"; // Metadata: 0x006A9373
		internal const string UnionAvailableForKeysMessageFormat = "\nUnion of Type={0} found with {1}"; // Metadata: 0x006A93A2
		internal const string UnionAvailableForKeysWithoutOtherMessageFormat = "\nUnion of Type={0} found with {1}. Without {2}"; // Metadata: 0x006A93C4
		internal const string IntersectionAvailableMessageFormat = "\nAn Intersection exists for Type={0}"; // Metadata: 0x006A93F3
		internal const string KeyAvailableAsTypeMessageFormat = "\nType={0} exists for {1}"; // Metadata: 0x006A9418
	
		// Properties
		public object Key { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806CCBA0-0x00000001806CCBB0 0x0000000180664160-0x0000000180664180
		public Type Type { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806CCBC0-0x00000001806CCBD0 0x00000001806CCE20-0x00000001806CCE40
		public Addressables.MergeMode? MergeMode { [CompilerGenerated] get; } // 0x00000001805B5990-0x00000001805B59A0 
		public override string Message { get; } // 0x0000000181C7D8F0-0x0000000181C7DDF0 
	
		// Nested types
		internal enum Format // TypeDefIndex: 14031
		{
			StandardMessage = 0,
			NoMergeMode = 1,
			MultipleTypesRequested = 2,
			NoLocation = 3,
			TypeMismatch = 4,
			MultipleTypeMismatch = 5,
			MergeModeBase = 6,
			UnionAvailableForKeys = 7,
			UnionAvailableForKeysWithoutOther = 8,
			IntersectionAvailable = 9,
			KeyAvailableAsType = 10
		}
	
		// Constructors
		public InvalidKeyException(object key); // 0x0000000181C7D640-0x0000000181C7D6E0
		public InvalidKeyException(object key, Type type); // 0x0000000181AD4E50-0x0000000181AD4ED0
		internal InvalidKeyException(object key, Type type, AddressablesImpl addr); // 0x0000000181C7D850-0x0000000181C7D8F0
		public InvalidKeyException(object key, Type type, Addressables.MergeMode mergeMode); // 0x0000000181C7D7A0-0x0000000181C7D850
		internal InvalidKeyException(object key, Type type, Addressables.MergeMode mergeMode, AddressablesImpl addr); // 0x0000000181C7D6E0-0x0000000181C7D7A0
		public InvalidKeyException(); // 0x00000001815FE7B0-0x00000001815FE7E0
		public InvalidKeyException(string message); // 0x00000001813FDE30-0x00000001813FDE70
		public InvalidKeyException(string message, Exception innerException); // 0x00000001813FDED0-0x00000001813FDF70
		protected InvalidKeyException(SerializationInfo message, StreamingContext context); // 0x00000001814ADEF0-0x00000001814ADF50
	
		// Methods
		internal string FormatMessage(Format format, string foundWithTypeString = null); // 0x0000000181C7B540-0x0000000181C7BCB0
		internal string FormatMergeModeMessage(Format format, string keysAvailable = null, string keysUnavailable = null, string typeString = null); // 0x0000000181C7B0F0-0x0000000181C7B540
		private string GetMessageForSingleKey(string keyString); // 0x0000000181C7C3D0-0x0000000181C7C440
		private string FormatNotFoundMessage(string keyString); // 0x0000000181C7BE80-0x0000000181C7BE90
		private string FormatTypeNotAssignableMessage(string keyString, HashSet<Type> typesAvailableForKey); // 0x0000000181C7BE90-0x0000000181C7C010
		private string FormatMultipleAssignableTypesMessage(string keyString, HashSet<Type> typesAvailableForKey); // 0x0000000181C7BCB0-0x0000000181C7BE80
		private string GetMessageforMergeKeys(List<string> keys); // 0x0000000181C7C440-0x0000000181C7D030
		private HashSet<Type> GetTypesForKey(string keyString); // 0x0000000181C7D240-0x0000000181C7D640
		private bool GetTypeToKeys(string key, Dictionary<Type, List<string>> typeToKeys); // 0x0000000181C7D030-0x0000000181C7D240
		internal string GetKeyString(); // 0x0000000181C7C2E0-0x0000000181C7C3D0
		internal static string GetCSVString(IEnumerable enumerator, string prefixSingle, string prefixPlural); // 0x0000000181C7C010-0x0000000181C7C2E0
	}
}
