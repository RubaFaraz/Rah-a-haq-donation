# Raha-e-Haq Donation App

## Overview
The **Raha-e-Haq Donation App** is a C# application designed to facilitate donations and manage charitable contributions. Built using .NET and Visual Studio, this application provides an efficient way to connect donors with organizations in need.

## Prerequisites
Before running or developing the project, ensure you have the following installed:

- **Visual Studio** (Latest version with .NET support)
- **.NET SDK** (Check [here](https://dotnet.microsoft.com/en-us/download) for the latest version)
- **SQL Server** (if the app requires a database)

## Cloning the Repository
To clone the repository, open **Command Prompt** or **Git Bash** and run:

```sh
 git clone https://github.com/your-repository/raha-e-haq-donation-app.git
 cd raha-e-haq-donation-app
```

## Creating and Running the Project
### Step 1: Open in Visual Studio
1. Open **Visual Studio**.
2. Click on **Open a project or solution**.
3. Navigate to the project folder and open the `.sln` file.

### Step 2: Build the Project
1. In **Solution Explorer**, right-click on the project and select **Build**.
2. Ensure there are no errors before proceeding.

### Step 3: Configure Database (If applicable)
1. Open **SQL Server Management Studio** (SSMS).
2. Create a new database (e.g., `RahaEHaqDB`).
3. Update the connection string in `appsettings.json` or `Program.cs`.

### Step 4: Run the Application
1. Set the **Startup Project** by right-clicking on the main project and selecting **Set as Startup Project**.
2. Click **Start** (or press `F5`) to run the application.

## Project Structure
```
Raha-e-Haq Donation App/
│-- Controllers/        # Handles HTTP requests
│-- Models/             # Defines database models
│-- Views/              # UI Templates (if using MVC)
│-- wwwroot/            # Static files (CSS, JS, images)
│-- Program.cs          # Entry point of the application
│-- appsettings.json    # Configuration file
```

## Deployment
To publish the application:
1. Click **Build** > **Publish Raha-e-Haq Donation App**.
2. Select **Folder** or **Azure** (if deploying online).
3. Follow the prompts to complete deployment.

## Contributions
Contributions are welcome! Follow these steps to contribute:
1. Fork the repository.
2. Create a feature branch (`git checkout -b feature-name`).
3. Commit your changes (`git commit -m "Added new feature"`).
4. Push to the branch (`git push origin feature-name`).
5. Open a **Pull Request**.


