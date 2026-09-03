/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class APIManager : MonoBehaviour // TypeDefIndex: 1142
{
	// Fields
	private static APIManager _instance; // 0x00
	private const string QUOTED_MESSAGE_KEY = "\"message\""; // Metadata: 0x0064D37E

	// Properties
	public static APIManager Instance { get; } // 0x00000001804AC4F0-0x00000001804AC600 

	// Nested types
	[Serializable]
	private class ErrorEnvelope // TypeDefIndex: 1143
	{
		// Fields
		public bool success; // 0x10
		public string code; // 0x18
		public string message; // 0x20

		// Constructors
		public ErrorEnvelope(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	private class ResponseWrapper<T> // TypeDefIndex: 1144
	{
		// Fields
		public T data;
		public bool success;
		public string message;

		// Constructors
		public ResponseWrapper();
	}

	[CompilerGenerated]
	private sealed class _GetRequest_d__8<T> : IEnumerator<object> // TypeDefIndex: 1145
	{
		// Fields
		private int __1__state;
		private object __2__current;
		public APIManager __4__this;
		public Action<string> onError;
		public string url;
		public Action<T> onSuccess;
		private UnityWebRequest _request_5__2;

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; }
		object IEnumerator.Current { [DebuggerHidden] get; }

		// Constructors
		[DebuggerHidden]
		public _GetRequest_d__8(int __1__state);

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose();
		private bool MoveNext();
		private void __m__Finally1();
		[DebuggerHidden]
		void IEnumerator.Reset();
	}

	[CompilerGenerated]
	private sealed class _PostRequest_d__10<T> : IEnumerator<object> // TypeDefIndex: 1146
	{
		// Fields
		private int __1__state;
		private object __2__current;
		public string url;
		public APIManager __4__this;
		public Action<string> onError;
		public object body;
		public Action<T> onSuccess;
		private UnityWebRequest _request_5__2;

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; }
		object IEnumerator.Current { [DebuggerHidden] get; }

		// Constructors
		[DebuggerHidden]
		public _PostRequest_d__10(int __1__state);

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose();
		private bool MoveNext();
		private void __m__Finally1();
		[DebuggerHidden]
		void IEnumerator.Reset();
	}

	[CompilerGenerated]
	private sealed class _PostRequestRaw_d__9 : IEnumerator<object> // TypeDefIndex: 1147
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string url; // 0x20
		public APIManager __4__this; // 0x28
		public Action<string> onError; // 0x30
		public object data; // 0x38
		public Action<string> onSuccess; // 0x40
		private UnityWebRequest _request_5__2; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PostRequestRaw_d__9(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804C1410-0x00000001804C14F0
		private bool MoveNext(); // 0x00000001804C0D10-0x00000001804C13D0
		private void __m__Finally1(); // 0x00000001804C14F0-0x00000001804C1540
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804C13D0-0x00000001804C1410
	}

	[CompilerGenerated]
	private sealed class _PostRequest_Generic_d__11<T> : IEnumerator<object> // TypeDefIndex: 1148
	{
		// Fields
		private int __1__state;
		private object __2__current;
		public APIManager __4__this;
		public string url;
		public object data;
		public Action<T> onSuccess;
		public Action<string> onError;

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; }
		object IEnumerator.Current { [DebuggerHidden] get; }

		// Constructors
		[DebuggerHidden]
		public _PostRequest_Generic_d__11(int __1__state);

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose();
		private bool MoveNext();
		[DebuggerHidden]
		void IEnumerator.Reset();
	}

	[CompilerGenerated]
	private sealed class _PostRequest_Generic_d__12<T> : IEnumerator<object> // TypeDefIndex: 1149
	{
		// Fields
		private int __1__state;
		private object __2__current;
		public string url;
		public APIManager __4__this;
		public Action<string> onError;
		public object data;
		public Dictionary<string, string> extraHeaders;
		public Action<T> onSuccess;
		private UnityWebRequest _request_5__2;

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; }
		object IEnumerator.Current { [DebuggerHidden] get; }

		// Constructors
		[DebuggerHidden]
		public _PostRequest_Generic_d__12(int __1__state);

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose();
		private bool MoveNext();
		private void __m__Finally1();
		[DebuggerHidden]
		void IEnumerator.Reset();
	}

	// Constructors
	public APIManager(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	public Coroutine Run(IEnumerator routine); // 0x00000001804AC400-0x00000001804AC410
	public static bool Alive(MonoBehaviour m); // 0x00000001804ABEB0-0x00000001804ABF20
	private string GetAuthToken(); // 0x00000001804ABF20-0x00000001804ABF70
	private bool HasToken(); // 0x00000001804AC070-0x00000001804AC0D0
	private void HandleUnauthorized(); // 0x00000001804ABF70-0x00000001804AC010
	[IteratorStateMachine(typeof(_GetRequest_d__8<T>))]
	public IEnumerator GetRequest<T>(string url, Action<T> onSuccess, Action<string> onError);
	[IteratorStateMachine(typeof(_PostRequestRaw_d__9))]
	public IEnumerator PostRequestRaw(string url, object data, Action<string> onSuccess, Action<string> onError); // 0x00000001804AC320-0x00000001804AC400
	[IteratorStateMachine(typeof(_PostRequest_d__10<T>))]
	public IEnumerator PostRequest<T>(string url, object body, Action<T> onSuccess, Action<string> onError);
	[IteratorStateMachine(typeof(_PostRequest_Generic_d__11<T>))]
	public IEnumerator PostRequest_Generic<T>(string url, object data, Action<T> onSuccess, Action<string> onError);
	[IteratorStateMachine(typeof(_PostRequest_Generic_d__12<T>))]
	public IEnumerator PostRequest_Generic<T>(string url, object data, Action<T> onSuccess, Action<string> onError, Dictionary<string, string> extraHeaders);
	public void Logout(); // 0x00000001804AC280-0x00000001804AC320
	private static bool IsServerEnvelope(string rawResponse); // 0x00000001804AC210-0x00000001804AC280
	private static bool HasNullData(string rawResponse); // 0x00000001804AC010-0x00000001804AC070
	private static string BusinessError<T>(ResponseWrapper<T> wrapped, bool serverEnveloped, string rawResponse);
	public static bool IsServerBusinessMessage(string err); // 0x00000001804AC0D0-0x00000001804AC210
	private static string ServerMessageOf(string body); // 0x00000001804AC410-0x00000001804AC4F0
}

