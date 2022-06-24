# To check if Makefile has correct syntax (all must be tabs (^I), no spaces)
# cat -e -t -v Makefile

default: docker-test

.PHONY: test
test:
	dotnet test test

.PHONY: coverage
coverage:
	dotnet test test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput='./TestResults/'
	dotnet reportgenerator -reports:test/TestResults/coverage.cobertura.xml -targetdir:test/TestResults/html
	@printf "\nOpen test/TestResults/html/index.html\n"


.PHONY: mutation
mutation:
	dotnet stryker -tp test

.PHONY: docker-build
docker-build:
	docker build -t codiumteam/legacy-training-csharp:gilded-rose-characterization .

.PHONY: docker-test
docker-test:
	docker run --rm -v ${PWD}:/code -w /code codiumteam/legacy-training-csharp:gilded-rose-characterization make test

.PHONY: docker-coverage
docker-coverage:
	docker run --rm -v ${PWD}:/code -w /code codiumteam/legacy-training-csharp:gilded-rose-characterization make coverage

.PHONY: docker-mutation
docker-mutation:
	docker run --rm -v ${PWD}:/code -w /code codiumteam/legacy-training-csharp:gilded-rose-characterization make mutation