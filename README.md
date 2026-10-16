# Database-Driven Localization for Syncfusion Blazor Scheduler in a Blazor Server Application

## Overview

This sample demonstrates how to perform localization using a database instead of traditional RESX resource files in a Blazor Server application. The application retrieves localized text values from a SQL Server database through Entity Framework Core and provides those translations to Syncfusion components using a custom localization provider.

The sample uses Syncfusion [Blazor Scheduler](https://www.syncfusion.com/scheduler-sdk/blazor-scheduler) the primary scenario. By storing translations in a database, applications can update and manage multilingual content dynamically without requiring resource file modifications, recompilation, or redeployment.

## Key Features

- Uses the Syncfusion Blazor Schedule component to demonstrate localized Syncfusion UI text.
- Implements a custom `ISyncfusionStringLocalizer` service through the `SyncfusionLocalizer` class.
- Retrieves localized strings from a SQL Server database using Entity Framework Core instead of `.resx` resource files.
- Uses the `SyncLocalizationContext` DbContext to access localization records stored in the `Table` database table.
- Resolves localized values dynamically through the `GetText(string key)` method based on `CultureInfo.CurrentCulture`.
- Supports multiple cultures, including English (`en-US`) and German (`de`).
- Configures application-wide localization using `RequestLocalizationOptions`.
- Registers supported cultures through `SupportedCultures` and `SupportedUICultures`.
- Sets the default application culture to `en-US`.
- Persists the selected culture using ASP.NET Core localization cookies via `CookieRequestCultureProvider`.
- Uses the `CultureController.SetCulture()` action to update the current culture and redirect users back to the originating page.
- Provides a reusable `CultureSwitcher` Razor component that allows users to switch languages at runtime.
- Integrates localization services and Syncfusion services through dependency injection in `Program.cs`.
- Demonstrates culture-specific property mapping (`EnUs` and `De`) to retrieve translated values directly from database records.
- Uses SQL Server connectivity configured through `UseSqlServer()` and an application connection string.

## Prerequisites

- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/)
- [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet) compatible with the project's target framework (.NET 7.0)
- SQL Server instance with access to the localization database

## How to Run the Project

**Visual Studio 2022**

1. Clone or download this repository.
2. Open `BlazorServerWithLocalization.sln`.
3. Restore all NuGet packages.
4. Verify and update the SQL Server connection string in `appsettings.json`.
5. Ensure the required localization tables and translation records exist in the database.
6. Build the solution.
7. Run the application using `Ctrl+F5`.

**Visual Studio Code**

1. Open the repository folder in Visual Studio Code.
2. Navigate to the project directory.

```bash
dotnet restore
dotnet run
```

3. Ensure the configured SQL Server database is accessible before launching the application.

## Project Structure

`BlazorServerWithLocalization.sln` - Visual Studio solution file for the sample application.

`BlazorServerWithLocalization.csproj` - Project file targeting .NET 7 and referencing Syncfusion Blazor and Entity Framework Core packages.

`Program.cs` - Configures Entity Framework Core, Syncfusion Blazor services, database localization, supported cultures, request localization middleware, controller routing, and Blazor Server hosting.

`Controllers/CultureController.cs` - Handles runtime culture selection and stores the selected culture in localization cookies using `CookieRequestCultureProvider`.

`Models/SyncLocalizationContext.cs` - Entity Framework Core DbContext that connects to SQL Server and exposes the localization data through the `Tables` DbSet.

`Models/Table.cs` - Localization entity model containing translation keys and culture-specific values (`EnUs` and `De`).

`Pages/Index.razor` - Demonstrates localization using the Syncfusion `SfSchedule` component with sample appointment data.

`Shared/CultureSwitcher.razor` - Language selector component that enables users to switch between supported cultures and reload the application with the selected culture.

`Shared/SyncfusionLocalizer.razor` - Custom implementation of `ISyncfusionStringLocalizer` that retrieves localized Syncfusion resource strings from the database.

`Data/WeatherForecastService.cs` - Sample service registered with dependency injection for the Blazor Server application.

`appsettings.json` - Application configuration file containing the database connection string and application settings.

## Support and Feedback

- For general product questions, visit the [Syncfusion Community Forum](https://www.syncfusion.com/forums) or [Syncfusion Support](https://www.syncfusion.com/support).
- To report an issue specific to this sample, open a GitHub issue in this repository.
- Documentation: https://blazor.syncfusion.com/documentation/common/localization

## License

This is a Syncfusion sample project provided to demonstrate product usage. Review the [Syncfusion license terms](https://www.syncfusion.com/sales/pricing?category=ui-components) before using Syncfusion components in your own applications.