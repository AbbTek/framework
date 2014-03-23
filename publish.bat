del *.nupkg
.\.nuget\NuGet.exe pack Simplelabs.Framework\Simplelabs.Framework.csproj -IncludeReferencedProjects -Prop Configuration=Release -Symbols 
.\.nuget\NuGet.exe SetApiKey 315994b9-e162-4208-93e5-59b715f16ebc

for %%f in (*.nupkg) do .\.nuget\NuGet.exe push %%f