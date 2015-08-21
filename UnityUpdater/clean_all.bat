@echo off

call clean.bat

if exist Library (
    rmdir /S /Q Library
)

if exist Assembly-CSharp.csproj (
    del /F /Q Assembly-CSharp.csproj
)

if exist Assembly-CSharp-vs.csproj (
    del /F /Q Assembly-CSharp-vs.csproj
)

if exist UnityUpdater.sln (
    del /F /Q UnityUpdater.sln
)

if exist UnityUpdater.userprefs (
    del /F /Q UnityUpdater.userprefs
)

if exist UnityUpdater-csharp.sln (
    del /F /Q UnityUpdater-csharp.sln
)
