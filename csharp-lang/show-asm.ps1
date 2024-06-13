# https://www.meziantou.net/how-to-get-assembly-code-generated-by-the-jit-for-a-csharp-method.htm#using-the-dotnet-jit
# https://sharplab.io/
$env:DOTNET_JitDisasm="Program:ProfileMe"
$env:DOTNET_TieredCompilation="0"
dotnet run -c release
