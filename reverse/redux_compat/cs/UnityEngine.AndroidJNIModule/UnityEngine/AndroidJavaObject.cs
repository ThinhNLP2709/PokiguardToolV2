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
	public class AndroidJavaObject : IDisposable // TypeDefIndex: 14773
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static bool enableDebugPrints; // 0x00
		internal GlobalJavaObjectRef m_jobject; // 0x10
		internal GlobalJavaObjectRef m_jclass; // 0x18
	
		// Constructors
		public AndroidJavaObject(string className, params object[] args); // 0x000000018214ECE0-0x000000018214ED20
		public AndroidJavaObject(IntPtr jobject); // 0x000000018214EB40-0x000000018214ECE0
		internal AndroidJavaObject(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void Dispose(); // 0x000000018214E440-0x000000018214E4B0
		public IntPtr GetRawObject(); // 0x000000018214E580-0x000000018214E5A0
		public IntPtr GetRawClass(); // 0x0000000181777F00-0x0000000181777F20
		public ReturnType Call<ReturnType>(string methodName, params object[] args);
		public ReturnType CallStatic<ReturnType>(string methodName, params object[] args);
		protected void DebugPrint(string msg); // 0x000000018214E3D0-0x000000018214E440
		private void _AndroidJavaObject(string className, params object[] args); // 0x000000018214E5A0-0x000000018214E840
		private void _AndroidJavaObject(IntPtr constructorID, params object[] args); // 0x000000018214E840-0x000000018214EB40
		~AndroidJavaObject(); // 0x0000000181428550-0x00000001814285D0
		protected virtual void Dispose(bool disposing); // 0x000000018214E4B0-0x000000018214E580
		protected ReturnType _Call<ReturnType>(string methodName, params object[] args);
		protected ReturnType _Call<ReturnType>(IntPtr methodID, params object[] args);
		protected ReturnType _CallStatic<ReturnType>(string methodName, params object[] args);
		protected ReturnType _CallStatic<ReturnType>(IntPtr methodID, params object[] args);
		internal static AndroidJavaObject AndroidJavaObjectDeleteLocalRef(IntPtr jobject); // 0x000000018214E2F0-0x000000018214E3D0
		internal static ReturnType FromJavaArray<ReturnType>(IntPtr jobject);
		protected IntPtr _GetRawObject(); // 0x000000018214E580-0x000000018214E5A0
		protected IntPtr _GetRawClass(); // 0x0000000181777F00-0x0000000181777F20
	}
}
