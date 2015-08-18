@echo off

call clean.bat /q

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

mkdir out

robocopy UnityEditor\out  out\ /E
robocopy UnityServer\out  out\ /E
robocopy UnityUpdater\out out\ /E

rem ------------------------------------------------

pause