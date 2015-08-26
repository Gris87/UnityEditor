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

if exist UnityServer.sln (
    del /F /Q UnityServer.sln
)

if exist UnityServer.userprefs (
    del /F /Q UnityServer.userprefs
)

if exist UnityServer-csharp.sln (
    del /F /Q UnityServer-csharp.sln
)
