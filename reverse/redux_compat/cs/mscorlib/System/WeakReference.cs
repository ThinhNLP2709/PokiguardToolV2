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
	[ComVisible(true)]
	public class WeakReference : ISerializable // TypeDefIndex: 2507
	{
		// Fields
		private bool isLongReference; // 0x10
		private GCHandle gcHandle; // 0x18
	
		// Properties
		public virtual bool IsAlive { get; } // 0x0000000181679C90-0x0000000181679CC0 
		public virtual object Target { get; set; } // 0x0000000181679CC0-0x0000000181679D00 0x0000000181679D00-0x0000000181679D60
		public virtual bool TrackResurrection { get; } // 0x00000001805625D0-0x00000001805625E0 
	
		// Constructors
		protected WeakReference(); // 0x00000001802E5CB0-0x00000001802E5CC0
		public WeakReference(object target); // 0x0000000181679AE0-0x0000000181679B20
		public WeakReference(object target, bool trackResurrection); // 0x0000000181679B20-0x0000000181679B70
		protected WeakReference(SerializationInfo info, StreamingContext context); // 0x0000000181679B70-0x0000000181679C90
	
		// Methods
		private void AllocateHandle(object target); // 0x0000000181679920-0x0000000181679950
		~WeakReference(); // 0x0000000181679950-0x00000001816799C0
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001816799C0-0x0000000181679AE0
	}
}
