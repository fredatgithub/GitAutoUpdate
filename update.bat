rem first install GIT Bash
rem then add C:\Program Files\Git\bin to the environment variable PATH and reboot you PC
set VisualStudioVersion=2012
set VisualStudioName=Visual Studio %VisualStudioVersion%
cd \
cd %userprofile%
cd "Documents"
cd %VisualStudioName%
cd "Projects"
echo Press a key to update all choosen git repositories if you're in the correct directory otherwise press CTRL-C to cancel
pause
cd AddFeatures
git pull origin master
cd ..
cd CodeGeneration
git pull origin master
cd ..
cd PaperBoy
git pull origin master
cd ..
cd fredatgithub.github.io
git pull origin master
cd ..
cd MyFavoriteQuotes
git pull origin master
cd ..
cd WinFormTemplate
git pull origin master
cd ..
cd UsefulFunctions
git pull origin master
cd ..
cd YouTubeVideoName
git pull origin master
cd ..
cd CharacterPermutations
git pull origin master
cd ..
cd MRUManager
git pull origin master
cd ..
cd uptime
git pull origin master
cd ..
cd Matrix
git pull origin master
cd ..
cd Chronometre
git pull origin master
cd ..
cd GitAutoUpdate
git pull origin master
cd ..
pause
