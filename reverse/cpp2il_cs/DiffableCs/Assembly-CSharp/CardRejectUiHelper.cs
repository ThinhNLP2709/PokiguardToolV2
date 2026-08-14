//Type is in global namespace

public static class CardRejectUiHelper
{
	private const float TOAST_THROTTLE_SEC = 1.2; //Field offset: 0x0
	private static float _lastToastAt; //Field offset: 0x0

	private static CardRejectUiHelper() { }

	public static void HandleReject(int cardId, string reasonCode) { }

	public static string ReasonToVi(string code) { }

	private static bool RevertCard(int cardId) { }

}

