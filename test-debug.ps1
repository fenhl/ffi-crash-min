Set-Location .\rust
cargo build
Set-Location ..\csharp
Copy-Item ..\rust\target\debug\fficrashlib.dll fficrashlib.dll
dotnet run --configuration=Release
Set-Location ..
