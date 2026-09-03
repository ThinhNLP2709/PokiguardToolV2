/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 40: Assembly-CSharp-firstpass.dll - Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15099-15191

public class WebViewObject : MonoBehaviour // TypeDefIndex: 15100
{
	// Fields
	private Action<string> onJS; // 0x20
	private Action<string> onError; // 0x28
	private Action<string> onHttpError; // 0x30
	private Action<string> onStarted; // 0x38
	private Action<string> onLoaded; // 0x40
	private Action<string> onHooked; // 0x48
	private Action<string> onCookies; // 0x50
	private bool paused; // 0x58
	private bool visibility; // 0x59
	private bool alertDialogEnabled; // 0x5A
	private bool scrollBounceEnabled; // 0x5B
	private int mMarginLeft; // 0x5C
	private int mMarginTop; // 0x60
	private int mMarginRight; // 0x64
	private int mMarginBottom; // 0x68
	private bool mMarginRelative; // 0x6C
	private float mMarginLeftComputed; // 0x70
	private float mMarginTopComputed; // 0x74
	private float mMarginRightComputed; // 0x78
	private float mMarginBottomComputed; // 0x7C
	private bool mMarginRelativeComputed; // 0x80
	private IntPtr webView; // 0x88

	// Properties
	public bool IsKeyboardVisible { get; } // 0x00000001802E7840-0x00000001802E7850 

	// Constructors
	public WebViewObject(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Awake(); // 0x00000001802E76D0-0x00000001802E7700
	public static bool IsWebViewAvailable(); // 0x00000001802E7990-0x00000001802E79A0
	public bool IsInitialized(); // 0x00000001802E7990-0x00000001802E79A0
	public void Init(Action<string> cb = null, Action<string> err = null, Action<string> httpErr = null, Action<string> ld = null, Action<string> started = null, Action<string> hooked = null, Action<string> cookies = null, bool transparent = false /* Metadata: 0x006A9E78 */, bool zoom = true /* Metadata: 0x006A9E79 */, string ua = "" /* Metadata: 0x006A9E7A */, int radius = 0 /* Metadata: 0x006A9E7B */, int androidForceDarkMode = 0 /* Metadata: 0x006A9E7C */, bool enableWKWebView = true /* Metadata: 0x006A9E7D */, int wkContentMode = 0 /* Metadata: 0x006A9E7E */, bool wkAllowsLinkPreview = true /* Metadata: 0x006A9E7F */, bool wkAllowsBackForwardNavigationGestures = true /* Metadata: 0x006A9E80 */, bool separated = false /* Metadata: 0x006A9E81 */); // 0x00000001802E7890-0x00000001802E7990
	protected virtual void OnDestroy(); // 0x00000001802E76C0-0x00000001802E76D0
	public void Pause(); // 0x00000001802E76C0-0x00000001802E76D0
	public void Resume(); // 0x00000001802E76C0-0x00000001802E76D0
	public void SetCenterPositionWithScale(Vector2 center, Vector2 scale); // 0x00000001802E76C0-0x00000001802E76D0
	public void SetMargins(int left, int top, int right, int bottom, bool relative = false /* Metadata: 0x006A9E82 */); // 0x00000001802E76C0-0x00000001802E76D0
	public void SetVisibility(bool v); // 0x00000001802E7A20-0x00000001802E7A70
	public bool GetVisibility(); // 0x00000001802E7880-0x00000001802E7890
	public void SetScrollbarsVisibility(bool v); // 0x00000001802E76C0-0x00000001802E76D0
	public void SetInteractionEnabled(bool enabled); // 0x00000001802E76C0-0x00000001802E76D0
	public void SetGoogleAppRedirectionEnabled(bool enabled); // 0x00000001802E76C0-0x00000001802E76D0
	public void SetAlertDialogEnabled(bool e); // 0x00000001802E7A00-0x00000001802E7A10
	public bool GetAlertDialogEnabled(); // 0x00000001802E7850-0x00000001802E7860
	public void SetScrollBounceEnabled(bool e); // 0x00000001802E7A10-0x00000001802E7A20
	public bool GetScrollBounceEnabled(); // 0x00000001802E7870-0x00000001802E7880
	public void SetCameraAccess(bool allowed); // 0x00000001802E76C0-0x00000001802E76D0
	public void SetMicrophoneAccess(bool allowed); // 0x00000001802E76C0-0x00000001802E76D0
	public bool SetURLPattern(string allowPattern, string denyPattern, string hookPattern); // 0x00000001802E7840-0x00000001802E7850
	public void LoadURL(string url); // 0x00000001802E79F0-0x00000001802E7A00
	public void LoadHTML(string html, string baseUrl); // 0x00000001802E79A0-0x00000001802E79F0
	public void EvaluateJS(string js); // 0x00000001802E76C0-0x00000001802E76D0
	public int Progress(); // 0x00000001802E7860-0x00000001802E7870
	public bool CanGoBack(); // 0x00000001802E7840-0x00000001802E7850
	public bool CanGoForward(); // 0x00000001802E7840-0x00000001802E7850
	public void GoBack(); // 0x00000001802E76C0-0x00000001802E76D0
	public void GoForward(); // 0x00000001802E76C0-0x00000001802E76D0
	public void Reload(); // 0x00000001802E76C0-0x00000001802E76D0
	public void CallOnError(string error); // 0x00000001802E7770-0x00000001802E7790
	public void CallOnHttpError(string error); // 0x00000001802E77E0-0x00000001802E7800
	public void CallOnStarted(string url); // 0x00000001802E7820-0x00000001802E7840
	public void CallOnLoaded(string url); // 0x00000001802E7800-0x00000001802E7820
	public void CallFromJS(string message); // 0x00000001802E7700-0x00000001802E7750
	public void CallOnHooked(string message); // 0x00000001802E7790-0x00000001802E77E0
	public void CallOnCookies(string cookies); // 0x00000001802E7750-0x00000001802E7770
	public void AddCustomHeader(string headerKey, string headerValue); // 0x00000001802E76C0-0x00000001802E76D0
	public string GetCustomHeaderValue(string headerKey); // 0x00000001802E7860-0x00000001802E7870
	public void RemoveCustomHeader(string headerKey); // 0x00000001802E76C0-0x00000001802E76D0
	public void ClearCustomHeader(); // 0x00000001802E76C0-0x00000001802E76D0
	public void ClearCookie(string url, string name); // 0x00000001802E76C0-0x00000001802E76D0
	public void ClearCookies(); // 0x00000001802E76C0-0x00000001802E76D0
	public void SaveCookies(); // 0x00000001802E76C0-0x00000001802E76D0
	public void GetCookies(string url); // 0x00000001802E76C0-0x00000001802E76D0
	public void SetBasicAuthInfo(string userName, string password); // 0x00000001802E76C0-0x00000001802E76D0
	public void ClearCache(bool includeDiskFiles); // 0x00000001802E76C0-0x00000001802E76D0
	public void SetTextZoom(int textZoom); // 0x00000001802E76C0-0x00000001802E76D0
	public void SetMixedContentMode(int mode); // 0x00000001802E76C0-0x00000001802E76D0
}

