#!/bin/bash
rm -r libsrd5.tests/TestResults
dotnet test libsrd5.tests/libsrd5.tests.csproj -r TestResults --collect:"XPlat Code Coverage"
reportgenerator -reports:"libsrd5.tests/TestResults/*/coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html


