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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class APIManager : MonoBehaviour // TypeDefIndex: 1740
{
	// Fields
	private static APIManager _instance; // 0x00
	private static float _lastUnauthorizedAt; // 0x08
	private const float UNAUTHORIZED_DEBOUNCE_SEC = 10f; // Metadata: 0x005F153A
	private static bool _unauthorizedDeferred; // 0x0C
	private const string QUOTED_MESSAGE_KEY = "\"message\""; // Metadata: 0x005F153E

	// Properties
	public static APIManager Instance { get; } // 0x00000001808CB730-0x00000001808CB940 

	// Nested types
	[Serializable]
	private class ErrorEnvelope // TypeDefIndex: 1741
	{
		// Fields
		public string message; // 0x10

		// Constructors
		public ErrorEnvelope(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	private class ResponseWrapper<T> // TypeDefIndex: 1742
	{
		// Fields
		public T data;
		public bool success;
		public string message;

		// Constructors
		public ResponseWrapper();
	}

	[CompilerGenerated]
	private sealed class _GetRequest_d__14<T> : IEnumerator<object> // TypeDefIndex: 1743
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
		public _GetRequest_d__14(int __1__state);

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose();
		private bool MoveNext();
		private void __m__Finally1();
		[DebuggerHidden]
		void IEnumerator.Reset();
	}

	[CompilerGenerated]
	private sealed class _PostBytes_d__16 : IEnumerator<object> // TypeDefIndex: 1744
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PostBytes_d__16(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001808CCB30-0x00000001808CCC60
		private bool MoveNext(); // 0x00000001808CCC60-0x00000001808CD3D0
		private void __m__Finally1(); // 0x00000001808CD3D0-0x00000001808CD430
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808CD430-0x00000001808CD470
	}

	[CompilerGenerated]
	private sealed class _PostRequest_d__17<T> : IEnumerator<object> // TypeDefIndex: 1745
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
		public _PostRequest_d__17(int __1__state);

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose();
		private bool MoveNext();
		private void __m__Finally1();
		[DebuggerHidden]
		void IEnumerator.Reset();
	}

	[CompilerGenerated]
	private sealed class _PostRequestRaw_d__15 : IEnumerator<object> // TypeDefIndex: 1746
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PostRequestRaw_d__15(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001808CD470-0x00000001808CD5A0
		private bool MoveNext(); // 0x00000001808CD5A0-0x00000001808CDE40
		private void __m__Finally1(); // 0x00000001808CDE40-0x00000001808CDEA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808CDEA0-0x00000001808CDEE0
	}

	[CompilerGenerated]
	private sealed class _PostRequest_Generic_d__18<T> : IEnumerator<object> // TypeDefIndex: 1747
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
		public _PostRequest_Generic_d__18(int __1__state);

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose();
		private bool MoveNext();
		[DebuggerHidden]
		void IEnumerator.Reset();
	}

	[CompilerGenerated]
	private sealed class _PostRequest_Generic_d__19<T> : IEnumerator<object> // TypeDefIndex: 1748
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
		public _PostRequest_Generic_d__19(int __1__state);

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose();
		private bool MoveNext();
		private void __m__Finally1();
		[DebuggerHidden]
		void IEnumerator.Reset();
	}

	// Constructors
	public APIManager(); // 0x000000018028A560-0x000000018028A5B0
	static APIManager(); // 0x00000001808CCAE0-0x00000001808CCB30

	// Methods
	public Coroutine Run(IEnumerator routine); // 0x00000001808CB940-0x00000001808CB950
	public static bool Alive(MonoBehaviour m); // 0x00000001808CB950-0x00000001808CBA70
	private string GetAuthToken(); // 0x00000001808CBA70-0x00000001808CBAD0
	private bool HasToken(); // 0x00000001808CBAD0-0x00000001808CBB40
	private void HandleUnauthorized(); // 0x00000001808CBB40-0x00000001808CBD00
	public void ReportUnauthorized(); // 0x00000001808CBD00-0x00000001808CBD10
	private void DoUnauthorizedTeardown(); // 0x00000001808CBD10-0x00000001808CBEC0
	private void Update(); // 0x00000001808CBEC0-0x00000001808CBFC0
	[IteratorStateMachine(typeof(_GetRequest_d__14<T>))]
	public IEnumerator GetRequest<T>(string url, Action<T> onSuccess, Action<string> onError);
	[IteratorStateMachine(typeof(_PostRequestRaw_d__15))]
	public IEnumerator PostRequestRaw(string url, object data, Action<string> onSuccess, Action<string> onError); // 0x00000001808CBFC0-0x00000001808CC1E0
	[IteratorStateMachine(typeof(_PostBytes_d__16))]
	public IEnumerator PostBytes(string url, byte[] bytes, string contentType, Action<string> onSuccess, Action<string> onError); // 0x00000001808CC1E0-0x00000001808CC450
	[IteratorStateMachine(typeof(_PostRequest_d__17<T>))]
	public IEnumerator PostRequest<T>(string url, object body, Action<T> onSuccess, Action<string> onError);
	[IteratorStateMachine(typeof(_PostRequest_Generic_d__18<T>))]
	public IEnumerator PostRequest_Generic<T>(string url, object data, Action<T> onSuccess, Action<string> onError);
	[IteratorStateMachine(typeof(_PostRequest_Generic_d__19<T>))]
	public IEnumerator PostRequest_Generic<T>(string url, object data, Action<T> onSuccess, Action<string> onError, Dictionary<string, string> extraHeaders);
	public void Logout(); // 0x00000001808CC450-0x00000001808CC5F0
	private static bool IsServerEnvelope(string rawResponse); // 0x00000001808CC5F0-0x00000001808CC670
	private static bool HasNullData(string rawResponse); // 0x00000001808CC670-0x00000001808CC6E0
	private static string BusinessError<T>(ResponseWrapper<T> wrapped, bool serverEnveloped, string rawResponse);
	public static bool IsServerBusinessMessage(string err); // 0x00000001808CC6E0-0x00000001808CC850
	private static string ServerMessageOf(string body); // 0x00000001808CC850-0x00000001808CCAE0
}

