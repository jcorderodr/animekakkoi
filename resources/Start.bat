mkdir %AppData%\BluegleTek\AnimeKakkoi
Call Install.bat
cd %AppData%\BluegleTek\AnimeKakkoi
if exist ak_data.b (
ren *.ak *.akm
ren *.b *.bin
echo '' > usr-h.log
) else (
 del *.ak
 del *.b
)

