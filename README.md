ProgramLauncher
===============

A Windows program that launches multiple others in succession

================TYPICAL USE====================

1. Drag ProgramLauncher.exe to the directory of the application you want to replace. (Eg. MPC-HC.exe)
2. Rename the program you want to replace to "filename_orig.exe" (without quotes). (Eg. MPC-HC_orig.exe)
3. Start ProgramLauncher while holding CTRL (or just double click if there is no ProgLaunch_Config in the same directory)
4. Click the "Browse" button and specify the .exe file you just renamed.
5. Click the "+" button in the top right hand corner of the window and a new section for an addition program will be added.
6. Specify a new .exe file to run at the same time as the original .exe. (Eg. SVP.exe)
(optional) 7. Repeat steps 5-6 as many times as necessary.
8. Close and Save all changes made to ProgramLauncher.
9. Rename ProgramLauncher.exe to the name of the original renamed program (Eg. ProgramLauncher => MPC-HC.exe)
10. Double click on the renamed ProgramLauncher and all the specified programs will open!

Note: When the initial application is closed, all the other opened programs will also close.

====================HELP=======================

1. On First startup (if there is no ProgLaunch_Config.xml file), ProgramLauncher will open directly to the settings 
2. To enter ProgramLauncher settings, hold CTRL as you start the program.
3. To be able to specify more than one application to launch at once, click the + button in the top right.
4. ProgramLauncher also passes arguments through to the "Replaced Program" (Eg. vlc.exe "C:\Videos\sample.mp4")
5. ProgramLauncher IS COMPATIBILE with Steam and the Steam overlay
6. You can specify arguments for any program to be always passed to the application being launched.
