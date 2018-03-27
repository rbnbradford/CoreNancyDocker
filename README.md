# Core Nancy Docker
Example web app using a dockerised .net core application and the Nancy framework

## Requirements
- GNU make (https://www.gnu.org/software/make/)
- docker (https://docs.docker.com/engine/installation/)
- docker-compose (compose https://docs.docker.com/compose/install/)

##for local development 
- dotnet core (https://www.microsoft.com/net/learn/get-started/linuxubuntu)

## Install docker and docker compose
```
wget -qO- https://gist.githubusercontent.com/wdullaer/f1af16bd7e970389bad3/raw/23e196ac45c1f638323b66c3748bc376719fee91/install.sh | sh
```
or: `make install-docker`

## Install dotnet core
`make dotnetcore`

## To run docker without sudo
```
sudo groupadd docker; sudo gpasswd -a $USER docker; newgrp docker
```