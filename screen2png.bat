::@echo off
set o=image%DATE%-%TIME::=-%
set o=%o: =0%
set o=%o:~0,-3%.png
echo [%o%]
screen2file %temp%\%o%