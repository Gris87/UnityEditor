@echo off

call clean.bat

if exist Library (
    rmdir /S /Q Library
)

if exist Temp (
    rmdir /S /Q Temp
)

if exist Assembly-CSharp.csproj (
    del /F /Q Assembly-CSharp.csproj
)

if exist Assembly-CSharp-vs.csproj (
    del /F /Q Assembly-CSharp-vs.csproj
)

if exist UnityEditor.sln (
    del /F /Q UnityEditor.sln
)

if exist UnityEditor.userprefs (
    del /F /Q UnityEditor.userprefs
)

if exist UnityEditor-csharp.sln (
    del /F /Q UnityEditor-csharp.sln
)
