FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
#Exponer el puerto para que sea igual a las 4 últimas cifras del usuario de San Valero.
EXPOSE 80
WORKDIR /App
COPY --from=build-env /App/out .
CMD dotnet tool install --global dotnet-ef
CMD dotnet ef database update
ENTRYPOINT ["dotnet", "APIAA.dll"]