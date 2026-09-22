### 📂 Project Structure

```text
└── 📁 Homework1
    ├── 📁 Book
    │   ├── 📄 Book.cs
    │   └── 📄 BookDataAccess.cs
    │
    └── 📁 bin
        └── 📁 Debug
            └── 📁 net8.0
                ├── 📄 Program.cs
                ├── 📄 books.txt
                └── 📄 books-backup.txt
```

### 🗂️ Component Directory

#### 🔹 Book Layer
* **Book.cs** – Defines the core `Book` class model and properties.
* **BookDataAccess.cs** – Handles data access logic for reading and writing book data.

#### 🔹 Application & Execution
* **Program.cs** – The main entry point of the application where execution begins.

#### 🔹 Data Storage
* **books.txt** – The active text file used for storing book records.
* **books-backup.txt** – A backup copy of the book records to prevent data loss.
