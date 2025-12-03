# См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки и как Visual Studio использует этот Dockerfile для создания образов для ускорения отладки.

# Этот этап используется при запуске из VS в быстром режиме (по умолчанию для конфигурации отладки)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Этот этап используется для сборки проекта службы
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/backend/services/NotificationService/Directory.Packages.props", "src/backend/services/NotificationService/"]
COPY ["src/backend/services/NotificationService/Notification/NotificationService.csproj", "src/backend/services/NotificationService/Notification/"]
COPY ["src/backend/services/NotificationService/Notification.Application/NotificationService.Application.csproj", "src/backend/services/NotificationService/Notification.Application/"]
COPY ["src/backend/services/NotificationService/Notification.Domain/NotificationService.Domain.csproj", "src/backend/services/NotificationService/Notification.Domain/"]
COPY ["src/backend/services/NotificationService/Notification.Infrastructure/NotificationService.Infrastructure.csproj", "src/backend/services/NotificationService/Notification.Infrastructure/"]
#COPY ["src/backend/services/NotificationService/Notification.ServiceDefaults/NotificationService.ServiceDefaults.csproj", "src/backend/services/NotificationService/Notification.ServiceDefaults/"]
RUN dotnet restore "./src/backend/services/NotificationService/Notification/NotificationService.csproj"
COPY . .
WORKDIR "/src/src/backend/services/NotificationService/Notification"
RUN dotnet build "./NotificationService.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Этот этап используется для публикации проекта службы, который будет скопирован на последний этап
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NotificationService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Этот этап используется в рабочей среде или при запуске из VS в обычном режиме (по умолчанию, когда конфигурация отладки не используется)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NotificationService.dll"]