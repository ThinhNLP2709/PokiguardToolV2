/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Claims;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Security.Principal
{
	[Serializable]
	[ComVisible(true)]
	public class GenericPrincipal : ClaimsPrincipal // TypeDefIndex: 2859
	{
		// Fields
		private IIdentity m_identity; // 0x28
		private string[] m_roles; // 0x30
	
		// Properties
		public override IIdentity Identity { get; } // 0x000000018033D240-0x000000018033D250 
	
		// Constructors
		public GenericPrincipal(IIdentity identity, string[] roles); // 0x00000001814B96F0-0x00000001814B98C0
	}
}
