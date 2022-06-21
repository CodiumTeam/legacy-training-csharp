# To check if Makefile has correct syntax (all must be tabs (^I), no spaces)
# cat -e -t -v Makefile

default: docker-run

.PHONY: run
run:
	dotnet run --project src/WebPageGenerator
	@printf "Open html/users.html\n"


.PHONY: docker-run
docker-run:
	docker run --rm -v ${PWD}:/code -w /code mcr.microsoft.com/dotnet/sdk:6.0-alpine dotnet run --project src/WebPageGenerator
	@printf "Open html/users.html\n"