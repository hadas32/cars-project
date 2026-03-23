# Car Rental Management System 🚗

A full-stack web application for managing a car rental business. This project includes a client-side built with **Angular** and a RESTful API server-side built with **ASP.NET Web API (C#)** and **Entity Framework**.

---

## 📑 Features

* **User Management**: Registration and Login with authentication.
* **Car Inventory**: View available cars, filter by price, number of seats, and level.
* **Rentals**: Create new rental agreements, check car availability by dates, and view rental history.
* **Locations**: Manage cities and rental branches.
* **Payments**: Securely store and manage customer payment methods.

---

## 🛠️ Technologies & Tools

### Client-Side (Frontend)
* **Framework**: Angular
* **Language**: TypeScript, HTML5, CSS3
* **HTTP Client**: RxJS Observable & Angular HttpClient

### Server-Side (Backend)
* **Framework**: ASP.NET Web API 2 (.NET Framework 4.7.2)
* **Language**: C#
* **ORM**: Entity Framework 6 (Database First)
* **Database**: SQL Server LocalDB (`.mdf` file)

---

## 🚀 Getting Started

Follow these instructions to get a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites
* [Node.js](https://nodejs.org/) and npm installed (for Angular).
* [Angular CLI](https://cli.angular.io/) installed globally (`npm install -g @angular/cli`).
* [Visual Studio 2022](https://visualstudio.microsoft.com/) with "ASP.NET and web development" workload.
* SQL Server Express / LocalDB.

### 1. Server Setup (Backend)
1. Open the `.sln` file in Visual Studio.
2. Ensure the startup project is set to the **API** project.
3. Open the **Solution Explorer**, expand the `DAL` / `App_Data` folder, right-click on `CarsDB.mdf` -> **Properties**.
4. **CRITICAL**: Ensure **Copy to Output Directory** is set to `Copy if newer` (to prevent database overwrites).
5. Press `F5` or click **Start** to run the server. 
6. *Note: The server will run on `http://localhost:53191` (Update the port in the Angular environment/services if different).*

### 2. Client Setup (Frontend)
1. Open a terminal and navigate to the Angular project folder.
2. Run `npm install` to install all dependencies.
3. Run `ng serve` to start the development server.
4. Open your browser and navigate to `http://localhost:4200/`.

---

## 📡 API Endpoints Overview

The backend provides several RESTful endpoints, including:

* **Customers (`api/customer`)**:
  * `GET /login?email={email}&password={pass}` - Authenticates a user.
  * `POST /insertclient` - Registers a new user.
* **Cars (`api/car`)**:
  * `GET /getallcars` - Retrieves all cars.
  * `GET /getcarsbyseats/{numseats}` - Filters cars by seating capacity.
* **Rents (`api/rent`)**:
  * `POST /insertrent` - Creates a new rental record.
  * `GET /getrentthatavailablefromtoo/{start}/{end}` - Finds available cars for specific dates.

---

## ⚠️ Known Issues / Troubleshooting

* **CORS Errors**: If the Angular app fails to connect to the API, ensure the CORS configuration in `WebApiConfig.cs` or `Global.asax.cs` allows requests from `http://localhost:4200`.
* **Database Login Errors**: Ensure no ghost processes (like `VBCSCompiler.exe` or `iisexpress.exe`) are locking the `.mdf` file.

---

## 👨‍💻 Developed By
* Hadas Chomri & Sara Levin
