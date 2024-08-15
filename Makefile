.DEFAULT_GOAL :=
   watch:
	   dotnet watch run --project ./src/PromptStorage/

   run:
	   dotnet run --project ./src/PromptStorage/

   build:
	   dotnet build ./src/PromptStorage/

   test:
	   dotnet test ./tests/PromptStorage.Tests/
