DEFAULT_GOAL: init

## Installs docker and docker-compose
install-docker:
	wget -qO- https://gist.githubusercontent.com/wdullaer/f1af16bd7e970389bad3/raw/23e196ac45c1f638323b66c3748bc376719fee91/install.sh | sh


## Installs dot net core
dotnetcore:
	curl https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.gpg
	sudo mv microsoft.gpg /etc/apt/trusted.gpg.d/microsoft.gpg
	sudo sh -c 'echo "deb [arch=amd64] https://packages.microsoft.com/repos/microsoft-ubuntu-xenial-prod xenial main" > /etc/apt/sources.list.d/dotnetdev.list'
	sudo apt-get install apt-transport-https
	sudo apt-get update
	sudo apt-get install dotnet-sdk-2.1.101

## Build and tag the base image
docker-base:
	docker build --pull -t domain:base ./Domain
	
## rebuild docker-compose
docker-compose-rebuild: docker-base
	docker-compose down
	docker-compose build
	
## run xunit tests on domain
docker-test:
	docker-compose run test dotnet vstest tests/Tests.dll

help: SHELL:=/bin/bash
## Prints this help
help:
	@echo -e "\nUsage: make <target>\n\nThe following targets are available:\n";
	@while IFS='' read -r line || [[ -n "$$line" ]]; \
	do \
		if [ "$$HELP_TEXT" != "" ]; \
		then \
			TARGET=`echo $$line | sed 's/\(^.*\):.*/\1/'`; \
			printf "\e[1;34m%-30s\e[m %s\n" "$$TARGET" "$$HELP_TEXT"; \
		fi; \
		HELP_TEXT=`echo $$line | sed 's/^##\(.*\)/\1/'`; \
		if [ "`echo -e $$HELP_TEXT`" == "`echo -e $$line`" ]; \
		then \
			HELP_TEXT=""; \
		fi; \
	done < $(MAKEFILE_LIST)
