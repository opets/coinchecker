echo off
echo remove [obj] and [bin]

FOR /F "tokens=*" %%G IN ('DIR /B /AD /S bin') DO RMDIR /S /Q "%%G"
FOR /F "tokens=*" %%G IN ('DIR /B /AD /S obj') DO RMDIR /S /Q "%%G"
FOR /F "tokens=*" %%G IN ('DIR /B /AD /S .vs') DO RMDIR /S /Q "%%G"

echo cleanup Publish and Tests
rmdir /s /q Publish
rmdir /s /q Tests
