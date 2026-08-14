namespace UnityEngine.InputSystem;

internal class FastTouchscreen : Touchscreen
{
	public const string metadata = "AutoWindowSpace;Touch;Vector2;Delta;Analog;TouchPress;Button;Axis;Integer;TouchPhase;Double;Touchscreen;Pointer"; //Field offset: 0x0

	public FastTouchscreen() { }

	private DeltaControl Initialize_ctrlTouchscreendelta(InternedString kDeltaLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreendeltadown(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreendeltaleft(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreendeltaright(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreendeltaup(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreendeltax(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreendeltay(InternedString kAxisLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreendisplayIndex(InternedString kIntegerLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreenposition(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreenpositionx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreenpositiony(InternedString kAxisLayout, InputControl parent) { }

	private TouchPressControl Initialize_ctrlTouchscreenpress(InternedString kTouchPressLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreenpressure(InternedString kAnalogLayout, InputControl parent) { }

	private TouchControl Initialize_ctrlTouchscreenprimaryTouch(InternedString kTouchLayout, InputControl parent) { }

	private DeltaControl Initialize_ctrlTouchscreenprimaryTouchdelta(InternedString kDeltaLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreenprimaryTouchdeltadown(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreenprimaryTouchdeltaleft(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreenprimaryTouchdeltaright(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreenprimaryTouchdeltaup(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreenprimaryTouchdeltax(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreenprimaryTouchdeltay(InternedString kAxisLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreenprimaryTouchdisplayIndex(InternedString kIntegerLayout, InputControl parent) { }

	private ButtonControl Initialize_ctrlTouchscreenprimaryTouchindirectTouch(InternedString kButtonLayout, InputControl parent) { }

	private TouchPhaseControl Initialize_ctrlTouchscreenprimaryTouchphase(InternedString kTouchPhaseLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreenprimaryTouchposition(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreenprimaryTouchpositionx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreenprimaryTouchpositiony(InternedString kAxisLayout, InputControl parent) { }

	private TouchPressControl Initialize_ctrlTouchscreenprimaryTouchpress(InternedString kTouchPressLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreenprimaryTouchpressure(InternedString kAxisLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreenprimaryTouchradius(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreenprimaryTouchradiusx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreenprimaryTouchradiusy(InternedString kAxisLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreenprimaryTouchstartPosition(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreenprimaryTouchstartPositionx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreenprimaryTouchstartPositiony(InternedString kAxisLayout, InputControl parent) { }

	private DoubleControl Initialize_ctrlTouchscreenprimaryTouchstartTime(InternedString kDoubleLayout, InputControl parent) { }

	private ButtonControl Initialize_ctrlTouchscreenprimaryTouchtap(InternedString kButtonLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreenprimaryTouchtapCount(InternedString kIntegerLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreenprimaryTouchtouchId(InternedString kIntegerLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreenradius(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreenradiusx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreenradiusy(InternedString kAxisLayout, InputControl parent) { }

	private TouchControl Initialize_ctrlTouchscreentouch0(InternedString kTouchLayout, InputControl parent) { }

	private DeltaControl Initialize_ctrlTouchscreentouch0delta(InternedString kDeltaLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch0deltadown(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch0deltaleft(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch0deltaright(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch0deltaup(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch0deltax(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch0deltay(InternedString kAxisLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch0displayIndex(InternedString kIntegerLayout, InputControl parent) { }

	private ButtonControl Initialize_ctrlTouchscreentouch0indirectTouch(InternedString kButtonLayout, InputControl parent) { }

	private TouchPhaseControl Initialize_ctrlTouchscreentouch0phase(InternedString kTouchPhaseLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch0position(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch0positionx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch0positiony(InternedString kAxisLayout, InputControl parent) { }

	private TouchPressControl Initialize_ctrlTouchscreentouch0press(InternedString kTouchPressLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch0pressure(InternedString kAxisLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch0radius(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch0radiusx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch0radiusy(InternedString kAxisLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch0startPosition(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch0startPositionx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch0startPositiony(InternedString kAxisLayout, InputControl parent) { }

	private DoubleControl Initialize_ctrlTouchscreentouch0startTime(InternedString kDoubleLayout, InputControl parent) { }

	private ButtonControl Initialize_ctrlTouchscreentouch0tap(InternedString kButtonLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch0tapCount(InternedString kIntegerLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch0touchId(InternedString kIntegerLayout, InputControl parent) { }

	private TouchControl Initialize_ctrlTouchscreentouch1(InternedString kTouchLayout, InputControl parent) { }

	private DeltaControl Initialize_ctrlTouchscreentouch1delta(InternedString kDeltaLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch1deltadown(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch1deltaleft(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch1deltaright(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch1deltaup(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch1deltax(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch1deltay(InternedString kAxisLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch1displayIndex(InternedString kIntegerLayout, InputControl parent) { }

	private ButtonControl Initialize_ctrlTouchscreentouch1indirectTouch(InternedString kButtonLayout, InputControl parent) { }

	private TouchPhaseControl Initialize_ctrlTouchscreentouch1phase(InternedString kTouchPhaseLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch1position(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch1positionx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch1positiony(InternedString kAxisLayout, InputControl parent) { }

	private TouchPressControl Initialize_ctrlTouchscreentouch1press(InternedString kTouchPressLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch1pressure(InternedString kAxisLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch1radius(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch1radiusx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch1radiusy(InternedString kAxisLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch1startPosition(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch1startPositionx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch1startPositiony(InternedString kAxisLayout, InputControl parent) { }

	private DoubleControl Initialize_ctrlTouchscreentouch1startTime(InternedString kDoubleLayout, InputControl parent) { }

	private ButtonControl Initialize_ctrlTouchscreentouch1tap(InternedString kButtonLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch1tapCount(InternedString kIntegerLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch1touchId(InternedString kIntegerLayout, InputControl parent) { }

	private TouchControl Initialize_ctrlTouchscreentouch2(InternedString kTouchLayout, InputControl parent) { }

	private DeltaControl Initialize_ctrlTouchscreentouch2delta(InternedString kDeltaLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch2deltadown(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch2deltaleft(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch2deltaright(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch2deltaup(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch2deltax(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch2deltay(InternedString kAxisLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch2displayIndex(InternedString kIntegerLayout, InputControl parent) { }

	private ButtonControl Initialize_ctrlTouchscreentouch2indirectTouch(InternedString kButtonLayout, InputControl parent) { }

	private TouchPhaseControl Initialize_ctrlTouchscreentouch2phase(InternedString kTouchPhaseLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch2position(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch2positionx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch2positiony(InternedString kAxisLayout, InputControl parent) { }

	private TouchPressControl Initialize_ctrlTouchscreentouch2press(InternedString kTouchPressLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch2pressure(InternedString kAxisLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch2radius(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch2radiusx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch2radiusy(InternedString kAxisLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch2startPosition(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch2startPositionx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch2startPositiony(InternedString kAxisLayout, InputControl parent) { }

	private DoubleControl Initialize_ctrlTouchscreentouch2startTime(InternedString kDoubleLayout, InputControl parent) { }

	private ButtonControl Initialize_ctrlTouchscreentouch2tap(InternedString kButtonLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch2tapCount(InternedString kIntegerLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch2touchId(InternedString kIntegerLayout, InputControl parent) { }

	private TouchControl Initialize_ctrlTouchscreentouch3(InternedString kTouchLayout, InputControl parent) { }

	private DeltaControl Initialize_ctrlTouchscreentouch3delta(InternedString kDeltaLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch3deltadown(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch3deltaleft(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch3deltaright(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch3deltaup(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch3deltax(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch3deltay(InternedString kAxisLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch3displayIndex(InternedString kIntegerLayout, InputControl parent) { }

	private ButtonControl Initialize_ctrlTouchscreentouch3indirectTouch(InternedString kButtonLayout, InputControl parent) { }

	private TouchPhaseControl Initialize_ctrlTouchscreentouch3phase(InternedString kTouchPhaseLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch3position(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch3positionx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch3positiony(InternedString kAxisLayout, InputControl parent) { }

	private TouchPressControl Initialize_ctrlTouchscreentouch3press(InternedString kTouchPressLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch3pressure(InternedString kAxisLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch3radius(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch3radiusx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch3radiusy(InternedString kAxisLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch3startPosition(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch3startPositionx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch3startPositiony(InternedString kAxisLayout, InputControl parent) { }

	private DoubleControl Initialize_ctrlTouchscreentouch3startTime(InternedString kDoubleLayout, InputControl parent) { }

	private ButtonControl Initialize_ctrlTouchscreentouch3tap(InternedString kButtonLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch3tapCount(InternedString kIntegerLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch3touchId(InternedString kIntegerLayout, InputControl parent) { }

	private TouchControl Initialize_ctrlTouchscreentouch4(InternedString kTouchLayout, InputControl parent) { }

	private DeltaControl Initialize_ctrlTouchscreentouch4delta(InternedString kDeltaLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch4deltadown(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch4deltaleft(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch4deltaright(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch4deltaup(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch4deltax(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch4deltay(InternedString kAxisLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch4displayIndex(InternedString kIntegerLayout, InputControl parent) { }

	private ButtonControl Initialize_ctrlTouchscreentouch4indirectTouch(InternedString kButtonLayout, InputControl parent) { }

	private TouchPhaseControl Initialize_ctrlTouchscreentouch4phase(InternedString kTouchPhaseLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch4position(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch4positionx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch4positiony(InternedString kAxisLayout, InputControl parent) { }

	private TouchPressControl Initialize_ctrlTouchscreentouch4press(InternedString kTouchPressLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch4pressure(InternedString kAxisLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch4radius(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch4radiusx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch4radiusy(InternedString kAxisLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch4startPosition(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch4startPositionx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch4startPositiony(InternedString kAxisLayout, InputControl parent) { }

	private DoubleControl Initialize_ctrlTouchscreentouch4startTime(InternedString kDoubleLayout, InputControl parent) { }

	private ButtonControl Initialize_ctrlTouchscreentouch4tap(InternedString kButtonLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch4tapCount(InternedString kIntegerLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch4touchId(InternedString kIntegerLayout, InputControl parent) { }

	private TouchControl Initialize_ctrlTouchscreentouch5(InternedString kTouchLayout, InputControl parent) { }

	private DeltaControl Initialize_ctrlTouchscreentouch5delta(InternedString kDeltaLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch5deltadown(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch5deltaleft(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch5deltaright(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch5deltaup(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch5deltax(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch5deltay(InternedString kAxisLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch5displayIndex(InternedString kIntegerLayout, InputControl parent) { }

	private ButtonControl Initialize_ctrlTouchscreentouch5indirectTouch(InternedString kButtonLayout, InputControl parent) { }

	private TouchPhaseControl Initialize_ctrlTouchscreentouch5phase(InternedString kTouchPhaseLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch5position(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch5positionx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch5positiony(InternedString kAxisLayout, InputControl parent) { }

	private TouchPressControl Initialize_ctrlTouchscreentouch5press(InternedString kTouchPressLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch5pressure(InternedString kAxisLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch5radius(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch5radiusx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch5radiusy(InternedString kAxisLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch5startPosition(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch5startPositionx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch5startPositiony(InternedString kAxisLayout, InputControl parent) { }

	private DoubleControl Initialize_ctrlTouchscreentouch5startTime(InternedString kDoubleLayout, InputControl parent) { }

	private ButtonControl Initialize_ctrlTouchscreentouch5tap(InternedString kButtonLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch5tapCount(InternedString kIntegerLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch5touchId(InternedString kIntegerLayout, InputControl parent) { }

	private TouchControl Initialize_ctrlTouchscreentouch6(InternedString kTouchLayout, InputControl parent) { }

	private DeltaControl Initialize_ctrlTouchscreentouch6delta(InternedString kDeltaLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch6deltadown(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch6deltaleft(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch6deltaright(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch6deltaup(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch6deltax(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch6deltay(InternedString kAxisLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch6displayIndex(InternedString kIntegerLayout, InputControl parent) { }

	private ButtonControl Initialize_ctrlTouchscreentouch6indirectTouch(InternedString kButtonLayout, InputControl parent) { }

	private TouchPhaseControl Initialize_ctrlTouchscreentouch6phase(InternedString kTouchPhaseLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch6position(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch6positionx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch6positiony(InternedString kAxisLayout, InputControl parent) { }

	private TouchPressControl Initialize_ctrlTouchscreentouch6press(InternedString kTouchPressLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch6pressure(InternedString kAxisLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch6radius(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch6radiusx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch6radiusy(InternedString kAxisLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch6startPosition(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch6startPositionx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch6startPositiony(InternedString kAxisLayout, InputControl parent) { }

	private DoubleControl Initialize_ctrlTouchscreentouch6startTime(InternedString kDoubleLayout, InputControl parent) { }

	private ButtonControl Initialize_ctrlTouchscreentouch6tap(InternedString kButtonLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch6tapCount(InternedString kIntegerLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch6touchId(InternedString kIntegerLayout, InputControl parent) { }

	private TouchControl Initialize_ctrlTouchscreentouch7(InternedString kTouchLayout, InputControl parent) { }

	private DeltaControl Initialize_ctrlTouchscreentouch7delta(InternedString kDeltaLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch7deltadown(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch7deltaleft(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch7deltaright(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch7deltaup(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch7deltax(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch7deltay(InternedString kAxisLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch7displayIndex(InternedString kIntegerLayout, InputControl parent) { }

	private ButtonControl Initialize_ctrlTouchscreentouch7indirectTouch(InternedString kButtonLayout, InputControl parent) { }

	private TouchPhaseControl Initialize_ctrlTouchscreentouch7phase(InternedString kTouchPhaseLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch7position(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch7positionx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch7positiony(InternedString kAxisLayout, InputControl parent) { }

	private TouchPressControl Initialize_ctrlTouchscreentouch7press(InternedString kTouchPressLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch7pressure(InternedString kAxisLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch7radius(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch7radiusx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch7radiusy(InternedString kAxisLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch7startPosition(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch7startPositionx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch7startPositiony(InternedString kAxisLayout, InputControl parent) { }

	private DoubleControl Initialize_ctrlTouchscreentouch7startTime(InternedString kDoubleLayout, InputControl parent) { }

	private ButtonControl Initialize_ctrlTouchscreentouch7tap(InternedString kButtonLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch7tapCount(InternedString kIntegerLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch7touchId(InternedString kIntegerLayout, InputControl parent) { }

	private TouchControl Initialize_ctrlTouchscreentouch8(InternedString kTouchLayout, InputControl parent) { }

	private DeltaControl Initialize_ctrlTouchscreentouch8delta(InternedString kDeltaLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch8deltadown(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch8deltaleft(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch8deltaright(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch8deltaup(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch8deltax(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch8deltay(InternedString kAxisLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch8displayIndex(InternedString kIntegerLayout, InputControl parent) { }

	private ButtonControl Initialize_ctrlTouchscreentouch8indirectTouch(InternedString kButtonLayout, InputControl parent) { }

	private TouchPhaseControl Initialize_ctrlTouchscreentouch8phase(InternedString kTouchPhaseLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch8position(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch8positionx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch8positiony(InternedString kAxisLayout, InputControl parent) { }

	private TouchPressControl Initialize_ctrlTouchscreentouch8press(InternedString kTouchPressLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch8pressure(InternedString kAxisLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch8radius(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch8radiusx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch8radiusy(InternedString kAxisLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch8startPosition(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch8startPositionx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch8startPositiony(InternedString kAxisLayout, InputControl parent) { }

	private DoubleControl Initialize_ctrlTouchscreentouch8startTime(InternedString kDoubleLayout, InputControl parent) { }

	private ButtonControl Initialize_ctrlTouchscreentouch8tap(InternedString kButtonLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch8tapCount(InternedString kIntegerLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch8touchId(InternedString kIntegerLayout, InputControl parent) { }

	private TouchControl Initialize_ctrlTouchscreentouch9(InternedString kTouchLayout, InputControl parent) { }

	private DeltaControl Initialize_ctrlTouchscreentouch9delta(InternedString kDeltaLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch9deltadown(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch9deltaleft(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch9deltaright(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch9deltaup(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch9deltax(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch9deltay(InternedString kAxisLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch9displayIndex(InternedString kIntegerLayout, InputControl parent) { }

	private ButtonControl Initialize_ctrlTouchscreentouch9indirectTouch(InternedString kButtonLayout, InputControl parent) { }

	private TouchPhaseControl Initialize_ctrlTouchscreentouch9phase(InternedString kTouchPhaseLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch9position(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch9positionx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch9positiony(InternedString kAxisLayout, InputControl parent) { }

	private TouchPressControl Initialize_ctrlTouchscreentouch9press(InternedString kTouchPressLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch9pressure(InternedString kAxisLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch9radius(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch9radiusx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch9radiusy(InternedString kAxisLayout, InputControl parent) { }

	private Vector2Control Initialize_ctrlTouchscreentouch9startPosition(InternedString kVector2Layout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch9startPositionx(InternedString kAxisLayout, InputControl parent) { }

	private AxisControl Initialize_ctrlTouchscreentouch9startPositiony(InternedString kAxisLayout, InputControl parent) { }

	private DoubleControl Initialize_ctrlTouchscreentouch9startTime(InternedString kDoubleLayout, InputControl parent) { }

	private ButtonControl Initialize_ctrlTouchscreentouch9tap(InternedString kButtonLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch9tapCount(InternedString kIntegerLayout, InputControl parent) { }

	private IntegerControl Initialize_ctrlTouchscreentouch9touchId(InternedString kIntegerLayout, InputControl parent) { }

}

