mkdir %UserProfile%\Documents\Corderoski\AnimeKakkoi
Call Install.bat
cd %UserProfile%\Documents\Corderoski\AnimeKakkoi
if exist ak_data.b (
ren *.ak *.akm
ren *.b *.bin
echo '' > usr-h.log
) else (
 del *.ak
 del *.b
)

