# Tropicana Cafe

A Windows Forms application for managing and validating student meal plans at a dining hall check-in station. Built for Tropicana Student Living.

## Overview

Tropicana Cafe runs at the dining hall entrance and lets staff look up a resident by ID number or last name, validate their active meal plan, log the meal swipe, and view reports — all in real time against two SQL Server databases (a StarRez student housing database and a local meals logging database).

## Projects

| Project | Description |
|---|---|
| `Tropicana.Cafe.Forms` | WinForms UI — the main check-in application |
| `Tropicana.Cafe.DataConnection` | Data access, business rules, models, and validation logic (namespace `Tropicana.Cafe.Main`) |
| `Tropicana.Cafe.Console` | Console test harness for running validation against a given EntryID |
| `Tropicana.Cafe.MainTests` | Unit test project |

## Features

- **Student lookup** — search by numeric EntryID or last name; results populate from StarRez
- **Photo display** — pulls the resident photo from the database
- **Meal validation** — validates the active meal plan against seven plan types (see below)
- **Meal logging** — records successful swipes and failed attempts with reason codes
- **Meal reversal** — undoes the most recent swipe from the session log
- **Building restriction** — optionally restricts a meal plan to a specific dining hall
- **Admin hold** — a custom field flag blocks the meal with a configurable reason message
- **Reports** — hourly, half-hourly, by meal period, by meal plan, and per-resident reports via RDLC
- **ClickOnce update check** — built-in update prompt on startup

## Meal Plan Types

| Type | Description |
|---|---|
| `SinglePlan` | Date-range plan; validates breakfast/lunch/dinner flags and check-in status |
| `WeeklyPlan` | Day-of-week schedule; maps each day to allowed meal periods |
| `NumberMeals` | Punch-card; deducts from a total count per swipe |
| `NumberPerMeal` | Per-period count; resets each day; configurable per breakfast/lunch/dinner |
| `Allowance` | Weekly allowance; deducts from a period balance that resets on Sunday |
| `AdHoc` | Date-specific plan; each date has explicit breakfast/lunch/dinner flags |
| `AdHocAdjustable` | Adjustable ad-hoc; uses check-in/check-out day as special day-of-week values |

## Configuration

Sensitive credentials are **not committed**. Each project contains an `app.config.example` showing the required keys. Copy it to `app.config` and fill in your values before building.

Key settings (`Tropicana.Cafe.Main.Settings.MainSettings`):

| Setting | Description |
|---|---|
| `Building` | Dining hall name shown in logs (e.g. `Tropicana Gardens`) |
| `StuServer` / `StuDB` / `StuUser` / `StuPass` | StarRez student database connection |
| `MealServer` / `MealDB` / `MealUser` / `MealPass` | Meals logging database connection |
| `CommitMeals` | Set `False` to run in read-only / demo mode |
| `EnforceSingleMeal` | Set `True` to block duplicate swipes within the same meal period |
| `RestrictToBuilding` | Set `True` to reject meal plans assigned to a different building |

## Testing Mode

`Globals.TESTINGMODE = true` prevents any writes to either database and turns the log list red as a visual indicator. It is set to `false` by default.

## Requirements

- .NET Framework 4.x
- SQL Server (two instances: StarRez student DB and the local `TropicanaMeals` DB)
- Windows (WinForms + RDLC reports)

## Building

1. Copy `app.config.example` to `app.config` in `Tropicana.Cafe.DataConnection` and `Tropicana.Cafe.Forms` and populate your connection settings.
2. Open `Tropicana.Cafe.Console.sln` in Visual Studio.
3. Set `Tropicana.Cafe.Forms` as the startup project and build/run.

To run the console test harness instead, set `Tropicana.Cafe.Console` as the startup project, enter an EntryID at the prompt, and the validator output will be printed to the console.
