# To check if Makefile has correct syntax (all must be tabs (^I), no spaces)
# cat -e -t -v Makefile

default: docker-test

.PHONY: test
test:
	dotnet test test/UserRegistrationTests

.PHONY: coverage
coverage:
	dotnet test ./test/UserRegistrationTests /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput='./TestResults/'

.PHONY: docker-build
docker-build:
	docker build -f ../Dockerfile -t codiumteam/legacy-training-csharp:userregistration .

.PHONY: docker-test
docker-test:
	docker run --user $$(id -u) -e DOTNET_CLI_HOME=/tmp/.vscode --rm -v ${PWD}:/code codiumteam/legacy-training-csharp:userregistration make test

.PHONY: docker-coverage
docker-coverage:
	docker run --user $$(id -u) -e DOTNET_CLI_HOME=/tmp/.vscode --rm -v ${PWD}:/code codiumteam/legacy-training-csharp:userregistration make coverage
