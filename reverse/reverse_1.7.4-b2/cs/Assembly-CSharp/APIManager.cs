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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class APIManager : MonoBehaviour // TypeDefIndex: 1356
{
	// Fields
	private static APIManager _instance; // 0x00
	private const string QUOTED_MESSAGE_KEY = "\"message\""; // Metadata: 0x0068CED9

	// Properties
	public static APIManager Instance { get; } // 0x00000001805A79E0-0x00000001805A7AF0 

	// Nested types
	[Serializable]
	private class ErrorEnvelope // TypeDefIndex: 1357
	{
		// Fields
		public bool success; // 0x10
		public string code; // 0x18
		public string message; // 0x20

		// Constructors
		public ErrorEnvelope(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	private class ResponseWrapper<T> // TypeDefIndex: 1358
	{
		// Fields
		public T data;
		public bool success;
		public string message;

		// Constructors
		public ResponseWrapper();
	}

	[CompilerGenerated]
	private sealed class _GetRequest_d__8<T> : IEnumerator<object> // TypeDefIndex: 1359
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
	private sealed class _PostBytes_d__10 : IEnumerator<object> // TypeDefIndex: 1360
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public byte[] bytes; // 0x20
		public Action<string> onError; // 0x28
		public APIManager __4__this; // 0x30
		public string url; // 0x38
		public string contentType; // 0x40
		public Action<string> onSuccess; // 0x48
		private UnityWebRequest _request_5__2; // 0x50

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PostBytes_d__10(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805BC540-0x00000001805BC620
		private bool MoveNext(); // 0x00000001805BBEC0-0x00000001805BC500
		private void __m__Finally1(); // 0x00000001805BC620-0x00000001805BC670
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805BC500-0x00000001805BC540
	}

	[CompilerGenerated]
	private sealed class _PostRequest_d__11<T> : IEnumerator<object> // TypeDefIndex: 1361
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
		public _PostRequest_d__11(int __1__state);

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose();
		private bool MoveNext();
		private void __m__Finally1();
		[DebuggerHidden]
		void IEnumerator.Reset();
	}

	[CompilerGenerated]
	private sealed class _PostRequestRaw_d__9 : IEnumerator<object> // TypeDefIndex: 1362
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PostRequestRaw_d__9(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805BCD70-0x00000001805BCE50
		private bool MoveNext(); // 0x00000001805BC670-0x00000001805BCD30
		private void __m__Finally1(); // 0x00000001805BCE50-0x00000001805BCEA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805BCD30-0x00000001805BCD70
	}

	[CompilerGenerated]
	private sealed class _PostRequest_Generic_d__12<T> : IEnumerator<object> // TypeDefIndex: 1363
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
		public _PostRequest_Generic_d__12(int __1__state);

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose();
		private bool MoveNext();
		[DebuggerHidden]
		void IEnumerator.Reset();
	}

	[CompilerGenerated]
	private sealed class _PostRequest_Generic_d__13<T> : IEnumerator<object> // TypeDefIndex: 1364
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
		public _PostRequest_Generic_d__13(int __1__state);

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose();
		private bool MoveNext();
		private void __m__Finally1();
		[DebuggerHidden]
		void IEnumerator.Reset();
	}

	// Constructors
	public APIManager(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	public Coroutine Run(IEnumerator routine); // 0x00000001805A78F0-0x00000001805A7900
	public static bool Alive(MonoBehaviour m); // 0x00000001805A72B0-0x00000001805A7320
	private string GetAuthToken(); // 0x00000001805A7320-0x00000001805A7370
	private bool HasToken(); // 0x00000001805A7470-0x00000001805A74D0
	private void HandleUnauthorized(); // 0x00000001805A7370-0x00000001805A7410
	[IteratorStateMachine(typeof(_GetRequest_d__8<T>))]
	public IEnumerator GetRequest<T>(string url, Action<T> onSuccess, Action<string> onError);
	[IteratorStateMachine(typeof(_PostRequestRaw_d__9))]
	public IEnumerator PostRequestRaw(string url, object data, Action<string> onSuccess, Action<string> onError); // 0x00000001805A7810-0x00000001805A78F0
	[IteratorStateMachine(typeof(_PostBytes_d__10))]
	public IEnumerator PostBytes(string url, byte[] bytes, string contentType, Action<string> onSuccess, Action<string> onError); // 0x00000001805A7720-0x00000001805A7810
	[IteratorStateMachine(typeof(_PostRequest_d__11<T>))]
	public IEnumerator PostRequest<T>(string url, object body, Action<T> onSuccess, Action<string> onError);
	[IteratorStateMachine(typeof(_PostRequest_Generic_d__12<T>))]
	public IEnumerator PostRequest_Generic<T>(string url, object data, Action<T> onSuccess, Action<string> onError);
	[IteratorStateMachine(typeof(_PostRequest_Generic_d__13<T>))]
	public IEnumerator PostRequest_Generic<T>(string url, object data, Action<T> onSuccess, Action<string> onError, Dictionary<string, string> extraHeaders);
	public void Logout(); // 0x00000001805A7680-0x00000001805A7720
	private static bool IsServerEnvelope(string rawResponse); // 0x00000001805A7610-0x00000001805A7680
	private static bool HasNullData(string rawResponse); // 0x00000001805A7410-0x00000001805A7470
	private static string BusinessError<T>(ResponseWrapper<T> wrapped, bool serverEnveloped, string rawResponse);
	public static bool IsServerBusinessMessage(string err); // 0x00000001805A74D0-0x00000001805A7610
	private static string ServerMessageOf(string body); // 0x00000001805A7900-0x00000001805A79E0
}

