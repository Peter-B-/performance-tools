

```
docker build -t webapplication:latest -f WebApplication/Dockerfile .

docker run -d -p 5000:8080 --name webapp webapplication:latest

docker exec -it webapp bash

cd ~ 
mkdir tools
cd tools

curl -L https://aka.ms/dotnet-counters/linux-x64 -o dotnet-counters
chmod +x dotnet-counters
./dotnet-counters monitor --process-id 1

curl -L https://download.jetbrains.com/resharper/dotUltimate.2023.3.4/JetBrains.dotMemory.Console.linux-x64.2023.3.4.tar.gz -o JetBrains.dotMemory.Console.linux-x64.2023.3.4.tar.gz
mkdir ./dotMemory
tar  -xf  JetBrains.dotMemory.Console.linux-x64.2023.3.4.tar.gz -C ./dotMemory
cd dotMemory

./dotmemory attach 1 --trigger-timer=5s --trigger-max-snapshots=100 --save-to-dir=~/tools/snapshots
 docker cp webapp:/home/app/tools/snapshots/ 'D:\temp\Web App\'


curl -L https://aka.ms/dotnet-dump/linux-x64 -o dotnet-dump
chmod +x dotnet-dump
./dotnet-dump collect --process-id 1 -o dump1

docker cp 5f533fa1ecc8:/home/app/tools/dump2 'D:\temp\Web App\dump2'

```

## Siege docker

```
docker run --rm -it siege:latest bash

siege -c 5 -t10s http://host.docker.internal:5065/leak
```