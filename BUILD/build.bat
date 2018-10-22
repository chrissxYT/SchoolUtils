@echo off
echo.
echo ^<----------^>
echo Cleaning up.
echo ^<----------^>
echo.
echo $ rmdir /S /Q x64
rmdir /S /Q x64 >NUL
echo $ mkdir x64
mkdir x64 >NUL
echo $ rmdir /S /Q stealth
rmdir /S /Q stealth >NUL
echo $ mkdir stealth
mkdir stealth >NUL
echo $ rmdir /S /Q su
rmdir /S /Q su >NUL
echo $ mkdir su
mkdir su >NUL
echo.
echo ^<---------^>
echo Cleaned up.
echo ^<---------^>
echo.
echo ^<-----------------^>
echo Starting x64 Build.
echo ^<-----------------^>
echo.
echo $ "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe" /m /p:Configuration=Release /p:Platform=x64 ..\SchoolUtils.sln
"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe" /m /p:Configuration=Release /p:Platform=x64 ..\SchoolUtils.sln >NUL
echo.
echo ^<----------------^>
echo Done building x64.
echo ^<----------------^>
echo.
echo ^<---------------------------------^>
echo Starting generating output folders.
echo ^<---------------------------------^>
echo.
echo $ mkdir su\\CpuGpuNames
mkdir su\\CpuGpuNames >NUL
echo $ copy x64\\CpuGpuNames.exe su\\CpuGpuNames\\firefox.exe
copy x64\\CpuGpuNames.exe su\\CpuGpuNames\\firefox.exe >NUL
echo $ mkdir su\\SchoolUtils
mkdir su\\SchoolUtils >NUL
echo $ copy x64\\SchoolUtils.exe su\\SchoolUtils\\firefox.exe
copy x64\\SchoolUtils.exe su\\SchoolUtils\\firefox.exe >NUL
echo $ mkdir su\\GetIP
mkdir su\\GetIP >NUL
echo $ copy x64\\GetIP.exe su\\GetIP\\firefox.exe
copy x64\\GetIP.exe su\\GetIP\\firefox.exe >NUL
echo $ mkdir su\\IPScanner
mkdir su\\IPScanner >NUL
echo $ copy x64\\IPScanner.exe su\\IPScanner\\firefox.exe
copy x64\\IPScanner.exe su\\IPScanner\\firefox.exe >NUL
echo $ mkdir su\\RamStatus
mkdir su\\RamStatus >NUL
echo $ copy x64\\RamStatus.exe su\\RamStatus\\firefox.exe
copy x64\\RamStatus.exe su\\RamStatus\\firefox.exe >NUL
echo $ mkdir su\\ListPrinters
mkdir su\\ListPrinters >NUL
echo $ copy x64\\ListPrinters.exe su\\ListPrinters\\firefox.exe
copy x64\\ListPrinters.exe su\\ListPrinters\\firefox.exe >NUL
echo $ mkdir su\\GetDotNetVersion
mkdir su\\GetDotNetVersion >NUL
echo $ copy x64\\GetDotNetVersion.exe su\\GetDotNetVersion\\firefox.exe
copy x64\\GetDotNetVersion.exe su\\GetDotNetVersion\\firefox.exe >NUL
echo $ mkdir su\\EmergencyTextPrinter
mkdir su\\EmergencyTextPrinter >NUL
echo $ copy x64\\EmergencyTextPrinter.exe su\\EmergencyTextPrinter\\firefox.exe
copy x64\\EmergencyTextPrinter.exe su\\EmergencyTextPrinter\\firefox.exe >NUL
echo $ mkdir su\\SilentDirCopy
mkdir su\\SilentDirCopy >NUL
echo $ copy x64\\SilentDirCopy.exe su\\SilentDirCopy\\firefox.exe
copy x64\\SilentDirCopy.exe su\\SilentDirCopy\\firefox.exe >NUL
echo $ mkdir su\\procexp64
mkdir su\\procexp64 >NUL
echo $ copy pkgd\\procexp64.exe su\\procexp64\\firefox.exe
copy pkgd\\procexp64.exe su\\procexp64\\firefox.exe >NUL
echo.
echo ^<-----------------------------^>
echo Done generating output folders.
echo ^<-----------------------------^>
echo.
echo ^<-------------------------------------^>
echo Running stealth build dedicated script.
echo ^<-------------------------------------^>
echo.
call stealth_build.bat
echo.
echo ^<----------------^>
echo Ran stealth build.
echo ^<----------------^>
