Name "ScreenshareHelper"
Caption "ScreenshareHelper Installation"
Icon "${NSISDIR}\Contrib\Graphics\Icons\nsis1-install.ico"
OutFile "ScreenshareHelperInstaller.exe"

InstallDir "$LOCALAPPDATA\ScreenshareHelper"
InstallDirRegKey HKCU "Software\ScreenshareHelper" "Install_Dir"

RequestExecutionLevel user

Unicode true

;--------------------------------
;Interface Settings
  !include "MUI2.nsh"
  !define MUI_ABORTWARNING

;--------------------------------
;Pages

  !insertmacro MUI_PAGE_LICENSE "./LICENSE"
  !insertmacro MUI_PAGE_DIRECTORY
  !insertmacro MUI_PAGE_INSTFILES
  
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES
  
;--------------------------------
;Languages
 
  !insertmacro MUI_LANGUAGE "English"

;--------------------------------
;Installer Sections

Section "Dummy Section" SecDummy

  SetOutPath "$INSTDIR"
  
  ;ADD YOUR OWN FILES HERE...
  File "/oname=ScreenshareHelper.exe" ".\src\ScreenshareHelper\bin\Release\ScreenshareHelper.exe"
  File "/oname=ScreenshareHelper.dll" ".\src\ScreenshareHelper\bin\Release\ScreenshareHelper.dll"
  File "/oname=CommandLine.dll" ".\src\ScreenshareHelper\bin\Release\CommandLine.dll"
  File "/oname=ScreenshareHelper.runtimeconfig.json" ".\src\ScreenshareHelper\bin\Release\ScreenshareHelper.runtimeconfig.json"
  createShortCut "$SMPROGRAMS\ScreenshareHelper.lnk" "$INSTDIR\ScreenshareHelper.exe"
  
  ;Store installation folder
  WriteRegStr HKCU "Software\ScreenshareHelper" "" $INSTDIR
  ;For control panel uninstall
  WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\ScreenshareHelper" \
                 "DisplayName" "ScreenshareHelper"
  WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\ScreenshareHelper" \
                 "UninstallString" "$\"$INSTDIR\uninstall.exe$\""
  
  ;Create uninstaller
  WriteUninstaller "$INSTDIR\Uninstall.exe"

SectionEnd

;--------------------------------
;Uninstaller Section

Section "Uninstall"

  ;ADD YOUR OWN FILES HERE...

  Delete "$INSTDIR\Uninstall.exe"
  Delete "$INSTDIR\ScreenshareHelper.exe"
  Delete "$INSTDIR\ScreenshareHelper.dll"
  Delete "$INSTDIR\CommandLine.dll"
  Delete "$INSTDIR\ScreenshareHelper.runtimeconfig.json"
  Delete "$SMPROGRAMS\ScreenshareHelper.lnk"

  ; todo: remove user.conf file(s) after asking user
  RMDir "$INSTDIR"

  DeleteRegKey /ifempty HKCU "Software\ScreenshareHelper"
  DeleteRegKey HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\ScreenshareHelper"

SectionEnd