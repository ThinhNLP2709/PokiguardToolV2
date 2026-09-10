/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class LeanTweenExt // TypeDefIndex: 335
{
	// Extension methods
	public static LTDescr LeanAlpha(this GameObject gameObject, float to, float time); // 0x0000000180343910-0x0000000180343980
	public static LTDescr LeanAlphaVertex(this GameObject gameObject, float to, float time); // 0x00000001803437C0-0x0000000180343830
	public static LTDescr LeanAlpha(this RectTransform rectTransform, float to, float time); // 0x00000001803438A0-0x0000000180343910
	public static LTDescr LeanAlpha(this CanvasGroup canvas, float to, float time); // 0x0000000180343830-0x00000001803438A0
	public static LTDescr LeanAlphaText(this RectTransform rectTransform, float to, float time); // 0x0000000180343750-0x00000001803437C0
	public static void LeanCancel(this GameObject gameObject); // 0x0000000180343A30-0x0000000180343A80
	public static void LeanCancel(this GameObject gameObject, bool callOnComplete); // 0x0000000180343980-0x00000001803439E0
	public static void LeanCancel(this GameObject gameObject, int uniqueId, bool callOnComplete = false /* Metadata: 0x0068AEFA */); // 0x0000000180343A80-0x0000000180343AF0
	public static void LeanCancel(this RectTransform rectTransform); // 0x00000001803439E0-0x0000000180343A30
	public static LTDescr LeanColor(this GameObject gameObject, Color to, float time); // 0x0000000180343B70-0x0000000180343BF0
	public static LTDescr LeanColorText(this RectTransform rectTransform, Color to, float time); // 0x0000000180343AF0-0x0000000180343B70
	public static LTDescr LeanDelayedCall(this GameObject gameObject, float delayTime, Action callback); // 0x0000000180343CE0-0x0000000180343D50
	public static LTDescr LeanDelayedCall(this GameObject gameObject, float delayTime, Action<object> callback); // 0x0000000180343C70-0x0000000180343CE0
	public static bool LeanIsPaused(this GameObject gameObject); // 0x0000000180343D50-0x0000000180343DA0
	public static bool LeanIsPaused(this RectTransform rectTransform); // 0x0000000180343DA0-0x0000000180343DF0
	public static bool LeanIsTweening(this GameObject gameObject); // 0x0000000180343DF0-0x0000000180343E40
	public static LTDescr LeanMove(this GameObject gameObject, Vector3 to, float time); // 0x0000000180344BB0-0x0000000180344C30
	public static LTDescr LeanMove(this Transform transform, Vector3 to, float time); // 0x0000000180344ED0-0x0000000180344F70
	public static LTDescr LeanMove(this RectTransform rectTransform, Vector3 to, float time); // 0x0000000180344D30-0x0000000180344DB0
	public static LTDescr LeanMove(this GameObject gameObject, Vector2 to, float time); // 0x0000000180344F70-0x0000000180344FE0
	public static LTDescr LeanMove(this Transform transform, Vector2 to, float time); // 0x0000000180344E40-0x0000000180344ED0
	public static LTDescr LeanMove(this GameObject gameObject, Vector3[] to, float time); // 0x0000000180344C30-0x0000000180344CA0
	public static LTDescr LeanMove(this GameObject gameObject, LTBezierPath to, float time); // 0x00000001803450E0-0x0000000180345150
	public static LTDescr LeanMove(this GameObject gameObject, LTSpline to, float time); // 0x0000000180345070-0x00000001803450E0
	public static LTDescr LeanMove(this Transform transform, Vector3[] to, float time); // 0x0000000180344DB0-0x0000000180344E40
	public static LTDescr LeanMove(this Transform transform, LTBezierPath to, float time); // 0x0000000180344CA0-0x0000000180344D30
	public static LTDescr LeanMove(this Transform transform, LTSpline to, float time); // 0x0000000180344FE0-0x0000000180345070
	public static LTDescr LeanMoveLocal(this GameObject gameObject, Vector3 to, float time); // 0x00000001803441D0-0x0000000180344250
	public static LTDescr LeanMoveLocal(this GameObject gameObject, LTBezierPath to, float time); // 0x0000000180344250-0x00000001803442C0
	public static LTDescr LeanMoveLocal(this GameObject gameObject, LTSpline to, float time); // 0x0000000180344350-0x00000001803443C0
	public static LTDescr LeanMoveLocal(this Transform transform, Vector3 to, float time); // 0x00000001803443C0-0x0000000180344460
	public static LTDescr LeanMoveLocal(this Transform transform, LTBezierPath to, float time); // 0x0000000180344140-0x00000001803441D0
	public static LTDescr LeanMoveLocal(this Transform transform, LTSpline to, float time); // 0x00000001803442C0-0x0000000180344350
	public static LTDescr LeanMoveLocalX(this GameObject gameObject, float to, float time); // 0x0000000180343E40-0x0000000180343EB0
	public static LTDescr LeanMoveLocalY(this GameObject gameObject, float to, float time); // 0x0000000180343FD0-0x0000000180344040
	public static LTDescr LeanMoveLocalZ(this GameObject gameObject, float to, float time); // 0x0000000180344040-0x00000001803440B0
	public static LTDescr LeanMoveLocalX(this Transform transform, float to, float time); // 0x0000000180343EB0-0x0000000180343F40
	public static LTDescr LeanMoveLocalY(this Transform transform, float to, float time); // 0x0000000180343F40-0x0000000180343FD0
	public static LTDescr LeanMoveLocalZ(this Transform transform, float to, float time); // 0x00000001803440B0-0x0000000180344140
	public static LTDescr LeanMoveSpline(this GameObject gameObject, Vector3[] to, float time); // 0x0000000180344560-0x00000001803445D0
	public static LTDescr LeanMoveSpline(this GameObject gameObject, LTSpline to, float time); // 0x00000001803445D0-0x0000000180344640
	public static LTDescr LeanMoveSpline(this Transform transform, Vector3[] to, float time); // 0x00000001803446D0-0x0000000180344760
	public static LTDescr LeanMoveSpline(this Transform transform, LTSpline to, float time); // 0x0000000180344640-0x00000001803446D0
	public static LTDescr LeanMoveSplineLocal(this GameObject gameObject, Vector3[] to, float time); // 0x0000000180344460-0x00000001803444D0
	public static LTDescr LeanMoveSplineLocal(this Transform transform, Vector3[] to, float time); // 0x00000001803444D0-0x0000000180344560
	public static LTDescr LeanMoveX(this GameObject gameObject, float to, float time); // 0x0000000180344760-0x00000001803447D0
	public static LTDescr LeanMoveX(this Transform transform, float to, float time); // 0x00000001803447D0-0x0000000180344860
	public static LTDescr LeanMoveX(this RectTransform rectTransform, float to, float time); // 0x0000000180344860-0x00000001803448D0
	public static LTDescr LeanMoveY(this GameObject gameObject, float to, float time); // 0x0000000180344960-0x00000001803449D0
	public static LTDescr LeanMoveY(this Transform transform, float to, float time); // 0x00000001803448D0-0x0000000180344960
	public static LTDescr LeanMoveY(this RectTransform rectTransform, float to, float time); // 0x00000001803449D0-0x0000000180344A40
	public static LTDescr LeanMoveZ(this GameObject gameObject, float to, float time); // 0x0000000180344AB0-0x0000000180344B20
	public static LTDescr LeanMoveZ(this Transform transform, float to, float time); // 0x0000000180344B20-0x0000000180344BB0
	public static LTDescr LeanMoveZ(this RectTransform rectTransform, float to, float time); // 0x0000000180344A40-0x0000000180344AB0
	public static void LeanPause(this GameObject gameObject); // 0x0000000180345150-0x00000001803451A0
	public static LTDescr LeanPlay(this RectTransform rectTransform, Sprite[] sprites); // 0x00000001803451A0-0x0000000180345200
	public static void LeanResume(this GameObject gameObject); // 0x0000000180345200-0x0000000180345250
	public static LTDescr LeanRotate(this GameObject gameObject, Vector3 to, float time); // 0x0000000180345930-0x00000001803459B0
	public static LTDescr LeanRotate(this Transform transform, Vector3 to, float time); // 0x0000000180345A30-0x0000000180345AD0
	public static LTDescr LeanRotate(this RectTransform rectTransform, Vector3 to, float time); // 0x00000001803459B0-0x0000000180345A30
	public static LTDescr LeanRotateAround(this GameObject gameObject, Vector3 axis, float add, float time); // 0x00000001803454F0-0x0000000180345590
	public static LTDescr LeanRotateAround(this Transform transform, Vector3 axis, float add, float time); // 0x0000000180345440-0x00000001803454F0
	public static LTDescr LeanRotateAround(this RectTransform rectTransform, Vector3 axis, float add, float time); // 0x0000000180345590-0x0000000180345630
	public static LTDescr LeanRotateAroundLocal(this GameObject gameObject, Vector3 axis, float add, float time); // 0x0000000180345250-0x00000001803452F0
	public static LTDescr LeanRotateAroundLocal(this Transform transform, Vector3 axis, float add, float time); // 0x0000000180345390-0x0000000180345440
	public static LTDescr LeanRotateAroundLocal(this RectTransform rectTransform, Vector3 axis, float add, float time); // 0x00000001803452F0-0x0000000180345390
	public static LTDescr LeanRotateX(this GameObject gameObject, float to, float time); // 0x00000001803456C0-0x0000000180345730
	public static LTDescr LeanRotateX(this Transform transform, float to, float time); // 0x0000000180345630-0x00000001803456C0
	public static LTDescr LeanRotateY(this GameObject gameObject, float to, float time); // 0x0000000180345730-0x00000001803457A0
	public static LTDescr LeanRotateY(this Transform transform, float to, float time); // 0x00000001803457A0-0x0000000180345830
	public static LTDescr LeanRotateZ(this GameObject gameObject, float to, float time); // 0x00000001803458C0-0x0000000180345930
	public static LTDescr LeanRotateZ(this Transform transform, float to, float time); // 0x0000000180345830-0x00000001803458C0
	public static LTDescr LeanScale(this GameObject gameObject, Vector3 to, float time); // 0x0000000180345DD0-0x0000000180345E50
	public static LTDescr LeanScale(this Transform transform, Vector3 to, float time); // 0x0000000180345E50-0x0000000180345EF0
	public static LTDescr LeanScale(this RectTransform rectTransform, Vector3 to, float time); // 0x0000000180345EF0-0x0000000180345F70
	public static LTDescr LeanScaleX(this GameObject gameObject, float to, float time); // 0x0000000180345AD0-0x0000000180345B40
	public static LTDescr LeanScaleX(this Transform transform, float to, float time); // 0x0000000180345B40-0x0000000180345BD0
	public static LTDescr LeanScaleY(this GameObject gameObject, float to, float time); // 0x0000000180345BD0-0x0000000180345C40
	public static LTDescr LeanScaleY(this Transform transform, float to, float time); // 0x0000000180345C40-0x0000000180345CD0
	public static LTDescr LeanScaleZ(this GameObject gameObject, float to, float time); // 0x0000000180345CD0-0x0000000180345D40
	public static LTDescr LeanScaleZ(this Transform transform, float to, float time); // 0x0000000180345D40-0x0000000180345DD0
	public static LTDescr LeanSize(this RectTransform rectTransform, Vector2 to, float time); // 0x0000000180346270-0x00000001803462E0
	public static LTDescr LeanValue(this GameObject gameObject, Color from, Color to, float time); // 0x00000001803465D0-0x0000000180346670
	public static LTDescr LeanValue(this GameObject gameObject, float from, float to, float time); // 0x0000000180346870-0x0000000180346900
	public static LTDescr LeanValue(this GameObject gameObject, Vector2 from, Vector2 to, float time); // 0x0000000180346490-0x0000000180346520
	public static LTDescr LeanValue(this GameObject gameObject, Vector3 from, Vector3 to, float time); // 0x0000000180346520-0x00000001803465D0
	public static LTDescr LeanValue(this GameObject gameObject, Action<float> callOnUpdate, float from, float to, float time); // 0x0000000180346370-0x0000000180346400
	public static LTDescr LeanValue(this GameObject gameObject, Action<float, float> callOnUpdate, float from, float to, float time); // 0x0000000180346670-0x0000000180346700
	public static LTDescr LeanValue(this GameObject gameObject, Action<float, object> callOnUpdate, float from, float to, float time); // 0x0000000180346400-0x0000000180346490
	public static LTDescr LeanValue(this GameObject gameObject, Action<Color> callOnUpdate, Color from, Color to, float time); // 0x0000000180346700-0x00000001803467B0
	public static LTDescr LeanValue(this GameObject gameObject, Action<Vector2> callOnUpdate, Vector2 from, Vector2 to, float time); // 0x00000001803462E0-0x0000000180346370
	public static LTDescr LeanValue(this GameObject gameObject, Action<Vector3> callOnUpdate, Vector3 from, Vector3 to, float time); // 0x00000001803467B0-0x0000000180346870
	public static void LeanSetPosX(this Transform transform, float val); // 0x00000001803460F0-0x0000000180346170
	public static void LeanSetPosY(this Transform transform, float val); // 0x0000000180346170-0x00000001803461F0
	public static void LeanSetPosZ(this Transform transform, float val); // 0x00000001803461F0-0x0000000180346270
	public static void LeanSetLocalPosX(this Transform transform, float val); // 0x0000000180345F70-0x0000000180345FF0
	public static void LeanSetLocalPosY(this Transform transform, float val); // 0x0000000180345FF0-0x0000000180346070
	public static void LeanSetLocalPosZ(this Transform transform, float val); // 0x0000000180346070-0x00000001803460F0
	public static Color LeanColor(this Transform transform); // 0x0000000180343BF0-0x0000000180343C70
}

