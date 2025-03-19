# The Access Group coding test

**Candidate**: Shamsul Amry Mokhtar

## How to run
1. Clone the repository.
2. In the terminal, navigate to the root of the repository.
3. Run `cd AccessGroupCodingTest`.
4. Set the environment variable `AccessGroup__BaseUrl` to the base URL used for actual testing e.g. `https://actual-test.dev.access-aps.com`, or you may also change the `AccessGroup:BaseUrl` value in the `appsettings.json` file.
4. Run `dotnet run` (the solution was developed on .NET 9).

## Endpoints
- Test 1: `GET http://localhost:9999/`
- Test 2: `POST http://localhost:9999/test2`

## What I may have done if I had more time
- Add more unit tests
- Add integration tests
- Test multi-culture support for text search
- Implement leetcode-style performance optimizations

## IDE
JetBrains Rider + GitHub Copilot (autocompletion)