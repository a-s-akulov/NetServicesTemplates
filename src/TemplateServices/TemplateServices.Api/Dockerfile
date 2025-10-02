FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk add --no-cache icu-libs tzdata
USER app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NuGet.config", "NuGet.config"]
COPY ["$safeprojectname$/$safeprojectname$.csproj", "$safeprojectname$/"]
COPY ["$ext_safeprojectname$Services.Common/$ext_safeprojectname$Services.Common.csproj", "$ext_safeprojectname$Services.Common/"]
COPY ["$ext_safeprojectname$Services.Db/$ext_safeprojectname$Services.Db.csproj", "$ext_safeprojectname$Services.Db/"]
RUN dotnet restore "./$safeprojectname$/$safeprojectname$.csproj"
COPY . .
WORKDIR "/src/$safeprojectname$"
RUN dotnet build "./$safeprojectname$.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./$safeprojectname$.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "$safeprojectname$.dll"]