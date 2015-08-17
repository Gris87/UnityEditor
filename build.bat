@echo off

rem ------------------------------------------------

cd UnityEditor
call build.bat /q
cd ..

cd UnityServer
call build.bat /q
cd ..

cd UnityUpdater
call build.bat /q
cd ..

rem ------------------------------------------------

if exist out (
    rmdir /S /Q out
)

mkdir out

robocopy UnityEditor\out  out\ /E
robocopy UnityServer\out  out\ /E
robocopy UnityUpdater\out out\ /E

rem ------------------------------------------------

pause