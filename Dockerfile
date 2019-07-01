#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["vMt2.Web/vMt2.Web.csproj", "vMt2.Web/"]
RUN dotnet restore "vMt2.Web/vMt2.Web.csproj"
COPY . .
WORKDIR "/src/vMt2.Web"
RUN dotnet build "vMt2.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "vMt2.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "vMt2.Web.dll"]