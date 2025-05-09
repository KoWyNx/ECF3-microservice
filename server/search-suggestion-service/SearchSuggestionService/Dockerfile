FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 10000
ENV ASPNETCORE_URLS=http://+:10000

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["SearchSuggestionService.csproj", "./"]
RUN dotnet restore "SearchSuggestionService.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "SearchSuggestionService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SearchSuggestionService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SearchSuggestionService.dll"]
