//Type is in global namespace

public class WebViewObject : MonoBehaviour
{
	private Action<String> onJS; //Field offset: 0x20
	private Action<String> onError; //Field offset: 0x28
	private Action<String> onHttpError; //Field offset: 0x30
	private Action<String> onStarted; //Field offset: 0x38
	private Action<String> onLoaded; //Field offset: 0x40
	private Action<String> onHooked; //Field offset: 0x48
	private Action<String> onCookies; //Field offset: 0x50
	private bool paused; //Field offset: 0x58
	private bool visibility; //Field offset: 0x59
	private bool alertDialogEnabled; //Field offset: 0x5A
	private bool scrollBounceEnabled; //Field offset: 0x5B
	private int mMarginLeft; //Field offset: 0x5C
	private int mMarginTop; //Field offset: 0x60
	private int mMarginRight; //Field offset: 0x64
	private int mMarginBottom; //Field offset: 0x68
	private bool mMarginRelative; //Field offset: 0x6C
	private float mMarginLeftComputed; //Field offset: 0x70
	private float mMarginTopComputed; //Field offset: 0x74
	private float mMarginRightComputed; //Field offset: 0x78
	private float mMarginBottomComputed; //Field offset: 0x7C
	private bool mMarginRelativeComputed; //Field offset: 0x80
	private IntPtr webView; //Field offset: 0x88

	public bool IsKeyboardVisible
	{
		 get { } //Length: 3
	}

	public WebViewObject() { }

	public void AddCustomHeader(string headerKey, string headerValue) { }

	private void Awake() { }

	public void CallFromJS(string message) { }

	public void CallOnCookies(string cookies) { }

	public void CallOnError(string error) { }

	public void CallOnHooked(string message) { }

	public void CallOnHttpError(string error) { }

	public void CallOnLoaded(string url) { }

	public void CallOnStarted(string url) { }

	public bool CanGoBack() { }

	public bool CanGoForward() { }

	public void ClearCache(bool includeDiskFiles) { }

	public void ClearCookie(string url, string name) { }

	public void ClearCookies() { }

	public void ClearCustomHeader() { }

	public void EvaluateJS(string js) { }

	public bool get_IsKeyboardVisible() { }

	public bool GetAlertDialogEnabled() { }

	public void GetCookies(string url) { }

	public string GetCustomHeaderValue(string headerKey) { }

	public bool GetScrollBounceEnabled() { }

	public bool GetVisibility() { }

	public void GoBack() { }

	public void GoForward() { }

	public void Init(Action<String> cb = null, Action<String> err = null, Action<String> httpErr = null, Action<String> ld = null, Action<String> started = null, Action<String> hooked = null, Action<String> cookies = null, bool transparent = false, bool zoom = true, string ua = "", int radius = 0, int androidForceDarkMode = 0, bool enableWKWebView = true, int wkContentMode = 0, bool wkAllowsLinkPreview = true, bool wkAllowsBackForwardNavigationGestures = true, bool separated = false) { }

	public bool IsInitialized() { }

	public static bool IsWebViewAvailable() { }

	public void LoadHTML(string html, string baseUrl) { }

	public void LoadURL(string url) { }

	protected override void OnDestroy() { }

	public void Pause() { }

	public int Progress() { }

	public void Reload() { }

	public void RemoveCustomHeader(string headerKey) { }

	public void Resume() { }

	public void SaveCookies() { }

	public void SetAlertDialogEnabled(bool e) { }

	public void SetBasicAuthInfo(string userName, string password) { }

	public void SetCameraAccess(bool allowed) { }

	public void SetCenterPositionWithScale(Vector2 center, Vector2 scale) { }

	public void SetGoogleAppRedirectionEnabled(bool enabled) { }

	public void SetInteractionEnabled(bool enabled) { }

	public void SetMargins(int left, int top, int right, int bottom, bool relative = false) { }

	public void SetMicrophoneAccess(bool allowed) { }

	public void SetMixedContentMode(int mode) { }

	public void SetScrollbarsVisibility(bool v) { }

	public void SetScrollBounceEnabled(bool e) { }

	public void SetTextZoom(int textZoom) { }

	public bool SetURLPattern(string allowPattern, string denyPattern, string hookPattern) { }

	public void SetVisibility(bool v) { }

}

