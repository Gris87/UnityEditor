@echo off

if exist out (
    rmdir /S /Q out
)

rem ------------------------------------------------

cd UnityEditor
call clean_all.bat
cd ..

cd UnityServer
call clean_all.bat
cd ..

cd UnityUpdater
call clean_all.bat
cd ..

rem ------------------------------------------------

if [%1]==[] (
    echo Completed
    
    pause
)
