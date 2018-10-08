; -- installer.iss --

[Setup]
AppNAme=MEL
AppVersion=811.18
DefaultDirName={pf}\MEL
DefaultGroupName=M4V3R1CK_Digital
Compression=lzma2
SolidCompression=yes
OutputBaseFilename=MELInstaller
OutputDir=.
UninstallDisplayIcon={app}\MEL.exe
UninstallDisplayName=MEL

[Files]
Source: "..\MEL_r811_18\bin\Debug\MEL_r811_18.exe"; DestDir: "{app}"

[Icons]
Name:"{group}\MEL"; Filename: "{app}\MEL_r811_18.exe"
Name: "{group}\Uninstall"; Filename: "{uninstallexe}"
