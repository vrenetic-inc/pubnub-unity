#! /bin/sh

# Downloads
echo 'Downloading Unity-2017.2 pkg:'
curl --retry 5 -o Unity.pkg https://netstorage.unity3d.com/unity/46dda1414e51/MacEditorInstaller/Unity-2017.2.0f3.pkg
if [ $? -ne 0 ]; then { echo "Unity Download failed"; exit $?; } fi

echo 'Downloading iOS build support:'
curl --retry 5 -o Unity_iOS.pkg https://beta.unity3d.com/download/46dda1414e51/MacEditorTargetInstaller/UnitySetup-iOS-Support-for-Editor-2017.2.0f3.pkg
if [ $? -ne 0 ]; then { echo "iOS Download failed"; exit $?; } fi

echo 'Downloading Android build support:'
curl --retry 5 -o Unity_Android.pkg https://beta.unity3d.com/download/46dda1414e51/MacEditorTargetInstaller/UnitySetup-Android-Support-for-Editor-2017.2.0f3.pkg
if [ $? -ne 0 ]; then { echo "Download failed"; exit $?; } fi

echo 'Downloading WebGL build support:'
curl --retry 5 -o Unity_WebGL.pkg https://beta.unity3d.com/download/46dda1414e51/MacEditorTargetInstaller/UnitySetup-WebGL-Support-for-Editor-2017.2.0f3.pkg
if [ $? -ne 0 ]; then { echo "Download failed"; exit $?; } fi

echo 'Downloading Windows build support:'
curl --retry 5 -o Unity_Win.pkg https://beta.unity3d.com/download/46dda1414e51/MacEditorTargetInstaller/UnitySetup-Windows-Support-for-Editor-2017.2.0f3.pkg
if [ $? -ne 0 ]; then { echo "Download failed"; exit $?; } fi

echo 'Downloading Linux build support:'
curl --retry 5 -o Unity_Linux.pkg https://beta.unity3d.com/download/46dda1414e51/MacEditorTargetInstaller/UnitySetup-Linux-Support-for-Editor-2017.2.0f3.pkg
if [ $? -ne 0 ]; then { echo "Download failed"; exit $?; } fi

# Install
echo 'Installing Unity.pkg'
sudo installer -dumplog -package Unity.pkg -target /
echo 'Installing Unity_win.pkg'
sudo installer -dumplog -package Unity_iOS.pkg -target /
echo 'Installing Unity_win.pkg'
sudo installer -dumplog -package Unity_Android.pkg -target /
echo 'Installing Unity_win.pkg'
sudo installer -dumplog -package Unity_WebGL.pkg -target /
echo 'Installing Unity_win.pkg'
sudo installer -dumplog -package Unity_Win.pkg -target /
echo 'Installing Unity_win.pkg'
sudo installer -dumplog -package Unity_Linux.pkg -target /
