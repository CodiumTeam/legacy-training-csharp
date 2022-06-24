# To check if Makefile has correct syntax (all must be tabs (^I), no spaces)
# cat -e -t -v Makefile

default: docker-test

.PHONY: test
test:
	dotnet test test/UserRegistrationTests

.PHONY: coverage
coverage:
	dotnet test ./test/UserRegistrationTests /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput='./TestResults/'

.PHONY: docker-test
docker-test:
	docker run --user $$(id -u) -e DOTNET_CLI_HOME=/tmp/.vscode --rm -v ${PWD}:/code -w /code mcr.microsoft.com/dotnet/sdk:6.0-alpine dotnet test test/UserRegistrationTests

.PHONY: docker-coverage
docker-coverage:
	docker run --user $$(id -u) -e DOTNET_CLI_HOME=/tmp/.vscode --rm -v ${PWD}:/code -w /code mcr.microsoft.com/dotnet/sdk:6.0-alpine dotnet test ./test/UserRegistrationTests /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput='./TestResults/'
