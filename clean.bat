@echo off

if exist out (
    rmdir /S /Q out
)

rem ------------------------------------------------

cd UnityEditor
call clean.bat
cd ..

cd UnityServer
call clean.bat
cd ..

cd UnityUpdater
call clean.bat
cd ..

rem ------------------------------------------------

if [%1]==[] (
    echo Completed
    
    pause
)
