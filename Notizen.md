

```
docker build -t webapplication:latest -f WebApplication/Dockerfile .

docker run -d -p 5000:8080 --name webapp webapplication:latest

docker exec -it webapp bash

cd ~ 
mkdir tools
cd tools

curl -L https://download-cdn.jetbrains.com/resharper/dotUltimate.2024.1/JetBrains.dotMemory.Console.linux-x64.2024.1.tar.gz -o dotMemory.Console.tar.gz
mkdir ./dotMemory
tar  -xf  dotMemory.Console.tar.gz -C ./dotMemory/
cd dotMemory

./dotmemory attach 1 --trigger-timer=5s --trigger-max-snapshots=100 --save-to-dir=~/tools/snapshots
 docker cp webapp:/home/app/tools/snapshots/ 'C:\temp\Web App\'

```
