# To check if Makefile has correct syntax (all must be tabs (^I), no spaces)
# cat -e -t -v Makefile

default: docker-test

.PHONY: test
test:
	dotnet test test

.PHONY: docker-test
docker-test:
	docker run --rm -v ${PWD}/UserRegistration:/code -w /code mcr.microsoft.com/dotnet/sdk:3.1-alpine dotnet test
