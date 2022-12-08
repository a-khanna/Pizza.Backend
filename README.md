## Running the backend
The repo already contains a SQLite local database file. So, running `Update-Database` is NOT required.\
The backend uses a data seeder that runs at the application startup.\
It drops the database first and then seeds new values. Please comment out the seeder code in `Program.cs` if you want to persist data from previous runs.\
Once the API is run, swagger should automatically open in a browser at `https://localhost:7199/swagger/index.html`