FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# build runtime image


FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/out .

RUN addgroup sentience
RUN adduser --system sentience
RUN adduser sentience sentience
USER sentience

ENTRYPOINT ["dotnet", "aspnetapp.dll"]

EXPOSE 80
