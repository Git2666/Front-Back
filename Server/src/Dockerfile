# 1️⃣ Build stage
FROM bitnami/dotnet-sdk:8 AS build

WORKDIR /app

# 拷贝项目文件并还原依赖
COPY *.csproj ./
RUN dotnet restore

# 拷贝所有源码并编译
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# 2️⃣ Runtime stage
FROM bitnami/aspnet-core:8

WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Server.dll"]