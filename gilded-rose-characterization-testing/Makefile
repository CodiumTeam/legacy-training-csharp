# To check if Makefile has correct syntax (all must be tabs (^I), no spaces)
# cat -e -t -v Makefile

default: docker-test

.PHONY: test
test:
	dotnet test test


.PHONY: mutation
mutation:
	dotnet stryker -tp test

.PHONY: docker-build
docker-build:
	docker build -t codiumteam/legacy-training-csharp:gilded-rose-characterization .

.PHONY: docker-test
docker-test:
	docker run --rm -v ${PWD}:/code -w /code mcr.microsoft.com/dotnet/sdk:6.0-alpine dotnet test test

.PHONY: docker-mutation
docker-mutation:
	docker run --rm -v ${PWD}:/code -w /code codiumteam/legacy-training-csharp:gilded-rose-characterization dotnet stryker -tp test