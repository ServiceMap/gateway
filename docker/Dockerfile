FROM mcr.microsoft.com/dotnet/sdk:9.0 AS dev

# Set working directory
WORKDIR /app

# Copy everything from the gateway directory
COPY . .

# Install required tools (e.g. EF migrations, hot reload, etc.)
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

# Restore packages (find the csproj automatically)
RUN dotnet restore

# Expose ports for ASP.NET + Hot Reload
EXPOSE 8085
EXPOSE 443

# By default, start in watch mode (for dev)
# Explicitly find and specify the csproj file
ENTRYPOINT ["sh", "-c", "dotnet watch run --project $(find . -name '*.csproj' | head -n 1) --urls http://0.0.0.0:8085"]