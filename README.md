# Khatra – Online Journalism & Publishing Platform

Khatra is an **online content publishing platform** designed for **journalists** and **writers** to publish articles and engage with readers.  
It offers **role-based access control**, allowing different levels of permissions for Admins, Writers, and Regular Users.

---

## 🚀 Features

- **Article Publishing**  
  Writers and Admins can create, edit, and publish articles.

- **Role-Based Access Control**  
  - **Admins**: Manage users, view all admin accounts, control content and settings.  
  - **Writers**: Publish articles, create categories.  
  - **Users**: Browse and comment on articles.

- **Content Management**  
  Organize articles into categories for better navigation.

- **Reader Engagement**  
  Commenting system to interact with readers.

- **Admin Tools**  
  Full control over platform content, categories, users, and system settings.

---

## 🛠️ Tech Stack

| Technology         | Purpose                                 |
|--------------------|-----------------------------------------|
| ASP.NET MVC        | Core web application framework          |
| Entity Framework   | ORM for database access                 |
| Microsoft SQL Server | Relational database                   |
| Bootstrap          | Responsive UI design                    |
| jQuery & JavaScript| Interactive client-side functionality   |
| HTML5 & CSS3       | Markup and styling                      |

---

## 📂 Project Structure

```
Khatra/
│── Controllers/ # MVC controllers for handling requests
│── Models/ # Entity and ViewModel classes
│── Views/ # Razor views for the UI
│── Scripts/ # jQuery, JavaScript files
│── Content/ # CSS, Bootstrap styles
│── App_Start/ # Route config, filters, etc.
│── Web.config # Application configuration
```
## ⚙️ Installation & Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/farouk4web/Khatra.git
---

## ⚙️ Installation & Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/Coursaty.git
   ```

2. **Open in Visual Studio**
   - Open the `.sln` file.

3. **Configure the Database**
   - Update the `connectionStrings` section in `Web.config` with your SQL Server instance.
   - Run the initial migrations or SQL scripts to create the database schema.

4. **Build & Run**
   - Press `F5` in Visual Studio or run via IIS Express.

---

## 🔐 User Roles

- **Admin**  
  Manage users, assign roles, and oversee platform content.
- **Work Team Member**  
  Add and edit courses.
- **Normal User**  
  Browse and view courses.

---

## 📸 Screenshots

*(Add screenshots of your platform here for a better visual overview.)*

---

## 📜 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

