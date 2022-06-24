# To check if Makefile has correct syntax (all must be tabs (^I), no spaces)
# cat -e -t -v Makefile

default: docker-run

.PHONY: run
run:
	dotnet run --project src/WebPageGenerator
	@printf "Open html/users.html\n"

.PHONY: docker-build
docker-build:
	docker build -f ../Dockerfile -t codiumteam/legacy-training-csharp:webpagegenerator .

.PHONY: docker-run
docker-run:
	docker run --rm -v ${PWD}:/code codiumteam/legacy-training-csharp:webpagegenerator make run
