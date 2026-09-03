/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[Serializable]
	[NativeClass("EntityId")]
	[NativeHeader("Runtime/BaseClasses/EntityIdStore.h")]
	[NativeHeader("Runtime/BaseClasses/BaseObject.h")]
	[UsedByNativeCode]
	public struct EntityId : IEquatable<UnityEngine.EntityId>, IComparable<UnityEngine.EntityId>, IFormattable // TypeDefIndex: 7785
	{
		// Fields
		[SerializeField]
		private ulong m_rawData; // 0x00
	
		// Properties
		public static EntityId None { get; } // 0x00000001802E7860-0x00000001802E7870 
		internal uint Index { get; } // 0x00000001821E72B0-0x00000001821E72C0 
		internal uint Version { get; } // 0x00000001821E72C0-0x00000001821E72D0 
	
		// Methods
		public override bool Equals(object obj); // 0x00000001821E70D0-0x00000001821E7150
		public bool Equals(EntityId other); // 0x0000000180DF5FE0-0x0000000180DF5FF0
		public int CompareTo(EntityId other); // 0x00000001821E70C0-0x00000001821E70D0
		public static bool operator ==(EntityId left, EntityId right); // 0x0000000180A29AB0-0x0000000180A29AC0
		public static bool operator !=(EntityId left, EntityId right); // 0x000000018126B560-0x000000018126B570
		public override int GetHashCode(); // 0x00000001821E7150-0x00000001821E7170
		[Obsolete("EntityId will not be representable by an int in the future. This casting operator will be removed in a future version.", true)]
		public static implicit operator int(EntityId entityId); // 0x00000001821E72D0-0x00000001821E7310
		[Obsolete("EntityId will not be representable by an int in the future. This casting operator will be removed in a future version.", true)]
		public static implicit operator EntityId(int intValue); // 0x00000001821E7310-0x00000001821E7350
		public override string ToString(); // 0x00000001821E7210-0x00000001821E72B0
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001821E7170-0x00000001821E7210
		[Obsolete("Please use EntityId.ToULong(EntityId) instead.", false)]
		public ulong GetRawData(); // 0x00000001808BADD0-0x00000001808BADE0
		public static EntityId FromULong(ulong input); // 0x0000000180370C60-0x0000000180370C70
		public static ulong ToULong(EntityId entityId); // 0x0000000180370C60-0x0000000180370C70
	}
}
