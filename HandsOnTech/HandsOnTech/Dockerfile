FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["HandsOnTech/HandsOnTech.csproj", "HandsOnTech/"]
COPY ["HandsOnTech.DAL/HandsOnTech.DAL.csproj", "HandsOnTech.DAL/"]
COPY ["HandsOnTech.BLL/HandsOnTech.BLL.csproj", "HandsOnTech.BLL/"]
RUN dotnet restore "HandsOnTech/HandsOnTech.csproj"
COPY . .
WORKDIR "/src/HandsOnTech"
RUN dotnet build "HandsOnTech.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "HandsOnTech.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HandsOnTech.dll"]