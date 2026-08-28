[CmdletBinding()]
param(
    [string]$OutputRoot,
    [switch]$SkipFocusedTests
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version Latest

$projectRoot = [System.IO.Path]::GetFullPath((Join-Path $PSScriptRoot '..'))
$pythonCommand = Get-Command python.exe -ErrorAction Stop
$python = $pythonCommand.Source

$architecture = & $python -c "import struct; print(struct.calcsize('P') * 8)"
if ($LASTEXITCODE -ne 0 -or $architecture.Trim() -ne '64') {
    throw 'Phase 2F.1 packaging requires 64-bit Python.'
}

& $python -c "import PyInstaller; print(PyInstaller.__version__)"
if ($LASTEXITCODE -ne 0) {
    throw 'PyInstaller is not installed in the selected Python runtime.'
}

$version = & $python -c "import sys; sys.path.insert(0, r'$projectRoot\src'); from pokiguard_v2.version import APP_VERSION; print(APP_VERSION)"
if ($LASTEXITCODE -ne 0 -or [string]::IsNullOrWhiteSpace($version)) {
    throw 'Could not read the canonical application version.'
}
$version = $version.Trim()

if ([string]::IsNullOrWhiteSpace($OutputRoot)) {
    if ([string]::IsNullOrWhiteSpace($env:LOCALAPPDATA)) {
        throw 'LOCALAPPDATA is unavailable; provide -OutputRoot explicitly.'
    }
    $OutputRoot = Join-Path $env:LOCALAPPDATA "PokiguardToolV2\package-builds\$version"
}
$output = [System.IO.Path]::GetFullPath($OutputRoot)
$work = Join-Path $output 'work'
$dist = Join-Path $output 'dist'

function Reset-SafeChildDirectory {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)][string]$Parent
    )
    $resolvedPath = [System.IO.Path]::GetFullPath($Path)
    $resolvedParent = [System.IO.Path]::GetFullPath($Parent).TrimEnd(
        [System.IO.Path]::DirectorySeparatorChar,
        [System.IO.Path]::AltDirectorySeparatorChar
    )
    $prefix = $resolvedParent + [System.IO.Path]::DirectorySeparatorChar
    if (-not $resolvedPath.StartsWith($prefix, [System.StringComparison]::OrdinalIgnoreCase)) {
        throw "Refusing to reset a path outside the build root: $resolvedPath"
    }
    if (Test-Path -LiteralPath $resolvedPath) {
        Remove-Item -LiteralPath $resolvedPath -Recurse -Force
    }
    New-Item -ItemType Directory -Path $resolvedPath -Force | Out-Null
}

New-Item -ItemType Directory -Path $output -Force | Out-Null
Reset-SafeChildDirectory -Path $work -Parent $output
Reset-SafeChildDirectory -Path $dist -Parent $output

if (-not $SkipFocusedTests) {
    $previousPythonPath = $env:PYTHONPATH
    try {
        $env:PYTHONPATH = "$projectRoot\src;$projectRoot"
        & $python -m unittest tests.test_app_paths tests.test_windows_packaging -v
        if ($LASTEXITCODE -ne 0) {
            throw 'Focused Phase 2F.1 tests failed.'
        }
    }
    finally {
        $env:PYTHONPATH = $previousPythonPath
    }
}

$spec = Join-Path $projectRoot 'packaging\PokiguardToolV2.spec'
& $python -m PyInstaller --noconfirm --clean --workpath $work --distpath $dist $spec
if ($LASTEXITCODE -ne 0) {
    throw 'PyInstaller build failed.'
}

$packageDirectory = Join-Path $dist 'PokiguardToolV2'
$executable = Join-Path $packageDirectory 'PokiguardToolV2.exe'
if (-not (Test-Path -LiteralPath $executable -PathType Leaf)) {
    throw "Packaged executable was not created: $executable"
}

$archive = Join-Path $output "PokiguardToolV2-$version-win-x64.zip"
if (Test-Path -LiteralPath $archive) {
    Remove-Item -LiteralPath $archive -Force
}
& $python (Join-Path $projectRoot 'scripts\create_deterministic_zip.py') $packageDirectory $archive
if ($LASTEXITCODE -ne 0) {
    throw 'Creating the deterministic package archive failed.'
}

$hash = (Get-FileHash -Algorithm SHA256 -LiteralPath $archive).Hash.ToLowerInvariant()
Write-Output "APP_VERSION=$version"
Write-Output "PACKAGE_DIRECTORY=$packageDirectory"
Write-Output "EXECUTABLE=$executable"
Write-Output "ARCHIVE=$archive"
Write-Output "SHA256=$hash"
