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
using System.Security.Claims;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Security.Principal
{
	[Serializable]
	[ComVisible(true)]
	public class WindowsIdentity : ClaimsIdentity, IIdentity, IDeserializationCallback, ISerializable, IDisposable // TypeDefIndex: 2861
	{
		// Fields
		private IntPtr _token; // 0x78
		private string _type; // 0x80
		private WindowsAccountType _account; // 0x88
		private bool _authenticated; // 0x8C
		private string _name; // 0x90
		private SerializationInfo _info; // 0x98
		private static IntPtr invalidWindows; // 0x00
	
		// Properties
		public sealed override string AuthenticationType { get; } // 0x000000018033D4A0-0x000000018033D4B0 
		public override bool IsAuthenticated { get; } // 0x00000001814CB7E0-0x00000001814CB7F0 
		public override string Name { get; } // 0x00000001814CB7F0-0x00000001814CB870 
	
		// Constructors
		public WindowsIdentity(IntPtr userToken, string type, WindowsAccountType acctType, bool isAuthenticated); // 0x00000001814CB680-0x00000001814CB730
		public WindowsIdentity(SerializationInfo info, StreamingContext context); // 0x00000001814CB730-0x00000001814CB790
		internal WindowsIdentity(ClaimsIdentity claimsIdentity, IntPtr userToken); // 0x00000001814CB790-0x00000001814CB7E0
		static WindowsIdentity(); // 0x00000001814CB640-0x00000001814CB680
	
		// Methods
		[ComVisible(false)]
		public void Dispose(); // 0x00000001814CAED0-0x00000001814CAEE0
		public static WindowsIdentity GetCurrent(); // 0x00000001814CAEF0-0x00000001814CAFD0
		public virtual WindowsImpersonationContext Impersonate(); // 0x00000001814CAFE0-0x00000001814CB0A0
		void IDeserializationCallback.OnDeserialization(object sender); // 0x00000001814CB200-0x00000001814CB510
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001814CB510-0x00000001814CB640
		internal ClaimsIdentity CloneAsBase(); // 0x00000001814CAEC0-0x00000001814CAED0
		internal IntPtr GetTokenInternal(); // 0x000000018033D4E0-0x000000018033D4F0
		private void SetToken(IntPtr token); // 0x00000001814CB0A0-0x00000001814CB200
		internal static IntPtr GetCurrentToken(); // 0x00000001814CAEE0-0x00000001814CAEF0
		private static string GetTokenName(IntPtr token); // 0x00000001814CAFD0-0x00000001814CAFE0
	}
}
