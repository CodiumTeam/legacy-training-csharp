# To check if Makefile has correct syntax (all must be tabs (^I), no spaces)
# cat -e -t -v Makefile

default: docker-run


.PHONY: run
run:
	dotnet run --project src/GildedRose

.PHONY: test
test:
	dotnet test test

.PHONY: docker-build
docker-build:
	docker build -f ../Dockerfile -t codiumteam/legacy-training-csharp:gilded-rose-golden-master .

.PHONY: docker-run
docker-run:
	docker run --rm -v ${PWD}:/code codiumteam/legacy-training-csharp:gilded-rose-golden-master make run

.PHONY: docker-test
docker-test:
	docker run --rm -v ${PWD}:/code -w /code codiumteam/legacy-training-csharp:gilded-rose-golden-master make test
