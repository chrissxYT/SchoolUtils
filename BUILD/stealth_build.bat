@echo off
echo.
echo ^<----------^>
echo Cleaning up.
echo ^<----------^>
echo.
echo $ rm -r x64
rmdir /S /Q x64 >NUL
echo $ mkdir x64
mkdir x64 >NUL
echo $ rm -r stealth
rmdir /S /Q stealth >NUL
echo $ mkdir stealth
mkdir stealth >NUL
echo.
echo ^<---------^>
echo Cleaned up.
echo ^<---------^>
echo.
echo ^<-----------------^>
echo Starting x64 Build.
echo ^<-----------------^>
echo.
echo $ msbuild /m /p:Configuration=Release /p:Platform=x64 ..\SchoolUtils.sln
"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe" /m /p:Configuration=Release /p:Platform=x64 ..\SchoolUtils.sln >NUL
echo.
echo ^<----------------^>
echo Done building x64.
echo ^<----------------^>
echo.
echo ^<-----------------------^>
echo Generating output folder.
echo ^<-----------------------^>
echo.
echo $ cp x64\\Stealth.exe stealth\\firefox.exe
copy x64\\Stealth.exe stealth\\firefox.exe >NUL
echo $ mkdir stealth\\CpuGpuNames
mkdir stealth\\CpuGpuNames >NUL
echo $ cp x64\\CpuGpuNames.exe stealth\\CpuGpuNames\\firefox.exe
copy x64\\CpuGpuNames.exe stealth\\CpuGpuNames\\firefox.exe >NUL
echo $ mkdir stealth\\SchoolUtils
mkdir stealth\\SchoolUtils >NUL
echo $ cp x64\\SchoolUtils.exe stealth\\SchoolUtils\\firefox.exe
copy x64\\SchoolUtils.exe stealth\\SchoolUtils\\firefox.exe >NUL
echo $ mkdir stealth\\GetIP
mkdir stealth\\GetIP >NUL
echo $ cp x64\\GetIP.exe stealth\\GetIP\\firefox.exe
copy x64\\GetIP.exe stealth\\GetIP\\firefox.exe >NUL
echo $ mkdir stealth\\IPScanner
mkdir stealth\\IPScanner >NUL
echo $ cp x64\\IPScanner.exe stealth\\IPScanner\\firefox.exe
copy x64\\IPScanner.exe stealth\\IPScanner\\firefox.exe >NUL
echo $ mkdir stealth\\RamStatus
mkdir stealth\\RamStatus >NUL
echo $ cp x64\\RamStatus.exe stealth\\RamStatus\\firefox.exe
copy x64\\RamStatus.exe stealth\\RamStatus\\firefox.exe >NUL
echo $ mkdir stealth\\ListPrinters
mkdir stealth\\ListPrinters >NUL
echo $ cp x64\\ListPrinters.exe stealth\\ListPrinters\\firefox.exe
copy x64\\ListPrinters.exe stealth\\ListPrinters\\firefox.exe >NUL
echo $ mkdir stealth\\GetDotNetVersion
mkdir stealth\\GetDotNetVersion >NUL
echo $ cp x64\\GetDotNetVersion.exe stealth\\GetDotNetVersion\\firefox.exe
copy x64\\GetDotNetVersion.exe stealth\\GetDotNetVersion\\firefox.exe >NUL
echo.
echo ^< ---------------------^>
echo Generated output folder.
echo ^< ---------------------^>
echo.
pause
