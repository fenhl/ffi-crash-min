Set-Location .\rust
cargo build --release
Set-Location ..\csharp
Copy-Item ..\rust\target\release\fficrashlib.dll fficrashlib.dll
dotnet run --configuration=Release
