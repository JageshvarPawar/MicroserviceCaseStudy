#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Book/Book.csproj", "Book/"]
RUN dotnet restore "Book/Book.csproj"
COPY . .
WORKDIR "/src/Book"
RUN dotnet build "Book.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Book.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Book.dll"]