# Football Team Management System

This project is a full-stack application for managing football team players, built with **ASP.NET Core Web API** for the backend and **Angular** for the frontend. It demonstrates a robust, CRUD-enabled web application that manages player data and showcases a well-structured approach to combining Angular and .NET technologies.

## Features

- **CRUD Operations**: Easily add, update, view, and delete players with a clean and responsive interface.
- **Modal-Driven Forms**: Use of modals for intuitive player data management.
- **Client-Server Communication**: Uses Angular’s HTTP client to interact with ASP.NET Core Web API endpoints.
- **Responsive Design**: Built with Bootstrap for mobile-friendly, visually appealing user interfaces.
- **Real-Time Updates**: Instant display of updated player data after each operation.

## Technology Stack

- **Backend**: ASP.NET Core Web API
- **Frontend**: Angular 18
- **Styling**: Bootstrap
- **Dependency Injection**: Leveraged across the project for cleaner, modular code
- **Version Control**: Git and GitHub for project management and code versioning

---

## Getting Started

To get this project up and running locally, follow these steps:

### Prerequisites

- **Node.js** (v18 or later)
- **Angular CLI** (v18 or later)
- **.NET SDK** (v7.0 or later)
- **SQL Server** (or a suitable database setup for your .NET API)

### Clone the Repository

Clone this repository to your local machine:

```bash
git clone https://github.com/your-username/FootballTeamManagementSystem.git
```
### Backend Setup (ASP.NET Core Web API)

1. **Navigate to the Backend Project**:
   ```bash
   cd FootballTeamManagementSystem/API
  
2. **Restore Dependencies** :
   ```bash
   dotnet restore

3. **Configure Database**

- Update the `appsettings.json` file with your database connection string.
- Run migrations if needed to set up the database schema.

4. **Run the API**

```bash
dotnet run
```

The API should be available at `https://localhost:7003/api/Player`.

### Frontend Setup (Angular)

1. **Navigate to the Angular Project**:
   ```bash
   cd FootballTeamManagementSystem/Angular
2. **Install Angular Dependencies**:
   ```bash
   npm install
3. **Run the Development Server**:
   ```bash
   ng serve
The application will be available at `http://localhost:4200/`.

## Project Structure

- **API** (ASP.NET Core Web API): Handles all backend functionality and CRUD operations through RESTful endpoints.
- **Angular** (Angular Frontend): Provides an interactive UI for managing player data with a fully responsive design.

---

## Key Components

### PlayerController (ASP.NET Core Web API)

Handles HTTP requests for CRUD operations:

- `GET /api/Player` - Retrieves all players.
- `POST /api/Player` - Adds a new player.
- `PUT /api/Player/{id}` - Updates an existing player.
- `DELETE /api/Player/{id}` - Deletes a player by ID.

### Code Examples

#### API Endpoint Example - Update Player

```csharp
[HttpPut("{id}")]
public ActionResult UpdatePlayer(int id, [FromBody] Player player)
{
    if (!_playerService.UpdatePlayer(id, player))
        return NotFound("Player not found or failed to update.");
    return Ok(new { message = "Player updated successfully." });
}
```
### Angular Service - `PlayerService`

```typescript
export class PlayerService {
  private apiUrl = 'https://localhost:7003/api/Player';

  constructor(private http: HttpClient) {}

  getAllPlayers() {
    return this.http.get<Player[]>(this.apiUrl);
  }

  addPlayer(data: any) {
    return this.http.post(this.apiUrl, data);
  }

  updatePlayer(player: Player) {
    return this.http.put(`${this.apiUrl}/${player.id}`, player);
  }

  deletePlayer(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
```
## Running Tests

### Angular Unit Tests

Run unit tests with Angular’s test framework:

```bash
ng test
```
### ASP.NET Core Unit Tests

If you have unit tests for your ASP.NET Core API, run them with:

```bash
dotnet test
```

## Usage

- **Viewing Players**: The main dashboard lists all players in the database.
- **Adding a Player**: Click "Add Player" to open a form modal for creating a new player.
- **Editing a Player**: Click "Edit" next to a player to modify their details.
- **Deleting a Player**: Use the "Delete" button to remove a player from the database.

## Future Improvements

- **Authorization**: Add role-based access control for player management.
- **Pagination**: Implement pagination for better handling of large player lists.
- **Search and Filter**: Add search and filtering options for a more user-friendly experience.

## Conclusion

This Football Team Management System demonstrates a comprehensive approach to full-stack development, leveraging **ASP.NET Core** and **Angular**. The project showcases skills in REST API design, CRUD operations, and modern frontend development, making it a strong portfolio piece for full-stack development roles. Contributions and feedback are welcome!





