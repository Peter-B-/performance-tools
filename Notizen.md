

```
docker build -t webapplication:latest -f WebApplication/Dockerfile .

docker run -d -p 5000:8080 --name webapp webapplication:latest

docker exec -it webapp sh

cd ~ 
mkdir tools
cd tools

curl -L https://aka.ms/dotnet-counters/linux-x64 -o dotnet-counters
chmod +x dotnet-counters

```