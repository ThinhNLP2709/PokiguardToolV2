/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;

// Image 33: UnityEngine.AndroidJNIModule.dll - Assembly: UnityEngine.AndroidJNIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14765-14805

namespace UnityEngine
{
	public class AndroidJavaProxy // TypeDefIndex: 14772
	{
		// Fields
		public readonly AndroidJavaClass javaInterface; // 0x10
		internal IntPtr proxyObject; // 0x18
		[NoAutoStaticsCleanup]
		private static readonly GlobalJavaObjectRef s_JavaLangSystemClass; // 0x00
		private static readonly IntPtr s_HashCodeMethodID; // 0x08
	
		// Constructors
		public AndroidJavaProxy(string javaInterface); // 0x000000018214FEF0-0x000000018214FF70
		public AndroidJavaProxy(AndroidJavaClass javaInterface); // 0x000000018214FF70-0x000000018214FFB0
		static AndroidJavaProxy(); // 0x000000018214FDB0-0x000000018214FEF0
	
		// Methods
		~AndroidJavaProxy(); // 0x000000018214ED20-0x000000018214EDC0
		public virtual AndroidJavaObject Invoke(string methodName, object[] args); // 0x000000018214EEA0-0x000000018214F850
		public virtual AndroidJavaObject Invoke(string methodName, AndroidJavaObject[] javaArgs); // 0x000000018214F850-0x000000018214F9F0
		public virtual IntPtr Invoke(string methodName, IntPtr javaArgs); // 0x000000018214F9F0-0x000000018214FDB0
		public virtual bool equals(AndroidJavaObject obj); // 0x000000018214FFB0-0x0000000182150010
		public virtual int hashCode(); // 0x0000000182150010-0x00000001821500E0
		public virtual string toString(); // 0x00000001821500E0-0x0000000182150140
		internal AndroidJavaObject GetProxyObject(); // 0x000000018214EDC0-0x000000018214EDE0
		internal IntPtr GetRawProxy(); // 0x000000018214EDE0-0x000000018214EEA0
	}
}
