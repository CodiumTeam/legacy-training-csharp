# To check if Makefile has correct syntax (all must be tabs (^I), no spaces)
# cat -e -t -v Makefile

default: docker-run


.PHONY: run
run:
	dotnet run --project src/Trivia

.PHONY: test
test:
	dotnet test test


.PHONY: docker-run
docker-run:
	docker run --rm -v ${PWD}:/code -w /code mcr.microsoft.com/dotnet/sdk:6.0-alpine dotnet run --project src/Trivia

.PHONY: docker-test
docker-test:
	docker run --rm -v ${PWD}:/code -w /code mcr.microsoft.com/dotnet/sdk:6.0-alpine dotnet test test
