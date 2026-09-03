/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Security
{
	[Serializable]
	[ComVisible(true)]
	[MonoTODO("CAS support is experimental (and unsupported).")]
	public class PermissionSet : ISecurityEncodable, ICollection, IDeserializationCallback // TypeDefIndex: 2749
	{
		// Fields
		private static object[] psUnrestricted; // 0x00
		private PermissionState state; // 0x10
		private ArrayList list; // 0x18
		private bool _declsec; // 0x20
		private bool[] _ignored; // 0x28
		private static object[] action; // 0x08
	
		// Properties
		public virtual int Count { get; } // 0x0000000181480EC0-0x0000000181480EF0 
		public virtual bool IsSynchronized { get; } // 0x0000000181480EF0-0x0000000181480F20 
		public virtual object SyncRoot { get; } // 0x0000000180370C60-0x0000000180370C70 
	
		// Constructors
		internal PermissionSet(); // 0x0000000181480D40-0x0000000181480DB0
		public PermissionSet(PermissionState state); // 0x0000000181480DB0-0x0000000181480EC0
		internal PermissionSet(IPermission perm); // 0x0000000181480CA0-0x0000000181480D40
		static PermissionSet(); // 0x0000000181480AF0-0x0000000181480CA0
	
		// Methods
		public virtual void CopyTo(Array array, int index); // 0x000000018147FDC0-0x000000018147FF50
		public void Demand(); // 0x000000018147FF50-0x0000000181480150
		internal void CasOnlyDemand(int skip); // 0x000000018147FD40-0x000000018147FDC0
		public IEnumerator GetEnumerator(); // 0x0000000181480320-0x0000000181480350
		public bool IsEmpty(); // 0x00000001814803A0-0x0000000181480630
		public bool IsUnrestricted(); // 0x0000000180D91AF0-0x0000000180D91B00
		public override string ToString(); // 0x0000000181480630-0x0000000181480670
		public virtual SecurityElement ToXml(); // 0x0000000181480670-0x0000000181480AF0
		[MonoTODO("may not be required")]
		void IDeserializationCallback.OnDeserialization(object sender); // 0x00000001802E76C0-0x00000001802E76D0
		[ComVisible(false)]
		public override bool Equals(object obj); // 0x0000000181480150-0x0000000181480320
		[ComVisible(false)]
		public override int GetHashCode(); // 0x0000000181480350-0x00000001814803A0
	}
}
