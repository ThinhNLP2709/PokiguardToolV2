/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Security
{
	[Serializable]
	[ComVisible(true)]
	[MonoTODO("CAS support is experimental (and unsupported).")]
	public abstract class CodeAccessPermission : IPermission // TypeDefIndex: 2747
	{
		// Constructors
		protected CodeAccessPermission(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		[Conditional("MONO_FEATURE_CAS")]
		public void Demand(); // 0x0000000181474BE0-0x0000000181474C10
		[ComVisible(false)]
		public override bool Equals(object obj); // 0x0000000181474C10-0x0000000181474D40
		[ComVisible(false)]
		public override int GetHashCode(); // 0x0000000181474D40-0x0000000181474D50
		public abstract bool IsSubsetOf(IPermission target);
		public override string ToString(); // 0x0000000181474D50-0x0000000181474D90
		public abstract SecurityElement ToXml();
		internal static PermissionState CheckPermissionState(PermissionState state, bool allowUnrestricted); // 0x0000000181474B20-0x0000000181474BE0
		void IPermission.Demand(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
