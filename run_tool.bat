@echo off
setlocal EnableExtensions

rem Always run from this project, even when opened from Explorer or a shortcut.
cd /d "%~dp0"

rem Do not allow two Desktop UI/controller owners at the same time.
powershell.exe -NoProfile -NonInteractive -Command "$p = @(Get-CimInstance Win32_Process -ErrorAction SilentlyContinue).Where({ $_.Name -match '^python(w)?\.exe$' -and $_.CommandLine -match 'tools[\\/]desktop_ui\.py' }); if ($p.Count -gt 0) { exit 23 }"
if errorlevel 23 (
    echo PokiguardToolV2 dang mo. Hay dung cua so tool hien tai.
    pause
    exit /b 0
)

set "POKIGUARD_PYTHONW="
set "POKIGUARD_PYW_ARGS="

if exist ".venv\Scripts\pythonw.exe" (
    set "POKIGUARD_PYTHONW=%~dp0.venv\Scripts\pythonw.exe"
) else (
    for /f "delims=" %%I in ('where pythonw.exe 2^>nul') do if not defined POKIGUARD_PYTHONW set "POKIGUARD_PYTHONW=%%I"
)

if not defined POKIGUARD_PYTHONW (
    for /f "delims=" %%I in ('where pyw.exe 2^>nul') do if not defined POKIGUARD_PYTHONW (
        set "POKIGUARD_PYTHONW=%%I"
        set "POKIGUARD_PYW_ARGS=-3"
    )
)

if not defined POKIGUARD_PYTHONW (
    echo Khong tim thay Python 64-bit ^(pythonw.exe hoac pyw.exe^).
    echo Hay cai Python 3.11+ x64 va thu lai.
    pause
    exit /b 1
)

rem Opening the UI never starts or resumes farming automatically.
start "PokiguardToolV2" "%POKIGUARD_PYTHONW%" %POKIGUARD_PYW_ARGS% "tools\desktop_ui.py" --preferences "logs\desktop_ui\phase2e3_operator_preferences.json"
exit /b 0
