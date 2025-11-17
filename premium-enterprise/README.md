# Premium Calculator (Enterprise) - ASP.NET Core MVC + API + Repository

## What this contains
- MVC UI: `Controllers/PremiumController` + `Views/Premium/Index.cshtml`
- API endpoint: `POST /api/premium/calculate` (implemented using service layer)
- Service layer: `IPremiumService` + `PremiumService`
- Repository layer: `IOccupationRepository` + `InMemoryOccupationRepository`
- Strategy pattern: `IRatingStrategy` + `RatingStrategyFactory`
- Unit tests: xUnit project `PremiumCalculator.Tests`
- Input validation and exception handling included

## How to run locally (requires .NET SDK)
1. Extract the archive
2. From `src/PremiumCalculator` run:
   ```bash
   dotnet run
   ```
3. Browse to `http://localhost:5000` (or as printed)

## API
- `POST /api/premium/calculate` with body:
  ```json
  {
    "name":"John",
    "age":30,
    "dateOfBirth":"01/1990",
    "occupation":"Doctor",
    "deathSumInsured":100000
  }
  ```

## Commit History (sequential - for your Git commits)
01 - Initialize solution + project skeleton
02 - Add domain models (MemberInput, PremiumResult)
03 - Add InMemoryOccupationRepository and repository interfaces
04 - Add Strategy pattern and RatingStrategyFactory
05 - Implement PremiumService (business logic)
06 - Add MVC controller and views
07 - Add API controller (POST /api/premium/calculate)
08 - Add client JS to call API and recalc on occupation change
09 - Add xUnit tests for PremiumService
10 - Add README, CSS, and final polish
