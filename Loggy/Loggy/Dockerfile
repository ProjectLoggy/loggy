#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 26868
EXPOSE 44364

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["Loggy/Loggy.csproj", "Loggy/"]
RUN dotnet restore "Loggy/Loggy.csproj"
COPY . .
WORKDIR "/src/Loggy"
RUN dotnet build "Loggy.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Loggy.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Loggy.dll"]