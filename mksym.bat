cd /d %~dp0

rmdir "Assets\Plugins\UniRx\Scripts"
mklink /D "Assets\Plugins\UniRx\Scripts" "submodules\UniRx\Assets\Plugins\UniRx\Scripts"

