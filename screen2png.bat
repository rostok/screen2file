@echo off
set o=image%DATE%-%TIME::=-%
set o=%o:~0,-3%.png
screen2file %temp%\%o%