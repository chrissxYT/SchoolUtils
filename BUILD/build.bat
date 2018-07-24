@echo off
echo.
echo ^<----------^>
echo Cleaning up.
echo ^<----------^>
echo.
rem @echo on
echo $ rmdir /S /Q x64
rmdir /S /Q x64 >NUL
echo $ rmdir /S /Q x86
rmdir /S /Q x86 >NUL
echo $ rmdir /S /Q AnyCpu
rmdir /S /Q AnyCpu >NUL
echo $ mkdir x64
mkdir x64 >NUL
echo $ mkdir x86
mkdir x86 >NUL
echo $ mkdir AnyCpu
mkdir AnyCpu >NUL
rem @echo off
echo.
echo ^<---------^>
echo Cleaned up.
echo ^<---------^>
echo.
echo ^<---------------------^>
echo Starting Any CPU Build.
echo ^<---------------------^>
echo.
rem add a /ds arg to every build command to show details
rem if you wouldn't clear you would need to insert a /t:Rebuild into every build command
echo $ "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe" /m /p:Configuration=Release /p:Platform="Any CPU" ..\SchoolUtils.sln
"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe" /m /p:Configuration=Release /p:Platform="Any CPU" ..\SchoolUtils.sln
echo.
echo ^<--------------------^>
echo Done building Any CPU.
echo ^<--------------------^>
echo.
echo ^<-----------------^>
echo Starting x86 Build.
echo ^<-----------------^>
echo.
echo $ "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe" /m /p:Configuration=Release /p:Platform=x86 ..\SchoolUtils.sln
"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe" /m /p:Configuration=Release /p:Platform=x86 ..\SchoolUtils.sln
echo.
echo ^<----------------^>
echo Done building x86.
echo ^<----------------^>
echo.
echo ^<-----------------^>
echo Starting x64 Build.
echo ^<-----------------^>
echo.
echo $ "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe" /m /p:Configuration=Release /p:Platform=x64 ..\SchoolUtils.sln
"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe" /m /p:Configuration=Release /p:Platform=x64 ..\SchoolUtils.sln
echo.
echo ^<----------------^>
echo Done building x64.
echo ^<----------------^>
echo.
echo.
echo ^<---------------------------------^>
echo Starting generating output folders.
echo ^<---------------------------------^>
echo.
rem @echo on
echo $ mkdir x64\\CpuGpuNames
mkdir x64\\CpuGpuNames >NUL
echo $ mkdir x64\\SchoolUtils
mkdir x64\\SchoolUtils >NUL
echo $ mkdir x64\\GetIP
mkdir x64\\GetIP >NUL
echo $ mkdir x64\\IPScanner
mkdir x64\\IPScanner >NUL
echo $ mkdir x64\\RamStatus
mkdir x64\\RamStatus >NUL
echo $ mkdir x86\\CpuGpuNames
mkdir x86\\CpuGpuNames >NUL
echo $ mkdir x86\\SchoolUtils
mkdir x86\\SchoolUtils >NUL
echo $ mkdir x86\\GetIP
mkdir x86\\GetIP >NUL
echo $ mkdir x86\\IPScanner
mkdir x86\\IPScanner >NUL
echo $ mkdir x86\\RamStatus
mkdir x86\\RamStatus >NUL
echo $ mkdir AnyCpu\\CpuGpuNames
mkdir AnyCpu\\CpuGpuNames >NUL
echo $ mkdir AnyCpu\\SchoolUtils
mkdir AnyCpu\\SchoolUtils >NUL
echo $ mkdir AnyCpu\\GetIP
mkdir AnyCpu\\GetIP >NUL
echo $ mkdir AnyCpu\\IPScanner
mkdir AnyCpu\\IPScanner >NUL
echo $ mkdir AnyCpu\\RamStatus
mkdir AnyCpu\\RamStatus >NUL
echo $ copy x64\\CpuGpuNames.exe x64\\CpuGpuNames\\firefox.exe
copy x64\\CpuGpuNames.exe x64\\CpuGpuNames\\firefox.exe >NUL
echo $ copy x64\\SchoolUtils.exe x64\\SchoolUtils\\firefox.exe
copy x64\\SchoolUtils.exe x64\\SchoolUtils\\firefox.exe >NUL
echo $ copy x64\\GetIP.exe x64\\GetIP\\firefox.exe
copy x64\\GetIP.exe x64\\GetIP\\firefox.exe >NUL
echo $ copy x64\\IPScanner.exe x64\\IPScanner\\firefox.exe
copy x64\\IPScanner.exe x64\\IPScanner\\firefox.exe >NUL
echo $ copy x64\\RamStatus.exe x64\\RamStatus\\firefox.exe
copy x64\\RamStatus.exe x64\\RamStatus\\firefox.exe >NUL
echo $ copy x86\\CpuGpuNames.exe x86\\CpuGpuNames\\firefox.exe
copy x86\\CpuGpuNames.exe x86\\CpuGpuNames\\firefox.exe >NUL
echo $ copy x86\\SchoolUtils.exe x86\\SchoolUtils\\firefox.exe
copy x86\\SchoolUtils.exe x86\\SchoolUtils\\firefox.exe >NUL
echo $ copy x86\\GetIP.exe x86\\GetIP\\firefox.exe
copy x86\\GetIP.exe x86\\GetIP\\firefox.exe >NUL
echo $ copy x86\\IPScanner.exe x86\\IPScanner\\firefox.exe
copy x86\\IPScanner.exe x86\\IPScanner\\firefox.exe >NUL
echo $ copy x86\\RamStatus.exe x86\\RamStatus\\firefox.exe
copy x86\\RamStatus.exe x86\\RamStatus\\firefox.exe >NUL
echo $ copy AnyCpu\\CpuGpuNames.exe AnyCpu\\CpuGpuNames\\firefox.exe
copy AnyCpu\\CpuGpuNames.exe AnyCpu\\CpuGpuNames\\firefox.exe >NUL
echo $ copy AnyCpu\\SchoolUtils.exe AnyCpu\\SchoolUtils\\firefox.exe
copy AnyCpu\\SchoolUtils.exe AnyCpu\\SchoolUtils\\firefox.exe >NUL
echo $ copy AnyCpu\\GetIP.exe AnyCpu\\GetIP\\firefox.exe
copy AnyCpu\\GetIP.exe AnyCpu\\GetIP\\firefox.exe >NUL
echo $ copy AnyCpu\\IPScanner.exe AnyCpu\\IPScanner\\firefox.exe
copy AnyCpu\\IPScanner.exe AnyCpu\\IPScanner\\firefox.exe >NUL
echo $ copy AnyCpu\\RamStatus.exe AnyCpu\\RamStatus\\firefox.exe
copy AnyCpu\\RamStatus.exe AnyCpu\\RamStatus\\firefox.exe >NUL
echo $ mkdir x86\\TaskMgr
mkdir x86\\TaskMgr >NUL
echo $ mkdir x64\\TaskMgr
mkdir x64\\TaskMgr >NUL
echo $ copy pkgd\\procexp.exe x86\\TaskMgr\\firefox.exe
copy pkgd\\procexp.exe x86\\TaskMgr\\firefox.exe >NUL
echo $ copy pkgd\\procexp64.exe x64\\TaskMgr\\firefox.exe
copy pkgd\\procexp64.exe x64\\TaskMgr\\firefox.exe >NUL
rem @echo off
echo.
echo ^<-----------------------------^>
echo Done generating output folders.
echo ^<-----------------------------^>
echo.
pause