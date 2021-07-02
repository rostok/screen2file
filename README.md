# screen2file
saves clipboard bitmap data to file and copies the file path to clipboard. useful when you grab a screenshot with win+s and follow immediatley by win+r and `screen2file`

# syntax
choose your poison:
* no arguments will save bitmap as JPEG
* providing file with path will save bitmap there
* providing .jpg or .png extension will force image format
* screen2png.bat forces PNG encoder

# build
to compile use your favourite visual studio or just run `csc.exe /t:winexe screen2file.cs`

