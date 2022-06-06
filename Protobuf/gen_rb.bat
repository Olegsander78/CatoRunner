@echo off

rem del /S /Q ..\Assets\Scripts\

call .\protobuf-net\ProtoGen\protogen.exe -i:profile.proto -o:ProtoClasses\Profile.cs 
call .\protobuf-net\ProtoGen\protogen.exe -i:common.proto -o:ProtoClasses\Common.cs 

pause

"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe" ProtoClasses/ProtoClasses.sln /p:Configuration=Release 

pause
call protobuf-net\Precompile\precompile.exe ProtoClasses\bin\Release\ProtoClasses.dll -o:ProtoClasses\bin\Release\ProtoSerializer.dll -t:ProtoSerializer 

pause
call copy ProtoClasses\bin\Release\ProtoClasses.dll     .\proto_lib
call copy ProtoClasses\bin\Release\protobuf-net.dll     .\proto_lib
call copy ProtoClasses\bin\Release\ProtoSerializer.dll  .\proto_lib

call copy ProtoClasses\bin\Release\ProtoClasses.dll     ..\Assets\Scripts\
call copy ProtoClasses\bin\Release\protobuf-net.dll     ..\Assets\Scripts\
call copy ProtoClasses\bin\Release\ProtoSerializer.dll  ..\Assets\Scripts\